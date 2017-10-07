module CryptoSquare

open System

let private charsToString chars = String(Array.ofSeq chars)

let private chunksOfSize n seq = 
    seq 
    |> Seq.mapi(fun i x -> i / n, x)
    |> Seq.groupBy fst
    |> Seq.map (fun (_, g) -> g |> Seq.map snd |> charsToString)

let private transpose seq = 
    seq
    |> Seq.collect(fun s -> s |> Seq.mapi(fun i e -> (i, e)))
    |> Seq.groupBy(fst)
    |> Seq.map(fun (_, s) -> s |> Seq.map snd |> charsToString)    

let private normalizedPlaintext (input: string) = seq { for c in input do if Char.IsLetterOrDigit c then yield Char.ToLowerInvariant c } |> charsToString

let private size (input: string) = 
    input 
    |> normalizedPlaintext 
    |> String.length 
    |> float 
    |> Math.Sqrt 
    |> ceil 
    |> int

let private plaintextSegments (input: string) = 
    chunksOfSize (size input) (normalizedPlaintext input) 
    |> List.ofSeq

let ciphertext (input: string) = 
    let chunks = plaintextSegments input 
    let numberOfChunks = List.length chunks
    
    chunks
    |> transpose 
    |> Seq.map (fun x -> x.PadRight(numberOfChunks))
    |> String.concat " "