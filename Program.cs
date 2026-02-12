using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

// --- Абстрактна ієрархія ---
abstract class Entertainment
{
    public string Title { get; set; } = string.Empty;
    public int Duration { get; set; }
    public abstract void DisplayInfo(); // Абстрактний метод
}

abstract class Show : Entertainment
{
    public abstract double CalculatePrice(); // Абстрактний метод
}

// --- Інтерфейси ---
interface IPersonalized
{
    void SetName(string name);
}

interface IAgeRestricted
{
    bool IsAllowed(int age);
}

// --- Класи моделей ---
class Movie : Entertainment
{
    public override void DisplayInfo() => Console.WriteLine($"Фiльм: {Title} ({Duration} хв)");
}

class Session
{
    public Movie Movie { get; set; } = new();
    public string Time { get; set; } = string.Empty;
    public double Price { get; set; }
}

class Viewer
{
    public string Name { get; set; } = string.Empty;
    public string MovieTitle { get; set; } = string.Empty;
}

// --- Керування системою ---
class Cinema
{
    private List<Session> sessions = new();
    private List<Viewer> viewers = new();

    public Cinema()
    {
        sessions.Add(new Session { Movie = new Movie { Title = "Inception", Duration = 148 }, Time = "12:00", Price = 150 });
        sessions.Add(new Session { Movie = new Movie { Title = "Interstellar", Duration = 169 }, Time = "18:00", Price = 200 });
    }

    public void ShowSchedule()
    {
        Console.WriteLine("\n--- Розклад ---");
        for (int i = 0; i < sessions.Count; i++)
            Console.WriteLine($"{i + 1}. {sessions[i].Movie.Title} | {sessions[i].Time} | {sessions[i].Price} грн");
    }

    public void BuyTicket()
    {
        ShowSchedule();
        Console.Write("Оберiть номер: ");
        if (int.TryParse(Console.ReadLine(), out int idx) && idx > 0 && idx <= sessions.Count)
        {
            Console.Write("Ваше iм'я: ");
            string name = Console.ReadLine() ?? "Глядач";
            viewers.Add(new Viewer { Name = name, MovieTitle = sessions[idx - 1].Movie.Title });
            Console.WriteLine("Квиток куплено!");
        }
    }

    public void ShowLoyalCustomers()
    {
        var rating = viewers.GroupBy(v => v.Name)
                            .Select(g => new { Name = g.Key, Count = g.Count() })
                            .OrderByDescending(x => x.Count);
        foreach (var item in rating)
            Console.WriteLine($"{item.Name}: {item.Count} квиткiв");
    }

    public void SaveData() => File.WriteAllLines("viewers.txt", viewers.Select(v => $"{v.Name}|{v.MovieTitle}"));
    
    public void LoadData()
    {
        if (File.Exists("viewers.txt"))
            foreach (var line in File.ReadAllLines("viewers.txt"))
            {
                var p = line.Split('|');
                if (p.Length == 2) viewers.Add(new Viewer { Name = p[0], MovieTitle = p[1] });
            }
    }
}

class Program
{
    static void Main()
    {
        Cinema cinema = new();
        cinema.LoadData();
        // Демонстрація логіки...
        cinema.ShowSchedule();
        cinema.BuyTicket();
        cinema.ShowLoyalCustomers();
        cinema.SaveData();
    }
}
