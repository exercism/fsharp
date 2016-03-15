module CryptoSquare

open System

type CryptoSquare(input) = 

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

    member this.size() = this.normalizePlaintext() |> String.length |> float |> Math.Sqrt |> ceil |> int
    member this.normalizePlaintext() = seq { for c in input do if Char.IsLetterOrDigit c then yield Char.ToLowerInvariant c } |> charsToString
    member this.plaintextSegments() = chunksOfSize (this.size()) (this.normalizePlaintext()) |> List.ofSeq
    member this.ciphertext() = this.plaintextSegments() |> transpose |> String.concat ""
    member this.normalizeCiphertext() = this.plaintextSegments() |> transpose |> String.concat " "