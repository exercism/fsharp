~ "simple-cipher.ua" ~ SimpleCipher

# Random key cipher - Can encode
sut = SimpleCipher()
⍤⤙≍ sut.Key.[0..9] sut.Encode("aaaaaaaaaa")

# Random key cipher - Can decode
sut = SimpleCipher()
⍤⤙≍ "aaaaaaaaaa" sut.Decode(sut.Key.[0..9])

# Random key cipher - Is reversible. I.e., if you apply decode in a encoded result, you must see the same plaintext encode parameter as a result of the decode method
sut = SimpleCipher()
⍤⤙≍ "abcdefghij" sut.Decode(sut.Encode("abcdefghij"))

# Random key cipher - Key is made only of lowercase letters
sut = SimpleCipher()
⍤⤙≍ 1 Regex.IsMatchsut.Key_"^[a-z]+$"

# Substitution cipher - Can encode
sut = SimpleCipher("abcdefghij")
⍤⤙≍ "abcdefghij" sut.Encode("aaaaaaaaaa")

# Substitution cipher - Can decode
sut = SimpleCipher("abcdefghij")
⍤⤙≍ "aaaaaaaaaa" sut.Decode("abcdefghij")

# Substitution cipher - Is reversible. I.e., if you apply decode in a encoded result, you must see the same plaintext encode parameter as a result of the decode method
sut = SimpleCipher("abcdefghij")
⍤⤙≍ "abcdefghij" sut.Decode(sut.Encode("abcdefghij"))

# Substitution cipher - Can double shift encode
sut = SimpleCipher("iamapandabear")
⍤⤙≍ "qayaeaagaciai" sut.Encode("iamapandabear")

# Substitution cipher - Can wrap on encode
sut = SimpleCipher("abcdefghij")
⍤⤙≍ "zabcdefghi" sut.Encode("zzzzzzzzzz")

# Substitution cipher - Can wrap on decode
sut = SimpleCipher("abcdefghij")
⍤⤙≍ "zzzzzzzzzz" sut.Decode("zabcdefghi")

# Substitution cipher - Can encode messages longer than the key
sut = SimpleCipher("abc")
⍤⤙≍ "iboaqcnecbfcr" sut.Encode("iamapandabear")

# Substitution cipher - Can decode messages longer than the key
sut = SimpleCipher("abc")
⍤⤙≍ "iamapandabear" sut.Decode("iboaqcnecbfcr")

