module AffineCipher

open System

let alphabet = [ 'a' .. 'z' ]

let rec gcd p q =
    if (p = 0 || q = 0) then 0
    elif (p = q) then p
    elif (p > q) then gcd (p - q) q
    else gcd p (q - p)

let decode a b cipheredText =
    // D(y) = (a^-1)(y - b) mod m
    // // cipheredText |> Seq.map (fun c ->
    // //     let y = alphabet |> List.findIndex ((=) c)
    // //     let result = (y - b) % 26
    //
    // )
    ""

let encodeChar a b c =
    if (c |> Char.IsDigit) then
        c
    else
        let i = alphabet |> List.findIndex ((=) c)
        let result = (a * i + b) % 26
        alphabet[result]

let encode a b (plainText: string) =
    if (gcd a b = 1) then
        raise (ArgumentException "Not coprime")

    plainText.ToLower().Replace(" ", "")
    |> Seq.choose (fun c ->
        if (c |> Char.IsLetterOrDigit) then
            Some(encodeChar a b c)
        else
            None)
    |> Seq.chunkBySize 5
    |> Seq.map String.Concat
    |> (function
    | s -> String.Join(" ", s))
