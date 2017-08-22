module OcrNumbersTest

open NUnit.Framework
open FsUnit

open OcrNumbers

[<Test>]
let ``Recognizes zero`` () = 
    let converted = convert (" _ " + "\n" +
                              "| |" + "\n" +
                              "|_|" + "\n" +
                              "   ")
    converted |> should equal "0"

[<Test>]
[<Ignore("Remove to run test")>]
let ``Recognizes one`` () = 
    let converted = convert ("   " + "\n" +
                             "  |" + "\n" +
                             "  |" + "\n" +
                             "   ")
    converted |> should equal "1"

[<Test>]
[<Ignore("Remove to run test")>]
let ``Recognizes two`` () = 
    let converted = convert (" _ " + "\n" +
                             " _|" + "\n" +
                             "|_ " + "\n" +
                             "   ")
    converted |> should equal "2"

[<Test>]
[<Ignore("Remove to run test")>]
let ``Recognizes three`` () = 
    let converted = convert (" _ " + "\n" +
                             " _|" + "\n" +
                             " _|" + "\n" +
                             "   ")
    converted |> should equal "3"

[<Test>]
[<Ignore("Remove to run test")>]
let ``Recognizes four`` () = 
    let converted = convert ("   " + "\n" +
                             "|_|" + "\n" +
                             "  |" + "\n" +
                             "   ")
    converted |> should equal "4"

[<Test>]
[<Ignore("Remove to run test")>]
let ``Recognizes five`` () = 
    let converted = convert (" _ " + "\n" +
                             "|_ " + "\n" +
                             " _|" + "\n" +
                             "   ")
    converted |> should equal "5"

[<Test>]
[<Ignore("Remove to run test")>]
let ``Recognizes six`` () = 
    let converted = convert (" _ " + "\n" +
                             "|_ " + "\n" +
                             "|_|" + "\n" +
                             "   ")
    converted |> should equal "6"

[<Test>]
[<Ignore("Remove to run test")>]
let ``Recognizes seven`` () = 
    let converted = convert (" _ " + "\n" +
                             "  |" + "\n" +
                             "  |" + "\n" +
                             "   ")
    converted |> should equal "7"

[<Test>]
[<Ignore("Remove to run test")>]
let ``Recognizes eight`` () = 
    let converted = convert (" _ " + "\n" +
                             "|_|" + "\n" +
                             "|_|" + "\n" +
                             "   ")
    converted |> should equal "8"

[<Test>]
[<Ignore("Remove to run test")>]
let ``Recognizes nine`` () = 
    let converted = convert (" _ " + "\n" +
                             "|_|" + "\n" +
                             " _|" + "\n" +
                             "   ")
    converted |> should equal "9"

[<Test>]
[<Ignore("Remove to run test")>]
let ``Recognizes garble`` () = 
    let converted = convert ("   " + "\n" +
                             "| |" + "\n" +
                             "| |" + "\n" +
                             "   ")
    converted |> should equal "?"

[<Test>]
[<Ignore("Remove to run test")>]
let ``Recognizes ten`` () = 
    let converted = convert ("    _ " + "\n" +
                             "  || |" + "\n" +
                             "  ||_|" + "\n" +
                             "       ")
    converted |> should equal "10"

[<Test>]
[<Ignore("Remove to run test")>]
let ``Recognizes 110101100`` () = 
    let converted = convert ("       _     _        _  _ " + "\n" +
                             "  |  || |  || |  |  || || |" + "\n" +
                             "  |  ||_|  ||_|  |  ||_||_|" + "\n" +
                             "                            ")
    converted |> should equal "110101100"

[<Test>]
[<Ignore("Remove to run test")>]
let ``Recognizes numbers and garble`` () = 
    let converted = convert ("       _     _           _ " + "\n" +
                             "  |  || |  || |     || || |" + "\n" +
                             "  |  | _|  ||_|  |  ||_||_|" + "\n" +
                             "                            ")
    converted |> should equal "11?10?1?0"

[<Test>]
[<Ignore("Remove to run test")>]
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
