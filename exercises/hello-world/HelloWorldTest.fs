module HelloWorldTest

open Xunit
open FsUnit

open HelloWorld

[<Fact>]
let ``Say hi!`` () =
    hello |> should equal "Hello, World!"