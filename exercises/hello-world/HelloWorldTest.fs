module HelloWorldTest

open Xunit
open FsUnit

open HelloWorld

[<Test>]
let ``Say hi!`` () =
    hello |> should equal "Hello, World!"