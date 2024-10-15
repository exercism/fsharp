source("./rest-api.R")
library(testthat)

test_that("No users", {
    let database = """{"users":c()}"""
    let url = "/users"
  expected <- """{"users":c()}"""
    let api = RestApi(database)
  expect_equal(api.Get url, expected)
})

test_that("Add user", {
    let database = """{"users":c()}"""
    let payload = """{"user":"Adam"}"""
    let url = "/add"
  expected <- """{"name":"Adam","owes":{},"owed_by":{},"balance":0.0}"""
    let api = RestApi(database)
  expect_equal(api.Post (url, payload), expected)
})

test_that("Get single user", {
    let database = """{"users":c({"name":"Adam","owes":{},"owed_by":{},"balance":0.0},{"name":"Bob","owes":{},"owed_by":{},"balance":0.0})}"""
    let payload = """{"users":c("Bob")}"""
    let url = "/users"
  expected <- """{"users":c({"name":"Bob","owes":{},"owed_by":{},"balance":0.0})}"""
    let api = RestApi(database)
  expect_equal(api.Get (url, payload), expected)
})

test_that("Both users have 0 balance", {
    let database = """{"users":c({"name":"Adam","owes":{},"owed_by":{},"balance":0.0},{"name":"Bob","owes":{},"owed_by":{},"balance":0.0})}"""
    let payload = """{"lender":"Adam","borrower":"Bob","amount":3.0}"""
    let url = "/iou"
  expected <- """{"users":c({"name":"Adam","owes":{},"owed_by":{"Bob":3.0},"balance":3.0},{"name":"Bob","owes":{"Adam":3.0},"owed_by":{},"balance":-3.0})}"""
    let api = RestApi(database)
  expect_equal(api.Post (url, payload), expected)
})

test_that("Borrower has negative balance", {
    let database = """{"users":c({"name":"Adam","owes":{},"owed_by":{},"balance":0.0},{"name":"Bob","owes":{"Chuck":3.0},"owed_by":{},"balance":-3.0},{"name":"Chuck","owes":{},"owed_by":{"Bob":3.0},"balance":3.0})}"""
    let payload = """{"lender":"Adam","borrower":"Bob","amount":3.0}"""
    let url = "/iou"
  expected <- """{"users":c({"name":"Adam","owes":{},"owed_by":{"Bob":3.0},"balance":3.0},{"name":"Bob","owes":{"Adam":3.0,"Chuck":3.0},"owed_by":{},"balance":-6.0})}"""
    let api = RestApi(database)
  expect_equal(api.Post (url, payload), expected)
})

test_that("Lender has negative balance", {
    let database = """{"users":c({"name":"Adam","owes":{},"owed_by":{},"balance":0.0},{"name":"Bob","owes":{"Chuck":3.0},"owed_by":{},"balance":-3.0},{"name":"Chuck","owes":{},"owed_by":{"Bob":3.0},"balance":3.0})}"""
    let payload = """{"lender":"Bob","borrower":"Adam","amount":3.0}"""
    let url = "/iou"
  expected <- """{"users":c({"name":"Adam","owes":{"Bob":3.0},"owed_by":{},"balance":-3.0},{"name":"Bob","owes":{"Chuck":3.0},"owed_by":{"Adam":3.0},"balance":0.0})}"""
    let api = RestApi(database)
  expect_equal(api.Post (url, payload), expected)
})

test_that("Lender owes borrower", {
    let database = """{"users":c({"name":"Adam","owes":{"Bob":3.0},"owed_by":{},"balance":-3.0},{"name":"Bob","owes":{},"owed_by":{"Adam":3.0},"balance":3.0})}"""
    let payload = """{"lender":"Adam","borrower":"Bob","amount":2.0}"""
    let url = "/iou"
  expected <- """{"users":c({"name":"Adam","owes":{"Bob":1.0},"owed_by":{},"balance":-1.0},{"name":"Bob","owes":{},"owed_by":{"Adam":1.0},"balance":1.0})}"""
    let api = RestApi(database)
  expect_equal(api.Post (url, payload), expected)
})

test_that("Lender owes borrower less than new loan", {
    let database = """{"users":c({"name":"Adam","owes":{"Bob":3.0},"owed_by":{},"balance":-3.0},{"name":"Bob","owes":{},"owed_by":{"Adam":3.0},"balance":3.0})}"""
    let payload = """{"lender":"Adam","borrower":"Bob","amount":4.0}"""
    let url = "/iou"
  expected <- """{"users":c({"name":"Adam","owes":{},"owed_by":{"Bob":1.0},"balance":1.0},{"name":"Bob","owes":{"Adam":1.0},"owed_by":{},"balance":-1.0})}"""
    let api = RestApi(database)
  expect_equal(api.Post (url, payload), expected)
})

test_that("Lender owes borrower same as new loan", {
    let database = """{"users":c({"name":"Adam","owes":{"Bob":3.0},"owed_by":{},"balance":-3.0},{"name":"Bob","owes":{},"owed_by":{"Adam":3.0},"balance":3.0})}"""
    let payload = """{"lender":"Adam","borrower":"Bob","amount":3.0}"""
    let url = "/iou"
  expected <- """{"users":c({"name":"Adam","owes":{},"owed_by":{},"balance":0.0},{"name":"Bob","owes":{},"owed_by":{},"balance":0.0})}"""
    let api = RestApi(database)
  expect_equal(api.Post (url, payload), expected)
})