import "binary"

let ``Binary 0 is decimal 0`` () =
    toDecimal "0" |> should equal 0

let ``Binary 1 is decimal 1`` () =
    toDecimal "1" |> should equal 1

let ``Binary 10 is decimal 2`` () =
    toDecimal "10" |> should equal 2

let ``Binary 11 is decimal 3`` () =
    toDecimal "11" |> should equal 3

let ``Binary 100 is decimal 4`` () =
    toDecimal "100" |> should equal 4

let ``Binary 1001 is decimal 9`` () =
    toDecimal "1001" |> should equal 9

let ``Binary 11010 is decimal 26`` () =
    toDecimal "11010" |> should equal 26

let ``Binary 10001101000 is decimal 1128`` () =
    toDecimal "10001101000" |> should equal 1128

let ``Binary ignores leading zeros`` () =
    toDecimal "000011111" |> should equal 31

let ``2 is not a valid binary digit`` () =
    toDecimal "2" |> should equal 0

let ``A number containing a non binary digit is invalid`` () =
    toDecimal "01201" |> should equal 0

let ``A number with trailing non binary characters is invalid`` () =
    toDecimal "10nope" |> should equal 0

let ``A number with leading non binary characters is invalid`` () =
    toDecimal "nope10" |> should equal 0

let ``A number with internal non binary characters is invalid`` () =
    toDecimal "10nope10" |> should equal 0

let ``A number and a word whitespace separated is invalid`` () =
    toDecimal "001 nope" |> should equal 0

