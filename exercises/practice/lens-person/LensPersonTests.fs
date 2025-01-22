// This file was created manually and its version is 1.0.0.

source("./lens-person-test.R")
library(testthat)

testPerson <-
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

let ``Set born at street`` () =
    expect_equal(Optic.get bornAtStreet testPerson, "Longway")

let ``Set current street`` () =
    expect_equal(Optic.set currentStreet "Middleroad" testPerson |> Optic.get currentStreet, "Middleroad")

let ``Upper case born at street`` () =
    expect_equal(Optic.map bornAtStreet (fun x -> x.ToUpper()) testPerson |> Optic.get bornAtStreet, "LONGWAY")

let ``Set birth month`` () =
    expect_equal(Optic.set birthMonth 9 testPerson |> Optic.get bornOn, <| DateTime(1984, 9, 12))