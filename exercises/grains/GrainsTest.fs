module GrainsTest

open NUnit.Framework
open Grains
    
[<Test>]
let ``Test square 1`` () = 
    Assert.That(square 1, Is.EqualTo(1I))
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Test square 2`` () = 
    Assert.That(square 2, Is.EqualTo(2I))
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Test square 3`` () = 
    Assert.That(square 3, Is.EqualTo(4I))
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Test square 4`` () = 
    Assert.That(square 4, Is.EqualTo(8I))
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Test square 16`` () = 
    Assert.That(square 16, Is.EqualTo(32768I))
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Test square 32`` () = 
    Assert.That(square 32, Is.EqualTo(2147483648I))
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Test square 64`` () = 
    Assert.That(square 64, Is.EqualTo(9223372036854775808I))
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Test total grains`` () = 
    Assert.That(total, Is.EqualTo(18446744073709551615I))