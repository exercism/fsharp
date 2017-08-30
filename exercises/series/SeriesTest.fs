module SeriesTest

open System
open Xunit
open FsUnit
open Series

type SeriesTests () =
    static member SliceOneTestData = 
        [| 
            ("01234", [[0]; [1]; [2]; [3]; [4]]);
            ("92834", [[9]; [2]; [8]; [3]; [4]]) 
        |]

    [<Theory>]
    [MemberData("SliceOneTestData")]
    member this.``Series of one splits to one digit`` (testData: string * int list list) =
        let input, expected = testData
        slices input 1 |> should equal expected

    static member SliceTwoTestData =
        [| 
            ("01234", [[0; 1]; [1; 2]; [2; 3]; [3; 4]]);
            ("98273463", [[9; 8]; [8; 2]; [2; 7]; [7; 3]; [3; 4]; [4; 6]; [6; 3]]);
            ("37103", [[3; 7]; [7; 1]; [1; 0]; [0; 3]])
        |]

    [<Theory(Skip = "Remove to run test")>]
    [MemberData("SliceTwoTestData")]
    member this.``Series of two splits to two digits`` (testData: string * int list list) =
        let input, expected = testData
        slices input 2 |> should equal expected

    static member SliceThreeTestData =
        [| 
            ("01234", [[0; 1; 2]; [1; 2; 3]; [2; 3; 4]]);
            ("31001", [[3; 1; 0]; [1; 0; 0]; [0; 0; 1]]);
            ("982347", [[9; 8; 2]; [8; 2; 3]; [2; 3; 4]; [3; 4; 7]])
        |]

    [<Theory(Skip = "Remove to run test")>]
    [MemberData("SliceThreeTestData")]
    member this.``Series of three splits to three digits`` (testData: string * int list list) =
        let input, expected = testData
        slices input 3 |> should equal expected

    static member SliceFourTestData =
        [| 
            ("01234", [[0; 1; 2; 3]; [1; 2; 3; 4]]);
            ("91274", [[9; 1; 2; 7]; [1; 2; 7; 4]])
        |]

    [<Theory(Skip = "Remove to run test")>]
    [MemberData("SliceFourTestData")]
    member this.``Series of four splits to four digits`` (testData: string * int list list) =
        let input, expected = testData
        slices input 4 |> should equal expected

    static member SliceFiveTestData =
        [| 
            ("01234", [[0; 1; 2; 3; 4]]);
            ("81228", [[8; 1; 2; 2; 8]])
        |]

    [<Theory(Skip = "Remove to run test")>]
    [MemberData("SliceFiveTestData")]
    member this.``Series of five splits to five digits`` (testData: string * int list list) =
        let input, expected = testData
        slices input 5 |> should equal expected

    [<Theory(Skip = "Remove to run test")>]
    [InlineData("01234", 6)]
    [InlineData("01032987583", 19)]
    member this.``Slice longer than input is not allowed`` (input, slice) =
        (fun () -> slices input slice |> ignore) |> should throw typeof<Exception>