~ "crypto-square.ua" ~ CryptoSquare

# Empty plaintext results in an empty ciphertext
⍤⤙≍ "" ciphertext ""

# Lowercase
⍤⤙≍ "a" ciphertext "A"

# Remove spaces
⍤⤙≍ "b" ciphertext "  b "

# Remove punctuation
⍤⤙≍ "1" ciphertext "@1,%!"

# 9 character plaintext results in 3 chunks of 3 characters
⍤⤙≍ "tsf hiu isn" ciphertext "This is fun!"

# 8 character plaintext results in 3 chunks, the last one with a trailing space
⍤⤙≍ "clu hlt io " ciphertext "Chill out."

# 54 character plaintext results in 7 chunks, the last two with trailing spaces
⍤⤙≍ "imtgdvs fearwer mayoogo anouuio ntnnlvt wttddes aohghn  sseoau " ciphertext "If man was meant to stay on the ground, god would have given us roots."

