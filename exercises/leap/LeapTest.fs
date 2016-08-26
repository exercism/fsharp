module LeapYearTest

open NUnit.Framework
open LeapYear
    
[<Test>]
let ``Is 1996 a valid leap year`` () = 
    Assert.That(isLeapYear 1996, Is.True)
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Is 1997 an invalid leap year`` () = 
    Assert.That(isLeapYear 1997, Is.False)
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Is the turn of the 20th century an invalid leap year`` () = 
    Assert.That(isLeapYear 1900, Is.False)
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Is the turn of the 25th century a valid leap year`` () = 
    Assert.That(isLeapYear 2400, Is.True)