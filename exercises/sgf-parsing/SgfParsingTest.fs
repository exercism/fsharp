// This file was auto-generated based on version 1.0.0 of the canonical data.

module SgfParsingTest

open FsUnit.Xunit
open Xunit

open SgfParsing

[<Fact>]
let ``Empty input`` () =
    parseSgf "" |> should equal None

[<Fact(Skip = "Remove to run test")>]
let ``Tree with no nodes`` () =
    parseSgf "()" |> should equal None

[<Fact(Skip = "Remove to run test")>]
let ``Node without tree`` () =
    parseSgf ";" |> should equal None

[<Fact(Skip = "Remove to run test")>]
let ``Node without properties`` () =
    let expected = Some (Node (Map.empty, []))
    parseSgf "(;)" |> should equal expected   

[<Fact(Skip = "Remove to run test")>]
let ``Single node tree`` () =
    let expected = Some (Node (Map.empty.Add("A", ["B"]), []))
    parseSgf "(;A[B])" |> should equal expected   

[<Fact(Skip = "Remove to run test")>]
let ``Properties without delimiter`` () =
    parseSgf "(;A)" |> should equal None

[<Fact(Skip = "Remove to run test")>]
let ``All lowercase property`` () =
    parseSgf "(;a[b])" |> should equal None

[<Fact(Skip = "Remove to run test")>]
let ``Upper and lowercase property`` () =
    parseSgf "(;Aa[b])" |> should equal None

[<Fact(Skip = "Remove to run test")>]
let ``Two nodes`` () =
    let expected = Some (Node (Map.empty.Add("A", ["B"]), [Node (Map.empty.Add("B", ["C"]), [])]))
    parseSgf "(;A[B];B[C])" |> should equal expected   

[<Fact(Skip = "Remove to run test")>]
let ``Two child trees`` () =
    let expected = Some (Node (Map.empty.Add("A", ["B"]), [Node (Map.empty.Add("B", ["C"]), []); Node (Map.empty.Add("C", ["D"]), [])]))
    parseSgf "(;A[B](;B[C])(;C[D]))" |> should equal expected   

[<Fact(Skip = "Remove to run test")>]
let ``Multiple property values`` () =
    let expected = Some (Node (Map.empty.Add("A", ["b"; "c"; "d"]), []))
    parseSgf "(;A[b][c][d])" |> should equal expected   

[<Fact(Skip = "Remove to run test")>]
let ``Escaped property`` () =
    let expected = Some (Node (Map.empty.Add("A", ["]b\nc\nd  e \n]"]), []))
    parseSgf "(;A[\]b\nc\nd\t\te \n\]])" |> should equal expected   

