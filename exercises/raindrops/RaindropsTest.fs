// This file was auto-generated based on version 1.1.0 of the canonical data.

module RaindropsTest

open FsUnit.Xunit
open Xunit

open Raindrops

[<Fact>]
let ``The sound for 1 is 1`` () =
    convert 1 |> should equal "1"

[<Fact(Skip = "Remove to run test")>]
let ``The sound for 3 is Pling`` () =
    convert 3 |> should equal "Pling"

[<Fact(Skip = "Remove to run test")>]
let ``The sound for 5 is Plang`` () =
    convert 5 |> should equal "Plang"

[<Fact(Skip = "Remove to run test")>]
let ``The sound for 7 is Plong`` () =
    convert 7 |> should equal "Plong"

[<Fact(Skip = "Remove to run test")>]
let ``The sound for 6 is Pling as it has a factor 3`` () =
    convert 6 |> should equal "Pling"

[<Fact(Skip = "Remove to run test")>]
let ``2 to the power 3 does not make a raindrop sound as 3 is the exponent not the base`` () =
    convert 8 |> should equal "8"

[<Fact(Skip = "Remove to run test")>]
let ``The sound for 9 is Pling as it has a factor 3`` () =
    convert 9 |> should equal "Pling"

[<Fact(Skip = "Remove to run test")>]
let ``The sound for 10 is Plang as it has a factor 5`` () =
    convert 10 |> should equal "Plang"

[<Fact(Skip = "Remove to run test")>]
let ``The sound for 14 is Plong as it has a factor of 7`` () =
    convert 14 |> should equal "Plong"

[<Fact(Skip = "Remove to run test")>]
let ``The sound for 15 is PlingPlang as it has factors 3 and 5`` () =
    convert 15 |> should equal "PlingPlang"

[<Fact(Skip = "Remove to run test")>]
let ``The sound for 21 is PlingPlong as it has factors 3 and 7`` () =
    convert 21 |> should equal "PlingPlong"

[<Fact(Skip = "Remove to run test")>]
let ``The sound for 25 is Plang as it has a factor 5`` () =
    convert 25 |> should equal "Plang"

[<Fact(Skip = "Remove to run test")>]
let ``The sound for 27 is Pling as it has a factor 3`` () =
    convert 27 |> should equal "Pling"

[<Fact(Skip = "Remove to run test")>]
let ``The sound for 35 is PlangPlong as it has factors 5 and 7`` () =
    convert 35 |> should equal "PlangPlong"

[<Fact(Skip = "Remove to run test")>]
let ``The sound for 49 is Plong as it has a factor 7`` () =
    convert 49 |> should equal "Plong"

[<Fact(Skip = "Remove to run test")>]
let ``The sound for 52 is 52`` () =
    convert 52 |> should equal "52"

[<Fact(Skip = "Remove to run test")>]
let ``The sound for 105 is PlingPlangPlong as it has factors 3, 5 and 7`` () =
    convert 105 |> should equal "PlingPlangPlong"

[<Fact(Skip = "Remove to run test")>]
let ``The sound for 3125 is Plang as it has a factor 5`` () =
    convert 3125 |> should equal "Plang"

