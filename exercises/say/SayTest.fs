module SayTest

open Xunit
open FsUnit

open Say

[<Fact>]
let ``Zero`` () =
    inEnglish 0L |> should equal <| Some "zero"

[<Fact(Skip = "Remove to run test")>]
let ``One`` () =
    inEnglish 1L |> should equal <| Some "one"

[<Fact(Skip = "Remove to run test")>]
let ``Fourteen`` () =
    inEnglish 14L |> should equal <| Some "fourteen"

[<Fact(Skip = "Remove to run test")>]
let ``Twenty`` () =
    inEnglish 20L |> should equal <| Some "twenty"

[<Fact(Skip = "Remove to run test")>]
let ``Twenty-two`` () =
    inEnglish 22L |> should equal <| Some "twenty-two"

[<Fact(Skip = "Remove to run test")>]
let ``One hundred`` () =
    inEnglish 100L |> should equal <| Some "one hundred"

[<Fact(Skip = "Remove to run test")>]
let ``One hundred twenty-three`` () =
    inEnglish 123L |> should equal <| Some "one hundred twenty-three"

[<Fact(Skip = "Remove to run test")>]
let ``One thousand`` () =
    inEnglish 1000L |> should equal <| Some "one thousand"

[<Fact(Skip = "Remove to run test")>]
let ``One thousand two hundred thirty-four`` () =
    inEnglish 1234L |> should equal <| Some "one thousand two hundred thirty-four"

[<Fact(Skip = "Remove to run test")>]
let ``One million`` () =
    inEnglish 1000000L |> should equal <| Some "one million"

[<Fact(Skip = "Remove to run test")>]
let ``One million two`` () =
    inEnglish 1000002L |> should equal <| Some "one million two"

[<Fact(Skip = "Remove to run test")>]
let ``One million two thousand three hundred forty-five`` () =
    inEnglish 1002345L |> should equal <| Some "one million two thousand three hundred forty-five"

[<Fact(Skip = "Remove to run test")>]
let ``One billion`` () =
    inEnglish 1000000000L |> should equal <| Some "one billion"

[<Fact(Skip = "Remove to run test")>]
let ``A big number`` () =
    inEnglish 987654321123L |> should equal <| Some "nine hundred eighty-seven billion six hundred fifty-four million three hundred twenty-one thousand one hundred twenty-three"
 
[<Fact(Skip = "Remove to run test")>]
let ``Lower bound`` () =
    inEnglish -1L |> should equal None

[<Fact(Skip = "Remove to run test")>]
let ``Upper bound`` () =
    inEnglish 1000000000000L |> should equal None