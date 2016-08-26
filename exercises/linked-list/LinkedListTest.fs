module DequeTest

open NUnit.Framework
open Deque

[<Test>]
let ``Push and pop are first in last out order`` () =
    let deque = 
        mkDeque
        |> push 10
        |> push 20

    let (val', deque') = pop deque
    let (val'', _) = pop deque'

    Assert.That(val', Is.EqualTo(20))
    Assert.That(val'', Is.EqualTo(10))

[<Test>]  
[<Ignore("Remove to run test")>]  
let ``Push and shift are first in first out order`` () =
    let deque = 
        mkDeque
        |> push 10
        |> push 20

    let (val', deque') = shift deque
    let (val'', _) = shift deque'

    Assert.That(val', Is.EqualTo(10))
    Assert.That(val'', Is.EqualTo(20))

[<Test>] 
[<Ignore("Remove to run test")>]  
let ``Unshift and shift are last in first out order`` () =
    let deque = 
        mkDeque
        |> unshift 10
        |> unshift 20

    let (val', deque') = shift deque
    let (val'', _) = shift deque'

    Assert.That(val', Is.EqualTo(20))
    Assert.That(val'', Is.EqualTo(10))

[<Test>]    
[<Ignore("Remove to run test")>]
let ``Unshift and pop are last in last out order`` () =
    let deque = 
        mkDeque
        |> unshift 10
        |> unshift 20

    let (val', deque') = pop deque
    let (val'', _) = pop deque'

    Assert.That(val', Is.EqualTo(10))
    Assert.That(val'', Is.EqualTo(20))

[<Test>]    
[<Ignore("Remove to run test")>]
let ``Push and pop can handle multiple values`` () =
    let deque = 
        mkDeque
        |> push 10
        |> push 20
        |> push 30

    let (val', deque') = pop deque
    let (val'', deque'') = pop deque'
    let (val''', _) = pop deque''

    Assert.That(val', Is.EqualTo(30))
    Assert.That(val'', Is.EqualTo(20))
    Assert.That(val''', Is.EqualTo(10))

[<Test>]    
[<Ignore("Remove to run test")>]
let ``Unshift and shift can handle multiple values`` () =
    let deque = 
        mkDeque
        |> unshift 10
        |> unshift 20
        |> unshift 30

    let (val', deque') = shift deque
    let (val'', deque'') = shift deque'
    let (val''', _) = shift deque''

    Assert.That(val', Is.EqualTo(30))
    Assert.That(val'', Is.EqualTo(20))
    Assert.That(val''', Is.EqualTo(10))

[<Test>]    
[<Ignore("Remove to run test")>]
let ``All methods of manipulating the deque can be used together`` () =
    let deque = 
        mkDeque
        |> push 10
        |> push 20

    let (val', deque') = pop deque

    Assert.That(val', Is.EqualTo(20))

    let deque'' = push 30 deque'
    let (val''', deque''') = shift deque''

    Assert.That(val''', Is.EqualTo(10))

    let deque'''' = unshift 40 deque'''
    let deque''''' = push 50 deque''''

    let (val'''''', deque'''''') = shift deque'''''
    let (val''''''', deque''''''') = pop deque''''''
    let (val'''''''', _) = shift deque'''''''
        
    Assert.That(val'''''', Is.EqualTo(40))
    Assert.That(val''''''', Is.EqualTo(50))
    Assert.That(val'''''''', Is.EqualTo(30))