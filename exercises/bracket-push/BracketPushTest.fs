module BracketPushTest

open NUnit.Framework
open FsUnit

open BracketPush

[<Test>]
let ``Paired square brackets`` () =
    let actual ="[]"
    matched actual |> should be True

[<Test>]
[<Ignore("Remove to run test")>]
let ``Empty string`` () =
    let actual =""
    matched actual |> should be True

[<Test>]
[<Ignore("Remove to run test")>]
let ``Unpaired brackets`` () =
    let actual ="[["
    matched actual |> should be False

[<Test>]
[<Ignore("Remove to run test")>]
let ``Wrong ordered brackets`` () =
    let actual ="}{"
    matched actual |> should be False

[<Test>]
[<Ignore("Remove to run test")>]
let ``Paired with whitespace`` () =
    let actual ="{ }"
    matched actual |> should be True

[<Test>]
[<Ignore("Remove to run test")>]
let ``Simple nested brackets`` () =
    let actual ="{[]}"
    matched actual |> should be True

[<Test>]
[<Ignore("Remove to run test")>]
let ``Several paired brackets`` () =
    let actual ="{}[]"
    matched actual |> should be True

[<Test>]
[<Ignore("Remove to run test")>]
let ``Paired and nested brackets`` () =
    let actual ="([{}({}[])])"
    matched actual |> should be True

[<Test>]
[<Ignore("Remove to run test")>]
let ``Unpaired and nested brackets`` () =
    let actual ="([{])"
    matched actual |> should be False

[<Test>]
[<Ignore("Remove to run test")>]
let ``Paired and wrong nested brackets`` () =
    let actual ="[({]})"
    matched actual |> should be False

[<Test>]
[<Ignore("Remove to run test")>]
let ``Math expression`` () =
    let actual ="(((185 + 223.85) * 15) - 543)/2"
    matched actual |> should be True

[<Test>]
[<Ignore("Remove to run test")>]
let ``Complex latex expression`` () =
    let actual ="\\left(\\begin{array}{cc} \\frac{1}{3} & x\\\\ \\mathrm{e}^{x} &... x^2 \\end{array}\\right)"
    matched actual |> should be True