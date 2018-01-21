// This file was created manually and its version is 1.0.0.

module SeriesTest

open System
open Xunit
open FsUnit.Xunit
open Series

type SeriesTests () =
    static member SliceOneTestData = 
        let theoryData = new TheoryData<string, int list list>()
        theoryData.Add("01234", [[0]; [1]; [2]; [3]; [4]])
        theoryData.Add("92834", [[9]; [2]; [8]; [3]; [4]])
        theoryData

    [<Theory>]
    [<MemberData("SliceOneTestData")>]
    member this.``Series of one splits to one digit`` input expected =
        slices input 1 |> should equal expected

    static member SliceTwoTestData = 
        let theoryData = new TheoryData<string, int list list>()
        theoryData.Add("01234", [[0; 1]; [1; 2]; [2; 3]; [3; 4]]);
        theoryData.Add("98273463", [[9; 8]; [8; 2]; [2; 7]; [7; 3]; [3; 4]; [4; 6]; [6; 3]]);
        theoryData.Add("37103", [[3; 7]; [7; 1]; [1; 0]; [0; 3]])
        theoryData

    [<Theory(Skip = "Remove to run test")>]
    [<MemberData("SliceTwoTestData")>]
    member this.``Series of two splits to two digits`` input expected =
        slices input 2 |> should equal expected

    static member SliceThreeTestData = 
        let theoryData = new TheoryData<string, int list list>()
        theoryData.Add("01234", [[0; 1; 2]; [1; 2; 3]; [2; 3; 4]]);
        theoryData.Add("31001", [[3; 1; 0]; [1; 0; 0]; [0; 0; 1]]);
        theoryData.Add("982347", [[9; 8; 2]; [8; 2; 3]; [2; 3; 4]; [3; 4; 7]])
        theoryData

    [<Theory(Skip = "Remove to run test")>]
    [<MemberData("SliceThreeTestData")>]
    member this.``Series of three splits to three digits`` input expected =
        slices input 3 |> should equal expected

    static member SliceFourTestData = 
        let theoryData = new TheoryData<string, int list list>()
        theoryData.Add("01234", [[0; 1; 2; 3]; [1; 2; 3; 4]]);
        theoryData.Add("91274", [[9; 1; 2; 7]; [1; 2; 7; 4]])
        theoryData

    [<Theory(Skip = "Remove to run test")>]
    [<MemberData("SliceFourTestData")>]
    member this.``Series of four splits to four digits`` input expected =
        slices input 4 |> should equal expected

    static member SliceFiveTestData = 
        let theoryData = new TheoryData<string, int list list>()
        theoryData.Add("01234", [[0; 1; 2; 3; 4]]);
        theoryData.Add("81228", [[8; 1; 2; 2; 8]])
        theoryData

    [<Theory(Skip = "Remove to run test")>]
    [<MemberData("SliceFiveTestData")>]
    member this.``Series of five splits to five digits`` input expected =
        slices input 5 |> should equal expected

    [<Theory(Skip = "Remove to run test")>]
    [<InlineData("01234", 6)>]
    [<InlineData("01032987583", 19)>]
    member this.``Slice longer than input is not allowed`` input slice =
        (fun () -> slices input slice |> ignore) |> should throw typeof<ArgumentException>