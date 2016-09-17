module LinkedListTest

open NUnit.Framework
open LinkedList

[<Test>]
let ``Push and pop are first in last out order`` () =
    let linkedList = 
        mkLinkedList
        |> push 10
        |> push 20

    let (val', linkedList') = pop linkedList
    let (val'', _) = pop linkedList'

    Assert.That(val', Is.EqualTo(20))
    Assert.That(val'', Is.EqualTo(10))

[<Test>]  
[<Ignore("Remove to run test")>]  
let ``Push and shift are first in first out order`` () =
    let linkedList = 
        mkLinkedList
        |> push 10
        |> push 20

    let (val', linkedList') = shift linkedList
    let (val'', _) = shift linkedList'

    Assert.That(val', Is.EqualTo(10))
    Assert.That(val'', Is.EqualTo(20))

[<Test>] 
[<Ignore("Remove to run test")>]  
let ``Unshift and shift are last in first out order`` () =
    let linkedList = 
        mkLinkedList
        |> unshift 10
        |> unshift 20

    let (val', linkedList') = shift linkedList
    let (val'', _) = shift linkedList'

    Assert.That(val', Is.EqualTo(20))
    Assert.That(val'', Is.EqualTo(10))

[<Test>]    
[<Ignore("Remove to run test")>]
let ``Unshift and pop are last in last out order`` () =
    let linkedList = 
        mkLinkedList
        |> unshift 10
        |> unshift 20

    let (val', linkedList') = pop linkedList
    let (val'', _) = pop linkedList'

    Assert.That(val', Is.EqualTo(10))
    Assert.That(val'', Is.EqualTo(20))

[<Test>]    
[<Ignore("Remove to run test")>]
let ``Push and pop can handle multiple values`` () =
    let linkedList = 
        mkLinkedList
        |> push 10
        |> push 20
        |> push 30

    let (val', linkedList') = pop linkedList
    let (val'', linkedList'') = pop linkedList'
    let (val''', _) = pop linkedList''

    Assert.That(val', Is.EqualTo(30))
    Assert.That(val'', Is.EqualTo(20))
    Assert.That(val''', Is.EqualTo(10))

[<Test>]    
[<Ignore("Remove to run test")>]
let ``Unshift and shift can handle multiple values`` () =
    let linkedList = 
        mkLinkedList
        |> unshift 10
        |> unshift 20
        |> unshift 30

    let (val', linkedList') = shift linkedList
    let (val'', linkedList'') = shift linkedList'
    let (val''', _) = shift linkedList''

    Assert.That(val', Is.EqualTo(30))
    Assert.That(val'', Is.EqualTo(20))
    Assert.That(val''', Is.EqualTo(10))

[<Test>]    
[<Ignore("Remove to run test")>]
let ``All methods of manipulating the linkedList can be used together`` () =
    let linkedList = 
        mkLinkedList
        |> push 10
        |> push 20

    let (val', linkedList') = pop linkedList

    Assert.That(val', Is.EqualTo(20))

    let linkedList'' = push 30 linkedList'
    let (val''', linkedList''') = shift linkedList''

    Assert.That(val''', Is.EqualTo(10))

    let linkedList'''' = unshift 40 linkedList'''
    let linkedList''''' = push 50 linkedList''''

    let (val'''''', linkedList'''''') = shift linkedList'''''
    let (val''''''', linkedList''''''') = pop linkedList''''''
    let (val'''''''', _) = shift linkedList'''''''
        
    Assert.That(val'''''', Is.EqualTo(40))
    Assert.That(val''''''', Is.EqualTo(50))
    Assert.That(val'''''''', Is.EqualTo(30))