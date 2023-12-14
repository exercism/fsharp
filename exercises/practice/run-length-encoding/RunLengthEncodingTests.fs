module RunLengthEncodingTests

open FsUnit.Xunit
open Xunit

open RunLengthEncoding

[<Fact>]
let ``Encode empty string`` () =
    encode "" |> should equal ""

[<Fact>]
let ``Encode single characters only are encoded without count`` () =
    encode "XYZ" |> should equal "XYZ"

[<Fact>]
let ``Encode string with no single characters`` () =
    encode "AABBBCCCC" |> should equal "2A3B4C"

[<Fact>]
let ``Encode single characters mixed with repeated characters`` () =
    encode "WWWWWWWWWWWWBWWWWWWWWWWWWBBBWWWWWWWWWWWWWWWWWWWWWWWWB" |> should equal "12WB12W3B24WB"

[<Fact>]
let ``Encode multiple whitespace mixed in string`` () =
    encode "  hsqq qww  " |> should equal "2 hs2q q2w2 "

[<Fact>]
let ``Encode lowercase characters`` () =
    encode "aabbbcccc" |> should equal "2a3b4c"

[<Fact>]
let ``Decode empty string`` () =
    decode "" |> should equal ""

[<Fact>]
let ``Decode single characters only`` () =
    decode "XYZ" |> should equal "XYZ"

[<Fact>]
let ``Decode string with no single characters`` () =
    decode "2A3B4C" |> should equal "AABBBCCCC"

[<Fact>]
let ``Decode single characters with repeated characters`` () =
    decode "12WB12W3B24WB" |> should equal "WWWWWWWWWWWWBWWWWWWWWWWWWBBBWWWWWWWWWWWWWWWWWWWWWWWWB"

[<Fact>]
let ``Decode multiple whitespace mixed in string`` () =
    decode "2 hs2q q2w2 " |> should equal "  hsqq qww  "

[<Fact>]
let ``Decode lowercase string`` () =
    decode "2a3b4c" |> should equal "aabbbcccc"

[<Fact>]
let ``Encode followed by decode gives original string`` () =
    "zzz ZZ  zZ" |> encode |> decode |> should equal "zzz ZZ  zZ"

