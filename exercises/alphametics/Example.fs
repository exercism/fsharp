module Alphametics

open System

let private foldMapBy mapping map1 map2 =
    let helper acc key value = 
        match Map.tryFind key acc with
        | Some x -> Map.add key (mapping x value) acc
        | None   -> Map.add key value acc

    map1 |> Map.fold helper map2

let private tenToPower power = Math.Pow(10., float power) |> int

let private generateCombinations length =
    let rec helper remaining options =
        seq { if remaining = 0 then yield [] else
                for x in options do
                    for xs in helper (remaining - 1) (Set.remove x options) do
                        yield x::xs }

    helper length ([0..9] |> Set.ofList)    

let private solutions parts = 
    let letters = parts |> Seq.concat |> Seq.toList |> List.distinct
    let nonZeroLetters = Array.map Seq.head parts |> Array.distinct
    
    letters
    |> List.length
    |> generateCombinations
    |> Seq.map (fun combination -> Seq.zip letters combination |> Map.ofSeq)
    |> Seq.filter (fun solution -> Array.forall (fun letter -> Map.find letter solution <> 0) nonZeroLetters)

let private trySolve counts solution = 
    let folder sum letter count =
        let multiplier = Map.find letter solution
        sum + count * multiplier

    match Map.fold folder 0 counts with
    | 0 -> Some solution
    | _ -> None

let private parseAddends (puzzle: string) =
    puzzle
        .Replace("==", "")
        .Replace("+", "")
        .Split([|" "|], StringSplitOptions.RemoveEmptyEntries)

let private addendToLetterCount multiplier word =
    word
    |> Seq.rev
    |> Seq.mapi (fun i letter -> (letter, tenToPower i * multiplier))
    |> Seq.groupBy fst
    |> Seq.map (fun (letter, counts) -> (letter, counts |> Seq.sumBy snd))
    |> Map.ofSeq

let private addendsToLetterCount addends =   
    let mapAddend i addend = 
        let multiplier = if i = Array.length addends - 1 then -1 else 1
        addendToLetterCount multiplier addend

    addends
    |> Array.mapi mapAddend
    |> Array.reduce (foldMapBy (+))

let solve (puzzle: string) =
    let addends = parseAddends puzzle
    let letterCounts = addendsToLetterCount addends
    
    solutions addends
    |> Seq.tryPick (trySolve letterCounts)
