source("./cars-assemble.R")
library(testthat)

open FsUnit.Xunit
open Xunit
open Exercism.Tests

open CarsAssemble

[<Task(1)>]
let ``Success rate for speed 10``() = successRate 10 |> should (equalWithin 0.01) 0.77

[<Task(1)>]
let ``Success rate for speed 9``() = successRate 9 |> should (equalWithin 0.01) 0.8

[<Task(1)>]
let ``Success rate for speed 8``() = successRate 8 |> should (equalWithin 0.01) 0.9

[<Task(1)>]
let ``Success rate for speed 5``() = successRate 5 |> should (equalWithin 0.01) 0.9

[<Task(1)>]
let ``Success rate for speed 4``() = successRate 4 |> should (equalWithin 0.01) 1.0

[<Task(1)>]
let ``Success rate for speed 1``() = successRate 1 |> should (equalWithin 0.01) 1.0

[<Task(2)>]
let ``Production rate per hour for speed 0``() = productionRatePerHour 0 |> should (equalWithin 0.1) 0.0

[<Task(2)>]
let ``Production rate per hour for speed 1``() = productionRatePerHour 1 |> should (equalWithin 0.1) 221.0

[<Task(2)>]
let ``Production rate per hour for speed 4``() = productionRatePerHour 4 |> should (equalWithin 0.1) 884.0

[<Task(2)>]
let ``Production rate per hour for speed 7``() = productionRatePerHour 7 |> should (equalWithin 0.1) 1392.3

[<Task(2)>]
let ``Production rate per hour for speed 9``() = productionRatePerHour 9 |> should (equalWithin 0.1) 1591.2

[<Task(2)>]
let ``Production rate per hour for speed 10``() = productionRatePerHour 10 |> should (equalWithin 0.1) 1701.7

[<Task(3)>]
let ``Working items per minute for speed 0``() = workingItemsPerMinute 0 |> should equal 0

[<Task(3)>]
let ``Working items per minute for speed 1``() = workingItemsPerMinute 1 |> should equal 3

[<Task(3)>]
let ``Working items per minute for speed 5``() = workingItemsPerMinute 5 |> should equal 16

[<Task(3)>]
let ``Working items per minute for speed 8``() = workingItemsPerMinute 8 |> should equal 26

[<Task(3)>]
let ``Working items per minute for speed 9``() = workingItemsPerMinute 9 |> should equal 26

[<Task(3)>]
let ``Working items per minute for speed 10``() = workingItemsPerMinute 10 |> should equal 28
