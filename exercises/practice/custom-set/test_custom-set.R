source("./custom-set.R")
library(testthat)

test_that("Sets with no elements are empty", {
    let actual = CustomSet.isEmpty (CustomSet.fromList [])
  expect_equal(actual, true)
})

test_that("Sets with elements are not empty", {
    let actual = CustomSet.isEmpty (CustomSet.fromList [1])
  expect_equal(actual, false)
})

test_that("Nothing is contained in an empty set", {
    let setValue = CustomSet.fromList []
    let element = 1
    let actual = CustomSet.contains element setValue
  expect_equal(actual, false)
})

test_that("When the element is in the set", {
    let setValue = CustomSet.fromList [1; 2; 3]
    let element = 1
    let actual = CustomSet.contains element setValue
  expect_equal(actual, true)
})

test_that("When the element is not in the set", {
    let setValue = CustomSet.fromList [1; 2; 3]
    let element = 4
    let actual = CustomSet.contains element setValue
  expect_equal(actual, false)
})

test_that("Empty set is a subset of another empty set", {
    let set1 = CustomSet.fromList []
    let set2 = CustomSet.fromList []
    let actual = CustomSet.isSubsetOf set1 set2
  expect_equal(actual, true)
})

test_that("Empty set is a subset of non-empty set", {
    let set1 = CustomSet.fromList []
    let set2 = CustomSet.fromList [1]
    let actual = CustomSet.isSubsetOf set1 set2
  expect_equal(actual, true)
})

test_that("Non-empty set is not a subset of empty set", {
    let set1 = CustomSet.fromList [1]
    let set2 = CustomSet.fromList []
    let actual = CustomSet.isSubsetOf set1 set2
  expect_equal(actual, false)
})

test_that("Set is a subset of set with exact same elements", {
    let set1 = CustomSet.fromList [1; 2; 3]
    let set2 = CustomSet.fromList [1; 2; 3]
    let actual = CustomSet.isSubsetOf set1 set2
  expect_equal(actual, true)
})

test_that("Set is a subset of larger set with same elements", {
    let set1 = CustomSet.fromList [1; 2; 3]
    let set2 = CustomSet.fromList [4; 1; 2; 3]
    let actual = CustomSet.isSubsetOf set1 set2
  expect_equal(actual, true)
})

test_that("Set is not a subset of set that does not contain its elements", {
    let set1 = CustomSet.fromList [1; 2; 3]
    let set2 = CustomSet.fromList [4; 1; 3]
    let actual = CustomSet.isSubsetOf set1 set2
  expect_equal(actual, false)
})

test_that("The empty set is disjoint with itself", {
    let set1 = CustomSet.fromList []
    let set2 = CustomSet.fromList []
    let actual = CustomSet.isDisjointFrom set1 set2
  expect_equal(actual, true)
})

test_that("Empty set is disjoint with non-empty set", {
    let set1 = CustomSet.fromList []
    let set2 = CustomSet.fromList [1]
    let actual = CustomSet.isDisjointFrom set1 set2
  expect_equal(actual, true)
})

test_that("Non-empty set is disjoint with empty set", {
    let set1 = CustomSet.fromList [1]
    let set2 = CustomSet.fromList []
    let actual = CustomSet.isDisjointFrom set1 set2
  expect_equal(actual, true)
})

test_that("Sets are not disjoint if they share an element", {
    let set1 = CustomSet.fromList [1; 2]
    let set2 = CustomSet.fromList [2; 3]
    let actual = CustomSet.isDisjointFrom set1 set2
  expect_equal(actual, false)
})

test_that("Sets are disjoint if they share no elements", {
    let set1 = CustomSet.fromList [1; 2]
    let set2 = CustomSet.fromList [3; 4]
    let actual = CustomSet.isDisjointFrom set1 set2
  expect_equal(actual, true)
})

test_that("Empty sets are equal", {
    let set1 = CustomSet.fromList []
    let set2 = CustomSet.fromList []
    let actual = CustomSet.isEqualTo set1 set2
  expect_equal(actual, true)
})

test_that("Empty set is not equal to non-empty set", {
    let set1 = CustomSet.fromList []
    let set2 = CustomSet.fromList [1; 2; 3]
    let actual = CustomSet.isEqualTo set1 set2
  expect_equal(actual, false)
})

test_that("Non-empty set is not equal to empty set", {
    let set1 = CustomSet.fromList [1; 2; 3]
    let set2 = CustomSet.fromList []
    let actual = CustomSet.isEqualTo set1 set2
  expect_equal(actual, false)
})

test_that("Sets with the same elements are equal", {
    let set1 = CustomSet.fromList [1; 2]
    let set2 = CustomSet.fromList [2; 1]
    let actual = CustomSet.isEqualTo set1 set2
  expect_equal(actual, true)
})

test_that("Sets with different elements are not equal", {
    let set1 = CustomSet.fromList [1; 2; 3]
    let set2 = CustomSet.fromList [1; 2; 4]
    let actual = CustomSet.isEqualTo set1 set2
  expect_equal(actual, false)
})

test_that("Set is not equal to larger set with same elements", {
    let set1 = CustomSet.fromList [1; 2; 3]
    let set2 = CustomSet.fromList [1; 2; 3; 4]
    let actual = CustomSet.isEqualTo set1 set2
  expect_equal(actual, false)
})

test_that("Add to empty set", {
    let setValue = CustomSet.fromList []
    let element = 3
    let actual = CustomSet.insert element setValue
    let expectedSet = CustomSet.fromList [3]
    let actualBool = CustomSet.isEqualTo actual expectedSet
  expect_equal(actualBool, true)
})

test_that("Add to non-empty set", {
    let setValue = CustomSet.fromList [1; 2; 4]
    let element = 3
    let actual = CustomSet.insert element setValue
    let expectedSet = CustomSet.fromList [1; 2; 3; 4]
    let actualBool = CustomSet.isEqualTo actual expectedSet
  expect_equal(actualBool, true)
})

test_that("Adding an existing element does not change the set", {
    let setValue = CustomSet.fromList [1; 2; 3]
    let element = 3
    let actual = CustomSet.insert element setValue
    let expectedSet = CustomSet.fromList [1; 2; 3]
    let actualBool = CustomSet.isEqualTo actual expectedSet
  expect_equal(actualBool, true)
})

test_that("Intersection of two empty sets is an empty set", {
    let set1 = CustomSet.fromList []
    let set2 = CustomSet.fromList []
    let actual = CustomSet.intersection set1 set2
    let expectedSet = CustomSet.fromList []
    let actualBool = CustomSet.isEqualTo actual expectedSet
  expect_equal(actualBool, true)
})

test_that("Intersection of an empty set and non-empty set is an empty set", {
    let set1 = CustomSet.fromList []
    let set2 = CustomSet.fromList [3; 2; 5]
    let actual = CustomSet.intersection set1 set2
    let expectedSet = CustomSet.fromList []
    let actualBool = CustomSet.isEqualTo actual expectedSet
  expect_equal(actualBool, true)
})

test_that("Intersection of a non-empty set and an empty set is an empty set", {
    let set1 = CustomSet.fromList [1; 2; 3; 4]
    let set2 = CustomSet.fromList []
    let actual = CustomSet.intersection set1 set2
    let expectedSet = CustomSet.fromList []
    let actualBool = CustomSet.isEqualTo actual expectedSet
  expect_equal(actualBool, true)
})

test_that("Intersection of two sets with no shared elements is an empty set", {
    let set1 = CustomSet.fromList [1; 2; 3]
    let set2 = CustomSet.fromList [4; 5; 6]
    let actual = CustomSet.intersection set1 set2
    let expectedSet = CustomSet.fromList []
    let actualBool = CustomSet.isEqualTo actual expectedSet
  expect_equal(actualBool, true)
})

test_that("Intersection of two sets with shared elements is a set of the shared elements", {
    let set1 = CustomSet.fromList [1; 2; 3; 4]
    let set2 = CustomSet.fromList [3; 2; 5]
    let actual = CustomSet.intersection set1 set2
    let expectedSet = CustomSet.fromList [2; 3]
    let actualBool = CustomSet.isEqualTo actual expectedSet
  expect_equal(actualBool, true)
})

test_that("Difference of two empty sets is an empty set", {
    let set1 = CustomSet.fromList []
    let set2 = CustomSet.fromList []
    let actual = CustomSet.difference set1 set2
    let expectedSet = CustomSet.fromList []
    let actualBool = CustomSet.isEqualTo actual expectedSet
  expect_equal(actualBool, true)
})

test_that("Difference of empty set and non-empty set is an empty set", {
    let set1 = CustomSet.fromList []
    let set2 = CustomSet.fromList [3; 2; 5]
    let actual = CustomSet.difference set1 set2
    let expectedSet = CustomSet.fromList []
    let actualBool = CustomSet.isEqualTo actual expectedSet
  expect_equal(actualBool, true)
})

test_that("Difference of a non-empty set and an empty set is the non-empty set", {
    let set1 = CustomSet.fromList [1; 2; 3; 4]
    let set2 = CustomSet.fromList []
    let actual = CustomSet.difference set1 set2
    let expectedSet = CustomSet.fromList [1; 2; 3; 4]
    let actualBool = CustomSet.isEqualTo actual expectedSet
  expect_equal(actualBool, true)
})

test_that("Difference of two non-empty sets is a set of elements that are only in the first set", {
    let set1 = CustomSet.fromList [3; 2; 1]
    let set2 = CustomSet.fromList [2; 4]
    let actual = CustomSet.difference set1 set2
    let expectedSet = CustomSet.fromList [1; 3]
    let actualBool = CustomSet.isEqualTo actual expectedSet
  expect_equal(actualBool, true)
})

test_that("Union of empty sets is an empty set", {
    let set1 = CustomSet.fromList []
    let set2 = CustomSet.fromList []
    let actual = CustomSet.union set1 set2
    let expectedSet = CustomSet.fromList []
    let actualBool = CustomSet.isEqualTo actual expectedSet
  expect_equal(actualBool, true)
})

test_that("Union of an empty set and non-empty set is the non-empty set", {
    let set1 = CustomSet.fromList []
    let set2 = CustomSet.fromList [2]
    let actual = CustomSet.union set1 set2
    let expectedSet = CustomSet.fromList [2]
    let actualBool = CustomSet.isEqualTo actual expectedSet
  expect_equal(actualBool, true)
})

test_that("Union of a non-empty set and empty set is the non-empty set", {
    let set1 = CustomSet.fromList [1; 3]
    let set2 = CustomSet.fromList []
    let actual = CustomSet.union set1 set2
    let expectedSet = CustomSet.fromList [1; 3]
    let actualBool = CustomSet.isEqualTo actual expectedSet
  expect_equal(actualBool, true)
})

test_that("Union of non-empty sets contains all unique elements", {
    let set1 = CustomSet.fromList [1; 3]
    let set2 = CustomSet.fromList [2; 3]
    let actual = CustomSet.union set1 set2
    let expectedSet = CustomSet.fromList [3; 2; 1]
    let actualBool = CustomSet.isEqualTo actual expectedSet
  expect_equal(actualBool, true)

