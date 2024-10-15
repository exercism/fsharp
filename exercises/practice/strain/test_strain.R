source("./strain.R")
library(testthat)



test_that("Empty keep", {
    [] |> Seq.keep (fun x -> x < 10) |> should be Empty

  
test_that("Keep everything", {
    set [1; 2; 3] |> Seq.keep (fun x -> x < 10) |> Seq.toList |> should equal <| [1; 2; 3]

 
test_that("Keep first and last", {
    [|1; 2; 3|] |> Seq.keep (fun x -> x % 2 <> 0) |> Seq.toList |> should equal [1; 3]


test_that("Keep neither first nor last", {
    [1; 2; 3; 4; 5] |> Seq.keep (fun x -> x % 2 = 0) |> Seq.toList |> should equal [2; 4]


test_that("Keep strings", {
    let words = "apple zebra banana zombies cherimoya zelot".Split(' ');
    words |> Seq.keep (fun (x:string) -> x.StartsWith("z")) |> Seq.toList |> should equal <| List.ofArray("zebra zombies zelot".Split(' '))


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
    actual |> Seq.keep (Array.exists ((=) 5)) |> Seq.toList |> should equal expected


test_that("Empty discard", {
    [] |> Seq.discard (fun x -> x < 10) |> should be Empty


test_that("Discard nothing", {
    set [1; 2; 3] |> Seq.discard (fun x -> x > 10) |> Seq.toList |> should equal <| [1; 2; 3]


test_that("Discard first and last", {
    [|1; 2; 3|] |> Seq.discard (fun x -> x % 2 <> 0) |> Seq.toList |> should equal [2]


test_that("Discard neither first nor last", {
    [1; 2; 3; 4; 5] |> Seq.discard (fun x -> x % 2 = 0) |> Seq.toList |> should equal [1; 3; 5]


test_that("Discard strings", {
    let words = "apple zebra banana zombies cherimoya zelot".Split(' ')
    words |> Seq.discard (fun (x:string) -> x.StartsWith("z")) |> Seq.toList |> should equal <| List.ofArray("apple banana cherimoya".Split(' '))


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
    actual |> Seq.discard (Array.exists ((=) 5)) |> Seq.toList |> should equal expected