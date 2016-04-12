module PangramTest

open NUnit.Framework

open Pangram

[<Test>]
let ``Empty sentence`` () =
    let input = ""
    Assert.That(isPangram input, Is.False)

[<Test>]
[<Ignore("Remove to run test")>]
let ``Pangram with only lower case`` () =
    let input = "the quick brown fox jumps over the lazy dog"
    Assert.That(isPangram input, Is.True)

[<Test>]
[<Ignore("Remove to run test")>]
let ``Missing character 'x'`` () =
    let input = "a quick movement of the enemy will jeopardize five gunboats"
    Assert.That(isPangram input, Is.False)
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Pangram with mixed case and punctuation`` () =
    let input = "\"Five quacking Zephyrs jolt my wax bed.\""
    Assert.That(isPangram input, Is.True)

[<Test>]
[<Ignore("Remove to run test")>]
let ``Pangram with non ascii characters`` () =
    let input = "Victor jagt zwölf Boxkämpfer quer über den großen Sylter Deich."
    Assert.That(isPangram input, Is.True)