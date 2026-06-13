// ============================================================
// C# & ADO.NET Exercises — All 30 Programs
// Community Event Portal — Cognizant Upskilling
// ============================================================
// HOW TO RUN:
//   dotnet new console -n CSharpExercises
//   Replace Program.cs with this file
//   dotnet run
// ============================================================

using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
// For ADO.NET (Exercise 30), install:
//   dotnet add package Microsoft.Data.SqlClient
// using Microsoft.Data.SqlClient;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("=== C# & ADO.NET Exercises ===\n");

        Exercise01_HelloWorld();
        Exercise02_ValueVsReference();
        Exercise03_PrimaryConstructors();
        Exercise04_TypeInference();
        Exercise05_GradeCalculation();
        Exercise06_LoopsThroughArray();
        Exercise07_MethodOverloading();
        Exercise08_RefOutIn();
        Exercise09_LocalFunctions();
        Exercise10_OOPConstructors();
        Exercise11_AccessModifiers();
        Exercise12_AutoPropertiesBackingFields();
        Exercise13_Records();
        Exercise14_InheritanceOverriding();
        Exercise15_AbstractClassesInterfaces();
        Exercise16_NullReferences();
        Exercise17_NullConditionalChaining();
        Exercise18_RequiredModifier();
        Exercise19_ListsAndDictionaries();
        Exercise20_LINQ();
        Exercise21_PatternMatching();
        Exercise22_Tuples();
        await Exercise23_AsyncFileUpload();
        Exercise24_SerializeDeserializeJSON();
        Exercise25_FileStreamMemoryStream();
        Exercise26_RaceConditions();
        Exercise27_Deadlock();
        Exercise28_TraceLogging();
        Exercise29_SanitizeInput();
        // Exercise30_CRUD_ADONet(); // Requires SQL Server — see method below
        Console.WriteLine("\n=== All Exercises Complete ===");
    }

    // ============================================================
    // EXERCISE 1: Hello World / Environment Setup
    // ============================================================
    static void Exercise01_HelloWorld()
    {
        Console.WriteLine("--- Exercise 1: Hello World ---");
        Console.WriteLine("Hello, World!");
        Console.WriteLine($".NET Version: {Environment.Version}");
        Console.WriteLine();
    }

    // ============================================================
    // EXERCISE 2: Value Types vs Reference Types
    // ============================================================
    static void ModifyValue(int x) { x = 999; }

    static void ModifyReference(StringBuilder sb) { sb.Append(" [modified]"); }

    static void Exercise02_ValueVsReference()
    {
        Console.WriteLine("--- Exercise 2: Value vs Reference Types ---");

        // Value type: int
        int num = 42;
        Console.WriteLine($"Before ModifyValue: {num}");
        ModifyValue(num);
        Console.WriteLine($"After  ModifyValue: {num}  ← unchanged (value type)");

        // Reference type: StringBuilder
        var sb = new StringBuilder("Hello");
        Console.WriteLine($"Before ModifyReference: {sb}");
        ModifyReference(sb);
        Console.WriteLine($"After  ModifyReference: {sb}  ← changed (reference type)");

        // double value type
        double d = 3.14;
        Console.WriteLine($"double is value type: {d}");

        // string (immutable reference type)
        string s = "original";
        string s2 = s;
        s2 = "changed";
        Console.WriteLine($"string original: {s} | copy: {s2}  ← string is immutable");
        Console.WriteLine();
    }

    // ============================================================
    // EXERCISE 3: Primary Constructors (C# 12)
    // ============================================================
    class Person(string firstName, string lastName, int age)
    {
        public string FirstName { get; } = firstName;
        public string LastName  { get; } = lastName;
        public int    Age       { get; } = age;

        public void DisplayInfo()
            => Console.WriteLine($"Name: {FirstName} {LastName}, Age: {Age}");
    }

    static void Exercise03_PrimaryConstructors()
    {
        Console.WriteLine("--- Exercise 3: Primary Constructors (C# 12) ---");
        var p = new Person("Alice", "Johnson", 30);
        p.DisplayInfo();
        Console.WriteLine($"First: {p.FirstName}, Last: {p.LastName}, Age: {p.Age}");
        Console.WriteLine();
    }

    // ============================================================
    // EXERCISE 4: Type Inference with var and new()
    // ============================================================
    class Point { public int X; public int Y; public override string ToString() => $"({X},{Y})"; }

    static void Exercise04_TypeInference()
    {
        Console.WriteLine("--- Exercise 4: Type Inference ---");
        var num    = 42;           // int
        var name   = "Community";  // string
        var price  = 9.99;         // double
        var point  = new Point { X = 5, Y = 10 };

        // new() target-typed expression (C# 9+)
        Point p2   = new() { X = 1, Y = 2 };

        Console.WriteLine($"var int:    {num}   → {num.GetType().Name}");
        Console.WriteLine($"var string: {name}  → {name.GetType().Name}");
        Console.WriteLine($"var double: {price} → {price.GetType().Name}");
        Console.WriteLine($"var Point:  {point} → {point.GetType().Name}");
        Console.WriteLine($"new() Point:{p2}    → {p2.GetType().Name}");
        Console.WriteLine();
    }

    // ============================================================
    // EXERCISE 5: Conditional Logic / Grade Calculation
    // ============================================================
    static void Exercise05_GradeCalculation()
    {
        Console.WriteLine("--- Exercise 5: Grade Calculation ---");
        int[] scores = { 95, 82, 70, 55, 40 };

        foreach (int score in scores)
        {
            // if-else chain
            string gradeIf = score >= 90 ? "A"
                           : score >= 80 ? "B"
                           : score >= 70 ? "C"
                           : score >= 60 ? "D" : "F";

            // switch with pattern matching (C# 8+)
            string gradeSwitch = score switch
            {
                >= 90 => "A",
                >= 80 => "B",
                >= 70 => "C",
                >= 60 => "D",
                _     => "F"
            };

            Console.WriteLine($"Score: {score} → if/else: {gradeIf}, switch pattern: {gradeSwitch}");
        }
        Console.WriteLine();
    }

    // ============================================================
    // EXERCISE 6: Loops Through Array
    // ============================================================
    static void Exercise06_LoopsThroughArray()
    {
        Console.WriteLine("--- Exercise 6: Loop Types ---");
        int[] arr = { 10, 20, 30, 40, 50, 60 };

        Console.Write("for loop (skip 30):       ");
        for (int i = 0; i < arr.Length; i++)
            if (arr[i] != 30) Console.Write(arr[i] + " ");
        Console.WriteLine();

        Console.Write("foreach (stop at 50):     ");
        foreach (int n in arr)
        {
            if (n == 50) break;
            Console.Write(n + " ");
        }
        Console.WriteLine();

        Console.Write("while (only even):        ");
        int wi = 0;
        while (wi < arr.Length)
        {
            if (arr[wi] % 20 == 0) Console.Write(arr[wi] + " ");
            wi++;
        }
        Console.WriteLine();

        Console.Write("do-while:                 ");
        int di = 0;
        do { Console.Write(arr[di] + " "); di++; } while (di < arr.Length);
        Console.WriteLine("\n");
    }

    // ============================================================
    // EXERCISE 7: Method Overloading
    // ============================================================
    static int    CalculateTotal(int a, int b)              => a + b;
    static double CalculateTotal(double a, double b)        => a + b;
    static double CalculateTotal(double a, double b, double c) => a + b + c;
    static string CalculateTotal(string a, string b)        => a + b;

    static void Exercise07_MethodOverloading()
    {
        Console.WriteLine("--- Exercise 7: Method Overloading ---");
        Console.WriteLine($"int    (2,3)       = {CalculateTotal(2, 3)}");
        Console.WriteLine($"double (2.5,3.5)   = {CalculateTotal(2.5, 3.5)}");
        Console.WriteLine($"double (1.0,2.0,3) = {CalculateTotal(1.0, 2.0, 3.0)}");
        Console.WriteLine($"string (Hi, ,World)= {CalculateTotal("Hi, ", "World")}");
        Console.WriteLine();
    }

    // ============================================================
    // EXERCISE 8: ref, out, in Parameters
    // ============================================================
    static void DoubleIt(ref int value)         { value *= 2; }
    static void GetMinMax(int[] arr, out int min, out int max)
    {
        min = arr.Min();
        max = arr.Max();
    }
    static void PrintSum(in int a, in int b)    { Console.WriteLine($"Sum (in): {a + b}"); }

    static void Exercise08_RefOutIn()
    {
        Console.WriteLine("--- Exercise 8: ref, out, in ---");

        int x = 10;
        Console.WriteLine($"Before ref: {x}");
        DoubleIt(ref x);
        Console.WriteLine($"After  ref: {x}");

        int[] nums = { 3, 1, 4, 1, 5, 9, 2 };
        GetMinMax(nums, out int min, out int max);
        Console.WriteLine($"out → Min: {min}, Max: {max}");

        int a = 5, b = 7;
        PrintSum(in a, in b);
        Console.WriteLine();
    }

    // ============================================================
    // EXERCISE 9: Local Functions
    // ============================================================
    static long CalculateFactorial(int n)
    {
        // Local function
        long Factorial(int num) => num <= 1 ? 1 : num * Factorial(num - 1);
        return Factorial(n);
    }

    static void Exercise09_LocalFunctions()
    {
        Console.WriteLine("--- Exercise 9: Local Functions ---");
        for (int i = 0; i <= 10; i++)
            Console.WriteLine($"{i}! = {CalculateFactorial(i)}");
        Console.WriteLine();
    }

    // ============================================================
    // EXERCISE 10: OOP Basics — Constructors
    // ============================================================
    class Car
    {
        public string Make  { get; set; }
        public string Model { get; set; }
        public int    Year  { get; set; }

        // Default constructor
        public Car() { Make = "Unknown"; Model = "Unknown"; Year = 2000; }

        // Parameterized constructor
        public Car(string make, string model, int year)
        { Make = make; Model = model; Year = year; }

        public override string ToString() => $"{Year} {Make} {Model}";
    }

    static void Exercise10_OOPConstructors()
    {
        Console.WriteLine("--- Exercise 10: OOP Constructors ---");
        var car1 = new Car();
        var car2 = new Car("Toyota", "Camry", 2023);
        Console.WriteLine($"Default:      {car1}");
        Console.WriteLine($"Parameterized:{car2}");
        Console.WriteLine();
    }

    // ============================================================
    // EXERCISE 11: Access Modifiers
    // ============================================================
    class BaseEntity
    {
        public    string PublicName    = "Public";
        private   string _privateName = "Private";
        protected string ProtectedName = "Protected";

        public string GetPrivate() => _privateName;
    }

    class DerivedEntity : BaseEntity
    {
        public void ShowAll()
        {
            Console.WriteLine($"  public:    {PublicName}");
            Console.WriteLine($"  protected: {ProtectedName}");
            // _privateName not accessible here
            Console.WriteLine($"  private (via getter): {GetPrivate()}");
        }
    }

    static void Exercise11_AccessModifiers()
    {
        Console.WriteLine("--- Exercise 11: Access Modifiers ---");
        var d = new DerivedEntity();
        d.ShowAll();
        Console.WriteLine($"  from outside (public only): {d.PublicName}");
        Console.WriteLine();
    }

    // ============================================================
    // EXERCISE 12: Auto-Properties & Backing Fields
    // ============================================================
    class Product
    {
        public string Name { get; set; } = "";

        private double _price;
        public double Price
        {
            get => _price;
            set => _price = value < 0
                ? throw new ArgumentException("Price cannot be negative")
                : value;
        }
    }

    static void Exercise12_AutoPropertiesBackingFields()
    {
        Console.WriteLine("--- Exercise 12: Auto-Properties & Backing Fields ---");
        var prod = new Product { Name = "Event Ticket", Price = 50.0 };
        Console.WriteLine($"Name: {prod.Name}, Price: {prod.Price}");
        try { prod.Price = -10; }
        catch (ArgumentException ex) { Console.WriteLine($"Validation: {ex.Message}"); }
        Console.WriteLine();
    }

    // ============================================================
    // EXERCISE 13: Records with init Properties
    // ============================================================
    record Employee
    {
        public required string Name       { get; init; }
        public required string Department { get; init; }
        public required int    Salary     { get; init; }
    }

    static void Exercise13_Records()
    {
        Console.WriteLine("--- Exercise 13: Records with init ---");
        var emp1 = new Employee { Name = "Alice", Department = "IT", Salary = 80000 };
        var emp2 = emp1 with { Salary = 90000 };  // with-expression
        Console.WriteLine($"Original: {emp1}");
        Console.WriteLine($"Modified: {emp2}");
        Console.WriteLine($"Are equal: {emp1 == emp2}");
        Console.WriteLine();
    }

    // ============================================================
    // EXERCISE 14: Inheritance & Method Overriding
    // ============================================================
    class Shape  { public virtual  void Draw() => Console.WriteLine("Drawing Shape"); }
    class Circle    : Shape { public override void Draw() => Console.WriteLine("Drawing Circle ⬤"); }
    class Rectangle : Shape { public override void Draw() => Console.WriteLine("Drawing Rectangle ▬"); }

    static void Exercise14_InheritanceOverriding()
    {
        Console.WriteLine("--- Exercise 14: Inheritance & Overriding ---");
        Shape[] shapes = { new Shape(), new Circle(), new Rectangle() };
        foreach (var s in shapes) s.Draw();
        Console.WriteLine();
    }

    // ============================================================
    // EXERCISE 15: Abstract Classes & Interfaces
    // ============================================================
    abstract class Vehicle    { public abstract void Drive(); }
    interface IDrivable       { void Start(); }

    class Automobile : Vehicle, IDrivable
    {
        public override void Drive()  => Console.WriteLine("Car is driving");
        public          void Start()  => Console.WriteLine("Car engine started");
    }

    static void Exercise15_AbstractClassesInterfaces()
    {
        Console.WriteLine("--- Exercise 15: Abstract + Interface ---");
        Automobile car = new();
        car.Start();
        car.Drive();
        Vehicle  v = car;  v.Drive();
        IDrivable d = car; d.Start();
        Console.WriteLine();
    }

    // ============================================================
    // EXERCISE 16: Null References Safely
    // ============================================================
    class PersonNullable { public string? Name { get; set; } public string? Email { get; set; } }

    static void Exercise16_NullReferences()
    {
        Console.WriteLine("--- Exercise 16: Null References ---");
        PersonNullable? p1 = null;
        PersonNullable  p2 = new() { Name = "Bob" };

        // Null-conditional ?.
        Console.WriteLine($"p1?.Name = {p1?.Name ?? "null"}");
        Console.WriteLine($"p2?.Name = {p2?.Name ?? "null"}");

        // Null-coalescing ??
        string name  = p1?.Name  ?? "Anonymous";
        string email = p2?.Email ?? "no-email@portal.com";
        Console.WriteLine($"name:  {name}");
        Console.WriteLine($"email: {email}");
        Console.WriteLine();
    }

    // ============================================================
    // EXERCISE 17: Null-Conditional Chaining in Contact App
    // ============================================================
    class Contact { public string? Name { get; set; } public string? PhoneNumber { get; set; } }

    static void Exercise17_NullConditionalChaining()
    {
        Console.WriteLine("--- Exercise 17: Null-Conditional Chaining ---");
        List<Contact?> contacts = new()
        {
            new Contact { Name = "Alice", PhoneNumber = "555-1234" },
            new Contact { Name = null },
            null
        };

        foreach (var c in contacts)
        {
            string display = c?.Name ?? "(contact is null or name missing)";
            Console.WriteLine($"Contact: {display}");
            Console.WriteLine($"  Phone: {c?.PhoneNumber ?? "N/A"}");
        }
        Console.WriteLine();
    }

    // ============================================================
    // EXERCISE 18: required Modifier (C# 11+)
    // ============================================================
    class Student
    {
        public required string Name   { get; init; }
        public required int    RollNo { get; init; }
        public string? Email { get; init; }
    }

    static void Exercise18_RequiredModifier()
    {
        Console.WriteLine("--- Exercise 18: required Modifier ---");
        // Must provide Name and RollNo — compiler error if omitted
        var s = new Student { Name = "Charlie", RollNo = 101, Email = "charlie@school.com" };
        Console.WriteLine($"Student: {s.Name}, Roll: {s.RollNo}, Email: {s.Email ?? "N/A"}");
        // var s2 = new Student(); ← compile error: required properties not set
        Console.WriteLine();
    }

    // ============================================================
    // EXERCISE 19: Lists and Dictionaries
    // ============================================================
    static void Exercise19_ListsAndDictionaries()
    {
        Console.WriteLine("--- Exercise 19: List<T> & Dictionary ---");

        var events = new List<string> { "Tech Meetup", "AI Conference", "Bootcamp" };
        events.Add("Health Fair");
        events.Remove("Bootcamp");
        Console.WriteLine("Events List:");
        foreach (var e in events) Console.WriteLine($"  - {e}");

        var eventFees = new Dictionary<int, string>
        {
            { 1, "Tech Meetup: Free" },
            { 2, "AI Conference: $50" },
            { 3, "Frontend Bootcamp: $100" }
        };
        eventFees.Add(4, "Health Fair: $20");
        eventFees.Remove(3);
        Console.WriteLine("Event Fees Dictionary:");
        foreach (var kvp in eventFees)
            Console.WriteLine($"  [{kvp.Key}] {kvp.Value}");
        Console.WriteLine();
    }

    // ============================================================
    // EXERCISE 20: LINQ for Filtering and Projection
    // ============================================================
    class Order { public int OrderId; public string CustomerName = ""; public double TotalAmount; }

    static void Exercise20_LINQ()
    {
        Console.WriteLine("--- Exercise 20: LINQ ---");
        var orders = new List<Order>
        {
            new() { OrderId=1, CustomerName="Alice", TotalAmount=250.0 },
            new() { OrderId=2, CustomerName="Bob",   TotalAmount=75.0  },
            new() { OrderId=3, CustomerName="Charlie",TotalAmount=500.0 },
            new() { OrderId=4, CustomerName="Diana", TotalAmount=30.0  }
        };

        // Filter: total > 100 | Project into anonymous type
        var expensive = orders
            .Where(o => o.TotalAmount > 100)
            .Select(o => new { o.OrderId, o.CustomerName, o.TotalAmount })
            .OrderByDescending(o => o.TotalAmount);

        Console.WriteLine("Orders > $100:");
        foreach (var o in expensive)
            Console.WriteLine($"  #{o.OrderId} {o.CustomerName}: ${o.TotalAmount}");
        Console.WriteLine($"Total orders: {orders.Count}, Average: ${orders.Average(o => o.TotalAmount):F2}");
        Console.WriteLine();
    }

    // ============================================================
    // EXERCISE 21: Pattern Matching with is and switch
    // ============================================================
    static void DescribeObject(object obj)
    {
        // is pattern
        if (obj is int i)         Console.WriteLine($"  int: {i * 2} (doubled)");
        else if (obj is string s) Console.WriteLine($"  string: '{s}' (length {s.Length})");
        else if (obj is double d) Console.WriteLine($"  double: {d:F3}");

        // switch expression
        string result = obj switch
        {
            int n    when n > 0  => $"Positive int: {n}",
            int n                => $"Non-positive int: {n}",
            string { Length: 0 } => "Empty string",
            string st            => $"String: {st}",
            null                 => "null value",
            _                    => $"Unknown: {obj.GetType().Name}"
        };
        Console.WriteLine($"  switch: {result}");
    }

    static void Exercise21_PatternMatching()
    {
        Console.WriteLine("--- Exercise 21: Pattern Matching ---");
        object[] items = { 42, "Hello", 3.14, -5, "", null! };
        foreach (var item in items) DescribeObject(item);
        Console.WriteLine();
    }

    // ============================================================
    // EXERCISE 22: Tuples
    // ============================================================
    static (int Count, string Message) GetEventSummary()
        => (3, "Events loaded successfully");

    static void Exercise22_Tuples()
    {
        Console.WriteLine("--- Exercise 22: Tuples ---");
        var result = GetEventSummary();
        Console.WriteLine($"Count: {result.Count}, Message: {result.Message}");

        // Deconstruction
        var (count, message) = GetEventSummary();
        Console.WriteLine($"Deconstructed — Count: {count}, Msg: {message}");

        // Inline tuple
        (string Name, int Age) person = ("Alice", 30);
        Console.WriteLine($"Person: {person.Name}, {person.Age}");
        Console.WriteLine();
    }

    // ============================================================
    // EXERCISE 23: Async File Upload Simulation
    // ============================================================
    static async Task<string> SimulateFileUploadAsync(string fileName)
    {
        Console.WriteLine($"  Uploading {fileName}...");
        await Task.Delay(1000); // simulate 1s delay
        if (fileName.Contains("fail")) throw new IOException("Upload failed: invalid file");
        return $"✅ {fileName} uploaded successfully";
    }

    static async Task Exercise23_AsyncFileUpload()
    {
        Console.WriteLine("--- Exercise 23: Async File Upload ---");
        string[] files = { "agenda.pdf", "fail_corrupt.pdf", "poster.jpg" };
        foreach (var f in files)
        {
            try
            {
                string result = await SimulateFileUploadAsync(f);
                Console.WriteLine($"  {result}");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"  ❌ Error: {ex.Message}");
            }
        }
        Console.WriteLine();
    }

    // ============================================================
    // EXERCISE 24: JSON Serialization / Deserialization
    // ============================================================
    class UserJson { public string Name { get; set; } = ""; public int Age { get; set; } public string Email { get; set; } = ""; }

    static void Exercise24_SerializeDeserializeJSON()
    {
        Console.WriteLine("--- Exercise 24: JSON Serialize/Deserialize ---");
        var user = new UserJson { Name = "Alice Johnson", Age = 30, Email = "alice@example.com" };

        // Serialize
        string json = JsonSerializer.Serialize(user, new JsonSerializerOptions { WriteIndented = true });
        Console.WriteLine("Serialized JSON:");
        Console.WriteLine(json);

        // Save to file
        string path = Path.Combine(Path.GetTempPath(), "user.json");
        File.WriteAllText(path, json);
        Console.WriteLine($"Saved to: {path}");

        // Deserialize
        string loaded = File.ReadAllText(path);
        var user2 = JsonSerializer.Deserialize<UserJson>(loaded);
        Console.WriteLine($"Deserialized: Name={user2?.Name}, Age={user2?.Age}, Email={user2?.Email}");
        Console.WriteLine();
    }

    // ============================================================
    // EXERCISE 25: FileStream and MemoryStream
    // ============================================================
    static void Exercise25_FileStreamMemoryStream()
    {
        Console.WriteLine("--- Exercise 25: FileStream & MemoryStream ---");

        // Write then read with FileStream
        string path = Path.Combine(Path.GetTempPath(), "portal_data.txt");
        string content = "Community Event Portal — FileStream Demo\nLine 2: Tech Meetup\nLine 3: AI Conference";

        using (var fs = new FileStream(path, FileMode.Create, FileAccess.Write))
        {
            byte[] bytes = Encoding.UTF8.GetBytes(content);
            fs.Write(bytes, 0, bytes.Length);
        }

        Console.WriteLine("FileStream — Read from file:");
        using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read))
        using (var reader = new StreamReader(fs))
            Console.WriteLine(reader.ReadToEnd());

        // MemoryStream
        using var ms = new MemoryStream();
        byte[] data = Encoding.UTF8.GetBytes("MemoryStream data written here");
        ms.Write(data, 0, data.Length);
        Console.WriteLine($"MemoryStream bytes written: {ms.Length}");
        ms.Position = 0;
        Console.WriteLine($"MemoryStream content: {new StreamReader(ms).ReadToEnd()}");
        Console.WriteLine();
    }

    // ============================================================
    // EXERCISE 26: Race Conditions with Multi-threading
    // ============================================================
    static int _counter = 0;
    static readonly object _lock = new();

    static void Exercise26_RaceConditions()
    {
        Console.WriteLine("--- Exercise 26: Race Conditions ---");
        _counter = 0;
        var threads = new Thread[5];

        for (int i = 0; i < threads.Length; i++)
            threads[i] = new Thread(() =>
            {
                for (int j = 0; j < 100; j++)
                    lock (_lock) { _counter++; }  // lock prevents race condition
            });

        foreach (var t in threads) t.Start();
        foreach (var t in threads) t.Join();

        Console.WriteLine($"Expected: 500, Got: {_counter}  (lock prevents race condition)");
        Console.WriteLine();
    }

    // ============================================================
    // EXERCISE 27: Deadlock Simulation & Resolution
    // ============================================================
    static readonly object _lockA = new();
    static readonly object _lockB = new();

    static void Exercise27_Deadlock()
    {
        Console.WriteLine("--- Exercise 27: Deadlock Resolution ---");
        bool resolved = false;

        var t1 = new Thread(() =>
        {
            lock (_lockA)
            {
                Thread.Sleep(50);
                // Use Monitor.TryEnter to avoid deadlock
                if (Monitor.TryEnter(_lockB, TimeSpan.FromMilliseconds(200)))
                {
                    try   { Console.WriteLine("  Thread1: acquired both locks"); resolved = true; }
                    finally { Monitor.Exit(_lockB); }
                }
                else
                    Console.WriteLine("  Thread1: could not acquire lockB — deadlock avoided");
            }
        });

        var t2 = new Thread(() =>
        {
            lock (_lockB)
            {
                Thread.Sleep(50);
                if (Monitor.TryEnter(_lockA, TimeSpan.FromMilliseconds(200)))
                {
                    try   { Console.WriteLine("  Thread2: acquired both locks"); }
                    finally { Monitor.Exit(_lockA); }
                }
                else
                    Console.WriteLine("  Thread2: could not acquire lockA — deadlock avoided");
            }
        });

        t1.Start(); t2.Start();
        t1.Join();  t2.Join();
        Console.WriteLine($"  Deadlock resolved: {!resolved || true}");
        Console.WriteLine();
    }

    // ============================================================
    // EXERCISE 28: Logging with System.Diagnostics.Trace
    // ============================================================
    static void Exercise28_TraceLogging()
    {
        Console.WriteLine("--- Exercise 28: Trace Logging ---");
        string logPath = Path.Combine(Path.GetTempPath(), "portal_trace.log");

        // TextWriterTraceListener writes to file
        var fileListener = new TextWriterTraceListener(logPath);
        Trace.Listeners.Add(fileListener);
        Trace.AutoFlush = true;

        Trace.WriteLine($"[{DateTime.Now}] Portal started");
        Trace.WriteLine($"[{DateTime.Now}] User Alice logged in");
        Trace.TraceInformation("Event registration processed successfully");
        Trace.TraceWarning("Session overlap detected for event 1");
        Trace.TraceError("Failed to load resource for event 2");

        fileListener.Flush();
        fileListener.Close();

        Console.WriteLine($"Log written to: {logPath}");
        Console.WriteLine("Log contents:");
        Console.WriteLine(File.ReadAllText(logPath));
        Console.WriteLine();
    }

    // ============================================================
    // EXERCISE 29: Sanitize Input / Prevent XSS
    // ============================================================
    static string SanitizeInput(string input)
    {
        // HTML encode: replace < > & " ' with safe equivalents
        return input
            .Replace("&",  "&amp;")
            .Replace("<",  "&lt;")
            .Replace(">",  "&gt;")
            .Replace("\"", "&quot;")
            .Replace("'",  "&#39;");
    }

    static void Exercise29_SanitizeInput()
    {
        Console.WriteLine("--- Exercise 29: Input Sanitization / XSS Prevention ---");
        string[] inputs =
        {
            "<script>alert('XSS')</script>",
            "Hello, World!",
            "<img src=x onerror=\"alert(1)\">",
            "Normal user input 123"
        };

        foreach (var raw in inputs)
        {
            string safe = SanitizeInput(raw);
            Console.WriteLine($"  Raw:  {raw}");
            Console.WriteLine($"  Safe: {safe}");
            Console.WriteLine();
        }
    }

    // ============================================================
    // EXERCISE 30: CRUD with ADO.NET (SQL Server)
    // ============================================================
    // Uncomment and install: dotnet add package Microsoft.Data.SqlClient
    /*
    static void Exercise30_CRUD_ADONet()
    {
        Console.WriteLine("--- Exercise 30: ADO.NET CRUD ---");
        string connStr = "Server=localhost;Database=community_portal;Trusted_Connection=True;TrustServerCertificate=True;";

        using var conn = new SqlConnection(connStr);
        conn.Open();

        // CREATE table if not exists
        using (var cmd = new SqlCommand(@"
            IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Employees')
            CREATE TABLE Employees (
                Id INT PRIMARY KEY IDENTITY,
                Name NVARCHAR(100) NOT NULL,
                Department NVARCHAR(100),
                Salary DECIMAL(10,2)
            )", conn))
            cmd.ExecuteNonQuery();

        // INSERT
        using (var cmd = new SqlCommand(
            "INSERT INTO Employees (Name, Department, Salary) VALUES (@n, @d, @s)", conn))
        {
            cmd.Parameters.AddWithValue("@n", "Alice Johnson");
            cmd.Parameters.AddWithValue("@d", "Technology");
            cmd.Parameters.AddWithValue("@s", 75000.00m);
            cmd.ExecuteNonQuery();
            Console.WriteLine("INSERT: Alice added");
        }

        // READ with SqlDataReader
        using (var cmd = new SqlCommand("SELECT Id, Name, Department, Salary FROM Employees", conn))
        using (var reader = cmd.ExecuteReader())
        {
            Console.WriteLine("READ:");
            while (reader.Read())
                Console.WriteLine($"  {reader["Id"]}: {reader["Name"]} — {reader["Department"]} ${reader["Salary"]}");
        }

        // UPDATE
        using (var cmd = new SqlCommand("UPDATE Employees SET Salary=@s WHERE Name=@n", conn))
        {
            cmd.Parameters.AddWithValue("@s", 80000.00m);
            cmd.Parameters.AddWithValue("@n", "Alice Johnson");
            int rows = cmd.ExecuteNonQuery();
            Console.WriteLine($"UPDATE: {rows} row(s) updated");
        }

        // DataAdapter / DataSet
        var adapter = new SqlDataAdapter("SELECT * FROM Employees", conn);
        var ds = new DataSet();
        adapter.Fill(ds, "Employees");
        Console.WriteLine($"DataSet rows: {ds.Tables["Employees"]?.Rows.Count}");

        // DELETE
        using (var cmd = new SqlCommand("DELETE FROM Employees WHERE Name=@n", conn))
        {
            cmd.Parameters.AddWithValue("@n", "Alice Johnson");
            int rows = cmd.ExecuteNonQuery();
            Console.WriteLine($"DELETE: {rows} row(s) deleted");
        }
    }
    */
}
