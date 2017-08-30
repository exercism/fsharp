module OcrNumbersTest

open Xunit
open FsUnit.Xunit

open OcrNumbers

[<Fact>]
let ``Recognizes zero`` () = 
    let converted = convert (" _ " + "\n" +
                              "| |" + "\n" +
                              "|_|" + "\n" +
                              "   ")
    converted |> should equal "0"

[<Fact(Skip = "Remove to run test")>]
let ``Recognizes one`` () = 
    let converted = convert ("   " + "\n" +
                             "  |" + "\n" +
                             "  |" + "\n" +
                             "   ")
    converted |> should equal "1"

[<Fact(Skip = "Remove to run test")>]
let ``Recognizes two`` () = 
    let converted = convert (" _ " + "\n" +
                             " _|" + "\n" +
                             "|_ " + "\n" +
                             "   ")
    converted |> should equal "2"

[<Fact(Skip = "Remove to run test")>]
let ``Recognizes three`` () = 
    let converted = convert (" _ " + "\n" +
                             " _|" + "\n" +
                             " _|" + "\n" +
                             "   ")
    converted |> should equal "3"

[<Fact(Skip = "Remove to run test")>]
let ``Recognizes four`` () = 
    let converted = convert ("   " + "\n" +
                             "|_|" + "\n" +
                             "  |" + "\n" +
                             "   ")
    converted |> should equal "4"

[<Fact(Skip = "Remove to run test")>]
let ``Recognizes five`` () = 
    let converted = convert (" _ " + "\n" +
                             "|_ " + "\n" +
                             " _|" + "\n" +
                             "   ")
    converted |> should equal "5"

[<Fact(Skip = "Remove to run test")>]
let ``Recognizes six`` () = 
    let converted = convert (" _ " + "\n" +
                             "|_ " + "\n" +
                             "|_|" + "\n" +
                             "   ")
    converted |> should equal "6"

[<Fact(Skip = "Remove to run test")>]
let ``Recognizes seven`` () = 
    let converted = convert (" _ " + "\n" +
                             "  |" + "\n" +
                             "  |" + "\n" +
                             "   ")
    converted |> should equal "7"

[<Fact(Skip = "Remove to run test")>]
let ``Recognizes eight`` () = 
    let converted = convert (" _ " + "\n" +
                             "|_|" + "\n" +
                             "|_|" + "\n" +
                             "   ")
    converted |> should equal "8"

[<Fact(Skip = "Remove to run test")>]
let ``Recognizes nine`` () = 
    let converted = convert (" _ " + "\n" +
                             "|_|" + "\n" +
                             " _|" + "\n" +
                             "   ")
    converted |> should equal "9"

[<Fact(Skip = "Remove to run test")>]
let ``Recognizes garble`` () = 
    let converted = convert ("   " + "\n" +
                             "| |" + "\n" +
                             "| |" + "\n" +
                             "   ")
    converted |> should equal "?"

[<Fact(Skip = "Remove to run test")>]
let ``Recognizes ten`` () = 
    let converted = convert ("    _ " + "\n" +
                             "  || |" + "\n" +
                             "  ||_|" + "\n" +
                             "       ")
    converted |> should equal "10"

[<Fact(Skip = "Remove to run test")>]
let ``Recognizes 110101100`` () = 
    let converted = convert ("       _     _        _  _ " + "\n" +
                             "  |  || |  || |  |  || || |" + "\n" +
                             "  |  ||_|  ||_|  |  ||_||_|" + "\n" +
                             "                            ")
    converted |> should equal "110101100"

[<Fact(Skip = "Remove to run test")>]
let ``Recognizes numbers and garble`` () = 
    let converted = convert ("       _     _           _ " + "\n" +
                             "  |  || |  || |     || || |" + "\n" +
                             "  |  | _|  ||_|  |  ||_||_|" + "\n" +
                             "                            ")
    converted |> should equal "11?10?1?0"

[<Fact(Skip = "Remove to run test")>]
let ``Recognizes multiple rows`` () = 
    let converted = convert ("    _  _ " + "\n" +
                             "  | _| _|" + "\n" +
                             "  ||_  _|" + "\n" +
                             "          " + "\n" +
                             "    _  _ " + "\n" +
                             "|_||_ |_ " + "\n" +
                             "  | _||_|" + "\n" +
                             "          " + "\n" +
                             " _  _  _ " + "\n" +
                             "  ||_||_|" + "\n" +
                             "  ||_| _|" + "\n" +
                             "          ")
    converted |> should equal "123,456,789"
