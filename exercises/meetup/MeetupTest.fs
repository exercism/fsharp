// This file was auto-generated based on version 1.0.0 of the canonical data.

module MeetupTest

open FsUnit.Xunit
open Xunit
open System

open Meetup

[<Fact>]
let ``Monteenth of May 2013`` () =
    meetup 2013 5 DayOfWeek.Monday Schedule.Teenth |> should equal (DateTime(2013, 5, 13))

[<Fact(Skip = "Remove to run test")>]
let ``Monteenth of August 2013`` () =
    meetup 2013 8 DayOfWeek.Monday Schedule.Teenth |> should equal (DateTime(2013, 8, 19))

[<Fact(Skip = "Remove to run test")>]
let ``Monteenth of September 2013`` () =
    meetup 2013 9 DayOfWeek.Monday Schedule.Teenth |> should equal (DateTime(2013, 9, 16))

[<Fact(Skip = "Remove to run test")>]
let ``Tuesteenth of March 2013`` () =
    meetup 2013 3 DayOfWeek.Tuesday Schedule.Teenth |> should equal (DateTime(2013, 3, 19))

[<Fact(Skip = "Remove to run test")>]
let ``Tuesteenth of April 2013`` () =
    meetup 2013 4 DayOfWeek.Tuesday Schedule.Teenth |> should equal (DateTime(2013, 4, 16))

[<Fact(Skip = "Remove to run test")>]
let ``Tuesteenth of August 2013`` () =
    meetup 2013 8 DayOfWeek.Tuesday Schedule.Teenth |> should equal (DateTime(2013, 8, 13))

[<Fact(Skip = "Remove to run test")>]
let ``Wednesteenth of January 2013`` () =
    meetup 2013 1 DayOfWeek.Wednesday Schedule.Teenth |> should equal (DateTime(2013, 1, 16))

[<Fact(Skip = "Remove to run test")>]
let ``Wednesteenth of February 2013`` () =
    meetup 2013 2 DayOfWeek.Wednesday Schedule.Teenth |> should equal (DateTime(2013, 2, 13))

[<Fact(Skip = "Remove to run test")>]
let ``Wednesteenth of June 2013`` () =
    meetup 2013 6 DayOfWeek.Wednesday Schedule.Teenth |> should equal (DateTime(2013, 6, 19))

[<Fact(Skip = "Remove to run test")>]
let ``Thursteenth of May 2013`` () =
    meetup 2013 5 DayOfWeek.Thursday Schedule.Teenth |> should equal (DateTime(2013, 5, 16))

[<Fact(Skip = "Remove to run test")>]
let ``Thursteenth of June 2013`` () =
    meetup 2013 6 DayOfWeek.Thursday Schedule.Teenth |> should equal (DateTime(2013, 6, 13))

[<Fact(Skip = "Remove to run test")>]
let ``Thursteenth of September 2013`` () =
    meetup 2013 9 DayOfWeek.Thursday Schedule.Teenth |> should equal (DateTime(2013, 9, 19))

[<Fact(Skip = "Remove to run test")>]
let ``Friteenth of April 2013`` () =
    meetup 2013 4 DayOfWeek.Friday Schedule.Teenth |> should equal (DateTime(2013, 4, 19))

[<Fact(Skip = "Remove to run test")>]
let ``Friteenth of August 2013`` () =
    meetup 2013 8 DayOfWeek.Friday Schedule.Teenth |> should equal (DateTime(2013, 8, 16))

[<Fact(Skip = "Remove to run test")>]
let ``Friteenth of September 2013`` () =
    meetup 2013 9 DayOfWeek.Friday Schedule.Teenth |> should equal (DateTime(2013, 9, 13))

[<Fact(Skip = "Remove to run test")>]
let ``Saturteenth of February 2013`` () =
    meetup 2013 2 DayOfWeek.Saturday Schedule.Teenth |> should equal (DateTime(2013, 2, 16))

[<Fact(Skip = "Remove to run test")>]
let ``Saturteenth of April 2013`` () =
    meetup 2013 4 DayOfWeek.Saturday Schedule.Teenth |> should equal (DateTime(2013, 4, 13))

[<Fact(Skip = "Remove to run test")>]
let ``Saturteenth of October 2013`` () =
    meetup 2013 10 DayOfWeek.Saturday Schedule.Teenth |> should equal (DateTime(2013, 10, 19))

[<Fact(Skip = "Remove to run test")>]
let ``Sunteenth of May 2013`` () =
    meetup 2013 5 DayOfWeek.Sunday Schedule.Teenth |> should equal (DateTime(2013, 5, 19))

[<Fact(Skip = "Remove to run test")>]
let ``Sunteenth of June 2013`` () =
    meetup 2013 6 DayOfWeek.Sunday Schedule.Teenth |> should equal (DateTime(2013, 6, 16))

[<Fact(Skip = "Remove to run test")>]
let ``Sunteenth of October 2013`` () =
    meetup 2013 10 DayOfWeek.Sunday Schedule.Teenth |> should equal (DateTime(2013, 10, 13))

[<Fact(Skip = "Remove to run test")>]
let ``First Monday of March 2013`` () =
    meetup 2013 3 DayOfWeek.Monday Schedule.First |> should equal (DateTime(2013, 3, 4))

[<Fact(Skip = "Remove to run test")>]
let ``First Monday of April 2013`` () =
    meetup 2013 4 DayOfWeek.Monday Schedule.First |> should equal (DateTime(2013, 4, 1))

[<Fact(Skip = "Remove to run test")>]
let ``First Tuesday of May 2013`` () =
    meetup 2013 5 DayOfWeek.Tuesday Schedule.First |> should equal (DateTime(2013, 5, 7))

[<Fact(Skip = "Remove to run test")>]
let ``First Tuesday of June 2013`` () =
    meetup 2013 6 DayOfWeek.Tuesday Schedule.First |> should equal (DateTime(2013, 6, 4))

[<Fact(Skip = "Remove to run test")>]
let ``First Wednesday of July 2013`` () =
    meetup 2013 7 DayOfWeek.Wednesday Schedule.First |> should equal (DateTime(2013, 7, 3))

[<Fact(Skip = "Remove to run test")>]
let ``First Wednesday of August 2013`` () =
    meetup 2013 8 DayOfWeek.Wednesday Schedule.First |> should equal (DateTime(2013, 8, 7))

[<Fact(Skip = "Remove to run test")>]
let ``First Thursday of September 2013`` () =
    meetup 2013 9 DayOfWeek.Thursday Schedule.First |> should equal (DateTime(2013, 9, 5))

[<Fact(Skip = "Remove to run test")>]
let ``First Thursday of October 2013`` () =
    meetup 2013 10 DayOfWeek.Thursday Schedule.First |> should equal (DateTime(2013, 10, 3))

[<Fact(Skip = "Remove to run test")>]
let ``First Friday of November 2013`` () =
    meetup 2013 11 DayOfWeek.Friday Schedule.First |> should equal (DateTime(2013, 11, 1))

[<Fact(Skip = "Remove to run test")>]
let ``First Friday of December 2013`` () =
    meetup 2013 12 DayOfWeek.Friday Schedule.First |> should equal (DateTime(2013, 12, 6))

[<Fact(Skip = "Remove to run test")>]
let ``First Saturday of January 2013`` () =
    meetup 2013 1 DayOfWeek.Saturday Schedule.First |> should equal (DateTime(2013, 1, 5))

[<Fact(Skip = "Remove to run test")>]
let ``First Saturday of February 2013`` () =
    meetup 2013 2 DayOfWeek.Saturday Schedule.First |> should equal (DateTime(2013, 2, 2))

[<Fact(Skip = "Remove to run test")>]
let ``First Sunday of March 2013`` () =
    meetup 2013 3 DayOfWeek.Sunday Schedule.First |> should equal (DateTime(2013, 3, 3))

[<Fact(Skip = "Remove to run test")>]
let ``First Sunday of April 2013`` () =
    meetup 2013 4 DayOfWeek.Sunday Schedule.First |> should equal (DateTime(2013, 4, 7))

[<Fact(Skip = "Remove to run test")>]
let ``Second Monday of March 2013`` () =
    meetup 2013 3 DayOfWeek.Monday Schedule.Second |> should equal (DateTime(2013, 3, 11))

[<Fact(Skip = "Remove to run test")>]
let ``Second Monday of April 2013`` () =
    meetup 2013 4 DayOfWeek.Monday Schedule.Second |> should equal (DateTime(2013, 4, 8))

[<Fact(Skip = "Remove to run test")>]
let ``Second Tuesday of May 2013`` () =
    meetup 2013 5 DayOfWeek.Tuesday Schedule.Second |> should equal (DateTime(2013, 5, 14))

[<Fact(Skip = "Remove to run test")>]
let ``Second Tuesday of June 2013`` () =
    meetup 2013 6 DayOfWeek.Tuesday Schedule.Second |> should equal (DateTime(2013, 6, 11))

[<Fact(Skip = "Remove to run test")>]
let ``Second Wednesday of July 2013`` () =
    meetup 2013 7 DayOfWeek.Wednesday Schedule.Second |> should equal (DateTime(2013, 7, 10))

[<Fact(Skip = "Remove to run test")>]
let ``Second Wednesday of August 2013`` () =
    meetup 2013 8 DayOfWeek.Wednesday Schedule.Second |> should equal (DateTime(2013, 8, 14))

[<Fact(Skip = "Remove to run test")>]
let ``Second Thursday of September 2013`` () =
    meetup 2013 9 DayOfWeek.Thursday Schedule.Second |> should equal (DateTime(2013, 9, 12))

[<Fact(Skip = "Remove to run test")>]
let ``Second Thursday of October 2013`` () =
    meetup 2013 10 DayOfWeek.Thursday Schedule.Second |> should equal (DateTime(2013, 10, 10))

[<Fact(Skip = "Remove to run test")>]
let ``Second Friday of November 2013`` () =
    meetup 2013 11 DayOfWeek.Friday Schedule.Second |> should equal (DateTime(2013, 11, 8))

[<Fact(Skip = "Remove to run test")>]
let ``Second Friday of December 2013`` () =
    meetup 2013 12 DayOfWeek.Friday Schedule.Second |> should equal (DateTime(2013, 12, 13))

[<Fact(Skip = "Remove to run test")>]
let ``Second Saturday of January 2013`` () =
    meetup 2013 1 DayOfWeek.Saturday Schedule.Second |> should equal (DateTime(2013, 1, 12))

[<Fact(Skip = "Remove to run test")>]
let ``Second Saturday of February 2013`` () =
    meetup 2013 2 DayOfWeek.Saturday Schedule.Second |> should equal (DateTime(2013, 2, 9))

[<Fact(Skip = "Remove to run test")>]
let ``Second Sunday of March 2013`` () =
    meetup 2013 3 DayOfWeek.Sunday Schedule.Second |> should equal (DateTime(2013, 3, 10))

[<Fact(Skip = "Remove to run test")>]
let ``Second Sunday of April 2013`` () =
    meetup 2013 4 DayOfWeek.Sunday Schedule.Second |> should equal (DateTime(2013, 4, 14))

[<Fact(Skip = "Remove to run test")>]
let ``Third Monday of March 2013`` () =
    meetup 2013 3 DayOfWeek.Monday Schedule.Third |> should equal (DateTime(2013, 3, 18))

[<Fact(Skip = "Remove to run test")>]
let ``Third Monday of April 2013`` () =
    meetup 2013 4 DayOfWeek.Monday Schedule.Third |> should equal (DateTime(2013, 4, 15))

[<Fact(Skip = "Remove to run test")>]
let ``Third Tuesday of May 2013`` () =
    meetup 2013 5 DayOfWeek.Tuesday Schedule.Third |> should equal (DateTime(2013, 5, 21))

[<Fact(Skip = "Remove to run test")>]
let ``Third Tuesday of June 2013`` () =
    meetup 2013 6 DayOfWeek.Tuesday Schedule.Third |> should equal (DateTime(2013, 6, 18))

[<Fact(Skip = "Remove to run test")>]
let ``Third Wednesday of July 2013`` () =
    meetup 2013 7 DayOfWeek.Wednesday Schedule.Third |> should equal (DateTime(2013, 7, 17))

[<Fact(Skip = "Remove to run test")>]
let ``Third Wednesday of August 2013`` () =
    meetup 2013 8 DayOfWeek.Wednesday Schedule.Third |> should equal (DateTime(2013, 8, 21))

[<Fact(Skip = "Remove to run test")>]
let ``Third Thursday of September 2013`` () =
    meetup 2013 9 DayOfWeek.Thursday Schedule.Third |> should equal (DateTime(2013, 9, 19))

[<Fact(Skip = "Remove to run test")>]
let ``Third Thursday of October 2013`` () =
    meetup 2013 10 DayOfWeek.Thursday Schedule.Third |> should equal (DateTime(2013, 10, 17))

[<Fact(Skip = "Remove to run test")>]
let ``Third Friday of November 2013`` () =
    meetup 2013 11 DayOfWeek.Friday Schedule.Third |> should equal (DateTime(2013, 11, 15))

[<Fact(Skip = "Remove to run test")>]
let ``Third Friday of December 2013`` () =
    meetup 2013 12 DayOfWeek.Friday Schedule.Third |> should equal (DateTime(2013, 12, 20))

[<Fact(Skip = "Remove to run test")>]
let ``Third Saturday of January 2013`` () =
    meetup 2013 1 DayOfWeek.Saturday Schedule.Third |> should equal (DateTime(2013, 1, 19))

[<Fact(Skip = "Remove to run test")>]
let ``Third Saturday of February 2013`` () =
    meetup 2013 2 DayOfWeek.Saturday Schedule.Third |> should equal (DateTime(2013, 2, 16))

[<Fact(Skip = "Remove to run test")>]
let ``Third Sunday of March 2013`` () =
    meetup 2013 3 DayOfWeek.Sunday Schedule.Third |> should equal (DateTime(2013, 3, 17))

[<Fact(Skip = "Remove to run test")>]
let ``Third Sunday of April 2013`` () =
    meetup 2013 4 DayOfWeek.Sunday Schedule.Third |> should equal (DateTime(2013, 4, 21))

[<Fact(Skip = "Remove to run test")>]
let ``Fourth Monday of March 2013`` () =
    meetup 2013 3 DayOfWeek.Monday Schedule.Fourth |> should equal (DateTime(2013, 3, 25))

[<Fact(Skip = "Remove to run test")>]
let ``Fourth Monday of April 2013`` () =
    meetup 2013 4 DayOfWeek.Monday Schedule.Fourth |> should equal (DateTime(2013, 4, 22))

[<Fact(Skip = "Remove to run test")>]
let ``Fourth Tuesday of May 2013`` () =
    meetup 2013 5 DayOfWeek.Tuesday Schedule.Fourth |> should equal (DateTime(2013, 5, 28))

[<Fact(Skip = "Remove to run test")>]
let ``Fourth Tuesday of June 2013`` () =
    meetup 2013 6 DayOfWeek.Tuesday Schedule.Fourth |> should equal (DateTime(2013, 6, 25))

[<Fact(Skip = "Remove to run test")>]
let ``Fourth Wednesday of July 2013`` () =
    meetup 2013 7 DayOfWeek.Wednesday Schedule.Fourth |> should equal (DateTime(2013, 7, 24))

[<Fact(Skip = "Remove to run test")>]
let ``Fourth Wednesday of August 2013`` () =
    meetup 2013 8 DayOfWeek.Wednesday Schedule.Fourth |> should equal (DateTime(2013, 8, 28))

[<Fact(Skip = "Remove to run test")>]
let ``Fourth Thursday of September 2013`` () =
    meetup 2013 9 DayOfWeek.Thursday Schedule.Fourth |> should equal (DateTime(2013, 9, 26))

[<Fact(Skip = "Remove to run test")>]
let ``Fourth Thursday of October 2013`` () =
    meetup 2013 10 DayOfWeek.Thursday Schedule.Fourth |> should equal (DateTime(2013, 10, 24))

[<Fact(Skip = "Remove to run test")>]
let ``Fourth Friday of November 2013`` () =
    meetup 2013 11 DayOfWeek.Friday Schedule.Fourth |> should equal (DateTime(2013, 11, 22))

[<Fact(Skip = "Remove to run test")>]
let ``Fourth Friday of December 2013`` () =
    meetup 2013 12 DayOfWeek.Friday Schedule.Fourth |> should equal (DateTime(2013, 12, 27))

[<Fact(Skip = "Remove to run test")>]
let ``Fourth Saturday of January 2013`` () =
    meetup 2013 1 DayOfWeek.Saturday Schedule.Fourth |> should equal (DateTime(2013, 1, 26))

[<Fact(Skip = "Remove to run test")>]
let ``Fourth Saturday of February 2013`` () =
    meetup 2013 2 DayOfWeek.Saturday Schedule.Fourth |> should equal (DateTime(2013, 2, 23))

[<Fact(Skip = "Remove to run test")>]
let ``Fourth Sunday of March 2013`` () =
    meetup 2013 3 DayOfWeek.Sunday Schedule.Fourth |> should equal (DateTime(2013, 3, 24))

[<Fact(Skip = "Remove to run test")>]
let ``Fourth Sunday of April 2013`` () =
    meetup 2013 4 DayOfWeek.Sunday Schedule.Fourth |> should equal (DateTime(2013, 4, 28))

[<Fact(Skip = "Remove to run test")>]
let ``Last Monday of March 2013`` () =
    meetup 2013 3 DayOfWeek.Monday Schedule.Last |> should equal (DateTime(2013, 3, 25))

[<Fact(Skip = "Remove to run test")>]
let ``Last Monday of April 2013`` () =
    meetup 2013 4 DayOfWeek.Monday Schedule.Last |> should equal (DateTime(2013, 4, 29))

[<Fact(Skip = "Remove to run test")>]
let ``Last Tuesday of May 2013`` () =
    meetup 2013 5 DayOfWeek.Tuesday Schedule.Last |> should equal (DateTime(2013, 5, 28))

[<Fact(Skip = "Remove to run test")>]
let ``Last Tuesday of June 2013`` () =
    meetup 2013 6 DayOfWeek.Tuesday Schedule.Last |> should equal (DateTime(2013, 6, 25))

[<Fact(Skip = "Remove to run test")>]
let ``Last Wednesday of July 2013`` () =
    meetup 2013 7 DayOfWeek.Wednesday Schedule.Last |> should equal (DateTime(2013, 7, 31))

[<Fact(Skip = "Remove to run test")>]
let ``Last Wednesday of August 2013`` () =
    meetup 2013 8 DayOfWeek.Wednesday Schedule.Last |> should equal (DateTime(2013, 8, 28))

[<Fact(Skip = "Remove to run test")>]
let ``Last Thursday of September 2013`` () =
    meetup 2013 9 DayOfWeek.Thursday Schedule.Last |> should equal (DateTime(2013, 9, 26))

[<Fact(Skip = "Remove to run test")>]
let ``Last Thursday of October 2013`` () =
    meetup 2013 10 DayOfWeek.Thursday Schedule.Last |> should equal (DateTime(2013, 10, 31))

[<Fact(Skip = "Remove to run test")>]
let ``Last Friday of November 2013`` () =
    meetup 2013 11 DayOfWeek.Friday Schedule.Last |> should equal (DateTime(2013, 11, 29))

[<Fact(Skip = "Remove to run test")>]
let ``Last Friday of December 2013`` () =
    meetup 2013 12 DayOfWeek.Friday Schedule.Last |> should equal (DateTime(2013, 12, 27))

[<Fact(Skip = "Remove to run test")>]
let ``Last Saturday of January 2013`` () =
    meetup 2013 1 DayOfWeek.Saturday Schedule.Last |> should equal (DateTime(2013, 1, 26))

[<Fact(Skip = "Remove to run test")>]
let ``Last Saturday of February 2013`` () =
    meetup 2013 2 DayOfWeek.Saturday Schedule.Last |> should equal (DateTime(2013, 2, 23))

[<Fact(Skip = "Remove to run test")>]
let ``Last Sunday of March 2013`` () =
    meetup 2013 3 DayOfWeek.Sunday Schedule.Last |> should equal (DateTime(2013, 3, 31))

[<Fact(Skip = "Remove to run test")>]
let ``Last Sunday of April 2013`` () =
    meetup 2013 4 DayOfWeek.Sunday Schedule.Last |> should equal (DateTime(2013, 4, 28))

[<Fact(Skip = "Remove to run test")>]
let ``Last Wednesday of February 2012`` () =
    meetup 2012 2 DayOfWeek.Wednesday Schedule.Last |> should equal (DateTime(2012, 2, 29))

[<Fact(Skip = "Remove to run test")>]
let ``Last Wednesday of December 2014`` () =
    meetup 2014 12 DayOfWeek.Wednesday Schedule.Last |> should equal (DateTime(2014, 12, 31))

[<Fact(Skip = "Remove to run test")>]
let ``Last Sunday of February 2015`` () =
    meetup 2015 2 DayOfWeek.Sunday Schedule.Last |> should equal (DateTime(2015, 2, 22))

[<Fact(Skip = "Remove to run test")>]
let ``First Friday of December 2012`` () =
    meetup 2012 12 DayOfWeek.Friday Schedule.First |> should equal (DateTime(2012, 12, 7))

