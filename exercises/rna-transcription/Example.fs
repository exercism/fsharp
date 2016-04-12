module RNATranscription

let dnaToRna = Map.ofSeq [('G', 'C'); ('C', 'G'); ('T', 'A'); ('A', 'U')]

let transpose (input:string) map = new string(input.ToCharArray() |> Array.map (fun c -> Map.find c map))

let toRna (dna:string) = transpose dna dnaToRna