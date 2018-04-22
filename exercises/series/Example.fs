module Series

let slices (str:string) length = 
    if length < 1 || length > str.Length || str.Length = 0 then None
    else Some [for i in 0 .. str.Length - length -> str.[i..i + length - 1]]