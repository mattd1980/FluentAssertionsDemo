using FluentAssertions;
using System;

public static class BasicMathDemo
{
    public static void Run()
    {
        Console.WriteLine("Basic Math Demo");

        int result = 2 + 3;
        result.Should().Be(5, "2 plus 3 should equal 5");

        try
        {
            int badResult = 2 + 2;
            badResult.Should().Be(5, "intentional failure to demonstrate FluentAssertions output");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Expected failure:");
            Console.WriteLine(ex.Message);
        }
    }
}