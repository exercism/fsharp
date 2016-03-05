module DequeTests

open NUnit.Framework
open Deque

type DequeTests() =

    [<Test>]
    member tests.push_and_pop_are_first_in_last_out_order() =
        let deque = new Deque<int>()
        deque.push(10)
        deque.push(20)
        Assert.That(deque.pop(), Is.EqualTo(20))
        Assert.That(deque.pop(), Is.EqualTo(10))

    [<Test>]
    [<Ignore("Remove to run test")>]
    member tests.push_and_shift_are_first_in_first_out_order() =
        let deque = new Deque<int>()
        deque.push(10)
        deque.push(20)
        Assert.That(deque.shift(), Is.EqualTo(10))
        Assert.That(deque.shift(), Is.EqualTo(20))

    [<Test>]
    [<Ignore("Remove to run test")>]
    member tests.unshift_and_shift_are_last_in_first_out_order() =
        let deque = new Deque<int>()
        deque.unshift(10)
        deque.unshift(20)
        Assert.That(deque.shift(), Is.EqualTo(20))
        Assert.That(deque.shift(), Is.EqualTo(10))

    [<Test>]
    [<Ignore("Remove to run test")>]
    member tests.unshift_and_pop_are_last_in_last_out_order() =
        let deque = new Deque<int>()
        deque.unshift(10)
        deque.unshift(20)
        Assert.That(deque.pop(), Is.EqualTo(10))
        Assert.That(deque.pop(), Is.EqualTo(20))

    [<Test>]
    [<Ignore("Remove to run test")>]
    member tests.push_and_pop_can_handle_multiple_values() =
        let deque = new Deque<int>()
        deque.push(10)
        deque.push(20)
        deque.push(30)
        Assert.That(deque.pop(), Is.EqualTo(30))
        Assert.That(deque.pop(), Is.EqualTo(20))
        Assert.That(deque.pop(), Is.EqualTo(10))

    [<Test>]
    [<Ignore("Remove to run test")>]
    member tests.unshift_and_shift_can_handle_multiple_values() =
        let deque = new Deque<int>()
        deque.unshift(10)
        deque.unshift(20)
        deque.unshift(30)
        Assert.That(deque.shift(), Is.EqualTo(30))
        Assert.That(deque.shift(), Is.EqualTo(20))
        Assert.That(deque.shift(), Is.EqualTo(10))

    [<Test>]
    [<Ignore("Remove to run test")>]
    member tests.All_methods_of_manipulating_the_deque_can_be_used_together() =
        let deque = new Deque<int>()
        deque.push(10)
        deque.push(20)
        Assert.That(deque.pop(), Is.EqualTo(20))

        deque.push(30)
        Assert.That(deque.shift(), Is.EqualTo(10))

        deque.unshift(40)
        deque.push(50)
        Assert.That(deque.shift(), Is.EqualTo(40))
        Assert.That(deque.pop(), Is.EqualTo(50))
        Assert.That(deque.shift(), Is.EqualTo(30))