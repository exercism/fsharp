module AffineCipher

open System

let alphabet = [ 'a' .. 'z' ]

let decode a b cipheredText =
    failwith "You need to implement this function."

let encodeChar a b c =
    if (c |> Char.IsDigit) then
        c
    else
        let i = alphabet |> List.findIndex ((=) c)
        let result = (a * i + b) % 26
        alphabet[result]

let encode a b (plainText: string) =
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
