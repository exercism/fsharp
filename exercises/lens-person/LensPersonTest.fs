module LensPersonTest

open System
open NUnit.Framework
open FsUnit
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
    Optic.get bornAtStreet testPerson |> should equal "Longway"

[<Test>]
[<Ignore("Remove to run test")>]
let ``Set current street`` () =
    Optic.set currentStreet "Middleroad" testPerson |> Optic.get currentStreet |> should equal "Middleroad"

[<Test>]
[<Ignore("Remove to run test")>]
let ``Upper case born at street`` () =
    Optic.map bornAtStreet (fun x -> x.ToUpper()) testPerson |> Optic.get bornAtStreet |> should equal "LONGWAY"

[<Test>]
[<Ignore("Remove to run test")>]
let ``Set birth month`` () =
    Optic.set birthMonth 9 testPerson |> Optic.get bornOn |> should equal DateTime(1984, 9, 12)