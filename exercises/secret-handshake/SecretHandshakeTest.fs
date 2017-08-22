module SecretHandshakeTest

open NUnit.Framework
open FsUnit

open SecretHandshake

[<Test>]
let ``Test 1 handshake to wink`` () =
    handshake 1 |> should equal ["wink"]
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Test 10 handshake to double blink`` () =
    handshake 2 |> should equal ["double blink"]
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Test 100 handshake to close your eyes`` () =
    handshake 4 |> should equal ["close your eyes"]
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Test 1000 handshake to close your eyes`` () =
    handshake 8 |> should equal ["jump"]
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Test handshake 11 to wink and double blink`` () =
    handshake 3 |> should equal ["wink"; "double blink"]
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Test handshake 10011 to double blink and wink`` () =
    handshake 19 |> should equal ["double blink"; "wink"]
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Test handshake 11111 to all commands reversed`` () =
    handshake 31 |> should equal ["jump"; "close your eyes"; "double blink"; "wink"]