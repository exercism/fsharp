module Alphametics

module Combinatorics =     
    // https://stackoverflow.com/questions/286427/calculating-permutations-in-f 
    let permutations list =
        let rec insertions x = function
            | [] -> [[x]]
            | y::ys as xs -> (x::xs)::(insertions x ys |> List.map(fun xs' -> y::xs'))
        list |> Seq.fold (fun accum x -> Seq.collect (insertions x) accum) (seq [List.empty])

    // https://stackoverflow.com/questions/4495597/combinations-and-permutations-in-f Tomas
    let rec combinations acc size set = seq {
        match size, set with 
        | n, x::xs -> 
            if n > 0 then yield! combinations (x::acc) (n - 1) xs
            if n >= 0 then yield! combinations acc n xs 
        | 0, [] -> yield acc 
        | _, [] -> () }

    let permsOf k list = 
        if k < List.length list then combinations [] k list |> Seq.collect (fun p -> permutations p ) 
        else permutations list

open Combinatorics

let unknowns = String.filter(" =+".Contains >> not) >> Seq.distinct >> List.ofSeq
// minimize summing by counting repetitions
let parse = 
    Array.rev
    >> Array.map Seq.rev
    >> Seq.transpose
    >> Seq.map (fun col -> col |> Seq.head, col |> Seq.tail |> Seq.countBy id |> Array.ofSeq)
    >> List.ofSeq // List much, much faster than Seq here! This was the main bottleneck!
let noLeadingZero = Array.map Seq.head >> Set 

// pre-compute as much as possible including using tokens (array indices)  instead of chars - for array lookup Big-O(1)
let mapCharsToTokens (chars:char list)= chars |>  List.mapi (fun i c -> c,i) |> Map.ofList
let tokenise (input:string) (tokens:Map<char,int>) =
    input.Replace("==","=")
    |> String.filter((<>) ' ' )
    |> fun compact -> compact.Split([|'+';'='|])
    |> Array.map (Seq.map (fun c -> tokens.[c]))

let buildZeroMask size (noZeroSet:Set<int>) = [| for i in [0..size - 1] do (noZeroSet.Contains i) = false |]        

let rec colSum chars (remain:(int*((int*int) []))list) carry (arr:int[]) = 
    match carry, remain  with
    | 0, [] -> arr |> Seq.zip chars |> Map.ofSeq |> Some // hence only done when solved
    | _, [] -> None    
    | c, (y,x)::tail -> 
        let sum = x |> Array.sumBy (fun (key,count) -> count * arr.[key]) |> (+) c
        if arr.[y] = (sum % 10) then colSum chars tail (sum / 10) arr else None
    
let solve puzzle = 
    let chars = unknowns puzzle 
    let k = chars |> List.length
    let tokens = chars |> mapCharsToTokens |> tokenise puzzle
    let columns = tokens |> parse  
    let zeroMask = tokens |> noLeadingZero |> buildZeroMask k 
    // Array.item is Big-O(1) >> Set.contains Big-O(log(n)) for F# Set hence zeroMask array
    let canBeZero = Array.tryFindIndex ((=)0) >> Option.forall(fun  i -> zeroMask.[i])
 
    //Insertions
    permsOf k [0..9] 
    |> Seq.map Array.ofList // array lookup Big-O(1) vs. map lookup Big-O(log(n)) & same cost for building here
    |> Seq.filter canBeZero // slower to filter during permutations generation
    |> Seq.tryPick (colSum chars columns 0) // uses efficient and minimal column carry short-circuit calculations
 
