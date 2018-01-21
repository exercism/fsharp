// This file was created manually and its version is 1.0.0.

module LinkedListTest

open Xunit
open FsUnit.Xunit
open LinkedList

[<Fact>]
let ``Push and pop are first in last out order`` () =
    let linkedList = mkLinkedList ()
    linkedList |> push 10
    linkedList |> push 20

    let val1 = pop linkedList
    let val2 = pop linkedList

    val1 |> should equal 20
    val2 |> should equal 10

[<Fact(Skip = "Remove to run test")>]
let ``Push and shift are first in first out order`` () =
    let linkedList = mkLinkedList ()
    linkedList |> push 10
    linkedList |> push 20

    let val1 = shift linkedList
    let val2 = shift linkedList

    val1 |> should equal 10
    val2 |> should equal 20

[<Fact(Skip = "Remove to run test")>]
let ``Unshift and shift are last in first out order`` () =
    let linkedList = mkLinkedList ()
    linkedList |> unshift 10
    linkedList |> unshift 20

    let val1 = shift linkedList
    let val2 = shift linkedList

    val1 |> should equal 20
    val2 |> should equal 10

[<Fact(Skip = "Remove to run test")>]
let ``Unshift and pop are last in last out order`` () =
    let linkedList = mkLinkedList ()
    linkedList |> unshift 10
    linkedList |> unshift 20

    let val1 = pop linkedList
    let val2 = pop linkedList

    val1 |> should equal 10
    val2 |> should equal 20

[<Fact(Skip = "Remove to run test")>]
let ``Push and pop can handle multiple values`` () =
    let linkedList = mkLinkedList ()
    linkedList |> push 10
    linkedList |> push 20
    linkedList |> push 30

    let val1 = pop linkedList
    let val2 = pop linkedList
    let val3 = pop linkedList

    val1 |> should equal 30
    val2 |> should equal 20
    val3 |> should equal 10

[<Fact(Skip = "Remove to run test")>]
let ``Unshift and shift can handle multiple values`` () =
    let linkedList = mkLinkedList ()
    linkedList |> unshift 10
    linkedList |> unshift 20
    linkedList |> unshift 30

    let val1 = shift linkedList
    let val2 = shift linkedList
    let val3 = shift linkedList

    val1 |> should equal 30
    val2 |> should equal 20
    val3 |> should equal 10

[<Fact(Skip = "Remove to run test")>]
let ``All methods of manipulating the linkedList can be used together`` () =
    let linkedList = mkLinkedList ()
    linkedList |> push 10
    linkedList |> push 20

    let val1 = pop linkedList

    val1 |> should equal 20

    linkedList |> push 30
    let val2 = shift linkedList

    val2 |> should equal 10

    linkedList |> unshift 40
    linkedList |> push 50

    let val3 = shift linkedList
    let val4 = pop linkedList
    let val5 = shift linkedList

    val3 |> should equal 40
    val4 |> should equal 50
    val5 |> should equal 30