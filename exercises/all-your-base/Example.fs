module AllYourBase

let swap (a, b) = b, a

let divMod n d = 
    let q = n / d
    let r = n % d
    (q, r)

let fromDigits fromBase digits = 
    let folder acc x = 
        if x < 0 || x >= fromBase || (x = 0 && acc = Some 0) then None 
        else Option.map (fun y -> y * fromBase + x) acc

    if List.isEmpty digits then None
    else List.fold folder (Some 0) digits

let toDigits toBase n =
    let unfolder x = 
        if x = 0 then None
        else Some (divMod x toBase |> swap)

    List.unfold unfolder n |> List.rev

let rebase inputBase inputDigits outputBase =
    if inputBase < 2 || outputBase < 2 then 
        None
    else 
        inputDigits 
        |> fromDigits inputBase 
        |> Option.map (toDigits outputBase)