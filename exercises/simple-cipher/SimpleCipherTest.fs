module SimpleCipherTest

open System
open NUnit.Framework

open SimpleCipher

let plainText = "abcdefghij"
let key = "abcdefghij";

[<Test>]
let ``Encode random uses key made of letters`` () =
    let (key, _) = encodeRandom plainText
    Assert.That(key, Does.Match("[a-z]+"))
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Encode random uses key of 100 characters`` () =
    let (key, _) = encodeRandom plainText
    Assert.That(key, Has.Length.EqualTo(100))
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Encode random uses randomly generated key`` () =
    let keys = List.init 100 (fun _ -> encodeRandom plainText |> fst)
    Assert.That(keys |> List.distinct, Is.EqualTo(keys))

// Here we take advantage of the fact that plaintext of "aaa..." outputs
// the key. This is a critical problem with shift ciphers, some characters
// will always output the key verbatim.
[<Test>]
[<Ignore("Remove to run test")>]
let ``Encode random can encode`` () =
    let (key, encoded) = encodeRandom "aaaaaaaaaa"
    Assert.That(encoded, Is.EqualTo(key.Substring(0, 10)))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Encode random can decode`` () =    
    let (key, _) = encodeRandom "aaaaaaaaaa"
    Assert.That(decode key (key.Substring(0, 10)), Is.EqualTo("aaaaaaaaaa"))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Encode random is reversible`` () =
    let (key, encoded) = encodeRandom plainText
    Assert.That(decode key encoded, Is.EqualTo(plainText))
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Cipher can encode with given key`` () =
    Assert.That(encode key "aaaaaaaaaa", Is.EqualTo("abcdefghij"))
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Cipher can decode with given key`` () =
    Assert.That(decode key "abcdefghij", Is.EqualTo("aaaaaaaaaa"))
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Cipher is reversible given key`` () =
    Assert.That(encode key plainText |> decode key, Is.EqualTo(plainText))
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Cipher can double shift encode`` () =
    let plainText = "iamapandabear"
    Assert.That(encode plainText plainText, Is.EqualTo("qayaeaagaciai"))
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Cipher can wrap encode`` () =
    Assert.That(encode key "zzzzzzzzzz", Is.EqualTo("zabcdefghi"))
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Cipher can encode a message that is shorter than the key`` () =
    Assert.That(encode key "aaaaa", Is.EqualTo("abcde"))
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Cipher can decode a message that is shorter than the key`` () =
    Assert.That(decode key "abcde", Is.EqualTo("aaaaa"))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Encode throws with an all caps key`` () =
    let key = "ABCDEF"
    Assert.That((fun () -> encode key plainText |> ignore), Throws.Exception)
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Encode throws with any caps key`` () =
    let key = "abcdEFg"
    Assert.That((fun () -> encode key plainText |> ignore), Throws.Exception)

[<Test>]
[<Ignore("Remove to run test")>]
let ``Encode throws with numeric key`` () =
    let key = "12345"
    Assert.That((fun () -> encode key plainText |> ignore), Throws.Exception)

[<Test>]
[<Ignore("Remove to run test")>]
let ``Encode throws with any numeric key`` () =
    let key = "abcd345ef"
    Assert.That((fun () -> encode key plainText |> ignore), Throws.Exception)
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Encode throws with empty key`` () =
    let key = ""
    Assert.That((fun () -> encode key plainText |> ignore), Throws.Exception)
