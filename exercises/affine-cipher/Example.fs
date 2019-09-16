module AffineCipher
let m = 26

let findInverse u v =
    let rec findInverseImpl a b x0 x1 y0 y1 =
        if a = 0 && b > 1 then invalidArg "a" "a must be coprime with 26"
        elif a = 0 then y0
        else
            let q = b / a
            let b_new,a_new = a, b % a
            let x0_new, x1_new = x1, x0 - q * x1
            let y0_new, y1_new = y1, y0 - q * y1

            findInverseImpl a_new b_new x0_new x1_new y0_new y1_new

    findInverseImpl u v 1 0 0 1

let moduloDecrypt a b x = ((x - b) * a) % m
let moduloEncrypt a b x = (a * x + b) % m

let rec compute f a b c =
    if not (System.Char.IsLetter(c)) 
        then c
    elif System.Char.IsUpper(c) 
        then compute f a b (System.Char.ToLower(c))
    else 
        let x = (int)c - 97
        let modulo = f a b x
        let result = if modulo < 0 then (modulo + m) else modulo
        (char)(result + 97)

let decode a b cipheredText=
    let inverse = findInverse a m
    cipheredText 
    |> Seq.filter System.Char.IsLetterOrDigit
    |> Seq.map (compute moduloDecrypt inverse b)
    |> Seq.toArray
    |> System.String

let rec addSpaces (source:char list) =
    match source with
    | e1::e2::e3::e4::e5::tail when (List.length tail > 0) -> e1::e2::e3::e4::e5::' '::(addSpaces tail)
    | _ -> source

let encode a b plainText=
    let inverse = findInverse a m
    plainText 
    |> Seq.toList
    |> List.filter System.Char.IsLetterOrDigit
    |> List.map (compute moduloEncrypt a b)
    |> addSpaces
    |> List.toArray
    |> System.String


