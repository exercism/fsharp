// This file was created manually and its version is 1.0.0.

module MatrixTest

open Xunit
open FsUnit.Xunit

open Matrix

type MatrixTest() =
    static member ExtractFirstRowData = 
        let theoryData = new TheoryData<string, int[]>()
        theoryData.Add("1", [| 1 |])
        theoryData.Add("4 7", [| 4; 7 |])
        theoryData.Add("1 2\n10 20", [| 1; 2 |])
        theoryData.Add("9 7 6\n8 6 5\n5 3 2", [| 9; 7; 6 |])
        theoryData

    [<Theory>]
    [<MemberData("ExtractFirstRowData")>]
    member this.``Extract first row`` (input: string) expected =    
        let matrix = fromString input    
        rows matrix |> Array.head |> should equal expected

    static member ExtractLastRowData = 
        let theoryData = new TheoryData<string, int[]>()
        theoryData.Add("5", [| 5 |])
        theoryData.Add("9 7", [| 9; 7 |])
        theoryData.Add("9 8 7\n19 18 17", [| 19; 18; 17 |])
        theoryData.Add("1 4 9\n16 25 36\n5 6 7", [| 5; 6; 7 |])
        theoryData

    [<Theory(Skip = "Remove to run test")>]
    [<MemberData("ExtractLastRowData")>]
    member this.``Extract last row`` (input: string) expected =
        let matrix = fromString input
        rows matrix |> Array.last |> should equal expected

    static member ExtractFirstColumnData = 
        let theoryData = new TheoryData<string, int[]>()
        theoryData.Add("55 44", [| 55 |])
        theoryData.Add("89 1903\n18 3", [| 89; 18 |])
        theoryData.Add("1 2 3\n4 5 6\n7 8 9\n8 7 6", [| 1; 4; 7; 8 |])
        theoryData

    [<Theory(Skip = "Remove to run test")>]
    [<MemberData("ExtractFirstColumnData")>]
    member this.``Extract first column`` (input: string) expected =
        let matrix = fromString input
        cols matrix |> Array.head |> should equal expected

    static member ExtractLastColumnData = 
        let theoryData = new TheoryData<string, int[]>()
        theoryData.Add("28", [| 28 |])
        theoryData.Add("13\n16\n19", [| 13; 16; 19 |])
        theoryData.Add("289 21903 23\n218 23 21", [| 23; 21 |])
        theoryData.Add("11 12 13\n14 15 16\n17 18 19\n18 17 16", [| 13; 16; 19; 16 |])
        theoryData

    [<Theory(Skip = "Remove to run test")>]
    [<MemberData("ExtractLastColumnData")>]
    member this.``Extract last column`` (input: string) expected =
        let matrix = fromString input
        cols matrix |> Array.last |> should equal expected

    [<Theory(Skip = "Remove to run test")>]
    [<InlineData("28", 1)>]
    [<InlineData("13\n16", 2)>]
    [<InlineData("289 21903\n23 218\n23 21", 3)>]
    [<InlineData("11 12 13\n14 15 16\n17 18 19\n18 17 16", 4)>]
    member this.``Number of rows`` (input: string) expected =
        let matrix = fromString input
        rows matrix |> Array.length |> should equal expected

    [<Theory(Skip = "Remove to run test")>]
    [<InlineData("28", 1)>]
    [<InlineData("13 2\n16 3\n19 4", 2)>]
    [<InlineData("289 21903\n23 218\n23 21", 2)>]
    [<InlineData("11 12 13\n14 15 16\n17 18 19\n18 17 16", 3)>]
    member this.``Number of columns`` (input: string) expected =
        let matrix = fromString input
        cols matrix |> Array.length |> should equal expected