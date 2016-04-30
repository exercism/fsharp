module SayTest

open NUnit.Framework

open Say

[<Test>]
let ``Zero`` () =
    Assert.That(inEnglish 0L, Is.EqualTo(Some "zero"))

[<Test>]
[<Ignore("Remove to run test")>]
let ``One`` () =
    Assert.That(inEnglish 1L, Is.EqualTo(Some "one"))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Fourteen`` () =
    Assert.That(inEnglish 14L, Is.EqualTo(Some "fourteen"))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Twenty`` () =
    Assert.That(inEnglish 20L, Is.EqualTo(Some "twenty"))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Twenty-two`` () =
    Assert.That(inEnglish 22L, Is.EqualTo(Some "twenty-two"))

[<Test>]
[<Ignore("Remove to run test")>]
let ``One hundred`` () =
    Assert.That(inEnglish 100L, Is.EqualTo(Some "one hundred"))

[<Test>]
[<Ignore("Remove to run test")>]
let ``One hundred twenty-three`` () =
    Assert.That(inEnglish 123L, Is.EqualTo(Some "one hundred twenty-three"))

[<Test>]
[<Ignore("Remove to run test")>]
let ``One thousand`` () =
    Assert.That(inEnglish 1000L, Is.EqualTo(Some "one thousand"))

[<Test>]
[<Ignore("Remove to run test")>]
let ``One thousand two hundred thirty-four`` () =
    Assert.That(inEnglish 1234L, Is.EqualTo(Some "one thousand two hundred thirty-four"))

[<Test>]
[<Ignore("Remove to run test")>]
let ``One million`` () =
    Assert.That(inEnglish 1000000L, Is.EqualTo(Some "one million"))

[<Test>]
[<Ignore("Remove to run test")>]
let ``One million two`` () =
    Assert.That(inEnglish 1000002L, Is.EqualTo(Some "one million two"))

[<Test>]
[<Ignore("Remove to run test")>]
let ``One million two thousand three hundred forty-five`` () =
    Assert.That(inEnglish 1002345L, Is.EqualTo(Some "one million two thousand three hundred forty-five"))

[<Test>]
[<Ignore("Remove to run test")>]
let ``One billion`` () =
    Assert.That(inEnglish 1000000000L, Is.EqualTo(Some "one billion"))

[<Test>]
[<Ignore("Remove to run test")>]
let ``A big number`` () =
    Assert.That(inEnglish 987654321123L, Is.EqualTo(Some "nine hundred eighty-seven billion six hundred fifty-four million three hundred twenty-one thousand one hundred twenty-three"))
 
[<Test>]
[<Ignore("Remove to run test")>]
let ``Lower bound`` () =
    Assert.That(inEnglish -1L, Is.EqualTo(None))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Upper bound`` () =
    Assert.That(inEnglish 1000000000000L, Is.EqualTo(None))