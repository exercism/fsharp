import "say"

let ``Zero`` () =
    say 0L |> should equal "zero"

let ``One`` () =
    say 1L |> should equal "one"

let ``Fourteen`` () =
    say 14L |> should equal "fourteen"

let ``Twenty`` () =
    say 20L |> should equal "twenty"

let ``Twenty-two`` () =
    say 22L |> should equal "twenty-two"

let ``Thirty`` () =
    say 30L |> should equal "thirty"

let ``Ninety-nine`` () =
    say 99L |> should equal "ninety-nine"

let ``One hundred`` () =
    say 100L |> should equal "one hundred"

let ``One hundred twenty-three`` () =
    say 123L |> should equal "one hundred twenty-three"

let ``Two hundred`` () =
    say 200L |> should equal "two hundred"

let ``Nine hundred ninety-nine`` () =
    say 999L |> should equal "nine hundred ninety-nine"

let ``One thousand`` () =
    say 1000L |> should equal "one thousand"

let ``One thousand two hundred thirty-four`` () =
    say 1234L |> should equal "one thousand two hundred thirty-four"

let ``One million`` () =
    say 1000000L |> should equal "one million"

let ``One million two thousand three hundred forty-five`` () =
    say 1002345L |> should equal "one million two thousand three hundred forty-five"

let ``One billion`` () =
    say 1000000000L |> should equal "one billion"

let ``A big number`` () =
    say 987654321123L |> should equal "nine hundred eighty-seven billion six hundred fifty-four million three hundred twenty-one thousand one hundred twenty-three"

let ``Numbers below zero are out of range`` () =
    say -1L |> should equal None

let ``Numbers above 999,999,999,999 are out of range`` () =
    say 1000000000000L |> should equal None

