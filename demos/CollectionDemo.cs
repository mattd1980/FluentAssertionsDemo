using FluentAssertions;
using System;
using System.Collections.Generic;

public static class CollectionDemo
{
    public static void Run()
    {
        Console.WriteLine("Collection Assertions Demo");

        var numbers = new[] { 1, 2, 3, 5, 8 };
        numbers.Should().Contain(5);
        numbers.Should().HaveCount(5);
        numbers.Should().BeInAscendingOrder();
        numbers.Should().NotContain(4, "because 4 is not part of this sequence");

        var fruits = new List<string> { "apple", "banana", "cherry" };
        fruits.Should().ContainInOrder(new[] { "apple", "banana" });
        fruits.Should().OnlyHaveUniqueItems();

        try
        {
            fruits.Should().Contain("durian", "we want to demonstrate a failure");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Expected failure:");
            Console.WriteLine(ex.Message);
        }
    }
}