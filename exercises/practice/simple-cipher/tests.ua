~ "simple-cipher.ua" ~ SimpleCipher

# Random key cipher - Can encode
    let sut = SimpleCipher()
⍤⤙≍ sut.Key.[0..9] sut.Encode("aaaaaaaaaa")

# Random key cipher - Can decode
    let sut = SimpleCipher()
⍤⤙≍ "aaaaaaaaaa" sut.Decode(sut.Key.[0..9])

# Random key cipher - Is reversible. I.e., if you apply decode in a encoded result, you must see the same plaintext encode parameter as a result of the decode method
    let sut = SimpleCipher()
⍤⤙≍ "abcdefghij" sut.Decode(sut.Encode("abcdefghij"))

# Random key cipher - Key is made only of lowercase letters
    let sut = SimpleCipher()
⍤⤙≍ true Regex.IsMatch(sut.Key, "^[a-z]+$")

# Substitution cipher - Can encode
    let sut = SimpleCipher("abcdefghij")
⍤⤙≍ "abcdefghij" sut.Encode("aaaaaaaaaa")

# Substitution cipher - Can decode
    let sut = SimpleCipher("abcdefghij")
⍤⤙≍ "aaaaaaaaaa" sut.Decode("abcdefghij")

# Substitution cipher - Is reversible. I.e., if you apply decode in a encoded result, you must see the same plaintext encode parameter as a result of the decode method
    let sut = SimpleCipher("abcdefghij")
⍤⤙≍ "abcdefghij" sut.Decode(sut.Encode("abcdefghij"))

# Substitution cipher - Can double shift encode
    let sut = SimpleCipher("iamapandabear")
⍤⤙≍ "qayaeaagaciai" sut.Encode("iamapandabear")

# Substitution cipher - Can wrap on encode
    let sut = SimpleCipher("abcdefghij")
⍤⤙≍ "zabcdefghi" sut.Encode("zzzzzzzzzz")

# Substitution cipher - Can wrap on decode
    let sut = SimpleCipher("abcdefghij")
⍤⤙≍ "zzzzzzzzzz" sut.Decode("zabcdefghi")

# Substitution cipher - Can encode messages longer than the key
    let sut = SimpleCipher("abc")
⍤⤙≍ "iboaqcnecbfcr" sut.Encode("iamapandabear")

# Substitution cipher - Can decode messages longer than the key
    let sut = SimpleCipher("abc")
⍤⤙≍ "iamapandabear" sut.Decode("iboaqcnecbfcr")

