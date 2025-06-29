import "diffie_hellman"

let ``Private key is greater than 1 and less than p`` () =
    let p = 7919I
    let private_keys = [for _ in 0 .. 10 -> privateKey p]
    privateKeys |> List.iter (fun x -> x |> should be (greaterThan 1I))
    privateKeys |> List.iter (fun x -> x |> should be (lessThan p))

let ``Private key is random`` () =
    let p = 7919I
    let private_keys = [for _ in 0 .. 10 -> privateKey p]
    List.distinct privateKeys |> List.length |> should equal (List.length privateKeys)

let ``Can calculate public key using private key`` () =
    let p = 23I
    let g = 5I
    let private_key = 6I
    publicKey p g privateKey |> should equal 8I

let ``Can calculate public key when given a different private key`` () =
    let p = 23I
    let g = 5I
    let private_key = 15I
    publicKey p g privateKey |> should equal 19I

let ``Can calculate secret using other party's public key`` () =
    let p = 23I
    let their_public_key = 19I
    let my_private_key = 6I
    secret p theirPublicKey myPrivateKey |> should equal 2I

let ``Key exchange`` () =
    let p = 23I
    let g = 5I
    let alice_private_key = privateKey p
    let alice_public_key = publicKey p g alicePrivateKey
    let bob_private_key = privateKey p
    let bob_public_key = publicKey p g bobPrivateKey
    let secret_a = secret p bobPublicKey alicePrivateKey
    let secret_b = secret p alicePublicKey bobPrivateKey
    secretA |> should equal secretB

