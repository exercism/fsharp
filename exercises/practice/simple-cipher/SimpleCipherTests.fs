source("./simple-cipher.R")
library(testthat)

let ``Random key cipher - Can encode`` () =
    sut <- SimpleCipher()
    expect_equal(sut.Encode("aaaaaaaaaa"), sut.Key.[0..9])

let ``Random key cipher - Can decode`` () =
    sut <- SimpleCipher()
    expect_equal(sut.Decode(sut.Key.[0..9]), "aaaaaaaaaa")

let ``Random key cipher - Is reversible. I.e., if you apply decode in a encoded result, you must see the same plaintext encode parameter as a result of the decode method`` () =
    sut <- SimpleCipher()
    expect_equal(sut.Decode(sut.Encode("abcdefghij")), "abcdefghij")

let ``Random key cipher - Key is made only of lowercase letters`` () =
    sut <- SimpleCipher()
    expect_equal(Regex.IsMatch(sut.Key, "^[a-z]+$"), true)

let ``Substitution cipher - Can encode`` () =
    sut <- SimpleCipher("abcdefghij")
    expect_equal(sut.Encode("aaaaaaaaaa"), "abcdefghij")

let ``Substitution cipher - Can decode`` () =
    sut <- SimpleCipher("abcdefghij")
    expect_equal(sut.Decode("abcdefghij"), "aaaaaaaaaa")

let ``Substitution cipher - Is reversible. I.e., if you apply decode in a encoded result, you must see the same plaintext encode parameter as a result of the decode method`` () =
    sut <- SimpleCipher("abcdefghij")
    expect_equal(sut.Decode(sut.Encode("abcdefghij")), "abcdefghij")

let ``Substitution cipher - Can double shift encode`` () =
    sut <- SimpleCipher("iamapandabear")
    expect_equal(sut.Encode("iamapandabear"), "qayaeaagaciai")

let ``Substitution cipher - Can wrap on encode`` () =
    sut <- SimpleCipher("abcdefghij")
    expect_equal(sut.Encode("zzzzzzzzzz"), "zabcdefghi")

let ``Substitution cipher - Can wrap on decode`` () =
    sut <- SimpleCipher("abcdefghij")
    expect_equal(sut.Decode("zabcdefghi"), "zzzzzzzzzz")

let ``Substitution cipher - Can encode messages longer than the key`` () =
    sut <- SimpleCipher("abc")
    expect_equal(sut.Encode("iamapandabear"), "iboaqcnecbfcr")

let ``Substitution cipher - Can decode messages longer than the key`` () =
    sut <- SimpleCipher("abc")
    expect_equal(sut.Decode("iboaqcnecbfcr"), "iamapandabear")

