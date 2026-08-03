module CamiciaTests

open FsUnit.Xunit
open Xunit

open Camicia

[<Fact>]
let ``Two cards, one trick`` () =
    let playerA = [|"2"|]
    let playerB = [|"3"|]
    let expected = { Status = Finished; Tricks = 1; Cards = 2 }
    simulateGame playerA playerB |> should equal expected

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Three cards, one trick`` () =
    let playerA = [|"2"; "4"|]
    let playerB = [|"3"|]
    let expected = { Status = Finished; Tricks = 1; Cards = 3 }
    simulateGame playerA playerB |> should equal expected

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Four cards, one trick`` () =
    let playerA = [|"2"; "4"|]
    let playerB = [|"3"; "5"; "6"|]
    let expected = { Status = Finished; Tricks = 1; Cards = 4 }
    simulateGame playerA playerB |> should equal expected

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``The ace reigns supreme`` () =
    let playerA = [|"2"; "A"|]
    let playerB = [|"3"; "4"; "5"; "6"; "7"|]
    let expected = { Status = Finished; Tricks = 1; Cards = 7 }
    simulateGame playerA playerB |> should equal expected

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``The king beats ace`` () =
    let playerA = [|"2"; "A"|]
    let playerB = [|"3"; "4"; "5"; "6"; "K"|]
    let expected = { Status = Finished; Tricks = 1; Cards = 7 }
    simulateGame playerA playerB |> should equal expected

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``The queen seduces the king`` () =
    let playerA = [|"2"; "A"; "7"; "8"; "Q"|]
    let playerB = [|"3"; "4"; "5"; "6"; "K"|]
    let expected = { Status = Finished; Tricks = 1; Cards = 10 }
    simulateGame playerA playerB |> should equal expected

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``The jack betrays the queen`` () =
    let playerA = [|"2"; "A"; "7"; "8"; "Q"|]
    let playerB = [|"3"; "4"; "5"; "6"; "K"; "9"; "J"|]
    let expected = { Status = Finished; Tricks = 1; Cards = 12 }
    simulateGame playerA playerB |> should equal expected

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``The 10 just wants to put on a show`` () =
    let playerA = [|"2"; "A"; "7"; "8"; "Q"; "10"|]
    let playerB = [|"3"; "4"; "5"; "6"; "K"; "9"; "J"|]
    let expected = { Status = Finished; Tricks = 1; Cards = 13 }
    simulateGame playerA playerB |> should equal expected

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Simple loop with decks of 3 cards`` () =
    let playerA = [|"J"; "2"; "3"|]
    let playerB = [|"4"; "J"; "5"|]
    let expected = { Status = Loop; Tricks = 3; Cards = 8 }
    simulateGame playerA playerB |> should equal expected

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``The story is starting to get a bit complicated`` () =
    let playerA = [| "2"; "6"; "6"; "J"; "4"; "K"; "Q"; "10";
                  "K"; "J"; "Q"; "2"; "3"; "K"; "5"; "6";
                  "Q"; "Q"; "A"; "A"; "6"; "9"; "K"; "A";
                  "8"; "K"; "2"; "A"; "9"; "A"; "Q"; "4";
                  "K"; "K"; "K"; "3"; "5"; "K"; "8"; "Q";
                  "3"; "Q"; "7"; "J"; "K"; "J"; "9"; "J";
                  "3"; "3"; "K"; "K"; "Q"; "A"; "K"; "7";
                  "10"; "A"; "Q"; "7"; "10"; "J"; "4"; "5";
                  "J"; "9"; "10"; "Q"; "J"; "J"; "K"; "6";
                  "10"; "J"; "6"; "Q"; "J"; "5"; "J"; "Q";
                  "Q"; "8"; "3"; "8"; "A"; "2"; "6"; "9";
                  "K"; "7"; "J"; "K"; "K"; "8"; "K"; "Q";
                  "6"; "10"; "J"; "10"; "J"; "Q"; "J"; "10";
                  "3"; "8"; "K"; "A"; "6"; "9"; "K"; "2";
                  "A"; "A"; "10"; "J"; "6"; "A"; "4"; "J";
                  "A"; "J"; "J"; "6"; "2"; "J"; "3"; "K";
                  "2"; "5"; "9"; "J"; "9"; "6"; "K"; "A";
                  "5"; "Q"; "J"; "2"; "Q"; "K"; "A"; "3";
                  "K"; "J"; "K"; "2"; "5"; "6"; "Q"; "J";
                  "Q"; "Q"; "J"; "2"; "J"; "9"; "Q"; "7";
                  "7"; "A"; "Q"; "7"; "Q"; "J"; "K"; "J";
                  "A"; "7"; "7"; "8"; "Q"; "10"; "J"; "10";
                  "J"; "J"; "9"; "2"; "A"; "2" |]
    let playerB = [| "7"; "2"; "10"; "K"; "8"; "2"; "J"; "9";
                  "A"; "5"; "6"; "J"; "Q"; "6"; "K"; "6";
                  "5"; "A"; "4"; "Q"; "7"; "J"; "7"; "10";
                  "2"; "Q"; "8"; "2"; "2"; "K"; "J"; "A";
                  "5"; "5"; "A"; "4"; "Q"; "6"; "Q"; "K";
                  "10"; "8"; "Q"; "2"; "10"; "J"; "A"; "Q";
                  "8"; "Q"; "Q"; "J"; "J"; "A"; "A"; "9";
                  "10"; "J"; "K"; "4"; "Q"; "10"; "10"; "J";
                  "K"; "10"; "2"; "J"; "7"; "A"; "K"; "K";
                  "J"; "A"; "J"; "10"; "8"; "K"; "A"; "7";
                  "Q"; "Q"; "J"; "3"; "Q"; "4"; "A"; "3";
                  "A"; "Q"; "Q"; "Q"; "5"; "4"; "K"; "J";
                  "10"; "A"; "Q"; "J"; "6"; "J"; "A"; "10";
                  "A"; "5"; "8"; "3"; "K"; "5"; "9"; "Q";
                  "8"; "7"; "7"; "J"; "7"; "Q"; "Q"; "Q";
                  "A"; "7"; "8"; "9"; "A"; "Q"; "A"; "K";
                  "8"; "A"; "A"; "J"; "8"; "4"; "8"; "K";
                  "J"; "A"; "10"; "Q"; "8"; "J"; "8"; "6";
                  "10"; "Q"; "J"; "J"; "A"; "A"; "J"; "5";
                  "Q"; "6"; "J"; "K"; "Q"; "8"; "K"; "4";
                  "Q"; "Q"; "6"; "J"; "K"; "4"; "7"; "J";
                  "J"; "9"; "9"; "A"; "Q"; "Q"; "K"; "A";
                  "6"; "5"; "K" |]
    let expected = { Status = Finished; Tricks = 1; Cards = 361 }
    simulateGame playerA playerB |> should equal expected

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Two tricks`` () =
    let playerA = [|"J"|]
    let playerB = [|"3"; "J"|]
    let expected = { Status = Finished; Tricks = 2; Cards = 5 }
    simulateGame playerA playerB |> should equal expected

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``More tricks`` () =
    let playerA = [|"J"; "2"; "4"|]
    let playerB = [|"3"; "J"; "A"|]
    let expected = { Status = Finished; Tricks = 4; Cards = 12 }
    simulateGame playerA playerB |> should equal expected

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Simple loop with decks of 4 cards`` () =
    let playerA = [|"2"; "3"; "J"; "6"|]
    let playerB = [|"K"; "5"; "J"; "7"|]
    let expected = { Status = Loop; Tricks = 4; Cards = 16 }
    simulateGame playerA playerB |> should equal expected

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Easy card combination`` () =
    let playerA = [| "4"; "8"; "7"; "5"; "4"; "10"; "3"; "9";
                  "7"; "3"; "10"; "10"; "6"; "8"; "2"; "8";
                  "5"; "4"; "5"; "9"; "6"; "5"; "2"; "8";
                  "10"; "9" |]
    let playerB = [| "6"; "9"; "4"; "7"; "2"; "2"; "3"; "6";
                  "7"; "3"; "A"; "A"; "A"; "A"; "K"; "K";
                  "K"; "K"; "Q"; "Q"; "Q"; "Q"; "J"; "J";
                  "J"; "J" |]
    let expected = { Status = Finished; Tricks = 4; Cards = 40 }
    simulateGame playerA playerB |> should equal expected

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Easy card combination, inverted decks`` () =
    let playerA = [| "3"; "3"; "5"; "7"; "3"; "2"; "10"; "7";
                  "6"; "7"; "A"; "A"; "A"; "A"; "K"; "K";
                  "K"; "K"; "Q"; "Q"; "Q"; "Q"; "J"; "J";
                  "J"; "J" |]
    let playerB = [| "5"; "10"; "8"; "2"; "6"; "7"; "2"; "4";
                  "9"; "2"; "6"; "10"; "10"; "5"; "4"; "8";
                  "4"; "8"; "6"; "9"; "8"; "5"; "9"; "3";
                  "4"; "9" |]
    let expected = { Status = Finished; Tricks = 4; Cards = 40 }
    simulateGame playerA playerB |> should equal expected

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Mirrored decks`` () =
    let playerA = [| "2"; "A"; "3"; "A"; "3"; "K"; "4"; "K";
                  "2"; "Q"; "2"; "Q"; "10"; "J"; "5"; "J";
                  "6"; "10"; "2"; "9"; "10"; "7"; "3"; "9";
                  "6"; "9" |]
    let playerB = [| "6"; "A"; "4"; "A"; "7"; "K"; "4"; "K";
                  "7"; "Q"; "7"; "Q"; "5"; "J"; "8"; "J";
                  "4"; "5"; "8"; "9"; "10"; "6"; "8"; "3";
                  "8"; "5" |]
    let expected = { Status = Finished; Tricks = 4; Cards = 59 }
    simulateGame playerA playerB |> should equal expected

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Opposite decks`` () =
    let playerA = [| "4"; "A"; "9"; "A"; "4"; "K"; "9"; "K";
                  "6"; "Q"; "8"; "Q"; "8"; "J"; "10"; "J";
                  "9"; "8"; "4"; "6"; "3"; "6"; "5"; "2";
                  "4"; "3" |]
    let playerB = [| "10"; "7"; "3"; "2"; "9"; "2"; "7"; "8";
                  "7"; "5"; "J"; "7"; "J"; "10"; "Q"; "10";
                  "Q"; "3"; "K"; "5"; "K"; "6"; "A"; "2";
                  "A"; "5" |]
    let expected = { Status = Finished; Tricks = 21; Cards = 151 }
    simulateGame playerA playerB |> should equal expected

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Random decks #1`` () =
    let playerA = [| "K"; "10"; "9"; "8"; "J"; "8"; "6"; "9";
                  "7"; "A"; "K"; "5"; "4"; "4"; "J"; "5";
                  "J"; "4"; "3"; "5"; "8"; "6"; "7"; "7";
                  "4"; "9" |]
    let playerB = [| "6"; "3"; "K"; "A"; "Q"; "10"; "A"; "2";
                  "Q"; "8"; "2"; "10"; "10"; "2"; "Q"; "3";
                  "K"; "9"; "7"; "A"; "3"; "Q"; "5"; "J";
                  "2"; "6" |]
    let expected = { Status = Finished; Tricks = 76; Cards = 542 }
    simulateGame playerA playerB |> should equal expected

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Random decks #2`` () =
    let playerA = [| "8"; "A"; "4"; "8"; "5"; "Q"; "J"; "2";
                  "6"; "2"; "9"; "7"; "K"; "A"; "8"; "10";
                  "K"; "8"; "10"; "9"; "K"; "6"; "7"; "3";
                  "K"; "9" |]
    let playerB = [| "10"; "5"; "2"; "6"; "Q"; "J"; "A"; "9";
                  "5"; "5"; "3"; "7"; "3"; "J"; "A"; "2";
                  "Q"; "3"; "J"; "Q"; "4"; "10"; "4"; "7";
                  "4"; "6" |]
    let expected = { Status = Finished; Tricks = 42; Cards = 327 }
    simulateGame playerA playerB |> should equal expected

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Kleber 1999`` () =
    let playerA = [| "4"; "8"; "9"; "J"; "Q"; "8"; "5"; "5";
                  "K"; "2"; "A"; "9"; "8"; "5"; "10"; "A";
                  "4"; "J"; "3"; "K"; "6"; "9"; "2"; "Q";
                  "K"; "7" |]
    let playerB = [| "10"; "J"; "3"; "2"; "4"; "10"; "4"; "7";
                  "5"; "3"; "6"; "6"; "7"; "A"; "J"; "Q";
                  "A"; "7"; "2"; "10"; "3"; "K"; "9"; "6";
                  "8"; "Q" |]
    let expected = { Status = Finished; Tricks = 805; Cards = 5790 }
    simulateGame playerA playerB |> should equal expected

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Collins 2006`` () =
    let playerA = [| "A"; "8"; "Q"; "K"; "9"; "10"; "3"; "7";
                  "4"; "2"; "Q"; "3"; "2"; "10"; "9"; "K";
                  "A"; "8"; "7"; "7"; "4"; "5"; "J"; "9";
                  "2"; "10" |]
    let playerB = [| "4"; "J"; "A"; "K"; "8"; "5"; "6"; "6";
                  "A"; "6"; "5"; "Q"; "4"; "6"; "10"; "8";
                  "J"; "2"; "5"; "7"; "Q"; "J"; "3"; "3";
                  "K"; "9" |]
    let expected = { Status = Finished; Tricks = 960; Cards = 6913 }
    simulateGame playerA playerB |> should equal expected

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Mann and Wu 2007`` () =
    let playerA = [| "K"; "2"; "K"; "K"; "3"; "3"; "6"; "10";
                  "K"; "6"; "A"; "2"; "5"; "5"; "7"; "9";
                  "J"; "A"; "A"; "3"; "4"; "Q"; "4"; "8";
                  "J"; "6" |]
    let playerB = [| "4"; "5"; "2"; "Q"; "7"; "9"; "9"; "Q";
                  "7"; "J"; "9"; "8"; "10"; "3"; "10"; "J";
                  "4"; "10"; "8"; "6"; "8"; "7"; "A"; "Q";
                  "5"; "2" |]
    let expected = { Status = Finished; Tricks = 1007; Cards = 7157 }
    simulateGame playerA playerB |> should equal expected

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Nessler 2012`` () =
    let playerA = [| "10"; "3"; "6"; "7"; "Q"; "2"; "9"; "8";
                  "2"; "8"; "4"; "A"; "10"; "6"; "K"; "2";
                  "10"; "A"; "5"; "A"; "2"; "4"; "Q"; "J";
                  "K"; "4" |]
    let playerB = [| "10"; "Q"; "4"; "6"; "J"; "9"; "3"; "J";
                  "9"; "3"; "3"; "Q"; "K"; "5"; "9"; "5";
                  "K"; "6"; "5"; "7"; "8"; "J"; "A"; "7";
                  "8"; "7" |]
    let expected = { Status = Finished; Tricks = 1015; Cards = 7207 }
    simulateGame playerA playerB |> should equal expected

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Anderson 2013`` () =
    let playerA = [| "6"; "7"; "A"; "3"; "Q"; "3"; "5"; "J";
                  "3"; "2"; "J"; "7"; "4"; "5"; "Q"; "10";
                  "5"; "A"; "J"; "2"; "K"; "8"; "9"; "9";
                  "K"; "3" |]
    let playerB = [| "4"; "J"; "6"; "9"; "8"; "5"; "10"; "7";
                  "9"; "Q"; "2"; "7"; "10"; "8"; "4"; "10";
                  "A"; "6"; "4"; "A"; "6"; "8"; "Q"; "K";
                  "K"; "2" |]
    let expected = { Status = Finished; Tricks = 1016; Cards = 7225 }
    simulateGame playerA playerB |> should equal expected

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Rucklidge 2014`` () =
    let playerA = [| "8"; "J"; "2"; "9"; "4"; "4"; "5"; "8";
                  "Q"; "3"; "9"; "3"; "6"; "2"; "8"; "A";
                  "A"; "A"; "9"; "4"; "7"; "2"; "5"; "Q";
                  "Q"; "3" |]
    let playerB = [| "K"; "7"; "10"; "6"; "3"; "J"; "A"; "7";
                  "6"; "5"; "5"; "8"; "10"; "9"; "10"; "4";
                  "2"; "7"; "K"; "Q"; "10"; "K"; "6"; "J";
                  "J"; "K" |]
    let expected = { Status = Finished; Tricks = 1122; Cards = 7959 }
    simulateGame playerA playerB |> should equal expected

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Nessler 2021`` () =
    let playerA = [| "7"; "2"; "3"; "4"; "K"; "9"; "6"; "10";
                  "A"; "8"; "9"; "Q"; "7"; "A"; "4"; "8";
                  "J"; "J"; "A"; "4"; "3"; "2"; "5"; "6";
                  "6"; "J" |]
    let playerB = [| "3"; "10"; "8"; "9"; "8"; "K"; "K"; "2";
                  "5"; "5"; "7"; "6"; "4"; "3"; "5"; "7";
                  "A"; "9"; "J"; "K"; "2"; "Q"; "10"; "Q";
                  "10"; "Q" |]
    let expected = { Status = Finished; Tricks = 1106; Cards = 7972 }
    simulateGame playerA playerB |> should equal expected

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Nessler 2022`` () =
    let playerA = [| "2"; "10"; "10"; "A"; "J"; "3"; "8"; "Q";
                  "2"; "5"; "5"; "5"; "9"; "2"; "4"; "3";
                  "10"; "Q"; "A"; "K"; "Q"; "J"; "J"; "9";
                  "Q"; "K" |]
    let playerB = [| "10"; "7"; "6"; "3"; "6"; "A"; "8"; "9";
                  "4"; "3"; "K"; "J"; "6"; "K"; "4"; "9";
                  "7"; "8"; "5"; "7"; "8"; "2"; "A"; "7";
                  "4"; "6" |]
    let expected = { Status = Finished; Tricks = 1164; Cards = 8344 }
    simulateGame playerA playerB |> should equal expected

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Casella 2024, first infinite game found`` () =
    let playerA = [| "2"; "8"; "4"; "K"; "5"; "2"; "3"; "Q";
                  "6"; "K"; "Q"; "A"; "J"; "3"; "5"; "9";
                  "8"; "3"; "A"; "A"; "J"; "4"; "4"; "J";
                  "7"; "5" |]
    let playerB = [| "7"; "7"; "8"; "6"; "10"; "10"; "6"; "10";
                  "7"; "2"; "Q"; "6"; "3"; "2"; "4"; "K";
                  "Q"; "10"; "J"; "5"; "9"; "8"; "9"; "9";
                  "K"; "A" |]
    let expected = { Status = Loop; Tricks = 66; Cards = 474 }
    simulateGame playerA playerB |> should equal expected

