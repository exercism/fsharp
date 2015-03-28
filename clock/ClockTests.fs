module ClockTests

open System
open NUnit.Framework
open Clock

[<TestFixture>]
type ClockTests() =
    [<TestCase(8, "08:00")>]
    [<TestCase(9, "09:00", Ignore = true)>]
    member tests.Prints_the_hour(hours, expected) =
        let clock = new Clock(hours)
        Assert.That(clock.ToString(), Is.EqualTo(expected))

    [<TestCase(11, 9, "11:09", Ignore = true)>]
    [<TestCase(11, 19, "11:19", Ignore = true)>]
    member tests.Prints_past_the_hour(hours, minutes, expected) =
        let clock = new Clock(hours, minutes)
        Assert.That(clock.ToString(), Is.EqualTo(expected))

    [<Test>]
    [<Ignore>]
    member tests.Can_add_minutes() =
        let clock = new Clock(10)
        let added = clock.add(3)
        Assert.That(added.ToString(), Is.EqualTo("10:03"))

    [<Test>]
    [<Ignore>]
    member tests.Can_add_over_an_hour() =
        let clock = new Clock(10)
        let added = clock.add(63)
        Assert.That(added.ToString(), Is.EqualTo("11:03"))

    [<Test>]
    [<Ignore>]
    member tests.Can_subtract_minutes() =
        let clock = new Clock(10, 3)
        let subtracted = clock.subtract(3)
        Assert.That(subtracted.ToString(), Is.EqualTo("10:00"))

    [<Test>]
    [<Ignore>]
    member tests.Can_subtract_to_previous_hour() =
        let clock = new Clock(10, 3)
        let subtracted = clock.subtract(30)
        Assert.That(subtracted.ToString(), Is.EqualTo("09:33"))

    [<Test>]
    [<Ignore>]
    member tests.Can_subtract_over_an_hour() =
        let clock = new Clock(10, 3)
        let subtracted = clock.subtract(70)
        Assert.That(subtracted.ToString(), Is.EqualTo("08:53"))

    [<Test>]
    [<Ignore>]
    member tests.Wraps_around_midnight() =
        let clock = new Clock(23, 59)
        let added = clock.add(2)
        Assert.That(added.ToString(), Is.EqualTo("00:01"))

    [<Test>]
    [<Ignore>]
    member tests.Wraps_around_midnight_backwards() =
        let clock = new Clock(0, 1)
        let subtracted = clock.subtract(2)
        Assert.That(subtracted.ToString(), Is.EqualTo("23:59"))

    [<Test>]
    [<Ignore>]
    member tests.Midnight_is_zero_hundred_hours() =
        let clock = new Clock(24)
        Assert.That(clock.ToString(), Is.EqualTo("00:00"))

    [<Test>]
    [<Ignore>]
    member tests.Sixty_minutes_is_next_hour() =
        let clock = new Clock(1, 60)
        Assert.That(clock.ToString(), Is.EqualTo("02:00"))

    [<Test>]
    [<Ignore>]
    member tests.Clocks_with_same_time_are_equal() =
        let clock1 = new Clock(14, 30)
        let clock2 = new Clock(14, 30)
        Assert.That(clock1, Is.EqualTo(clock2))