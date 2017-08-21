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

let toBytes values = List.collect toBytesSingle values

let fromBytes (bytes: byte list): uint32 list = 
    let folder (acc, values) b = 
        if acc &&& 0xfe000000u > 0u then 
            failwith "Overflow exception"
        else
            let value = (acc <<< 7) ||| (uint32 b &&& 0x7fu)

            if 0x80uy &&& b = 0uy then 
                (0u, value :: values) 
            else 
                (value, values)

    let (acc, values) = List.fold folder (0u, []) bytes

    if acc <> 0u then failwith "Incomplete byte sequence"
    else values |> List.rev