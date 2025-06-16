using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;

public record CartItem(string Sku, decimal Price, int Quantity, int Stock);
public record OrderSummary(decimal Subtotal, decimal Discount, decimal Total);

public class OutOfStockException : Exception
{
    public OutOfStockException(string sku)
        : base($"Item {sku} is out of stock.") { }
}

public static class CheckoutService
{
    public static OrderSummary FinalizeOrder(IEnumerable<CartItem> items)
    {
        foreach (var item in items)
        {
            if (item.Stock < item.Quantity)
                throw new OutOfStockException(item.Sku);
        }

        var subtotal = items.Sum(i => i.Price * i.Quantity);
        var discount = subtotal >= 100m ? subtotal * 0.10m : 0m;
        var total = subtotal - discount;

        return new OrderSummary(subtotal, discount, total);
    }
}

public static class BusinessLogicDemo
{
    public static void Run()
    {
        Console.WriteLine("Business-Logic (Checkout) Demo");

        var items = new[]
        {
            new CartItem("A", 40m, 1, 5),
            new CartItem("B", 30m, 2, 3)
        };

        var summary = CheckoutService.FinalizeOrder(items);

        summary.Subtotal.Should().Be(100m);
        summary.Discount.Should().Be(10m).And.Be(0.10m * summary.Subtotal);
        summary.Total.Should().Be(90m);

        var expected = new OrderSummary(100m, 10m, 90m);
        summary.Should().BeEquivalentTo(expected);

        try
        {
            var badItems = new[] { new CartItem("C", 20m, 2, 1) };
            CheckoutService.FinalizeOrder(badItems);
        }
        catch (OutOfStockException ex)
        {
            ex.Should().BeOfType<OutOfStockException>()
              .Which.Message.Should().Contain("out of stock");
            Console.WriteLine("Expected exception captured: " + ex.Message);
        }
    }
}