module Hamming

let distance (strand1:string) (strand2:string) = 
    if (strand1.Length <> strand2.Length) then
        None
    else
        Array.zip (strand1.ToCharArray()) (strand2.ToCharArray()) 
        |> Array.filter (fun (c1, c2) -> c1 <> c2) 
        |> Array.length
        |> Some