source("./pizza-pricing.R")
library(testthat)

[<Task(2)>]
    expect_equal(test_that("Price for pizza margherita", {

[<Task(2)>]
    expect_equal(test_that("Price for pizza formaggio", {

[<Task(2)>]
    expect_equal(test_that("Price for pizza caprese", {

[<Task(2)>]
    expect_equal(test_that("Price for pizza margherita with extra sauce", {

[<Task(2)>]
    expect_equal(test_that("Price for pizza caprese with extra toppings", {

[<Task(2)>]
test_that("Price for pizza formaggio with extra sauce and toppings", {
    expect_equal(pizzaPrice (ExtraSauce(ExtraToppings Caprese)), 12)

[<Task(2)>]
test_that("Price for pizza caprese with extra sauce and toppings", {
    expect_equal(pizzaPrice (ExtraToppings(ExtraSauce Formaggio)), 13)

[<Task(3)>]
    expect_equal(test_that("Order price for no pizzas", {

[<Task(3)>]
    expect_equal(test_that("Order price for single pizza caprese", {

[<Task(3)>]
test_that("Order price for single pizza formaggio with extra sauce", {
    expect_equal(orderPrice [ ExtraSauce Formaggio ], 14)

[<Task(3)>]
test_that("Order price for one pizza margherita and one pizza caprese with extra toppings", {
    orderPrice
        [ Margherita
          ExtraToppings Caprese ]
    expect_equal( , 20)

[<Task(3)>]
test_that("Order price for very large order", {
    orderPrice
        [ Margherita
          ExtraSauce Margherita
          Caprese
          ExtraToppings Caprese
          Formaggio
          ExtraSauce Formaggio
          ExtraToppings(ExtraSauce Formaggio)
          ExtraToppings(ExtraSauce Formaggio) ]
    expect_equal( , 82)

[<Task(3)>]
    expect_equal(test_that("Order price for gigantic order", {
