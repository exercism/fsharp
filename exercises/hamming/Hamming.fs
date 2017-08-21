module Hamming

let compute (strand1:string) (strand2:string) = 
    Array.zip (strand1.ToCharArray()) (strand2.ToCharArray()) 
    |> Array.filter (fun (c1, c2) -> c1 <> c2) 
    |> Array.length