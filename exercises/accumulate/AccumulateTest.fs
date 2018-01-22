// This file was created manually and its version is 1.0.0

module AccumulateTest

open System
open Xunit
open FsUnit.Xunit
open Accumulate

let reverse (str:string) = new string(str.ToCharArray() |> Array.rev)

[<Fact>]
let ``Empty accumulation produces empty accumulation`` () =
    accumulate (fun x -> x + 1) List.empty |> should be Empty

[<Fact(Skip = "Remove to run test")>]
let ``Identity accumulation returns unmodified list`` () =
    accumulate id [1; 2; 3] |> should equal [1; 2; 3]

[<Fact(Skip = "Remove to run test")>]
let ``Accumulate squares`` () =
    accumulate (fun x -> x * x) [1; 2; 3] |> should equal [1; 4; 9]

[<Fact(Skip = "Remove to run test")>]
let ``Accumulate upcases`` () =
    accumulate (fun (x:string) -> x.ToUpper()) ["hello"; "world"]
    |> should equal ["HELLO"; "WORLD"]

[<Fact(Skip = "Remove to run test")>]
let ``Accumulate reversed strings`` () =
    accumulate reverse (List.ofArray ("the quick brown fox etc".Split(' ')))
    |> should equal (List.ofArray("eht kciuq nworb xof cte".Split(' ')))

[<Fact(Skip = "Remove to run test")>]
let ``Accumulate within accumulate`` () =
    accumulate (fun (x:string) -> String.concat " " (accumulate (fun y -> x + y) ["1"; "2"; "3"])) ["a"; "b"; "c"]
    |> should equal ["a1 a2 a3"; "b1 b2 b3"; "c1 c2 c3"]