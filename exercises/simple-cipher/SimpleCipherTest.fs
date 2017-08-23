module SimpleCipherTest

open System
open System.Text.RegularExpressions
open NUnit.Framework
open FsUnit

open SimpleCipher

let plainText = "abcdefghij"
let key = "abcdefghij";

[<Test>]
let ``Encode random uses key made of letters`` () =
    let (key, _) = encodeRandom plainText
    Regex.IsMatch(key, "[a-z]+") |> should equal true
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Encode random uses key of 100 characters`` () =
    let (key, _) = encodeRandom plainText
    key |> should haveLength 100
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Encode random uses randomly generated key`` () =
    let keys = List.init 100 (fun _ -> encodeRandom plainText |> fst)
    keys |> List.distinct |> should equal keys

// Here we take advantage of the fact that plaintext of "aaa..." outputs
// the key. This is a critical problem with shift ciphers, some characters
// will always output the key verbatim.
[<Test>]
[<Ignore("Remove to run test")>]
let ``Encode random can encode`` () =
    let (key, encoded) = encodeRandom "aaaaaaaaaa"
    encoded |> should equal <| key.Substring(0, 10)

[<Test>]
[<Ignore("Remove to run test")>]
let ``Encode random can decode`` () =    
    let (key, _) = encodeRandom "aaaaaaaaaa"
    decode key (key.Substring(0, 10)) |> should equal "aaaaaaaaaa"

[<Test>]
[<Ignore("Remove to run test")>]
let ``Encode random is reversible`` () =
    let (key, encoded) = encodeRandom plainText
    decode key encoded |> should equal plainText
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Cipher can encode with given key`` () =
    encode key "aaaaaaaaaa" |> should equal "abcdefghij"
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Cipher can decode with given key`` () =
    decode key "abcdefghij" |> should equal "aaaaaaaaaa"
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Cipher is reversible given key`` () =
    encode key plainText |> decode key |> should equal plainText
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Cipher can double shift encode`` () =
    let plainText = "iamapandabear"
    encode plainText plainText |> should equal "qayaeaagaciai"
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Cipher can wrap encode`` () =
    encode key "zzzzzzzzzz" |> should equal "zabcdefghi"
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Cipher can encode a message that is shorter than the key`` () =
    encode key "aaaaa" |> should equal "abcde"
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Cipher can decode a message that is shorter than the key`` () =
    decode key "abcde" |> should equal "aaaaa"

[<Test>]
[<Ignore("Remove to run test")>]
let ``Encode throws with an all caps key`` () =
    let key = "ABCDEF"
    (fun () -> encode key plainText |> ignore) |> should throw typeof<Exception>
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Encode throws with any caps key`` () =
    let key = "abcdEFg"
    (fun () -> encode key plainText |> ignore) |> should throw typeof<Exception>

[<Test>]
[<Ignore("Remove to run test")>]
let ``Encode throws with numeric key`` () =
    let key = "12345"
    (fun () -> encode key plainText |> ignore) |> should throw typeof<Exception>

[<Test>]
[<Ignore("Remove to run test")>]
let ``Encode throws with any numeric key`` () =
    let key = "abcd345ef"
    (fun () -> encode key plainText |> ignore) |> should throw typeof<Exception>
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Encode throws with empty key`` () =
    let key = ""
    (fun () -> encode key plainText |> ignore) |> should throw typeof<Exception>
