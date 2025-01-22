// This file was created manually and its version is 1.0.0.

source("./linked-list-test.R")
library(testthat)

let ``Push and pop are first in last out order`` () =
    linkedList <- mkLinkedList ()
    linkedList |> push 10
    linkedList |> push 20

    val1 <- pop linkedList
    val2 <- pop linkedList

    expect_equal(val1, 20)
    expect_equal(val2, 10)

let ``Push and shift are first in first out order`` () =
    linkedList <- mkLinkedList ()
    linkedList |> push 10
    linkedList |> push 20

    val1 <- shift linkedList
    val2 <- shift linkedList

    expect_equal(val1, 10)
    expect_equal(val2, 20)

let ``Unshift and shift are last in first out order`` () =
    linkedList <- mkLinkedList ()
    linkedList |> unshift 10
    linkedList |> unshift 20

    val1 <- shift linkedList
    val2 <- shift linkedList

    expect_equal(val1, 20)
    expect_equal(val2, 10)

let ``Unshift and pop are last in last out order`` () =
    linkedList <- mkLinkedList ()
    linkedList |> unshift 10
    linkedList |> unshift 20

    val1 <- pop linkedList
    val2 <- pop linkedList

    expect_equal(val1, 10)
    expect_equal(val2, 20)

let ``Push and pop can handle multiple values`` () =
    linkedList <- mkLinkedList ()
    linkedList |> push 10
    linkedList |> push 20
    linkedList |> push 30

    val1 <- pop linkedList
    val2 <- pop linkedList
    val3 <- pop linkedList

    expect_equal(val1, 30)
    expect_equal(val2, 20)
    expect_equal(val3, 10)

let ``Unshift and shift can handle multiple values`` () =
    linkedList <- mkLinkedList ()
    linkedList |> unshift 10
    linkedList |> unshift 20
    linkedList |> unshift 30

    val1 <- shift linkedList
    val2 <- shift linkedList
    val3 <- shift linkedList

    expect_equal(val1, 30)
    expect_equal(val2, 20)
    expect_equal(val3, 10)

let ``All methods of manipulating the linkedList can be used together`` () =
    linkedList <- mkLinkedList ()
    linkedList |> push 10
    linkedList |> push 20

    val1 <- pop linkedList

    expect_equal(val1, 20)

    linkedList |> push 30
    val2 <- shift linkedList

    expect_equal(val2, 10)

    linkedList |> unshift 40
    linkedList |> push 50

    val3 <- shift linkedList
    val4 <- pop linkedList
    val5 <- shift linkedList

    expect_equal(val3, 40)
    expect_equal(val4, 50)
    expect_equal(val5, 30)