module Wordy

open System.Text.RegularExpressions

type Operation = int -> int
type Equation = int * (Operation list)

let equationRegex = Regex(@"(?<left>-?\d+) (?<operation>-?plus|minus|divided by|multiplied by) (?=(?<right>-?\d+))", RegexOptions.Compiled)

let regexGroupStr (group: string) (m: Match) = m.Groups.[group].Value
let regexGroupNumber (group: string) (m: Match) = regexGroupStr group m |> int

let calculate (left, operations) = List.fold (fun acc item -> item acc) left operations

let parseRight (m: Match) = regexGroupNumber "right" m

let parseOperand (m: Match) = 
    match regexGroupStr "operation" m with
    | "plus"          -> (+)
    | "minus"         -> (-)
    | "multiplied by" -> (*)
    | "divided by"    -> (/)
    | _ -> failwith "Unknown operation"

let parseOperation (m: Match) =
    fun x -> (parseOperand m) x (parseRight m)

let parseOperations (matches: MatchCollection) =
    matches 
    |> Seq.cast<Match> 
    |> Seq.map parseOperation
    |> Seq.toList

let parseLeft (matches: MatchCollection) = 
    matches 
    |> Seq.cast 
    |> Seq.head 
    |> regexGroupNumber "left" 

let parse (question: string): Equation option =
    match equationRegex.Matches question with
    | m when m.Count = 0 -> None
    | m -> Some (parseLeft m, parseOperations m)

let answer (question: string): int option =  
    question 
    |> parse 
    |> Option.map calculate