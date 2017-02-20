module HelloWorldTest

open NUnit.Framework

open HelloWorld

[<Test>]
let ``Say hi!`` () =
    Assert.That(hello, Is.EqualTo("Hello, World!"))