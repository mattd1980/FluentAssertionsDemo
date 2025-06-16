using FluentAssertions;
using System;

public class EventScheduler
{
    public DateTime? NextEventDate { get; private set; }

    public void ScheduleEvent(DateTime date)
    {
        if (date < DateTime.Today)
            throw new ArgumentException("Cannot schedule an event in the past.");

        NextEventDate = date;
    }
}

public static class EventSchedulerDemo
{
    public static void Run()
    {
        Console.WriteLine("\n📅 Running EventScheduler demo...");

        var scheduler = new EventScheduler();

        // Valid future date
        var futureDate = DateTime.Today.AddDays(3);
        scheduler.ScheduleEvent(futureDate);
        scheduler.NextEventDate.Should().Be(futureDate, "it was scheduled correctly");

        // Invalid past date
        try
        {
            var pastDate = DateTime.Today.AddDays(-1);
            scheduler.ScheduleEvent(pastDate);
        }
        catch (ArgumentException ex)
        {
            ex.Message.Should().Contain("past", "because scheduling in the past should not be allowed");
            Console.WriteLine("✔️ Caught expected exception: " + ex.Message);
        }

        // Null check
        var newScheduler = new EventScheduler();
        newScheduler.NextEventDate.Should().BeNull("nothing has been scheduled yet");
    }
}