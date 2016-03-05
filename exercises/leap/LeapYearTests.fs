module LeapYearTests

open NUnit.Framework
open LeapYear

type LeapYearTests() =

    [<Test>]
    member x.``Is 1996 a valid leap year``() =
        Assert.That(LeapYear.isLeap 1996, Is.True)

    [<Test>]
    [<Ignore("Remove to run test")>]
    member x.``Is 1997 an invalid leap year``() =
        Assert.That(LeapYear.isLeap 1997, Is.False)

    [<Test>]
    [<Ignore("Remove to run test")>]
    member x.``Is the turn of the 20th century an invalid leap year``() =
        Assert.That(LeapYear.isLeap 1900, Is.False)

    [<Test>]
    [<Ignore("Remove to run test")>]
    member x.``Is the turn of the 25th century a valid leap year``() =
        Assert.That(LeapYear.isLeap 2400, Is.True)