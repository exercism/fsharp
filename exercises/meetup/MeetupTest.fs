// This file was auto-generated based on version 1.1.0 of the canonical data.

module MeetupTest

open FsUnit.Xunit
open Xunit
open System

open Meetup

[<Fact>]
let ``Monteenth of May 2013`` () =
    meetup 2013 5 Week.Teenth DayOfWeek.Monday |> should equal (DateTime(2013, 5, 13))

[<Fact(Skip = "Remove to run test")>]
let ``Monteenth of August 2013`` () =
    meetup 2013 8 Week.Teenth DayOfWeek.Monday |> should equal (DateTime(2013, 8, 19))

[<Fact(Skip = "Remove to run test")>]
let ``Monteenth of September 2013`` () =
    meetup 2013 9 Week.Teenth DayOfWeek.Monday |> should equal (DateTime(2013, 9, 16))

[<Fact(Skip = "Remove to run test")>]
let ``Tuesteenth of March 2013`` () =
    meetup 2013 3 Week.Teenth DayOfWeek.Tuesday |> should equal (DateTime(2013, 3, 19))

[<Fact(Skip = "Remove to run test")>]
let ``Tuesteenth of April 2013`` () =
    meetup 2013 4 Week.Teenth DayOfWeek.Tuesday |> should equal (DateTime(2013, 4, 16))

[<Fact(Skip = "Remove to run test")>]
let ``Tuesteenth of August 2013`` () =
    meetup 2013 8 Week.Teenth DayOfWeek.Tuesday |> should equal (DateTime(2013, 8, 13))

[<Fact(Skip = "Remove to run test")>]
let ``Wednesteenth of January 2013`` () =
    meetup 2013 1 Week.Teenth DayOfWeek.Wednesday |> should equal (DateTime(2013, 1, 16))

[<Fact(Skip = "Remove to run test")>]
let ``Wednesteenth of February 2013`` () =
    meetup 2013 2 Week.Teenth DayOfWeek.Wednesday |> should equal (DateTime(2013, 2, 13))

[<Fact(Skip = "Remove to run test")>]
let ``Wednesteenth of June 2013`` () =
    meetup 2013 6 Week.Teenth DayOfWeek.Wednesday |> should equal (DateTime(2013, 6, 19))

[<Fact(Skip = "Remove to run test")>]
let ``Thursteenth of May 2013`` () =
    meetup 2013 5 Week.Teenth DayOfWeek.Thursday |> should equal (DateTime(2013, 5, 16))

[<Fact(Skip = "Remove to run test")>]
let ``Thursteenth of June 2013`` () =
    meetup 2013 6 Week.Teenth DayOfWeek.Thursday |> should equal (DateTime(2013, 6, 13))

[<Fact(Skip = "Remove to run test")>]
let ``Thursteenth of September 2013`` () =
    meetup 2013 9 Week.Teenth DayOfWeek.Thursday |> should equal (DateTime(2013, 9, 19))

[<Fact(Skip = "Remove to run test")>]
let ``Friteenth of April 2013`` () =
    meetup 2013 4 Week.Teenth DayOfWeek.Friday |> should equal (DateTime(2013, 4, 19))

[<Fact(Skip = "Remove to run test")>]
let ``Friteenth of August 2013`` () =
    meetup 2013 8 Week.Teenth DayOfWeek.Friday |> should equal (DateTime(2013, 8, 16))

[<Fact(Skip = "Remove to run test")>]
let ``Friteenth of September 2013`` () =
    meetup 2013 9 Week.Teenth DayOfWeek.Friday |> should equal (DateTime(2013, 9, 13))

[<Fact(Skip = "Remove to run test")>]
let ``Saturteenth of February 2013`` () =
    meetup 2013 2 Week.Teenth DayOfWeek.Saturday |> should equal (DateTime(2013, 2, 16))

[<Fact(Skip = "Remove to run test")>]
let ``Saturteenth of April 2013`` () =
    meetup 2013 4 Week.Teenth DayOfWeek.Saturday |> should equal (DateTime(2013, 4, 13))

[<Fact(Skip = "Remove to run test")>]
let ``Saturteenth of October 2013`` () =
    meetup 2013 10 Week.Teenth DayOfWeek.Saturday |> should equal (DateTime(2013, 10, 19))

[<Fact(Skip = "Remove to run test")>]
let ``Sunteenth of May 2013`` () =
    meetup 2013 5 Week.Teenth DayOfWeek.Sunday |> should equal (DateTime(2013, 5, 19))

[<Fact(Skip = "Remove to run test")>]
let ``Sunteenth of June 2013`` () =
    meetup 2013 6 Week.Teenth DayOfWeek.Sunday |> should equal (DateTime(2013, 6, 16))

[<Fact(Skip = "Remove to run test")>]
let ``Sunteenth of October 2013`` () =
    meetup 2013 10 Week.Teenth DayOfWeek.Sunday |> should equal (DateTime(2013, 10, 13))

[<Fact(Skip = "Remove to run test")>]
let ``First Monday of March 2013`` () =
    meetup 2013 3 Week.First DayOfWeek.Monday |> should equal (DateTime(2013, 3, 4))

[<Fact(Skip = "Remove to run test")>]
let ``First Monday of April 2013`` () =
    meetup 2013 4 Week.First DayOfWeek.Monday |> should equal (DateTime(2013, 4, 1))

[<Fact(Skip = "Remove to run test")>]
let ``First Tuesday of May 2013`` () =
    meetup 2013 5 Week.First DayOfWeek.Tuesday |> should equal (DateTime(2013, 5, 7))

[<Fact(Skip = "Remove to run test")>]
let ``First Tuesday of June 2013`` () =
    meetup 2013 6 Week.First DayOfWeek.Tuesday |> should equal (DateTime(2013, 6, 4))

[<Fact(Skip = "Remove to run test")>]
let ``First Wednesday of July 2013`` () =
    meetup 2013 7 Week.First DayOfWeek.Wednesday |> should equal (DateTime(2013, 7, 3))

[<Fact(Skip = "Remove to run test")>]
let ``First Wednesday of August 2013`` () =
    meetup 2013 8 Week.First DayOfWeek.Wednesday |> should equal (DateTime(2013, 8, 7))

[<Fact(Skip = "Remove to run test")>]
let ``First Thursday of September 2013`` () =
    meetup 2013 9 Week.First DayOfWeek.Thursday |> should equal (DateTime(2013, 9, 5))

[<Fact(Skip = "Remove to run test")>]
let ``First Thursday of October 2013`` () =
    meetup 2013 10 Week.First DayOfWeek.Thursday |> should equal (DateTime(2013, 10, 3))

[<Fact(Skip = "Remove to run test")>]
let ``First Friday of November 2013`` () =
    meetup 2013 11 Week.First DayOfWeek.Friday |> should equal (DateTime(2013, 11, 1))

[<Fact(Skip = "Remove to run test")>]
let ``First Friday of December 2013`` () =
    meetup 2013 12 Week.First DayOfWeek.Friday |> should equal (DateTime(2013, 12, 6))

[<Fact(Skip = "Remove to run test")>]
let ``First Saturday of January 2013`` () =
    meetup 2013 1 Week.First DayOfWeek.Saturday |> should equal (DateTime(2013, 1, 5))

[<Fact(Skip = "Remove to run test")>]
let ``First Saturday of February 2013`` () =
    meetup 2013 2 Week.First DayOfWeek.Saturday |> should equal (DateTime(2013, 2, 2))

[<Fact(Skip = "Remove to run test")>]
let ``First Sunday of March 2013`` () =
    meetup 2013 3 Week.First DayOfWeek.Sunday |> should equal (DateTime(2013, 3, 3))

[<Fact(Skip = "Remove to run test")>]
let ``First Sunday of April 2013`` () =
    meetup 2013 4 Week.First DayOfWeek.Sunday |> should equal (DateTime(2013, 4, 7))

[<Fact(Skip = "Remove to run test")>]
let ``Second Monday of March 2013`` () =
    meetup 2013 3 Week.Second DayOfWeek.Monday |> should equal (DateTime(2013, 3, 11))

[<Fact(Skip = "Remove to run test")>]
let ``Second Monday of April 2013`` () =
    meetup 2013 4 Week.Second DayOfWeek.Monday |> should equal (DateTime(2013, 4, 8))

[<Fact(Skip = "Remove to run test")>]
let ``Second Tuesday of May 2013`` () =
    meetup 2013 5 Week.Second DayOfWeek.Tuesday |> should equal (DateTime(2013, 5, 14))

[<Fact(Skip = "Remove to run test")>]
let ``Second Tuesday of June 2013`` () =
    meetup 2013 6 Week.Second DayOfWeek.Tuesday |> should equal (DateTime(2013, 6, 11))

[<Fact(Skip = "Remove to run test")>]
let ``Second Wednesday of July 2013`` () =
    meetup 2013 7 Week.Second DayOfWeek.Wednesday |> should equal (DateTime(2013, 7, 10))

[<Fact(Skip = "Remove to run test")>]
let ``Second Wednesday of August 2013`` () =
    meetup 2013 8 Week.Second DayOfWeek.Wednesday |> should equal (DateTime(2013, 8, 14))

[<Fact(Skip = "Remove to run test")>]
let ``Second Thursday of September 2013`` () =
    meetup 2013 9 Week.Second DayOfWeek.Thursday |> should equal (DateTime(2013, 9, 12))

[<Fact(Skip = "Remove to run test")>]
let ``Second Thursday of October 2013`` () =
    meetup 2013 10 Week.Second DayOfWeek.Thursday |> should equal (DateTime(2013, 10, 10))

[<Fact(Skip = "Remove to run test")>]
let ``Second Friday of November 2013`` () =
    meetup 2013 11 Week.Second DayOfWeek.Friday |> should equal (DateTime(2013, 11, 8))

[<Fact(Skip = "Remove to run test")>]
let ``Second Friday of December 2013`` () =
    meetup 2013 12 Week.Second DayOfWeek.Friday |> should equal (DateTime(2013, 12, 13))

[<Fact(Skip = "Remove to run test")>]
let ``Second Saturday of January 2013`` () =
    meetup 2013 1 Week.Second DayOfWeek.Saturday |> should equal (DateTime(2013, 1, 12))

[<Fact(Skip = "Remove to run test")>]
let ``Second Saturday of February 2013`` () =
    meetup 2013 2 Week.Second DayOfWeek.Saturday |> should equal (DateTime(2013, 2, 9))

[<Fact(Skip = "Remove to run test")>]
let ``Second Sunday of March 2013`` () =
    meetup 2013 3 Week.Second DayOfWeek.Sunday |> should equal (DateTime(2013, 3, 10))

[<Fact(Skip = "Remove to run test")>]
let ``Second Sunday of April 2013`` () =
    meetup 2013 4 Week.Second DayOfWeek.Sunday |> should equal (DateTime(2013, 4, 14))

[<Fact(Skip = "Remove to run test")>]
let ``Third Monday of March 2013`` () =
    meetup 2013 3 Week.Third DayOfWeek.Monday |> should equal (DateTime(2013, 3, 18))

[<Fact(Skip = "Remove to run test")>]
let ``Third Monday of April 2013`` () =
    meetup 2013 4 Week.Third DayOfWeek.Monday |> should equal (DateTime(2013, 4, 15))

[<Fact(Skip = "Remove to run test")>]
let ``Third Tuesday of May 2013`` () =
    meetup 2013 5 Week.Third DayOfWeek.Tuesday |> should equal (DateTime(2013, 5, 21))

[<Fact(Skip = "Remove to run test")>]
let ``Third Tuesday of June 2013`` () =
    meetup 2013 6 Week.Third DayOfWeek.Tuesday |> should equal (DateTime(2013, 6, 18))

[<Fact(Skip = "Remove to run test")>]
let ``Third Wednesday of July 2013`` () =
    meetup 2013 7 Week.Third DayOfWeek.Wednesday |> should equal (DateTime(2013, 7, 17))

[<Fact(Skip = "Remove to run test")>]
let ``Third Wednesday of August 2013`` () =
    meetup 2013 8 Week.Third DayOfWeek.Wednesday |> should equal (DateTime(2013, 8, 21))

[<Fact(Skip = "Remove to run test")>]
let ``Third Thursday of September 2013`` () =
    meetup 2013 9 Week.Third DayOfWeek.Thursday |> should equal (DateTime(2013, 9, 19))

[<Fact(Skip = "Remove to run test")>]
let ``Third Thursday of October 2013`` () =
    meetup 2013 10 Week.Third DayOfWeek.Thursday |> should equal (DateTime(2013, 10, 17))

[<Fact(Skip = "Remove to run test")>]
let ``Third Friday of November 2013`` () =
    meetup 2013 11 Week.Third DayOfWeek.Friday |> should equal (DateTime(2013, 11, 15))

[<Fact(Skip = "Remove to run test")>]
let ``Third Friday of December 2013`` () =
    meetup 2013 12 Week.Third DayOfWeek.Friday |> should equal (DateTime(2013, 12, 20))

[<Fact(Skip = "Remove to run test")>]
let ``Third Saturday of January 2013`` () =
    meetup 2013 1 Week.Third DayOfWeek.Saturday |> should equal (DateTime(2013, 1, 19))

[<Fact(Skip = "Remove to run test")>]
let ``Third Saturday of February 2013`` () =
    meetup 2013 2 Week.Third DayOfWeek.Saturday |> should equal (DateTime(2013, 2, 16))

[<Fact(Skip = "Remove to run test")>]
let ``Third Sunday of March 2013`` () =
    meetup 2013 3 Week.Third DayOfWeek.Sunday |> should equal (DateTime(2013, 3, 17))

[<Fact(Skip = "Remove to run test")>]
let ``Third Sunday of April 2013`` () =
    meetup 2013 4 Week.Third DayOfWeek.Sunday |> should equal (DateTime(2013, 4, 21))

[<Fact(Skip = "Remove to run test")>]
let ``Fourth Monday of March 2013`` () =
    meetup 2013 3 Week.Fourth DayOfWeek.Monday |> should equal (DateTime(2013, 3, 25))

[<Fact(Skip = "Remove to run test")>]
let ``Fourth Monday of April 2013`` () =
    meetup 2013 4 Week.Fourth DayOfWeek.Monday |> should equal (DateTime(2013, 4, 22))

[<Fact(Skip = "Remove to run test")>]
let ``Fourth Tuesday of May 2013`` () =
    meetup 2013 5 Week.Fourth DayOfWeek.Tuesday |> should equal (DateTime(2013, 5, 28))

[<Fact(Skip = "Remove to run test")>]
let ``Fourth Tuesday of June 2013`` () =
    meetup 2013 6 Week.Fourth DayOfWeek.Tuesday |> should equal (DateTime(2013, 6, 25))

[<Fact(Skip = "Remove to run test")>]
let ``Fourth Wednesday of July 2013`` () =
    meetup 2013 7 Week.Fourth DayOfWeek.Wednesday |> should equal (DateTime(2013, 7, 24))

[<Fact(Skip = "Remove to run test")>]
let ``Fourth Wednesday of August 2013`` () =
    meetup 2013 8 Week.Fourth DayOfWeek.Wednesday |> should equal (DateTime(2013, 8, 28))

[<Fact(Skip = "Remove to run test")>]
let ``Fourth Thursday of September 2013`` () =
    meetup 2013 9 Week.Fourth DayOfWeek.Thursday |> should equal (DateTime(2013, 9, 26))

[<Fact(Skip = "Remove to run test")>]
let ``Fourth Thursday of October 2013`` () =
    meetup 2013 10 Week.Fourth DayOfWeek.Thursday |> should equal (DateTime(2013, 10, 24))

[<Fact(Skip = "Remove to run test")>]
let ``Fourth Friday of November 2013`` () =
    meetup 2013 11 Week.Fourth DayOfWeek.Friday |> should equal (DateTime(2013, 11, 22))

[<Fact(Skip = "Remove to run test")>]
let ``Fourth Friday of December 2013`` () =
    meetup 2013 12 Week.Fourth DayOfWeek.Friday |> should equal (DateTime(2013, 12, 27))

[<Fact(Skip = "Remove to run test")>]
let ``Fourth Saturday of January 2013`` () =
    meetup 2013 1 Week.Fourth DayOfWeek.Saturday |> should equal (DateTime(2013, 1, 26))

[<Fact(Skip = "Remove to run test")>]
let ``Fourth Saturday of February 2013`` () =
    meetup 2013 2 Week.Fourth DayOfWeek.Saturday |> should equal (DateTime(2013, 2, 23))

[<Fact(Skip = "Remove to run test")>]
let ``Fourth Sunday of March 2013`` () =
    meetup 2013 3 Week.Fourth DayOfWeek.Sunday |> should equal (DateTime(2013, 3, 24))

[<Fact(Skip = "Remove to run test")>]
let ``Fourth Sunday of April 2013`` () =
    meetup 2013 4 Week.Fourth DayOfWeek.Sunday |> should equal (DateTime(2013, 4, 28))

[<Fact(Skip = "Remove to run test")>]
let ``Last Monday of March 2013`` () =
    meetup 2013 3 Week.Last DayOfWeek.Monday |> should equal (DateTime(2013, 3, 25))

[<Fact(Skip = "Remove to run test")>]
let ``Last Monday of April 2013`` () =
    meetup 2013 4 Week.Last DayOfWeek.Monday |> should equal (DateTime(2013, 4, 29))

[<Fact(Skip = "Remove to run test")>]
let ``Last Tuesday of May 2013`` () =
    meetup 2013 5 Week.Last DayOfWeek.Tuesday |> should equal (DateTime(2013, 5, 28))

[<Fact(Skip = "Remove to run test")>]
let ``Last Tuesday of June 2013`` () =
    meetup 2013 6 Week.Last DayOfWeek.Tuesday |> should equal (DateTime(2013, 6, 25))

[<Fact(Skip = "Remove to run test")>]
let ``Last Wednesday of July 2013`` () =
    meetup 2013 7 Week.Last DayOfWeek.Wednesday |> should equal (DateTime(2013, 7, 31))

[<Fact(Skip = "Remove to run test")>]
let ``Last Wednesday of August 2013`` () =
    meetup 2013 8 Week.Last DayOfWeek.Wednesday |> should equal (DateTime(2013, 8, 28))

[<Fact(Skip = "Remove to run test")>]
let ``Last Thursday of September 2013`` () =
    meetup 2013 9 Week.Last DayOfWeek.Thursday |> should equal (DateTime(2013, 9, 26))

[<Fact(Skip = "Remove to run test")>]
let ``Last Thursday of October 2013`` () =
    meetup 2013 10 Week.Last DayOfWeek.Thursday |> should equal (DateTime(2013, 10, 31))

[<Fact(Skip = "Remove to run test")>]
let ``Last Friday of November 2013`` () =
    meetup 2013 11 Week.Last DayOfWeek.Friday |> should equal (DateTime(2013, 11, 29))

[<Fact(Skip = "Remove to run test")>]
let ``Last Friday of December 2013`` () =
    meetup 2013 12 Week.Last DayOfWeek.Friday |> should equal (DateTime(2013, 12, 27))

[<Fact(Skip = "Remove to run test")>]
let ``Last Saturday of January 2013`` () =
    meetup 2013 1 Week.Last DayOfWeek.Saturday |> should equal (DateTime(2013, 1, 26))

[<Fact(Skip = "Remove to run test")>]
let ``Last Saturday of February 2013`` () =
    meetup 2013 2 Week.Last DayOfWeek.Saturday |> should equal (DateTime(2013, 2, 23))

[<Fact(Skip = "Remove to run test")>]
let ``Last Sunday of March 2013`` () =
    meetup 2013 3 Week.Last DayOfWeek.Sunday |> should equal (DateTime(2013, 3, 31))

[<Fact(Skip = "Remove to run test")>]
let ``Last Sunday of April 2013`` () =
    meetup 2013 4 Week.Last DayOfWeek.Sunday |> should equal (DateTime(2013, 4, 28))

[<Fact(Skip = "Remove to run test")>]
let ``Last Wednesday of February 2012`` () =
    meetup 2012 2 Week.Last DayOfWeek.Wednesday |> should equal (DateTime(2012, 2, 29))

[<Fact(Skip = "Remove to run test")>]
let ``Last Wednesday of December 2014`` () =
    meetup 2014 12 Week.Last DayOfWeek.Wednesday |> should equal (DateTime(2014, 12, 31))

[<Fact(Skip = "Remove to run test")>]
let ``Last Sunday of February 2015`` () =
    meetup 2015 2 Week.Last DayOfWeek.Sunday |> should equal (DateTime(2015, 2, 22))

[<Fact(Skip = "Remove to run test")>]
let ``First Friday of December 2012`` () =
    meetup 2012 12 Week.First DayOfWeek.Friday |> should equal (DateTime(2012, 12, 7))

