module ProverbTest

open NUnit.Framework

open Proverb

[<Test>]
let ``Line one`` () =
    Assert.That(line 1, Is.EqualTo("For want of a nail the shoe was lost."))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Line four`` () =
    Assert.That(line 4, Is.EqualTo("For want of a rider the message was lost."))
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Line seven`` () =
    Assert.That(line 7, Is.EqualTo("And all for the want of a horseshoe nail."))
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Proverb`` () =
    let expected =
        ["For want of a nail the shoe was lost.";
         "For want of a shoe the horse was lost.";
         "For want of a horse the rider was lost.";
         "For want of a rider the message was lost.";
         "For want of a message the battle was lost.";
         "For want of a battle the kingdom was lost.";
         "And all for the want of a horseshoe nail."]
        |> List.reduce (fun x y -> x + "\n" + y)

    Assert.That(proverb, Is.EqualTo(expected))