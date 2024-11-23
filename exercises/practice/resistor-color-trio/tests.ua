module ResistorColorTrioTests

open FsUnit.Xunit
open Xunit

open ResistorColorTrio

[<Fact>]
let ``Orange and orange and black`` () =
    label ["orange"; "orange"; "black"] |> should equal "33 ohms"

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Blue and grey and brown`` () =
    label ["blue"; "grey"; "brown"] |> should equal "680 ohms"

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Red and black and red`` () =
    label ["red"; "black"; "red"] |> should equal "2 kiloohms"

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Green and brown and orange`` () =
    label ["green"; "brown"; "orange"] |> should equal "51 kiloohms"

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Yellow and violet and yellow`` () =
    label ["yellow"; "violet"; "yellow"] |> should equal "470 kiloohms"

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Blue and violet and blue`` () =
    label ["blue"; "violet"; "blue"] |> should equal "67 megaohms"

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Minimum possible value`` () =
    label ["black"; "black"; "black"] |> should equal "0 ohms"

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Maximum possible value`` () =
    label ["white"; "white"; "white"] |> should equal "99 gigaohms"

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``First two colors make an invalid octal number`` () =
    label ["black"; "grey"; "black"] |> should equal "8 ohms"

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Ignore extra colors`` () =
    label ["blue"; "green"; "yellow"; "orange"] |> should equal "650 kiloohms"

