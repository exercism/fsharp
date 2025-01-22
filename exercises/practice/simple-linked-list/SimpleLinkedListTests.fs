// This file was created manually and its version is 1.0.0.

source("./simple-linked-list-test.R")
library(testthat)

open Xunit
open FsUnit.Xunit

open SimpleLinkedList

let ``Empty list`` () =
    let list = nil
    isNil list |> should equal true

let ``Single item list value`` () =
    let list = create 1 nil
    datum list |> should equal 1
        
let ``Single item list has no next item`` () =
    let list = create 1 nil
    next list |> isNil |> should equal true
        
let ``Two item list first value`` () =
    let list = create 2 (create 1 nil)
    datum list |> should equal 2
    
let ``Two item list second value`` () =
    let list = create 2 (create 1 nil)
    next list |> datum |> should equal 1
    
let ``Two item list second item has no next`` () =
    let list = create 2 (create 1 nil)
    next list |> next |> isNil |> should equal true
        
let ``To list`` () =
    let values = create 2 (create 1 nil) |> toList
    values |> should equal [2; 1]
        
let ``From list`` () =
    let list = fromList [11; 7; 5; 3; 2]
    list |> datum |> should equal 11
    list |> next |> datum |> should equal 7
    list |> next |> next |> datum |> should equal 5
    list |> next |> next |> next |> datum |> should equal 3
    list |> next |> next |> next |> next |> datum |> should equal 2

let ``Reverse length 1`` () =
    let values = [1..1]
    let list = fromList values
    let reversed = reverse list
    reversed |> toList |> should equal <| List.rev values

let ``Reverse length 2`` () =
    let values = [1..2]
    let list = fromList values
    let reversed = reverse list
    reversed |> toList |> should equal <| List.rev values 

let ``Reverse length 10`` () =
    let values = [1..10]
    let list = fromList values
    let reversed = reverse list
    reversed |> toList |> should equal <| List.rev values 

let ``Reverse length 100`` () =
    let values = [1..100]
    let list = fromList values
    let reversed = reverse list
    reversed |> toList |> should equal <| List.rev values 

let ``Roundtrip length 1`` () =
    let values = [1..1]
    let listValues = fromList values
    listValues |> toList |> should equal values

let ``Roundtrip length 2`` () =
    let values = [1..2]
    let listValues = fromList values
    listValues |> toList |> should equal values

let ``Roundtrip length 10`` () =
    let values = [1..10]
    let listValues = fromList values
    listValues |> toList |> should equal values

let ``Roundtrip length 100`` () =
    let values = [1..100]
    let listValues = fromList values
    listValues |> toList |> should equal values
