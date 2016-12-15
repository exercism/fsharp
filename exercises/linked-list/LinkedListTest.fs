module LinkedListTest

open NUnit.Framework
open LinkedList

[<Test>]
let ``Push and pop are first in last out order`` () =
    let linkedList = mkLinkedList ()
    linkedList |> push 10
    linkedList |> push 20

    let val1 = pop linkedList
    let val2 = pop linkedList

    Assert.That(val1, Is.EqualTo(20))
    Assert.That(val2, Is.EqualTo(10))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Push and shift are first in first out order`` () =
    let linkedList = mkLinkedList ()
    linkedList |> push 10
    linkedList |> push 20

    let val1 = shift linkedList
    let val2 = shift linkedList

    Assert.That(val1, Is.EqualTo(10))
    Assert.That(val2, Is.EqualTo(20))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Unshift and shift are last in first out order`` () =
    let linkedList = mkLinkedList ()
    linkedList |> unshift 10
    linkedList |> unshift 20

    let val1 = shift linkedList
    let val2 = shift linkedList

    Assert.That(val1, Is.EqualTo(20))
    Assert.That(val2, Is.EqualTo(10))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Unshift and pop are last in last out order`` () =
    let linkedList = mkLinkedList ()
    linkedList |> unshift 10
    linkedList |> unshift 20

    let val1 = pop linkedList
    let val2 = pop linkedList

    Assert.That(val1, Is.EqualTo(10))
    Assert.That(val2, Is.EqualTo(20))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Push and pop can handle multiple values`` () =
    let linkedList = mkLinkedList ()
    linkedList |> push 10
    linkedList |> push 20
    linkedList |> push 30

    let val1 = pop linkedList
    let val2 = pop linkedList
    let val3 = pop linkedList

    Assert.That(val1, Is.EqualTo(30))
    Assert.That(val2, Is.EqualTo(20))
    Assert.That(val3, Is.EqualTo(10))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Unshift and shift can handle multiple values`` () =
    let linkedList = mkLinkedList ()
    linkedList |> unshift 10
    linkedList |> unshift 20
    linkedList |> unshift 30

    let val1 = shift linkedList
    let val2 = shift linkedList
    let val3 = shift linkedList

    Assert.That(val1, Is.EqualTo(30))
    Assert.That(val2, Is.EqualTo(20))
    Assert.That(val3, Is.EqualTo(10))

[<Test>]
[<Ignore("Remove to run test")>]
let ``All methods of manipulating the linkedList can be used together`` () =
    let linkedList = mkLinkedList ()
    linkedList |> push 10
    linkedList |> push 20

    let val1 = pop linkedList

    Assert.That(val1, Is.EqualTo(20))

    linkedList |> push 30
    let val2 = shift linkedList

    Assert.That(val2, Is.EqualTo(10))

    linkedList |> unshift 40
    linkedList |> push 50

    let val3 = shift linkedList
    let val4 = pop linkedList
    let val5 = shift linkedList

    Assert.That(val3, Is.EqualTo(40))
    Assert.That(val4, Is.EqualTo(50))
    Assert.That(val5, Is.EqualTo(30))