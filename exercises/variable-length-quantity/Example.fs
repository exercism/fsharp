module VariableLengthQuantity

let sevenBitsMask = 0x7fu
let eightBitMask = 0x80u

let toBytesSingle value =
    let unfolder (remainder, first) =
        if remainder > 0u then 
            let maskedBytes = 
                if first then 
                    remainder &&& sevenBitsMask 
                else 
                    remainder &&& sevenBitsMask ||| eightBitMask

            Some (byte maskedBytes, (remainder >>> 7, false))
        else 
            None
        
    if value = 0u then [0uy]
    else List.unfold unfolder (value, true) |> List.rev

let encode values = List.collect toBytesSingle values

let decode (bytes: byte list): uint32 list option = 
    let folder acc b =
        match acc with
        | None -> None
        | Some (remainder, values) ->
            if remainder &&& 0xfe000000u > 0u then 
                None
            else
                let value = (remainder <<< 7) ||| (uint32 b &&& 0x7fu)

                if 0x80uy &&& b = 0uy then 
                    Some (0u, value :: values) 
                else 
                    Some (value, values)

    match List.fold folder (Some (0u, [])) bytes with
    | None -> None
    | Some (remainder, _) when remainder <> 0u -> None
    | Some (_, values) when List.isEmpty values -> None
    | Some (_, values) -> Some (List.rev values)