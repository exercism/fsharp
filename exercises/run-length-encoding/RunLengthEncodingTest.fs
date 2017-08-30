module RunLengthEncodingTest

open Xunit
open FsUnit.Xunit
open System.Text

open RunLengthEncoding

[<Fact>]
let ``Encode simple`` () =
    let input = "AABBBCCCC"
    let expected = "2A3B4C"
    encode input |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Decode simple`` () =
    let input = "2A3B4C"
    let expected = "AABBBCCCC"
    decode input |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Encode with single values`` () =
    let input = "WWWWWWWWWWWWBWWWWWWWWWWWWBBBWWWWWWWWWWWWWWWWWWWWWWWWB"
    let expected = "12WB12W3B24WB"
    encode input |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Decode with single values`` () =
    let input = "12WB12W3B24WB"
    let expected = "WWWWWWWWWWWWBWWWWWWWWWWWWBBBWWWWWWWWWWWWWWWWWWWWWWWWB"
    decode input |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Encode and then decode`` () =
    let input = "zzz ZZ  zZ"
    let expected = "zzz ZZ  zZ"
    encode input |> decode |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Encode unicode`` () =
    let input = Encoding.Unicode.GetString([|240uy; 35uy; 189uy; 38uy; 189uy; 38uy; 189uy; 38uy; 80uy; 43uy; 80uy; 43uy; 240uy; 35uy|])
    let expected = Encoding.Unicode.GetString([|240uy; 35uy; 51uy; 0uy; 189uy; 38uy; 50uy; 0uy; 80uy; 43uy; 240uy; 35uy|])
    encode input |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Decode unicode`` () =
    let input = Encoding.Unicode.GetString([|240uy; 35uy; 51uy; 0uy; 189uy; 38uy; 50uy; 0uy; 80uy; 43uy; 240uy; 35uy|])
    let expected = Encoding.Unicode.GetString([|240uy; 35uy; 189uy; 38uy; 189uy; 38uy; 189uy; 38uy; 80uy; 43uy; 80uy; 43uy; 240uy; 35uy|])
    decode input |> should equal expected