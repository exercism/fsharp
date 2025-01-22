source("./run-length-encoding.R")
library(testthat)

let ``Encode empty string`` () =
    encode "" |> should equal ""

let ``Encode single characters only are encoded without count`` () =
    encode "XYZ" |> should equal "XYZ"

let ``Encode string with no single characters`` () =
    encode "AABBBCCCC" |> should equal "2A3B4C"

let ``Encode single characters mixed with repeated characters`` () =
    encode "WWWWWWWWWWWWBWWWWWWWWWWWWBBBWWWWWWWWWWWWWWWWWWWWWWWWB" |> should equal "12WB12W3B24WB"

let ``Encode multiple whitespace mixed in string`` () =
    encode "  hsqq qww  " |> should equal "2 hs2q q2w2 "

let ``Encode lowercase characters`` () =
    encode "aabbbcccc" |> should equal "2a3b4c"

let ``Decode empty string`` () =
    decode "" |> should equal ""

let ``Decode single characters only`` () =
    decode "XYZ" |> should equal "XYZ"

let ``Decode string with no single characters`` () =
    decode "2A3B4C" |> should equal "AABBBCCCC"

let ``Decode single characters with repeated characters`` () =
    decode "12WB12W3B24WB" |> should equal "WWWWWWWWWWWWBWWWWWWWWWWWWBBBWWWWWWWWWWWWWWWWWWWWWWWWB"

let ``Decode multiple whitespace mixed in string`` () =
    decode "2 hs2q q2w2 " |> should equal "  hsqq qww  "

let ``Decode lowercase string`` () =
    decode "2a3b4c" |> should equal "aabbbcccc"

let ``Encode followed by decode gives original string`` () =
    "zzz ZZ  zZ" |> encode |> decode |> should equal "zzz ZZ  zZ"

