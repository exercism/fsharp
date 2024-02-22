module AffineCipher

open System

let alphabet = [ 'a' .. 'z' ]

let private coprime a b =
    let rec gcd a b =
        if a = b then a
        elif a > b then gcd (a - b) b
        else gcd a (b - a)

    gcd a b = 1

let private mmi a m =
    let rec loop a x m =
        match a * x % m with
        | 1 -> x
        | _ -> loop a (x + 1) m

    loop a 1 m

let rec gcd p q =
    if (p = 0 || q = 0) then 0
    elif (p = q) then p
    elif (p > q) then gcd (p - q) q
    else gcd p (q - p)

let private (%%) n m =
    match n % m with
    | mod' when sign mod' >= 0 -> mod'
    | mod' -> abs m + mod'

let decode a b (cipheredText: string) =
    if (coprime a 26 |> not) then
        raise (ArgumentException "Not coprime")

    cipheredText.ToLower().Replace(" ", "")
    |> Seq.map (fun c ->
        if c |> Char.IsDigit then
            c
        else
            let y = alphabet |> List.findIndex ((=) c)
            let result = (mmi a 26) * (y - b) %% 26
            alphabet[result])
    |> String.Concat

let encodeChar a b c =
    if (c |> Char.IsDigit) then
        c
    else
        let i = alphabet |> List.findIndex ((=) c)
        let result = (a * i + b) % 26
        alphabet[result]

let encode a b (plainText: string) =
    if (coprime a 26 |> not) then
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
