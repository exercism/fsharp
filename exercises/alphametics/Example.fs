module Alphametics

open System

open FParsec
open System.Text.RegularExpressions

let private plus = pstring " + "
let private equal = pstring " == "
let private operand = many1Satisfy isAsciiUpper
let private expression = sepBy operand plus
let private equation = expression .>> equal .>>. expression

let private parseToOption parser (input: string) =
    match run parser input with
    | Success(result, _, _)   -> Some result
    | Failure(errorMsg, _, _) -> None

let private parseEquation = parseToOption equation

let private operandToInt (map: Map<char, int>) (operand: string) =
    Seq.fold (fun acc x -> acc * 10 + Map.find x map) 0 operand

let private generateCombinations length =
    let rec helper remaining options =
        seq { if remaining = 0 then yield [] else
                for x in options do
                    for xs in helper (remaining - 1) (Set.remove x options) do
                        yield x::xs }

    helper length ([0..9] |> Set.ofList)

let private generateMaps (leftOperands, rightOperands) =
    let operands = leftOperands @ rightOperands 
    let chars = operands |> String.concat "" |> Set.ofSeq
    let nonZeroChars = operands |> List.map Seq.head |> Set.ofList
   
    generateCombinations (Set.count chars)
    |> Seq.map (Seq.zip chars >> Map.ofSeq)
    |> Seq.filter (fun m -> Set.forall (fun x -> Map.find x m <> 0) nonZeroChars)

let private sumOperands lettersToDigits = List.sumBy (operandToInt lettersToDigits)

let private trySolve (leftOperands, rightOperands) lettersToDigits =
    let left = sumOperands lettersToDigits leftOperands
    let right = sumOperands lettersToDigits rightOperands
    left = right

let solve input: Map<char, int> option = 
    match parseEquation input with
    | Some equation -> Seq.tryFind (trySolve equation) (generateMaps equation)
    | None -> None