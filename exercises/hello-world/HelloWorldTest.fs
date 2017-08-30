module HelloWorldTest

open Xunit
open FsUnit.Xunit

open HelloWorld

[<Fact>]
let ``Say hi!`` () =
    hello |> should equal "Hello, World!"