module LensPersonTest

open System
open NUnit.Framework
open Aether
open Aether.Operators
open LensPerson

let testPerson =
    { name = 
        { name = "Jane Joanna"
          surName = "Doe" }
      born = 
        { at = 
            { street = "Longway"
              houseNumber = 1024
              place = "Springfield"
              country = "United States" }
          on = DateTime(1984, 4, 12) }
      address = 
        { street = "Shortlane"
          houseNumber = 2
          place = "Fallmeadow"
          country = "Canada" } }

[<Test>]
let ``Set born at street`` () =
    Assert.That(Optic.get bornAtStreet testPerson, Is.EqualTo("Longway"))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Set current street`` () =
    Assert.That(Optic.set currentStreet "Middleroad" testPerson |> Optic.get currentStreet, Is.EqualTo("Middleroad"))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Upper case born at street`` () =
    Assert.That(Optic.map bornAtStreet (fun x -> x.ToUpper()) testPerson |> Optic.get bornAtStreet, Is.EqualTo("LONGWAY"))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Set birth month`` () =
    Assert.That(Optic.set birthMonth 9 testPerson |> Optic.get bornOn, Is.EqualTo(DateTime(1984, 9, 12)))