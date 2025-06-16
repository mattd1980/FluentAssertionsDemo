

using FluentAssertions;
using System;

public static class ExceptionDemo
{
    public static void Run()
    {
        Console.WriteLine("Exception Assertions Demo");

        Action act = () => throw new InvalidOperationException("Something went wrong");

        act.Should().Throw<InvalidOperationException>()
           .WithMessage("*went wrong*", "because we want to verify the exception message");

        try
        {
            Action badAct = () => { };
            badAct.Should().Throw<InvalidOperationException>("because this will demonstrate a failure");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Expected failure:");
            Console.WriteLine(ex.Message);
        }
    }
}