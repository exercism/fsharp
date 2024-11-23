module HelloWorldTests

open FsUnit.Xunit
open Xunit

open HelloWorld

[<Fact>]
let ``Say Hi!`` () =
    hello |> should equal "Hello, World!"

