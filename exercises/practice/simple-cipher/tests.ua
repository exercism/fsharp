~ "simple-cipher.ua" ~ SimpleCipher

# Random key cipher - Can encode
    let sut = SimpleCipher()
    sut.Encode("aaaaaaaaaa") |> should equal sut.Key.[0..9]

# Random key cipher - Can decode
    let sut = SimpleCipher()
    sut.Decode(sut.Key.[0..9]) |> should equal "aaaaaaaaaa"

# Random key cipher - Is reversible. I.e., if you apply decode in a encoded result, you must see the same plaintext encode parameter as a result of the decode method
    let sut = SimpleCipher()
    sut.Decode(sut.Encode("abcdefghij")) |> should equal "abcdefghij"

# Random key cipher - Key is made only of lowercase letters
    let sut = SimpleCipher()
    Regex.IsMatch(sut.Key, "^[a-z]+$") |> should equal true

# Substitution cipher - Can encode
    let sut = SimpleCipher("abcdefghij")
    sut.Encode("aaaaaaaaaa") |> should equal "abcdefghij"

# Substitution cipher - Can decode
    let sut = SimpleCipher("abcdefghij")
    sut.Decode("abcdefghij") |> should equal "aaaaaaaaaa"

# Substitution cipher - Is reversible. I.e., if you apply decode in a encoded result, you must see the same plaintext encode parameter as a result of the decode method
    let sut = SimpleCipher("abcdefghij")
    sut.Decode(sut.Encode("abcdefghij")) |> should equal "abcdefghij"

# Substitution cipher - Can double shift encode
    let sut = SimpleCipher("iamapandabear")
    sut.Encode("iamapandabear") |> should equal "qayaeaagaciai"

# Substitution cipher - Can wrap on encode
    let sut = SimpleCipher("abcdefghij")
    sut.Encode("zzzzzzzzzz") |> should equal "zabcdefghi"

# Substitution cipher - Can wrap on decode
    let sut = SimpleCipher("abcdefghij")
    sut.Decode("zabcdefghi") |> should equal "zzzzzzzzzz"

# Substitution cipher - Can encode messages longer than the key
    let sut = SimpleCipher("abc")
    sut.Encode("iamapandabear") |> should equal "iboaqcnecbfcr"

# Substitution cipher - Can decode messages longer than the key
    let sut = SimpleCipher("abc")
    sut.Decode("iboaqcnecbfcr") |> should equal "iamapandabear"

