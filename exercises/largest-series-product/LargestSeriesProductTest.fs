module LargestSeriesProductTest

open Xunit
open FsUnit.Xunit
open System
open LargestSeriesProduct
    
[<Theory(Skip = "Remove to run test")>]
[<InlineData("01234567890", 2, 72)>]
[<InlineData("1027839564", 3, 270)>]
let ``Gets the largest product``(digits: string) (seriesLength: int) (expected: string) =
    largestProduct digits seriesLength |> should equal expected

    
[<Fact(Skip = "Remove to run test")>]
let ``Largest product works for small numbers`` () =
    largestProduct "19" 2 |> should equal 9
    
[<Fact(Skip = "Remove to run test")>]
let ``Largest product works for large numbers`` () =
    let LARGE_NUMBER = "73167176531330624919225119674426574742355349194934"
    largestProduct LARGE_NUMBER 6 |> should equal 23520
    
[<Theory(Skip = "Remove to run test")>]
[<InlineData("0000", 2, 0)>]
[<InlineData("99099", 3, 0)>]
let ``Largest product works if all spans contain zero``(digits: string) (seriesLength: int) (expected: int) =
    largestProduct digits seriesLength |> should equal expected

    
[<Theory(Skip = "Remove to run test")>]
[<InlineData("", 1)>]
[<InlineData("123", 1)>]
let ``Largest product for empty span is 1``(digits: string) (expected: int) =
    largestProduct digits 0 |> should equal expected

    
[<Fact(Skip = "Remove to run test")>]
let ``Cannot slice empty string with nonzero span`` () =
    (fun () -> largestProduct "" 1 |> ignore) |> should throw typeof<Exception>
