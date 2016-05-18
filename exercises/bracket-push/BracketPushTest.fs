module BracketPushTest

open NUnit.Framework

open BracketPush

[<Test>]
let ``Paired square brackets`` () =
    let actual ="[]"
    Assert.That(matched actual, Is.True)

[<Test>]
[<Ignore("Remove to run test")>]
let ``Empty string`` () =
    let actual =""
    Assert.That(matched actual, Is.True)

[<Test>]
[<Ignore("Remove to run test")>]
let ``Unpaired brackets`` () =
    let actual ="[["
    Assert.That(matched actual, Is.False)

[<Test>]
[<Ignore("Remove to run test")>]
let ``Wrong ordered brackets`` () =
    let actual ="}{"
    Assert.That(matched actual, Is.False)

[<Test>]
[<Ignore("Remove to run test")>]
let ``Paired with whitespace`` () =
    let actual ="{ }"
    Assert.That(matched actual, Is.True)

[<Test>]
[<Ignore("Remove to run test")>]
let ``Simple nested brackets`` () =
    let actual ="{[]}"
    Assert.That(matched actual, Is.True)

[<Test>]
[<Ignore("Remove to run test")>]
let ``Several paired brackets`` () =
    let actual ="{}[]"
    Assert.That(matched actual, Is.True)

[<Test>]
[<Ignore("Remove to run test")>]
let ``Paired and nested brackets`` () =
    let actual ="([{}({}[])])"
    Assert.That(matched actual, Is.True)

[<Test>]
[<Ignore("Remove to run test")>]
let ``Unpaired and nested brackets`` () =
    let actual ="([{])"
    Assert.That(matched actual, Is.False)

[<Test>]
[<Ignore("Remove to run test")>]
let ``Paired and wrong nested brackets`` () =
    let actual ="[({]})"
    Assert.That(matched actual, Is.False)

[<Test>]
[<Ignore("Remove to run test")>]
let ``Math expression`` () =
    let actual ="(((185 + 223.85) * 15) - 543)/2"
    Assert.That(matched actual, Is.True)

[<Test>]
[<Ignore("Remove to run test")>]
let ``Complex latex expression`` () =
    let actual ="\\left(\\begin{array}{cc} \\frac{1}{3} & x\\\\ \\mathrm{e}^{x} &... x^2 \\end{array}\\right)"
    Assert.That(matched actual, Is.True)