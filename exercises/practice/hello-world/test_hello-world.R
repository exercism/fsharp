module HelloWorldTests



[<Fact>]
let ``Say Hi!`` () =
    hello |> should equal "Hello, World!"

