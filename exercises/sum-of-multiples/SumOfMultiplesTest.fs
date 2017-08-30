module SumOfMultiplesTest

open Xunit
open FsUnit
open SumOfMultiples

[<Test>]
let ``Sum to 1`` () =
    sumOfMultiples [3; 5] 0 |> should equal 0

[<Test>]
[<Ignore("Remove to run test")>]
let ``Sum to 3`` () =
    sumOfMultiples [3; 5] 3 |> should equal 0

[<Test>]
[<Ignore("Remove to run test")>]
let ``Sum to 4`` () =
    sumOfMultiples [3; 5] 4 |> should equal 3

[<Test>]
[<Ignore("Remove to run test")>]
let ``Sum to 10`` () =
    sumOfMultiples [3; 5] 10 |> should equal 23

[<Test>]
[<Ignore("Remove to run test")>]
let ``Sum to 20`` () =
    sumOfMultiples [7; 13; 17] 20 |> should equal 51

[<Test>]
[<Ignore("Remove to run test")>]
let ``Sum to 10000`` () =
    sumOfMultiples [43; 47] 10000 |> should equal 2203160
