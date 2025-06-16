using System;

while (true)
{
    Console.WriteLine("=== Fluent Assertions Demo Menu ===");
    Console.WriteLine("0. Exit");
    Console.WriteLine("1. Basic Math");
    Console.WriteLine("2. Event Scheduler");
    Console.WriteLine("3. Object Equivalence");
    Console.WriteLine("4. Collection Assertions");
    Console.WriteLine("5. String Assertions");
    Console.WriteLine("6. Exception Assertions");
    Console.WriteLine("7. Checkout Business-Logic Demo");
    Console.Write("Select a demo (0–6): ");
    var choice = Console.ReadLine();

    switch (choice)
    {
        case "0": return;
        case "1": BasicMathDemo.Run(); break;
        case "2": EventSchedulerDemo.Run(); break;
        case "3": ObjectEquivalenceDemo.Run(); break;
        case "4": CollectionDemo.Run(); break;
        case "5": StringDemo.Run(); break;
        case "6": ExceptionDemo.Run(); break;
        case "7": BusinessLogicDemo.Run(); break;
        default: Console.WriteLine("Invalid choice."); break;
    }

    Console.WriteLine("\nPress Enter to return to the menu...");
    Console.ReadLine();
    Console.Clear();
}