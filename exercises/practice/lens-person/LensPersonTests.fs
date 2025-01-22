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

test_that("Set born at street", {
  expect_equal(Optic.get bornAtStreet testPerson, "Longway")
})

test_that("Set current street", {
  expect_equal(Optic.set currentStreet "Middleroad" testPerson |> Optic.get currentStreet, "Middleroad")
})

test_that("Upper case born at street", {
  expect_equal(Optic.map bornAtStreet (fun x -> x.ToUpper()) testPerson |> Optic.get bornAtStreet, "LONGWAY")
})

test_that("Set birth month", {
  expect_equal(Optic.set birthMonth 9 testPerson |> Optic.get bornOn, <| DateTime(1984, 9, 12))