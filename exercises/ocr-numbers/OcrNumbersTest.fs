module OcrNumbersTest

open NUnit.Framework

open OcrNumbers

[<Test>]
let ``Recognizes zero`` () = 
    let converted = convert (" _ " + "\n" +
                              "| |" + "\n" +
                              "|_|" + "\n" +
                              "   ")
    Assert.That(converted, Is.EqualTo("0"))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Recognizes one`` () = 
    let converted = convert ("   " + "\n" +
                             "  |" + "\n" +
                             "  |" + "\n" +
                             "   ")
    Assert.That(converted, Is.EqualTo("1"))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Recognizes two`` () = 
    let converted = convert (" _ " + "\n" +
                             " _|" + "\n" +
                             "|_ " + "\n" +
                             "   ")
    Assert.That(converted, Is.EqualTo("2"))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Recognizes three`` () = 
    let converted = convert (" _ " + "\n" +
                             " _|" + "\n" +
                             " _|" + "\n" +
                             "   ")
    Assert.That(converted, Is.EqualTo("3"))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Recognizes four`` () = 
    let converted = convert ("   " + "\n" +
                             "|_|" + "\n" +
                             "  |" + "\n" +
                             "   ")
    Assert.That(converted, Is.EqualTo("4"))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Recognizes five`` () = 
    let converted = convert (" _ " + "\n" +
                             "|_ " + "\n" +
                             " _|" + "\n" +
                             "   ")
    Assert.That(converted, Is.EqualTo("5"))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Recognizes six`` () = 
    let converted = convert (" _ " + "\n" +
                             "|_ " + "\n" +
                             "|_|" + "\n" +
                             "   ")
    Assert.That(converted, Is.EqualTo("6"))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Recognizes seven`` () = 
    let converted = convert (" _ " + "\n" +
                             "  |" + "\n" +
                             "  |" + "\n" +
                             "   ")
    Assert.That(converted, Is.EqualTo("7"))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Recognizes eight`` () = 
    let converted = convert (" _ " + "\n" +
                             "|_|" + "\n" +
                             "|_|" + "\n" +
                             "   ")
    Assert.That(converted, Is.EqualTo("8"))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Recognizes nine`` () = 
    let converted = convert (" _ " + "\n" +
                             "|_|" + "\n" +
                             " _|" + "\n" +
                             "   ")
    Assert.That(converted, Is.EqualTo("9"))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Recognizes garble`` () = 
    let converted = convert ("   " + "\n" +
                             "| |" + "\n" +
                             "| |" + "\n" +
                             "   ")
    Assert.That(converted, Is.EqualTo("?"))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Recognizes ten`` () = 
    let converted = convert ("    _ " + "\n" +
                             "  || |" + "\n" +
                             "  ||_|" + "\n" +
                             "       ")
    Assert.That(converted, Is.EqualTo("10"))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Recognizes 110101100`` () = 
    let converted = convert ("       _     _        _  _ " + "\n" +
                             "  |  || |  || |  |  || || |" + "\n" +
                             "  |  ||_|  ||_|  |  ||_||_|" + "\n" +
                             "                            ")
    Assert.That(converted, Is.EqualTo("110101100"))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Recognizes numbers and garble`` () = 
    let converted = convert ("       _     _           _ " + "\n" +
                             "  |  || |  || |     || || |" + "\n" +
                             "  |  | _|  ||_|  |  ||_||_|" + "\n" +
                             "                            ")
    Assert.That(converted, Is.EqualTo("11?10?1?0"))

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
    Assert.That(converted, Is.EqualTo("123,456,789"))
