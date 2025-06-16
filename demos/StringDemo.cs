

using FluentAssertions;
using System;

public static class StringDemo
{
    public static void Run()
    {
        Console.WriteLine("String Assertions Demo");

        string greeting = "Welcome, Matt!";
        greeting.Should().StartWith("Welcome");
        greeting.Should().Contain("Matt");
        greeting.Should().EndWith("!");

        string phrase = "Fluent Assertions make tests readable";
        phrase.Should().NotBeNullOrEmpty();
        phrase.Should().ContainEquivalentOf("fluent", "case-insensitive match");

        try
        {
            greeting.Should().EndWith("?");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Expected failure:");
            Console.WriteLine(ex.Message);
        }
    }
}