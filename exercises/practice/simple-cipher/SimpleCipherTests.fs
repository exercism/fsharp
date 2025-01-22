source("./simple-cipher.R")
library(testthat)

let ``Random key cipher - Can encode`` () =
    sut <- SimpleCipher()
    sut.Encode("aaaaaaaaaa") |> should equal sut.Key.[0..9]

let ``Random key cipher - Can decode`` () =
    sut <- SimpleCipher()
    sut.Decode(sut.Key.[0..9]) |> should equal "aaaaaaaaaa"

let ``Random key cipher - Is reversible. I.e., if you apply decode in a encoded result, you must see the same plaintext encode parameter as a result of the decode method`` () =
    sut <- SimpleCipher()
    sut.Decode(sut.Encode("abcdefghij")) |> should equal "abcdefghij"

let ``Random key cipher - Key is made only of lowercase letters`` () =
    sut <- SimpleCipher()
    Regex.IsMatch(sut.Key, "^[a-z]+$") |> should equal true

let ``Substitution cipher - Can encode`` () =
    sut <- SimpleCipher("abcdefghij")
    sut.Encode("aaaaaaaaaa") |> should equal "abcdefghij"

let ``Substitution cipher - Can decode`` () =
    sut <- SimpleCipher("abcdefghij")
    sut.Decode("abcdefghij") |> should equal "aaaaaaaaaa"

let ``Substitution cipher - Is reversible. I.e., if you apply decode in a encoded result, you must see the same plaintext encode parameter as a result of the decode method`` () =
    sut <- SimpleCipher("abcdefghij")
    sut.Decode(sut.Encode("abcdefghij")) |> should equal "abcdefghij"

let ``Substitution cipher - Can double shift encode`` () =
    sut <- SimpleCipher("iamapandabear")
    sut.Encode("iamapandabear") |> should equal "qayaeaagaciai"

let ``Substitution cipher - Can wrap on encode`` () =
    sut <- SimpleCipher("abcdefghij")
    sut.Encode("zzzzzzzzzz") |> should equal "zabcdefghi"

let ``Substitution cipher - Can wrap on decode`` () =
    sut <- SimpleCipher("abcdefghij")
    sut.Decode("zabcdefghi") |> should equal "zzzzzzzzzz"

let ``Substitution cipher - Can encode messages longer than the key`` () =
    sut <- SimpleCipher("abc")
    sut.Encode("iamapandabear") |> should equal "iboaqcnecbfcr"

let ``Substitution cipher - Can decode messages longer than the key`` () =
    sut <- SimpleCipher("abc")
    sut.Decode("iboaqcnecbfcr") |> should equal "iamapandabear"

