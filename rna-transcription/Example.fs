module Complement

type Complement() =

    let rnaToDna = Map.ofSeq [('G', 'C'); ('C', 'G'); ('U', 'A'); ('A', 'T')]
    let dnaToRna = Map.ofSeq [('G', 'C'); ('C', 'G'); ('T', 'A'); ('A', 'U')]

    let transpose (input:string) map = new string(input.ToCharArray() |> Array.map (fun c -> Map.find c map))

    member this.ofDna(dna:string) = transpose dna dnaToRna
    member this.ofRna(rna:string) = transpose rna rnaToDna