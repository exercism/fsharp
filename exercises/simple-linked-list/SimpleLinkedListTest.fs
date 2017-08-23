module SimpleLinkedListTest

open NUnit.Framework
open FsUnit

open SimpleLinkedList

[<Test>]
let ``Empty list`` () =
    let list = nil
    isNil list |> should equal true

[<Test>]
[<Ignore("Remove to run test")>]
let ``Single item list value`` () =
    let list = create 1 nil
    datum list |> should equal 1
        
[<Test>]
[<Ignore("Remove to run test")>]
let ``Single item list has no next item`` () =
    let list = create 1 nil
    next list |> isNil |> should equal true
        
[<Test>]
[<Ignore("Remove to run test")>]
let ``Two item list first value`` () =
    let list = create 2 (create 1 nil)
    datum list |> should equal 2
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Two item list second value`` () =
    let list = create 2 (create 1 nil)
    next list |> datum |> should equal 1
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Two item list second item has no next`` () =
    let list = create 2 (create 1 nil)
    next list |> next |> isNil |> should equal true
        
[<Test>]
[<Ignore("Remove to run test")>]
let ``To list`` () =
    let values = create 2 (create 1 nil) |> toList
    values |> should equal [2; 1]
        
[<Test>]
[<Ignore("Remove to run test")>]
let ``From list`` () =
    let list = fromList [11; 7; 5; 3; 2]
    list |> datum |> should equal 11
    list |> next |> datum |> should equal 7
    list |> next |> next |> datum |> should equal 5
    list |> next |> next |> next |> datum |> should equal 3
    list |> next |> next |> next |> next |> datum |> should equal 2
    
[<TestCase(1, Ignore = "Remove to run test case")>]
[<TestCase(2, Ignore = "Remove to run test case")>]
[<TestCase(10, Ignore = "Remove to run test case")>]
[<TestCase(100, Ignore = "Remove to run test case")>]
let ``Reverse`` (length: int) =
    let values = [1..length]
    let list = fromList values
    let reversed = reverse list
    reversed |> toList |> should equal <| List.rev values 
    
[<TestCase(1, Ignore = "Remove to run test case")>]
[<TestCase(2, Ignore = "Remove to run test case")>]
[<TestCase(10, Ignore = "Remove to run test case")>]
[<TestCase(100, Ignore = "Remove to run test case")>]
let ``Roundtrip`` (length: int) =
    let values = [1..length]
    let listValues = fromList values
    listValues |> toList |> should equal values