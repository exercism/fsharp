module Complement

let rnaToDna = Map.ofSeq [('G', 'C'); ('C', 'G'); ('U', 'A'); ('A', 'T')]
let dnaToRna = Map.ofSeq [('G', 'C'); ('C', 'G'); ('T', 'A'); ('A', 'U')]

let transpose (input:string) map = new string(input.ToCharArray() |> Array.map (fun c -> Map.find c map))

let toRna (dna:string) = transpose dna dnaToRna
let toDna (rna:string) = transpose rna rnaToDna
