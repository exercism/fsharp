module DequeTests

open NUnit.Framework
open Deque

[<Test>]
let ``Push and pop are first in last out order`` () =
    let deque = new Deque<int>()
    deque.push(10)
    deque.push(20)
    Assert.That(deque.pop(), Is.EqualTo(20))
    Assert.That(deque.pop(), Is.EqualTo(10))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Push and shift are first in first out order`` () =
    let deque = new Deque<int>()
    deque.push(10)
    deque.push(20)
    Assert.That(deque.shift(), Is.EqualTo(10))
    Assert.That(deque.shift(), Is.EqualTo(20))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Unshift and shift are last in first out order`` () =
    let deque = new Deque<int>()
    deque.unshift(10)
    deque.unshift(20)
    Assert.That(deque.shift(), Is.EqualTo(20))
    Assert.That(deque.shift(), Is.EqualTo(10))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Unshift and pop are last in last out order`` () =
    let deque = new Deque<int>()
    deque.unshift(10)
    deque.unshift(20)
    Assert.That(deque.pop(), Is.EqualTo(10))
    Assert.That(deque.pop(), Is.EqualTo(20))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Push and pop can handle multiple values`` () =
    let deque = new Deque<int>()
    deque.push(10)
    deque.push(20)
    deque.push(30)
    Assert.That(deque.pop(), Is.EqualTo(30))
    Assert.That(deque.pop(), Is.EqualTo(20))
    Assert.That(deque.pop(), Is.EqualTo(10))

[<Test>]
[<Ignore("Remove to run test")>]    
let ``Unshift and shift can handle multiple values`` () =
    let deque = new Deque<int>()
    deque.unshift(10)
    deque.unshift(20)
    deque.unshift(30)
    Assert.That(deque.shift(), Is.EqualTo(30))
    Assert.That(deque.shift(), Is.EqualTo(20))
    Assert.That(deque.shift(), Is.EqualTo(10))

[<Test>]
[<Ignore("Remove to run test")>]
let ``All methods of manipulating the deque can be used together`` () =
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