module Wordy

open System.Text.RegularExpressions

let private equationRegex = Regex(@"^What is (?<left>-?\d+)(?<operations> (?<operand>plus|minus|multiplied by|divided by) (?<right>-?\d+))*\?$", RegexOptions.Compiled)

let private applyOperand left operand right =
    match operand with
    | "plus" -> left + right
    | "minus" -> left - right
    | "multiplied by" -> left * right
    | "divided by" -> left / right
    | _ -> failwith "Unknown operand"

let private solve (parsedQuestion: Match): int =
    let initial = int parsedQuestion.Groups.["left"].Value
    [0 .. parsedQuestion.Groups.["operations"].Captures.Count - 1]
    |> List.fold (fun acc i -> applyOperand acc (parsedQuestion.Groups.["operand"].Captures.[i].Value) (int parsedQuestion.Groups.["right"].Captures.[i].Value)) initial 

let private parse (question: string): Match option =
    match equationRegex.Match question with
    | m when m.Success -> Some m
    | _ -> None

let answer (question: string): int option =  
    question 
    |> parse 
    |> Option.map solve