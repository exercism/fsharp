module MeetupTest

open System
open NUnit.Framework

open Meetup

[<TestCase(5, DayOfWeek.Monday, ExpectedResult = "2013-5-13")>]
[<TestCase(3, DayOfWeek.Tuesday, ExpectedResult = "2013-3-19", Ignore = "Remove to run test case")>]
[<TestCase(1, DayOfWeek.Wednesday, ExpectedResult = "2013-1-16", Ignore = "Remove to run test case")>]
[<TestCase(5, DayOfWeek.Thursday, ExpectedResult = "2013-5-16", Ignore = "Remove to run test case")>]
[<TestCase(4, DayOfWeek.Friday, ExpectedResult = "2013-4-19", Ignore = "Remove to run test case")>]
[<TestCase(2, DayOfWeek.Saturday, ExpectedResult = "2013-2-16", Ignore = "Remove to run test case")>]
[<TestCase(10, DayOfWeek.Sunday, ExpectedResult = "2013-10-13", Ignore = "Remove to run test case")>]
let ``Finds first teenth day of week in a month``(month: int) (dayOfWeek: DayOfWeek) =
    let day = meetupDay dayOfWeek Schedule.Teenth 2013 month
    day.ToString("yyyy-M-d")
    
[<TestCase(3, DayOfWeek.Monday, ExpectedResult = "2013-3-4", Ignore = "Remove to run test case")>]
[<TestCase(5, DayOfWeek.Tuesday, ExpectedResult = "2013-5-7", Ignore = "Remove to run test case")>]
[<TestCase(7, DayOfWeek.Wednesday, ExpectedResult = "2013-7-3", Ignore = "Remove to run test case")>]
[<TestCase(9, DayOfWeek.Thursday, ExpectedResult = "2013-9-5", Ignore = "Remove to run test case")>]
[<TestCase(11, DayOfWeek.Friday, ExpectedResult = "2013-11-1", Ignore = "Remove to run test case")>]
[<TestCase(1, DayOfWeek.Saturday, ExpectedResult = "2013-1-5", Ignore = "Remove to run test case")>]
[<TestCase(4, DayOfWeek.Sunday, ExpectedResult = "2013-4-7", Ignore = "Remove to run test case")>]
let ``Finds first day of week in a month``(month: int) (dayOfWeek: DayOfWeek) =
    let day = meetupDay dayOfWeek Schedule.First 2013 month
    day.ToString("yyyy-M-d")
    
[<TestCase(3, DayOfWeek.Monday, ExpectedResult = "2013-3-11", Ignore = "Remove to run test case")>]
[<TestCase(5, DayOfWeek.Tuesday, ExpectedResult = "2013-5-14", Ignore = "Remove to run test case")>]
[<TestCase(7, DayOfWeek.Wednesday, ExpectedResult = "2013-7-10", Ignore = "Remove to run test case")>]
[<TestCase(9, DayOfWeek.Thursday, ExpectedResult = "2013-9-12", Ignore = "Remove to run test case")>]
[<TestCase(12, DayOfWeek.Friday, ExpectedResult = "2013-12-13", Ignore = "Remove to run test case")>]
[<TestCase(2, DayOfWeek.Saturday, ExpectedResult = "2013-2-9", Ignore = "Remove to run test case")>]
[<TestCase(4, DayOfWeek.Sunday, ExpectedResult = "2013-4-14", Ignore = "Remove to run test case")>]
let ``Finds second day of week in a month``(month: int) (dayOfWeek: DayOfWeek) =
    let day = meetupDay dayOfWeek Schedule.Second 2013 month
    day.ToString("yyyy-M-d")
    
[<TestCase(3, DayOfWeek.Monday, ExpectedResult = "2013-3-18", Ignore = "Remove to run test case")>]
[<TestCase(5, DayOfWeek.Tuesday, ExpectedResult = "2013-5-21", Ignore = "Remove to run test case")>]
[<TestCase(7, DayOfWeek.Wednesday, ExpectedResult = "2013-7-17", Ignore = "Remove to run test case")>]
[<TestCase(9, DayOfWeek.Thursday, ExpectedResult = "2013-9-19", Ignore = "Remove to run test case")>]
[<TestCase(12, DayOfWeek.Friday, ExpectedResult = "2013-12-20", Ignore = "Remove to run test case")>]
[<TestCase(2, DayOfWeek.Saturday, ExpectedResult = "2013-2-16", Ignore = "Remove to run test case")>]
[<TestCase(4, DayOfWeek.Sunday, ExpectedResult = "2013-4-21", Ignore = "Remove to run test case")>]
let ``Finds third day of week in a month``(month: int) (dayOfWeek: DayOfWeek) =
    let day = meetupDay dayOfWeek Schedule.Third 2013 month
    day.ToString("yyyy-M-d")
    
[<TestCase(3, DayOfWeek.Monday, ExpectedResult = "2013-3-25", Ignore = "Remove to run test case")>]
[<TestCase(5, DayOfWeek.Tuesday, ExpectedResult = "2013-5-28", Ignore = "Remove to run test case")>]
[<TestCase(7, DayOfWeek.Wednesday, ExpectedResult = "2013-7-24", Ignore = "Remove to run test case")>]
[<TestCase(9, DayOfWeek.Thursday, ExpectedResult = "2013-9-26", Ignore = "Remove to run test case")>]
[<TestCase(12, DayOfWeek.Friday, ExpectedResult = "2013-12-27", Ignore = "Remove to run test case")>]
[<TestCase(2, DayOfWeek.Saturday, ExpectedResult = "2013-2-23", Ignore = "Remove to run test case")>]
[<TestCase(4, DayOfWeek.Sunday, ExpectedResult = "2013-4-28", Ignore = "Remove to run test case")>]
let ``Finds fourth day of week in a month``(month: int) (dayOfWeek: DayOfWeek) =
    let day = meetupDay dayOfWeek Schedule.Fourth 2013 month
    day.ToString("yyyy-M-d")
    
[<TestCase(3, DayOfWeek.Monday, ExpectedResult = "2013-3-25", Ignore = "Remove to run test case")>]
[<TestCase(5, DayOfWeek.Tuesday, ExpectedResult = "2013-5-28", Ignore = "Remove to run test case")>]
[<TestCase(7, DayOfWeek.Wednesday, ExpectedResult = "2013-7-31", Ignore = "Remove to run test case")>]
[<TestCase(9, DayOfWeek.Thursday, ExpectedResult = "2013-9-26", Ignore = "Remove to run test case")>]
[<TestCase(12, DayOfWeek.Friday, ExpectedResult = "2013-12-27", Ignore = "Remove to run test case")>]
[<TestCase(2, DayOfWeek.Saturday, ExpectedResult = "2013-2-23", Ignore = "Remove to run test case")>]
[<TestCase(3, DayOfWeek.Sunday, ExpectedResult = "2013-3-31", Ignore = "Remove to run test case")>]
let ``Finds last day of week in a month``(month: int) (dayOfWeek: DayOfWeek) =
    let day = meetupDay dayOfWeek Schedule.Last 2013 month
    day.ToString("yyyy-M-d")