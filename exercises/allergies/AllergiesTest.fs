// This file was auto-generated based on version 1.0.0 of the canonical data.

module AllergiesTest

open FsUnit.Xunit
open Xunit

open Allergies

[<Fact>]
let ``No allergies means not allergic`` () =
    allergicTo 0 |> should equal [seq [seq [seq []]; seq [seq []]]; seq [seq [seq []]; seq [seq []]];
 seq [seq [seq []]; seq [seq []]]]

[<Fact(Skip = "Remove to run test")>]
let ``Is allergic to eggs`` () =
    allergicTo 1 |> should equal [seq [seq [seq []]; seq [seq []]]]

[<Fact(Skip = "Remove to run test")>]
let ``Allergic to eggs in addition to other stuff`` () =
    allergicTo 5 |> should equal [seq [seq [seq []]; seq [seq []]]; seq [seq [seq []]; seq [seq []]];
 seq [seq [seq []]; seq [seq []]]]

[<Fact(Skip = "Remove to run test")>]
let ``No allergies at all`` () =
    list 0 |> should be Empty

[<Fact(Skip = "Remove to run test")>]
let ``Allergic to just eggs`` () =
    list 1 |> should equal ["eggs"]

[<Fact(Skip = "Remove to run test")>]
let ``Allergic to just peanuts`` () =
    list 2 |> should equal ["peanuts"]

[<Fact(Skip = "Remove to run test")>]
let ``Allergic to just strawberries`` () =
    list 8 |> should equal ["strawberries"]

[<Fact(Skip = "Remove to run test")>]
let ``Allergic to eggs and peanuts`` () =
    list 3 |> should equal ["eggs"; "peanuts"]

[<Fact(Skip = "Remove to run test")>]
let ``Allergic to more than eggs but not peanuts`` () =
    list 5 |> should equal ["eggs"; "shellfish"]

[<Fact(Skip = "Remove to run test")>]
let ``Allergic to lots of stuff`` () =
    list 248 |> should equal ["strawberries"; "tomatoes"; "chocolate"; "pollen"; "cats"]

[<Fact(Skip = "Remove to run test")>]
let ``Allergic to everything`` () =
    list 255 |> should equal ["eggs"; "peanuts"; "shellfish"; "strawberries"; "tomatoes"; "chocolate";
 "pollen"; "cats"]

[<Fact(Skip = "Remove to run test")>]
let ``Ignore non allergen score parts`` () =
    list 509 |> should equal ["eggs"; "shellfish"; "strawberries"; "tomatoes"; "chocolate"; "pollen"; "cats"]

