// This file was created manually and its version is 1.0.0.

source("./simple-linked-list-test.R")
library(testthat)

let ``Empty list`` () =
    list <- nil
    expect_equal(isNil list, true)

let ``Single item list value`` () =
    list <- create 1 nil
    expect_equal(datum list, 1)
        
let ``Single item list has no next item`` () =
    list <- create 1 nil
    expect_equal(next list |> isNil, true)
        
let ``Two item list first value`` () =
    list <- create 2 (create 1 nil)
    expect_equal(datum list, 2)
    
let ``Two item list second value`` () =
    list <- create 2 (create 1 nil)
    expect_equal(next list |> datum, 1)
    
let ``Two item list second item has no next`` () =
    list <- create 2 (create 1 nil)
    expect_equal(next list |> next |> isNil, true)
        
let ``To list`` () =
    values <- create 2 (create 1 nil) |> toList
    expect_equal(values, [2; 1])
        
let ``From list`` () =
    list <- fromList [11; 7; 5; 3; 2]
    expect_equal(list |> datum, 11)
    expect_equal(list |> next |> datum, 7)
    expect_equal(list |> next |> next |> datum, 5)
    expect_equal(list |> next |> next |> next |> datum, 3)
    expect_equal(list |> next |> next |> next |> next |> datum, 2)

let ``Reverse length 1`` () =
    values <- [1..1]
    list <- fromList values
    reversed <- reverse list
    expect_equal(reversed |> toList, <| List.rev values)

let ``Reverse length 2`` () =
    values <- [1..2]
    list <- fromList values
    reversed <- reverse list
    expect_equal(reversed |> toList, <| List.rev values )

let ``Reverse length 10`` () =
    values <- [1..10]
    list <- fromList values
    reversed <- reverse list
    expect_equal(reversed |> toList, <| List.rev values )

let ``Reverse length 100`` () =
    values <- [1..100]
    list <- fromList values
    reversed <- reverse list
    expect_equal(reversed |> toList, <| List.rev values )

let ``Roundtrip length 1`` () =
    values <- [1..1]
    listValues <- fromList values
    expect_equal(listValues |> toList, values)

let ``Roundtrip length 2`` () =
    values <- [1..2]
    listValues <- fromList values
    expect_equal(listValues |> toList, values)

let ``Roundtrip length 10`` () =
    values <- [1..10]
    listValues <- fromList values
    expect_equal(listValues |> toList, values)

let ``Roundtrip length 100`` () =
    values <- [1..100]
    listValues <- fromList values
    expect_equal(listValues |> toList, values)
