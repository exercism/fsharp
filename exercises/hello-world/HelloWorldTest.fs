module HelloWorldTest

open NUnit.Framework

open HelloWorld

[<Test>]
let ``No name`` () =
    Assert.That(hello None, Is.EqualTo("Hello, World!"))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Sample name`` () =
    Assert.That(hello (Some "Alice"), Is.EqualTo("Hello, Alice!"))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Other sample name`` () =
    Assert.That(hello (Some "Bob"), Is.EqualTo("Hello, Bob!"))