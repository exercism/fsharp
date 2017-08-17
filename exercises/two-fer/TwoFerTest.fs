module TwoFerTest

open NUnit.Framework

open TwoFer

[<Test>]
let ``No name given`` () =
    Assert.That(getResponse None, Is.EqualTo("One for you, one for me."))

[<Test>]
[<Ignore("Remove to run test")>]
let ``A name given`` () =
    Assert.That(getResponse (Some "Alice")), Is.EqualTo("One for Alice, one for me."))
	
[<Test>]
[<Ignore("Remove to run test")>]
let ``Another name given`` () =
    Assert.That(getResponse (Some "Bob")), Is.EqualTo("One for Bob, one for me."))