// This file was created manually and its version is 1.0.0.

module SgfParsingTest

open Xunit
open FsUnit.Xunit

open SgfParsing

// This exercises requires you to do somewhat more complicated parsing.
// This is the perfect exercise to get to know the FParsec library,
// as the FParsec library helps you define parsers in a very convenient way.
// You can find the FParsec documentation here: http://www.quanttec.com/fparsec/

// A tree consists of two parts:
// - The node's data: a map of type Map<string, string list> 
// - A list of children (which are itself trees)
// You can define the data type as follows (but feel free to define your own):
// type Data = Map<string, string list>
// type Tree = Node of Data * Tree list

let treeWithChildren node children = mkTree (Map.ofList node) children
let treeWithSingleChild node child = mkTree (Map.ofList node) [child]
let treeWithNoChildren node = mkTree (Map.ofList node) []

[<Fact>]
let ``Empty value`` () =
    let input = "" 
    let expected = None
    parseSgf input |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Tree without nodes`` () =
    let input = "()"
    let expected = None
    parseSgf input |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Node without tree`` () =
    let input = ";"
    let expected = None
    parseSgf input |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Node without properties`` () =
    let input = "(;)"
    let expected = Some (treeWithNoChildren [])
    parseSgf input |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Single node tree`` () =
    let input = "(;A[B])"
    let expected = Some (treeWithNoChildren [("A", ["B"])])
    parseSgf input |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Properties without delimiter`` () =
    let input = "(;a)"
    let expected = None
    parseSgf input |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``All lowercase property`` () =
    let input = "(;a[b])"
    let expected = None
    parseSgf input |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Upper- and lowercase property`` () =
    let input = "(;Aa[b])"
    let expected = None
    parseSgf input |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Two nodes`` () =
    let input = "(;A[B];B[C])"
    let expected = Some (treeWithSingleChild [("A", ["B"])] (treeWithNoChildren [("B", ["C"])]))
    parseSgf input |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Two child trees`` () =
    let input = "(;A[B](;B[C])(;C[D]))"
    let expected = Some (treeWithChildren [("A", ["B"])]
                            [ treeWithNoChildren [("B", ["C"])]; 
                              treeWithNoChildren [("C", ["D"])] ])
    parseSgf input |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Multiple properties`` () =
    let input = "(;A[b][c][d])"
    let expected = Some (treeWithNoChildren [("A", ["b"; "c"; "d"])])
    parseSgf input |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Escaped property`` () =
    let input = @"(;A[\]b\nc\nd\t\te\\ \n\]])"
    let expected = Some (treeWithNoChildren [("A", [@"]b c d  e\  ]"])])
    parseSgf input |> should equal expected