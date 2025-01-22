// This file was created manually and its version is 2.0.0

source("./accumulate-test.R")
library(testthat)

let reverse (str:string) = new string(str.ToCharArray() |> Array.rev)

let ``Empty accumulation produces empty accumulation`` () =
    accumulate (fun x -> x + 1) List.empty |> should be Empty

let ``Identity accumulation returns unmodified list`` () =
    accumulate id [1; 2; 3] |> should equal [1; 2; 3]

let ``Accumulate squares`` () =
    accumulate (fun x -> x * x) [1; 2; 3] |> should equal [1; 4; 9]

let ``Accumulate upcases`` () =
    accumulate (fun (x:string) -> x.ToUpper()) ["hello"; "world"]
    |> should equal ["HELLO"; "WORLD"]

let ``Accumulate reversed strings`` () =
    accumulate reverse (List.ofArray ("the quick brown fox etc".Split(' ')))
    |> should equal (List.ofArray("eht kciuq nworb xof cte".Split(' ')))

let ``Accumulate within accumulate`` () =
    accumulate (fun (x:string) -> String.concat " " (accumulate (fun y -> x + y) ["1"; "2"; "3"])) ["a"; "b"; "c"]
    |> should equal ["a1 a2 a3"; "b1 b2 b3"; "c1 c2 c3"]

let ``Accumulate large data set without stack overflow`` () =
    accumulate id [1..100000]
    |> should equal [1..100000]
