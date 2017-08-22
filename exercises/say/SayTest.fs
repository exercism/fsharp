module SayTest

open NUnit.Framework
open FsUnit

open Say

[<Test>]
let ``Zero`` () =
    inEnglish 0L |> should equal Some "zero"

[<Test>]
[<Ignore("Remove to run test")>]
let ``One`` () =
    inEnglish 1L |> should equal Some "one"

[<Test>]
[<Ignore("Remove to run test")>]
let ``Fourteen`` () =
    inEnglish 14L |> should equal Some "fourteen"

[<Test>]
[<Ignore("Remove to run test")>]
let ``Twenty`` () =
    inEnglish 20L |> should equal Some "twenty"

[<Test>]
[<Ignore("Remove to run test")>]
let ``Twenty-two`` () =
    inEnglish 22L |> should equal Some "twenty-two"

[<Test>]
[<Ignore("Remove to run test")>]
let ``One hundred`` () =
    inEnglish 100L |> should equal Some "one hundred"

[<Test>]
[<Ignore("Remove to run test")>]
let ``One hundred twenty-three`` () =
    inEnglish 123L |> should equal Some "one hundred twenty-three"

[<Test>]
[<Ignore("Remove to run test")>]
let ``One thousand`` () =
    inEnglish 1000L |> should equal Some "one thousand"

[<Test>]
[<Ignore("Remove to run test")>]
let ``One thousand two hundred thirty-four`` () =
    inEnglish 1234L |> should equal Some "one thousand two hundred thirty-four"

[<Test>]
[<Ignore("Remove to run test")>]
let ``One million`` () =
    inEnglish 1000000L |> should equal Some "one million"

[<Test>]
[<Ignore("Remove to run test")>]
let ``One million two`` () =
    inEnglish 1000002L |> should equal Some "one million two"

[<Test>]
[<Ignore("Remove to run test")>]
let ``One million two thousand three hundred forty-five`` () =
    inEnglish 1002345L |> should equal Some "one million two thousand three hundred forty-five"

[<Test>]
[<Ignore("Remove to run test")>]
let ``One billion`` () =
    inEnglish 1000000000L |> should equal Some "one billion"

[<Test>]
[<Ignore("Remove to run test")>]
let ``A big number`` () =
    inEnglish 987654321123L |> should equal Some "nine hundred eighty-seven billion six hundred fifty-four million three hundred twenty-one thousand one hundred twenty-three"
 
[<Test>]
[<Ignore("Remove to run test")>]
let ``Lower bound`` () =
    inEnglish -1L |> should equal None

[<Test>]
[<Ignore("Remove to run test")>]
let ``Upper bound`` () =
    inEnglish 1000000000000L |> should equal None