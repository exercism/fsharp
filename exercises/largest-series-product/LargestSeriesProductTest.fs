module LargestSeriesProductTest

open NUnit.Framework
open LargestSeriesProduct
    
[<TestCase("01234567890", 2, ExpectedResult = 72)>]
[<TestCase("1027839564", 3, ExpectedResult = 270, Ignore = "Remove to run test case")>]
let ``Gets the largest product``(digits: string) (seriesLength: int) =
    largestProduct digits seriesLength
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Largest product works for small numbers`` () =
    Assert.That(largestProduct "19" 2, Is.EqualTo(9))
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Largest product works for large numbers`` () =
    let LARGE_NUMBER = "73167176531330624919225119674426574742355349194934"
    Assert.That(largestProduct LARGE_NUMBER 6, Is.EqualTo(23520))
    
[<TestCase("0000", 2, ExpectedResult = 0, Ignore = "Remove to run test case")>]
[<TestCase("99099", 3, ExpectedResult = 0, Ignore = "Remove to run test case")>]
let ``Largest product works if all spans contain zero``(digits: string) (seriesLength: int) =
    largestProduct digits seriesLength
    
[<TestCase("", ExpectedResult = 1)>]
[<TestCase("123", ExpectedResult = 1)>]
let ``Largest product for empty span is 1``(digits: string) =
    largestProduct digits 0
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Cannot slice empty string with nonzero span`` () =
    Assert.That((fun () -> largestProduct "" 1 |> ignore), Throws.Exception)
