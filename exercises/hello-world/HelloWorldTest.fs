module HelloWorldTest

open NUnit.Framework
open FsUnit

open HelloWorld

[<Test>]
let ``Say hi!`` () =
    hello |> should equal "Hello, World!"