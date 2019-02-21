// Learn more about F# at http://fsharp.org
module Alphametics

open System

let private permutations n r =
    let source = [|(n-1)..(-1)..0|] 
    let rec permutationsInner r =
        match r with
        | 1 -> seq {for i in (n-1)..(-1)..0 do yield [i] } 
        | _ -> permutationsInner (r-1) |> Seq.collect(fun p -> source |> Seq.filter (fun el -> not (Seq.contains el p))  |> Seq.map (fun u -> u::p))

    permutationsInner r


let private parseOperands (equation:string) =
    let leftRightOperands = equation.Split([|" == "|], StringSplitOptions.None) 
                            |> Seq.map (fun p -> p.Split([|" + "|], StringSplitOptions.None)) 
                            |> Seq.toList
    (leftRightOperands.Head,leftRightOperands.Tail.Head)

let private operandFolder (accumulator:Map<char,int>,multiplyBy:int) character =
    let prevCount = match accumulator.TryFind(character) with
                    | Some count -> count
                    | None -> 0 

    (accumulator.Add(character,prevCount + multiplyBy), multiplyBy * 10)

let private processOperand (multiplyBy,lettersWithCount) (operand:seq<char>)  =
    let map = operand |> Seq.fold operandFolder (lettersWithCount,multiplyBy) |> fst
    (multiplyBy,map)

let private findNonZeroLetters operand = operand |> Seq.map Seq.head |> set

let private computeLettersCountNonZeroLetters (left: string[]) (right: string[]) =
    let leftLettersCount = left|> Seq.map Seq.rev |> Seq.fold processOperand (1, Map.empty)
    let lettersCount =  right|> Seq.map Seq.rev |> Seq.fold processOperand (-1, snd leftLettersCount) |> snd
    let nonZeroLetters = left |> Seq.append right |> findNonZeroLetters
    (lettersCount,nonZeroLetters)

let private solutionFolder acc el1 (_,el2) =
    acc + el1 * el2

let solve equation = 
    let (left,right) = parseOperands equation
    let (lettersCount,nonZeroLetters) = computeLettersCountNonZeroLetters left right
    let availableCombinations = permutations 10 lettersCount.Count
    let lettersCounList = lettersCount |> Map.toList

    let isSolution (combination:int list) =
        let result = Seq.fold2 solutionFolder 0 combination lettersCounList
        let indexOfZeroValuedLetter = List.tryFindIndex(fun p -> p = 0) combination

        match indexOfZeroValuedLetter with
        | Some t -> not (nonZeroLetters.Contains((fst lettersCounList.[t]))) && result = 0
        | None -> result = 0

    let solution = availableCombinations |> Seq.tryFind isSolution

    match solution with 
    | Some comb -> comb |> List.zip lettersCounList |> List.map (fun ((c,_),v) -> (c,v)) |> Map |> Some
    | None -> None