module AllYourBase

let toBase b n =
    let rec loop n acc =
        if n = 0 then acc else
        let digit, n' = n % b, n / b
        loop n' (digit::acc)
    match loop n [] with
    | [] -> Some [0]
    | digits -> Some digits

let fromBase b nums =
    let rec loop acc = function
    | [] -> Some acc
    | digit::rest ->
        if digit <  0 then None else
        if digit >= b then None else
        loop (acc * b + digit) rest

    loop 0 nums

let rebase inB inDigits outB =
    match inB < 2 || outB < 2 with
    | true ->
        None
    | false ->
        inDigits
        |> List.skipWhile ((=) 0)
        |> fromBase inB
        |> Option.bind (toBase outB)