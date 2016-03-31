module SecretHandshakeTest

open NUnit.Framework

open SecretHandshake

[<Test>]
let ``Test 1 handshake to wink`` () =
    Assert.That(handshake 1, Is.EqualTo(["wink"]))
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Test 10 handshake to double blink`` () =
    Assert.That(handshake 2, Is.EqualTo(["double blink"]))
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Test 100 handshake to close your eyes`` () =
    Assert.That(handshake 4, Is.EqualTo(["close your eyes"]))
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Test 1000 handshake to close your eyes`` () =
    Assert.That(handshake 8, Is.EqualTo(["jump"]))
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Test handshake 11 to wink and double blink`` () =
    Assert.That(handshake 3, Is.EqualTo(["wink"; "double blink"]))
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Test handshake 10011 to double blink and wink`` () =
    Assert.That(handshake 19, Is.EqualTo(["double blink"; "wink"]))
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Test handshake 11111 to all commands reversed`` () =
    Assert.That(handshake 31, Is.EqualTo(["jump"; "close your eyes"; "double blink"; "wink"]))