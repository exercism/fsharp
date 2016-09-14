module WordyTest

open NUnit.Framework
open Wordy

[<Test>]
let ``Can parse and solve addition problems`` () =
    Assert.That(solve "What is 1 plus 1?", Is.EqualTo(Some 2))
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Can add double digit numbers`` () =
    Assert.That(solve "What is 53 plus 2?", Is.EqualTo(Some 55))
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Can add negative numbers`` () =
    Assert.That(solve "What is -1 plus -10?", Is.EqualTo(Some -11))
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Can add large numbers`` () =
    Assert.That(solve "What is 123 plus 45678?", Is.EqualTo(Some 45801))
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Can parse and solve subtraction problems`` () =
    Assert.That(solve "What is 4 minus -12?", Is.EqualTo(Some 16))
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Can parse and solve multiplication problems`` () =
    Assert.That(solve "What is -3 multiplied by 25?", Is.EqualTo(Some -75))
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Can parse and solve division problems`` () =
    Assert.That(solve "What is 33 divided by -3?", Is.EqualTo(Some -11))
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Can add twice`` () =
    Assert.That(solve "What is 1 plus 1 plus 1?", Is.EqualTo(Some 3))
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Can add then subtract`` () =
    Assert.That(solve "What is 1 plus 5 minus -2?", Is.EqualTo(Some 8))
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Can subtract twice`` () =
    Assert.That(solve "What is 20 minus 4 minus 13?", Is.EqualTo(Some 3))
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Can subtract then add`` () =
    Assert.That(solve "What is 17 minus 6 plus 3?", Is.EqualTo(Some 14))
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Can multiply twice`` () =
    Assert.That(solve "What is 2 multiplied by -2 multiplied by 3?", Is.EqualTo(Some -12))
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Can add then multiply`` () =
    Assert.That(solve "What is -3 plus 7 multiplied by -2?", Is.EqualTo(Some -8))
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Can divide twice`` () =
    Assert.That(solve "What is -12 divided by 2 divided by -3?", Is.EqualTo(Some 2))
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Cubed is too advanced`` () =
    Assert.That(solve "What is 53 cubed?", Is.EqualTo(None))
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Irrelevent problems are not valid`` () =
    Assert.That(solve "Who is the president of the United States?", Is.EqualTo(None))
