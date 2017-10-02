module CryptoSquare

open System

let charsToString chars = new String(chars |> Array.ofSeq)

let chunksOfSize n seq = 
    seq 
    |> Seq.mapi(fun i x -> i / n, x)
    |> Seq.groupBy fst
    |> Seq.map (fun (_, g) -> g |> Seq.map snd |> charsToString)

let transpose seq = 
    seq
    |> Seq.collect(fun s -> s |> Seq.mapi(fun i e -> (i, e)))
    |> Seq.groupBy(fst)
    |> Seq.map(fun (_, s) -> s |> Seq.map snd |> charsToString)    

let normalizedPlaintext (input: string) = seq { for c in input do if Char.IsLetterOrDigit c then yield Char.ToLowerInvariant c } |> charsToString

let size (input: string) = 
    input 
    |> normalizedPlaintext 
    |> String.length 
    |> float 
    |> Math.Sqrt 
    |> ceil 
    |> int

let plaintextSegments (input: string) = 
    chunksOfSize (size input) (normalizedPlaintext input) 
    |> List.ofSeq

let encoded (input: string) = 
    input 
    |> plaintextSegments 
    |> transpose 
    |> String.concat ""

let ciphertext (input: string) = 
    input 
    |> plaintextSegments 
    |> transpose 
    |> String.concat " "