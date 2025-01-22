source("./grade-school.R")
library(testthat)

test_that("Roster is empty when no student is added", {
    school <- empty
    roster school |> should be Empty

test_that("Student is added to the roster", {
    school <- 
        empty
        |> add "Aimee" 2
    expect_equal(roster(school), c("Aimee"))
})

test_that("Multiple students in the same grade are added to the roster", {
    school <- 
        empty
        |> add "Blair" 2
        |> add "James" 2
        |> add "Paul" 2
    expect_equal(roster(school), c("Blair", "James", "Paul"))
})

test_that("Student not added to same grade in the roster more than once", {
    school <- 
        empty
        |> add "Blair" 2
        |> add "James" 2
        |> add "James" 2
        |> add "Paul" 2
    expect_equal(roster(school), c("Blair", "James", "Paul"))
})

test_that("Students in multiple grades are added to the roster", {
    school <- 
        empty
        |> add "Chelsea" 3
        |> add "Logan" 7
    expect_equal(roster(school), c("Chelsea", "Logan"))
})

test_that("Student not added to multiple grades in the roster", {
    school <- 
        empty
        |> add "Blair" 2
        |> add "James" 2
        |> add "James" 3
        |> add "Paul" 3
    expect_equal(roster(school), c("Blair", "James", "Paul"))
})

test_that("Students are sorted by grades in the roster", {
    school <- 
        empty
        |> add "Jim" 3
        |> add "Peter" 2
        |> add "Anna" 1
    expect_equal(roster(school), c("Anna", "Peter", "Jim"))
})

test_that("Students are sorted by name in the roster", {
    school <- 
        empty
        |> add "Peter" 2
        |> add "Zoe" 2
        |> add "Alex" 2
    expect_equal(roster(school), c("Alex", "Peter", "Zoe"))
})

test_that("Students are sorted by grades and then by name in the roster", {
    school <- 
        empty
        |> add "Peter" 2
        |> add "Anna" 1
        |> add "Barb" 1
        |> add "Zoe" 2
        |> add "Alex" 2
        |> add "Jim" 3
        |> add "Charlie" 1
    expect_equal(roster(school), c("Anna", "Barb", "Charlie", "Alex", "Peter", "Zoe", "Jim"))
})

test_that("Grade is empty if no students in the roster", {
    school <- empty
    grade 1 school |> should be Empty

test_that("Grade is empty if no students in that grade", {
    school <- 
        empty
        |> add "Peter" 2
        |> add "Zoe" 2
        |> add "Alex" 2
        |> add "Jim" 3
    grade 1 school |> should be Empty

test_that("Student not added to same grade more than once", {
    school <- 
        empty
        |> add "Blair" 2
        |> add "James" 2
        |> add "James" 2
        |> add "Paul" 2
    expect_equal(grade 2 school, c("Blair", "James", "Paul"))
})

test_that("Student not added to multiple grades", {
    school <- 
        empty
        |> add "Blair" 2
        |> add "James" 2
        |> add "James" 3
        |> add "Paul" 3
    expect_equal(grade 2 school, c("Blair", "James"))
})

test_that("Student not added to other grade for multiple grades", {
    school <- 
        empty
        |> add "Blair" 2
        |> add "James" 2
        |> add "James" 3
        |> add "Paul" 3
    expect_equal(grade 3 school, c("Paul"))
})

test_that("Students are sorted by name in a grade", {
    school <- 
        empty
        |> add "Franklin" 5
        |> add "Bradley" 5
        |> add "Jeff" 1
    expect_equal(grade 5 school, c("Bradley", "Franklin"))
})
