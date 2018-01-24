// This file was auto-generated based on version 1.1.0 of the canonical data.

module HelloWorldTest

open FsUnit.Xunit
open Xunit

open HelloWorld

[<Fact>]
let ``Say Hi!`` () =
    hello |> should equal "Hello, World!"

