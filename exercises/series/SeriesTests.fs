module SeriesTests

open System
open NUnit.Framework
open Series

type SeriesTests() =
    static member SliceOneTestData = 
        [| 
            ("01234", [[0]; [1]; [2]; [3]; [4]]);
            ("92834", [[9]; [2]; [8]; [3]; [4]]) 
        |]

    [<TestCaseSource("SliceOneTestData")>]
    member tests.Series_of_one_splits_to_one_digit(testData: string * int list list) =
        let input, expected = testData
        let series = new Series(input)
        Assert.That(series.slices(1), Is.EqualTo(expected))

    static member SliceTwoTestData =
        [| 
            ("01234", [[0; 1]; [1; 2]; [2; 3]; [3; 4]]);
            ("98273463", [[9; 8]; [8; 2]; [2; 7]; [7; 3]; [3; 4]; [4; 6]; [6; 3]]);
            ("37103", [[3; 7]; [7; 1]; [1; 0]; [0; 3]])
        |]

    [<TestCaseSource("SliceTwoTestData")>]
    [<Ignore("Remove to run test")>]
    member tests.Series_of_two_splits_to_two_digits(testData: string * int list list) =
        let input, expected = testData
        let series = new Series(input)
        Assert.That(series.slices(2), Is.EqualTo(expected))

    static member SliceThreeTestData =
        [| 
            ("01234", [[0; 1; 2]; [1; 2; 3]; [2; 3; 4]]);
            ("31001", [[3; 1; 0]; [1; 0; 0]; [0; 0; 1]]);
            ("982347", [[9; 8; 2]; [8; 2; 3]; [2; 3; 4]; [3; 4; 7]])
        |]

    [<TestCaseSource("SliceThreeTestData")>]
    [<Ignore("Remove to run test")>]
    member tests.Series_of_three_splits_to_three_digits(testData: string * int list list) =
        let input, expected = testData
        let series = new Series(input)
        Assert.That(series.slices(3), Is.EqualTo(expected))

    static member SliceFourTestData =
        [| 
            ("01234", [[0; 1; 2; 3]; [1; 2; 3; 4]]);
            ("91274", [[9; 1; 2; 7]; [1; 2; 7; 4]])
        |]

    [<TestCaseSource("SliceFourTestData")>]
    [<Ignore("Remove to run test")>]
    member tests.Series_of_four_splits_to_four_digits(testData: string * int list list) =
        let input, expected = testData
        let series = new Series(input)
        Assert.That(series.slices(4), Is.EqualTo(expected))

    static member SliceFiveTestData =
        [| 
            ("01234", [[0; 1; 2; 3; 4]]);
            ("81228", [[8; 1; 2; 2; 8]])
        |]

    [<TestCaseSource("SliceFiveTestData")>]
    [<Ignore("Remove to run test")>]
    member tests.Series_of_five_splits_to_five_digits(testData: string * int list list) =
        let input, expected = testData
        let series = new Series(input)
        Assert.That(series.slices(5), Is.EqualTo(expected))

    [<TestCase("01234", 6, Ignore = "Remove to run test case")>]
    [<TestCase("01032987583", 19, Ignore = "Remove to run test case")>]
    member tests.Slice_longer_than_input_is_not_allowed(input, slice) =
        let series = new Series(input)
        Assert.Throws<System.ArgumentException>(fun () -> series.slices(slice) |> ignore) |> ignore