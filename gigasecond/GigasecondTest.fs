module GigasecondTest

open NUnit.Framework
open Gigasecond

[<TestFixture>]
type GigasecondTest() =
    
    [<Test>]
    member tests.First_date() =
        let gigasecond = Gigasecond(System.DateTime(2011, 4, 25))

        Assert.That(gigasecond.Date, Is.EqualTo(System.DateTime(2043, 1, 1)))

    [<Test>]
    [<Ignore>]
    member tests.Another_date() =
        let gigasecond = Gigasecond(System.DateTime(1977, 6, 13))

        Assert.That(gigasecond.Date, Is.EqualTo(System.DateTime(2009, 2, 19)))

    [<Test>]
    [<Ignore>]
    member tests.Yet_another_date() =
        let gigasecond = Gigasecond(System.DateTime(1959, 7, 19))

        Assert.That(gigasecond.Date, Is.EqualTo(System.DateTime(1991, 3, 27)))