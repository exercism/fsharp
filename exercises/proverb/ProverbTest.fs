module ProverbTest

open Xunit
open FsUnit

open Proverb

[Fact]
let ``Line one`` () =
    line 1 |> should equal "For want of a nail the shoe was lost."

[Fact(Skip = "Remove to run test")]
let ``Line four`` () =
    line 4 |> should equal "For want of a rider the message was lost."
    
[Fact(Skip = "Remove to run test")]
let ``Line seven`` () =
    line 7 |> should equal "And all for the want of a horseshoe nail."
    
[Fact(Skip = "Remove to run test")]
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

    proverb |> should equal expected