import "trinary"

let ``Trinary 1 is decimal 1`` () =
    toDecimal "1" |> should equal 1

let ``Trinary 2 is decimal 2`` () =
    toDecimal "2" |> should equal 2

let ``Trinary 10 is decimal 3`` () =
    toDecimal "10" |> should equal 3

let ``Trinary 11 is decimal 4`` () =
    toDecimal "11" |> should equal 4

let ``Trinary 100 is decimal 9`` () =
    toDecimal "100" |> should equal 9

let ``Trinary 112 is decimal 14`` () =
    toDecimal "112" |> should equal 14

let ``Trinary 222 is decimal 26`` () =
    toDecimal "222" |> should equal 26

let ``Trinary 1122000120 is decimal 32091`` () =
    toDecimal "1122000120" |> should equal 32091

let ``Invalid trinary digits returns 0`` () =
    toDecimal "1234" |> should equal 0

let ``Invalid word as input returns 0`` () =
    toDecimal "carrot" |> should equal 0

let ``Invalid numbers with letters as input returns 0`` () =
    toDecimal "0a1b2c" |> should equal 0

