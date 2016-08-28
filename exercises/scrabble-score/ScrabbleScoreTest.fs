module ScrabbleScoreTest

open NUnit.Framework
open ScrabbleScore
  
[<Test>]
let ``Empty word scores zero`` () =
    Assert.That(score "", Is.EqualTo(0))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Whitespace scores zero`` () =
    Assert.That(score " \t\n", Is.EqualTo(0))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Scores very short word`` () =
    Assert.That(score "a", Is.EqualTo(1))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Scores other very short word`` () =
    Assert.That(score "f", Is.EqualTo(4))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Simple word scores the number of letters`` () =
    Assert.That(score "street", Is.EqualTo(6))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Complicated word scores more`` () =
    Assert.That(score "quirky", Is.EqualTo(22))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Scores are case insensitive`` () =
    Assert.That(score "OXYPHENBUTAZONE", Is.EqualTo(41))