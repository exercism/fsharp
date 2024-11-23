~ "resistor-color-trio.ua" ~ ResistorColorTrio

let ``Orange and orange and black`` () =
    label ["orange"; "orange"; "black"] |> should equal "33 ohms"

let ``Blue and grey and brown`` () =
    label ["blue"; "grey"; "brown"] |> should equal "680 ohms"

let ``Red and black and red`` () =
    label ["red"; "black"; "red"] |> should equal "2 kiloohms"

let ``Green and brown and orange`` () =
    label ["green"; "brown"; "orange"] |> should equal "51 kiloohms"

let ``Yellow and violet and yellow`` () =
    label ["yellow"; "violet"; "yellow"] |> should equal "470 kiloohms"

let ``Blue and violet and blue`` () =
    label ["blue"; "violet"; "blue"] |> should equal "67 megaohms"

let ``Minimum possible value`` () =
    label ["black"; "black"; "black"] |> should equal "0 ohms"

let ``Maximum possible value`` () =
    label ["white"; "white"; "white"] |> should equal "99 gigaohms"

let ``First two colors make an invalid octal number`` () =
    label ["black"; "grey"; "black"] |> should equal "8 ohms"

let ``Ignore extra colors`` () =
    label ["blue"; "green"; "yellow"; "orange"] |> should equal "650 kiloohms"

