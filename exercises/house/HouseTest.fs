// This file was auto-generated based on version 2.2.0 of the canonical data.

module HouseTest

open FsUnit.Xunit
open Xunit

open House

[<Fact>]
let ``Verse one - the house that jack built`` () =
    let expected = ["This is the house that Jack built."]
    recite 1 1 |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Verse two - the malt that lay`` () =
    let expected = ["This is the malt that lay in the house that Jack built."]
    recite 2 2 |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Verse three - the rat that ate`` () =
    let expected = ["This is the rat that ate the malt that lay in the house that Jack built."]
    recite 3 3 |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Verse four - the cat that killed`` () =
    let expected = ["This is the cat that killed the rat that ate the malt that lay in the house that Jack built."]
    recite 4 4 |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Verse five - the dog that worried`` () =
    let expected = ["This is the dog that worried the cat that killed the rat that ate the malt that lay in the house that Jack built."]
    recite 5 5 |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Verse six - the cow with the crumpled horn`` () =
    let expected = ["This is the cow with the crumpled horn that tossed the dog that worried the cat that killed the rat that ate the malt that lay in the house that Jack built."]
    recite 6 6 |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Verse seven - the maiden all forlorn`` () =
    let expected = ["This is the maiden all forlorn that milked the cow with the crumpled horn that tossed the dog that worried the cat that killed the rat that ate the malt that lay in the house that Jack built."]
    recite 7 7 |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Verse eight - the man all tattered and torn`` () =
    let expected = ["This is the man all tattered and torn that kissed the maiden all forlorn that milked the cow with the crumpled horn that tossed the dog that worried the cat that killed the rat that ate the malt that lay in the house that Jack built."]
    recite 8 8 |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Verse nine - the priest all shaven and shorn`` () =
    let expected = ["This is the priest all shaven and shorn that married the man all tattered and torn that kissed the maiden all forlorn that milked the cow with the crumpled horn that tossed the dog that worried the cat that killed the rat that ate the malt that lay in the house that Jack built."]
    recite 9 9 |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Verse 10 - the rooster that crowed in the morn`` () =
    let expected = ["This is the rooster that crowed in the morn that woke the priest all shaven and shorn that married the man all tattered and torn that kissed the maiden all forlorn that milked the cow with the crumpled horn that tossed the dog that worried the cat that killed the rat that ate the malt that lay in the house that Jack built."]
    recite 10 10 |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Verse 11 - the farmer sowing his corn`` () =
    let expected = ["This is the farmer sowing his corn that kept the rooster that crowed in the morn that woke the priest all shaven and shorn that married the man all tattered and torn that kissed the maiden all forlorn that milked the cow with the crumpled horn that tossed the dog that worried the cat that killed the rat that ate the malt that lay in the house that Jack built."]
    recite 11 11 |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Verse 12 - the horse and the hound and the horn`` () =
    let expected = ["This is the horse and the hound and the horn that belonged to the farmer sowing his corn that kept the rooster that crowed in the morn that woke the priest all shaven and shorn that married the man all tattered and torn that kissed the maiden all forlorn that milked the cow with the crumpled horn that tossed the dog that worried the cat that killed the rat that ate the malt that lay in the house that Jack built."]
    recite 12 12 |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Multiple verses`` () =
    let expected = 
        [ "This is the cat that killed the rat that ate the malt that lay in the house that Jack built.";
          "This is the dog that worried the cat that killed the rat that ate the malt that lay in the house that Jack built.";
          "This is the cow with the crumpled horn that tossed the dog that worried the cat that killed the rat that ate the malt that lay in the house that Jack built.";
          "This is the maiden all forlorn that milked the cow with the crumpled horn that tossed the dog that worried the cat that killed the rat that ate the malt that lay in the house that Jack built.";
          "This is the man all tattered and torn that kissed the maiden all forlorn that milked the cow with the crumpled horn that tossed the dog that worried the cat that killed the rat that ate the malt that lay in the house that Jack built." ]
    recite 4 8 |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Full rhyme`` () =
    let expected = 
        [ "This is the house that Jack built.";
          "This is the malt that lay in the house that Jack built.";
          "This is the rat that ate the malt that lay in the house that Jack built.";
          "This is the cat that killed the rat that ate the malt that lay in the house that Jack built.";
          "This is the dog that worried the cat that killed the rat that ate the malt that lay in the house that Jack built.";
          "This is the cow with the crumpled horn that tossed the dog that worried the cat that killed the rat that ate the malt that lay in the house that Jack built.";
          "This is the maiden all forlorn that milked the cow with the crumpled horn that tossed the dog that worried the cat that killed the rat that ate the malt that lay in the house that Jack built.";
          "This is the man all tattered and torn that kissed the maiden all forlorn that milked the cow with the crumpled horn that tossed the dog that worried the cat that killed the rat that ate the malt that lay in the house that Jack built.";
          "This is the priest all shaven and shorn that married the man all tattered and torn that kissed the maiden all forlorn that milked the cow with the crumpled horn that tossed the dog that worried the cat that killed the rat that ate the malt that lay in the house that Jack built.";
          "This is the rooster that crowed in the morn that woke the priest all shaven and shorn that married the man all tattered and torn that kissed the maiden all forlorn that milked the cow with the crumpled horn that tossed the dog that worried the cat that killed the rat that ate the malt that lay in the house that Jack built.";
          "This is the farmer sowing his corn that kept the rooster that crowed in the morn that woke the priest all shaven and shorn that married the man all tattered and torn that kissed the maiden all forlorn that milked the cow with the crumpled horn that tossed the dog that worried the cat that killed the rat that ate the malt that lay in the house that Jack built.";
          "This is the horse and the hound and the horn that belonged to the farmer sowing his corn that kept the rooster that crowed in the morn that woke the priest all shaven and shorn that married the man all tattered and torn that kissed the maiden all forlorn that milked the cow with the crumpled horn that tossed the dog that worried the cat that killed the rat that ate the malt that lay in the house that Jack built." ]
    recite 1 12 |> should equal expected

