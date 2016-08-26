module AllergiesTest

open System
open NUnit.Framework
open Allergies

[<Test>]
let ``No allergies means not allergic`` () =
    Assert.That(allergicTo Allergen.Peanuts 0, Is.False)
    Assert.That(allergicTo Allergen.Cats 0, Is.False)
    Assert.That(allergicTo Allergen.Strawberries 0, Is.False)

[<Test>]
[<Ignore("Remove to run test")>]
let ``Allergic to eggs`` () =
    Assert.That(allergicTo Allergen.Eggs 1, Is.True)

[<Test>]
[<Ignore("Remove to run test")>]
let ``Allergic to eggs in addition to other stuff`` () =
    Assert.That(allergicTo Allergen.Eggs 5, Is.True)
    Assert.That(allergicTo Allergen.Shellfish 5, Is.True)
    Assert.That(allergicTo Allergen.Strawberries 5, Is.False)

[<Test>]
[<Ignore("Remove to run test")>]
let ``No allergies at all`` () =
    Assert.That(allergies 0, Is.Empty)

[<Test>]
[<Ignore("Remove to run test")>]
let ``Allergic to just eggs`` () =
    Assert.That(allergies 1, Is.EqualTo([Allergen.Eggs]))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Allergic to just peanuts`` () =
    Assert.That(allergies 2, Is.EqualTo([Allergen.Peanuts]))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Allergic to eggs and peanuts`` () =
    Assert.That(allergies 3, Is.EqualTo([Allergen.Eggs; Allergen.Peanuts]))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Allergic to lots of stuff`` () =
    Assert.That(allergies 248,
        Is.EqualTo([Allergen.Strawberries; Allergen.Tomatoes; Allergen.Chocolate; Allergen.Pollen; Allergen.Cats]))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Allergic to everything`` () =
    Assert.That(allergies 255,
        Is.EqualTo([Allergen.Eggs;
                    Allergen.Peanuts;
                    Allergen.Shellfish;
                    Allergen.Strawberries;
                    Allergen.Tomatoes;
                    Allergen.Chocolate;
                    Allergen.Pollen;
                    Allergen.Cats]))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Ignore non allergen score parts`` () =
    Assert.That(allergies 509,
        Is.EqualTo([Allergen.Eggs;
                    Allergen.Shellfish;
                    Allergen.Strawberries;
                    Allergen.Tomatoes;
                    Allergen.Chocolate;
                    Allergen.Pollen;
                    Allergen.Cats]))