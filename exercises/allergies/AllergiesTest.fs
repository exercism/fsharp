module AllergiesTest

open System
open Xunit
open FsUnit
open Allergies

[<Fact>]
let ``No allergies means not allergic`` () =
    allergicTo Allergen.Peanuts 0 |> should equal false
    allergicTo Allergen.Cats 0 |> should equal false
    allergicTo Allergen.Strawberries 0 |> should equal false

[<Fact(Skip = "Remove to run test")>]
let ``Allergic to eggs`` () =
    allergicTo Allergen.Eggs 1 |> should equal true

[<Fact(Skip = "Remove to run test")>]
let ``Allergic to eggs in addition to other stuff`` () =
    allergicTo Allergen.Eggs 5 |> should equal true
    allergicTo Allergen.Shellfish 5 |> should equal true
    allergicTo Allergen.Strawberries 5 |> should equal false

[<Fact(Skip = "Remove to run test")>]
let ``No allergies at all`` () =
    allergies 0 |> should be Empty

[<Fact(Skip = "Remove to run test")>]
let ``Allergic to just eggs`` () =
    allergies 1 |> should equal [Allergen.Eggs]

[<Fact(Skip = "Remove to run test")>]
let ``Allergic to just peanuts`` () =
    allergies 2 |> should equal [Allergen.Peanuts]

[<Fact(Skip = "Remove to run test")>]
let ``Allergic to eggs and peanuts`` () =
    allergies 3 |> should equal [Allergen.Eggs; Allergen.Peanuts]

[<Fact(Skip = "Remove to run test")>]
let ``Allergic to lots of stuff`` () =
    allergies 248 |> should equal 
        [ Allergen.Strawberries; 
          Allergen.Tomatoes;
          Allergen.Chocolate;
          Allergen.Pollen;
          Allergen.Cats ]

[<Fact(Skip = "Remove to run test")>]
let ``Allergic to everything`` () =
    allergies 255 |> should equal 
        [ Allergen.Eggs;
          Allergen.Peanuts;
          Allergen.Shellfish;
          Allergen.Strawberries;
          Allergen.Tomatoes;
          Allergen.Chocolate;
          Allergen.Pollen;
          Allergen.Cats ]

[<Fact(Skip = "Remove to run test")>]
let ``Ignore non allergen score parts`` () =
    allergies 509  |> should equal 
        [ Allergen.Eggs;
          Allergen.Shellfish;
          Allergen.Strawberries;
          Allergen.Tomatoes;
          Allergen.Chocolate;
          Allergen.Pollen;
          Allergen.Cats ]