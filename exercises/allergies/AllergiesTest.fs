module AllergiesTest

open System
open NUnit.Framework
open FsUnit
open Allergies

[<Test>]
let ``No allergies means not allergic`` () =
    allergicTo Allergen.Peanuts 0 |> should be False
    allergicTo Allergen.Cats 0 |> should be False
    allergicTo Allergen.Strawberries 0 |> should be False

[<Test>]
[<Ignore("Remove to run test")>]
let ``Allergic to eggs`` () =
    allergicTo Allergen.Eggs 1 |> should be True

[<Test>]
[<Ignore("Remove to run test")>]
let ``Allergic to eggs in addition to other stuff`` () =
    allergicTo Allergen.Eggs 5 |> should be True
    allergicTo Allergen.Shellfish 5 |> should be True
    allergicTo Allergen.Strawberries 5 |> should be False

[<Test>]
[<Ignore("Remove to run test")>]
let ``No allergies at all`` () =
    allergies 0 |> should be Empty

[<Test>]
[<Ignore("Remove to run test")>]
let ``Allergic to just eggs`` () =
    allergies 1 |> should equal [Allergen.Eggs]

[<Test>]
[<Ignore("Remove to run test")>]
let ``Allergic to just peanuts`` () =
    allergies 2 |> should equal [Allergen.Peanuts]

[<Test>]
[<Ignore("Remove to run test")>]
let ``Allergic to eggs and peanuts`` () =
    allergies 3 |> should equal [Allergen.Eggs; Allergen.Peanuts]

[<Test>]
[<Ignore("Remove to run test")>]
let ``Allergic to lots of stuff`` () =
    allergies 248 |> should equal 
        [ Allergen.Strawberries; 
          Allergen.Tomatoes;
          Allergen.Chocolate;
          Allergen.Pollen;
          Allergen.Cats ]

[<Test>]
[<Ignore("Remove to run test")>]
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

[<Test>]
[<Ignore("Remove to run test")>]
let ``Ignore non allergen score parts`` () =
    allergies 509  |> should equal 
        [ Allergen.Eggs;
          Allergen.Shellfish;
          Allergen.Strawberries;
          Allergen.Tomatoes;
          Allergen.Chocolate;
          Allergen.Pollen;
          Allergen.Cats ]