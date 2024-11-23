

[<Fact>]
let ``Resident who drinks water`` () =
    drinksWater |> should equal Norwegian

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Resident who owns zebra`` () =
    ownsZebra |> should equal Japanese

