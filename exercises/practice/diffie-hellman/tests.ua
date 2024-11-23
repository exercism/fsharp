~ "diffie-hellman.ua" ~ DiffieHellman

# Private key is greater than 1 and less than p
p           ← 7919I
privateKeys ← [⊃in 0 .. 10 -> privateKey p]
privateKeys
| > List.iter (fun x -> x|> should be (greaterThan 1I))
privateKeys
| > List.iter (fun x -> x|> should be (lessThan p))

# Private key is random
p           ← 7919I
privateKeys ← [⊃in 0 .. 10 -> privateKey p]
⍤⤙≍ (List.⧻ privateKeys) List.distinct privateKeys
| > List.⧻

# Can calculate public key using private key
p          ← 23I
g          ← 5I
privateKey ← 6I
⍤⤙≍ 8I publicKey p g privateKey

# Can calculate public key when given a different private key
p          ← 23I
g          ← 5I
privateKey ← 15I
⍤⤙≍ 19I publicKey p g privateKey

# Can calculate secret using other party's public key
p              ← 23I
theirPublicKey ← 19I
myPrivateKey   ← 6I
⍤⤙≍ 2I secret p theirPublicKey myPrivateKey

# Key exchange
p               ← 23I
g               ← 5I
alicePrivateKey ← privateKey p
alicePublicKey  ← publicKey p g alicePrivateKey
bobPrivateKey   ← privateKey p
bobPublicKey    ← publicKey p g bobPrivateKey
secretA         ← secret p bobPublicKey alicePrivateKey
secretB         ← secret p alicePublicKey bobPrivateKey
⍤⤙≍ secretB secretA
