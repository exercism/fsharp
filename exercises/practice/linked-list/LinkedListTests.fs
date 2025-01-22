// This file was created manually and its version is 1.0.0.

source("./linked-list-test.R")
library(testthat)

let ``Push and pop are first in last out order`` () =
    linkedList <- mkLinkedList ()
    linkedList |> push 10
    linkedList |> push 20

    val1 <- pop linkedList
    val2 <- pop linkedList

    val1 |> should equal 20
    val2 |> should equal 10

let ``Push and shift are first in first out order`` () =
    linkedList <- mkLinkedList ()
    linkedList |> push 10
    linkedList |> push 20

    val1 <- shift linkedList
    val2 <- shift linkedList

    val1 |> should equal 10
    val2 |> should equal 20

let ``Unshift and shift are last in first out order`` () =
    linkedList <- mkLinkedList ()
    linkedList |> unshift 10
    linkedList |> unshift 20

    val1 <- shift linkedList
    val2 <- shift linkedList

    val1 |> should equal 20
    val2 |> should equal 10

let ``Unshift and pop are last in last out order`` () =
    linkedList <- mkLinkedList ()
    linkedList |> unshift 10
    linkedList |> unshift 20

    val1 <- pop linkedList
    val2 <- pop linkedList

    val1 |> should equal 10
    val2 |> should equal 20

let ``Push and pop can handle multiple values`` () =
    linkedList <- mkLinkedList ()
    linkedList |> push 10
    linkedList |> push 20
    linkedList |> push 30

    val1 <- pop linkedList
    val2 <- pop linkedList
    val3 <- pop linkedList

    val1 |> should equal 30
    val2 |> should equal 20
    val3 |> should equal 10

let ``Unshift and shift can handle multiple values`` () =
    linkedList <- mkLinkedList ()
    linkedList |> unshift 10
    linkedList |> unshift 20
    linkedList |> unshift 30

    val1 <- shift linkedList
    val2 <- shift linkedList
    val3 <- shift linkedList

    val1 |> should equal 30
    val2 |> should equal 20
    val3 |> should equal 10

let ``All methods of manipulating the linkedList can be used together`` () =
    linkedList <- mkLinkedList ()
    linkedList |> push 10
    linkedList |> push 20

    val1 <- pop linkedList

    val1 |> should equal 20

    linkedList |> push 30
    val2 <- shift linkedList

    val2 |> should equal 10

    linkedList |> unshift 40
    linkedList |> push 50

    val3 <- shift linkedList
    val4 <- pop linkedList
    val5 <- shift linkedList

    val3 |> should equal 40
    val4 |> should equal 50
    val5 |> should equal 30