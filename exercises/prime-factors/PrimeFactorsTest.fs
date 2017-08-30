module PrimeFactorsTest

open Xunit
open FsUnit

open PrimeFactors

[<Fact>]
let ``Test 1`` () =
    primeFactorsFor 1L |> should equal []
    
[<Fact(Skip = "Remove to run test")>]
let ``Test 2`` () =
    primeFactorsFor 2L |> should equal [2]
    
[<Fact(Skip = "Remove to run test")>]
let ``Test 3`` () =
    primeFactorsFor 3L |> should equal [3]

[<Fact(Skip = "Remove to run test")>]
let ``Test 4`` () =
    primeFactorsFor 4L |> should equal [2; 2]
    
[<Fact(Skip = "Remove to run test")>]
let ``Test 6`` () =
    primeFactorsFor 6L |> should equal [2; 3]
    
[<Fact(Skip = "Remove to run test")>]
let ``Test 8`` () =
    primeFactorsFor 8L |> should equal [2; 2; 2]
    
[<Fact(Skip = "Remove to run test")>]
let ``Test 9`` () =
    primeFactorsFor 9L |> should equal [3; 3]
    
[<Fact(Skip = "Remove to run test")>]
let ``Test 27`` () =
    primeFactorsFor 27L |> should equal [3; 3; 3]
    
[<Fact(Skip = "Remove to run test")>]
let ``Test 625`` () =
    primeFactorsFor 625L |> should equal [5; 5; 5; 5]
    
[<Fact(Skip = "Remove to run test")>]
let ``Test 901255`` () =
    primeFactorsFor 901255L |> should equal [5; 17; 23; 461]