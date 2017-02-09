module AtbashTest

open NUnit.Framework
open Atbash

[<Test>]
let ``Encode yes`` () =
    let phrase = "yes"
    let expected = "bvh"
    let actual = encode phrase
    Assert.That(actual, Is.EqualTo(expected))

[<Test>]
[<Ignore("Remove to run test")>]     
let ``Encode no`` () =
    let phrase = "no"
    let expected = "ml"
    let actual = encode phrase
    Assert.That(actual, Is.EqualTo(expected))

[<Test>]
[<Ignore("Remove to run test")>]     
let ``Encode OMG`` () =
    let phrase = "OMG"
    let expected = "lnt"
    let actual = encode phrase
    Assert.That(actual, Is.EqualTo(expected))

[<Test>]
[<Ignore("Remove to run test")>]     
let ``Encode spaces`` () =
    let phrase = "O M G"
    let expected = "lnt"
    let actual = encode phrase
    Assert.That(actual, Is.EqualTo(expected))

[<Test>]
[<Ignore("Remove to run test")>]     
let ``Encode mindblowingly`` () =
    let phrase = "mindblowingly"
    let expected = "nrmwy oldrm tob"
    let actual = encode phrase
    Assert.That(actual, Is.EqualTo(expected))

[<Test>]
[<Ignore("Remove to run test")>]     
let ``Encode numbers`` () =
    let phrase = "Testing, 1 2 3, testing."
    let expected = "gvhgr mt123 gvhgr mt"
    let actual = encode phrase
    Assert.That(actual, Is.EqualTo(expected))

[<Test>]
[<Ignore("Remove to run test")>]     
let ``Encode deep thought`` () =
    let phrase = "Truth is fiction."
    let expected = "gifgs rhurx grlm"
    let actual = encode phrase
    Assert.That(actual, Is.EqualTo(expected))

[<Test>]
[<Ignore("Remove to run test")>]     
let ``Encode all the letters`` () =
    let phrase = "The quick brown fox jumps over the lazy dog."
    let expected = "gsvjf rxpyi ldmul cqfnk hlevi gsvoz abwlt"
    let actual = encode phrase
    Assert.That(actual, Is.EqualTo(expected))