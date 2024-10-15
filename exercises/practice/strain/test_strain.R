source("./strain.R")
library(testthat)
test_that("Empty keep", {
    [] |> Seq.keep (fun x -> x < 10) |> should be Empty

  
test_that("Keep everything", {
  expect_equal(set [1; 2; 3] |> Seq.keep (fun x -> x < 10) |> Seq.toList, <| [1; 2; 3])

 
test_that("Keep first and last", {
  expect_equal([|1; 2; 3|] |> Seq.keep (fun x -> x % 2 <> 0) |> Seq.toList, [1; 3])
})

test_that("Keep neither first nor last", {
  expect_equal([1; 2; 3; 4; 5] |> Seq.keep (fun x -> x % 2 = 0) |> Seq.toList, [2; 4])
})

test_that("Keep strings", {
    let words = "apple zebra banana zombies cherimoya zelot".Split(' ');
  expect_equal(words |> Seq.keep (fun (x:string) -> x.StartsWith("z")) |> Seq.toList, <| List.ofArray("zebra zombies zelot".Split(' ')))
})

test_that("Keep arrays", {
    let actual = [|
                    [|1; 2; 3|];
                    [|5; 5; 5|];
                    [|5; 1; 2|];
                    [|2; 1; 2|];
                    [|1; 5; 2|];
                    [|2; 2; 1|];
                    [|1; 2; 5|]
                    |]
    let expected = [ [|5; 5; 5|]; [|5; 1; 2|]; [|1; 5; 2|]; [|1; 2; 5|] ]
  expect_equal(actual |> Seq.keep (Array.exists ((=) 5)) |> Seq.toList, expected)
})

test_that("Empty discard", {
    [] |> Seq.discard (fun x -> x < 10) |> should be Empty
})

test_that("Discard nothing", {
  expect_equal(set [1; 2; 3] |> Seq.discard (fun x -> x > 10) |> Seq.toList, <| [1; 2; 3])
})

test_that("Discard first and last", {
  expect_equal([|1; 2; 3|] |> Seq.discard (fun x -> x % 2 <> 0) |> Seq.toList, [2])
})

test_that("Discard neither first nor last", {
  expect_equal([1; 2; 3; 4; 5] |> Seq.discard (fun x -> x % 2 = 0) |> Seq.toList, [1; 3; 5])
})

test_that("Discard strings", {
    let words = "apple zebra banana zombies cherimoya zelot".Split(' ')
  expect_equal(words |> Seq.discard (fun (x:string) -> x.StartsWith("z")) |> Seq.toList, <| List.ofArray("apple banana cherimoya".Split(' ')))
})

test_that("Discard arrays", {
    let actual = [|
                    [|1; 2; 3|];
                    [|5; 5; 5|];
                    [|5; 1; 2|];
                    [|2; 1; 2|];
                    [|1; 5; 2|];
                    [|2; 2; 1|];
                    [|1; 2; 5|]
                    |]
    let expected = [ [|1; 2; 3|]; [|2; 1; 2|]; [|2; 2; 1|] ]
  expect_equal(actual |> Seq.discard (Array.exists ((=) 5)) |> Seq.toList, expected)