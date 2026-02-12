# Entertainment Management System: Advanced OOP (C#)

This C# .NET 8.0 application is a showcase of advanced Object-Oriented Programming (OOP) principles. It models an entertainment ecosystem where different types of shows and movies are managed through abstract hierarchies and strict interface contracts.

###  Logic & OOP Architecture
The project structure is designed to demonstrate high-level software engineering concepts:

**1. Abstract Hierarchies:**
* **Base Abstract Class (`Entertainment`):** Defines common properties like `Title` and `Duration`, enforcing a mandatory `DisplayInfo()` method for all derived classes.
* **Specialized Abstraction (`Show`):** Inherits from `Entertainment` and introduces a price calculation contract (`CalculatePrice()`).



**2. Interface Contracts:**
* **`IPersonalized`:** Ensures that implementing classes can manage user-specific names.
* **`IAgeRestricted`:** Implements a safety contract to verify user eligibility based on age.

**3. Data Analytics & Persistence:**
* Utilizes **LINQ** to analyze customer behavior, grouping transactions to find the most loyal viewers.
* Implements file-based storage in `viewers.txt` to maintain a persistent record of all cinema visits.



###  Key Features
* **Polymorphic Design:** Allows the system to handle various entertainment types uniformly through base class references.
* **Encapsulation:** Protects data integrity within classes while providing controlled access via properties and methods.
* **Cinema Management v2:** An upgraded version of the cinema engine with enhanced scheduling, ticket purchasing, and loyalty tracking.

###  Technical Stack
* **Language:** C# (.NET 8.0)
* **Paradigm:** Object-Oriented Programming (OOP)
* **Key Libraries:** `System.Linq`, `System.Collections.Generic`, `System.IO`.

###  How to Use
1. Run the program to see the demonstration of polymorphism in action.
2. Use the interactive menu to manage the cinema:
   - View schedules.
   - Purchase tickets (linked to persistent storage).
   - View loyalty rankings based on historical data.
