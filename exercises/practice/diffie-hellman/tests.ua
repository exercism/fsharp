~ "diffie-hellman.ua" ~ DiffieHellman

# Private key is greater than 1 and less than p
    let p = 7919I
    let privateKeys = [for _ in 0 .. 10 -> privateKey p]
    privateKeys |> List.iter (fun x -> x |> should be (greaterThan 1I))
    privateKeys |> List.iter (fun x -> x |> should be (lessThan p))

# Private key is random
    let p = 7919I
    let privateKeys = [for _ in 0 .. 10 -> privateKey p]
⍤⤙≍ (List.length privateKeys) List.distinct privateKeys |> List.length

# Can calculate public key using private key
    let p = 23I
    let g = 5I
    let privateKey = 6I
⍤⤙≍ 8I publicKey p g privateKey

# Can calculate public key when given a different private key
    let p = 23I
    let g = 5I
    let privateKey = 15I
⍤⤙≍ 19I publicKey p g privateKey

# Can calculate secret using other party's public key
    let p = 23I
    let theirPublicKey = 19I
    let myPrivateKey = 6I
⍤⤙≍ 2I secret p theirPublicKey myPrivateKey

# Key exchange
    let p = 23I
    let g = 5I
    let alicePrivateKey = privateKey p
    let alicePublicKey = publicKey p g alicePrivateKey
    let bobPrivateKey = privateKey p
    let bobPublicKey = publicKey p g bobPrivateKey
    let secretA = secret p bobPublicKey alicePrivateKey
    let secretB = secret p alicePublicKey bobPrivateKey
⍤⤙≍ secretB secretA

