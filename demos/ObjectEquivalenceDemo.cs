using FluentAssertions;
using System;

public static class ObjectEquivalenceDemo
{
    public static void Run()
    {
        Console.WriteLine("Object Equivalence Demo");

        var expected = new { Name = "Alice", Age = 30 };
        var actual = new { Name = "Alice", Age = 30 };

        actual.Should().BeEquivalentTo(expected, "because the objects have the same data");

        var incorrect = new { Name = "Bob", Age = 30 };

        try
        {
            incorrect.Should().BeEquivalentTo(expected, "to demonstrate a failure");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Expected failure:");
            Console.WriteLine(ex.Message);
        }
    }
}