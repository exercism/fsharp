module Forth

open System
open System.Text.RegularExpressions

type Value = int
type Word = string

type Item = 
    | Value of Value
    | Word of Word

type Operation = 
    | Plus 
    | Minus 
    | Mult 
    | Div 
    | Dup 
    | Drop 
    | Swap 
    | Over 
    | User of Item list

type ForthState = { sStack: Value list; sInput: Item list; sMapping: Map<Word, Operation> }

type ForthError = 
    | DivisionByZero 
    | StackUnderflow 
    | InvalidWord 
    | UnknownWord of Word

let defaultMapping = 
    [("+",    Plus);
     ("-",    Minus);
     ("*",    Mult);
     ("/",    Div);
     ("dup",  Dup);
     ("drop", Drop);
     ("swap", Swap);
     ("over", Over)]
    |> Map.ofList

let breakBy callback xs = (xs |> List.takeWhile (callback >> not), xs |> List.skipWhile (callback >> not))

let empty = { sStack = []; sInput = []; sMapping = defaultMapping }

let split (str: string) = Regex.Split(str, "[\s\b]")

let formatStack (state: ForthState) = 
    match state.sStack with
    | [] -> ""
    | _  ->
        state.sStack
        |> List.rev
        |> List.map string
        |> List.reduce (fun x y -> x + " " + y)
    
let parseItem text = 
    match Int32.TryParse text with
    | true, value -> Value value
    | _ -> Word text

let parseText (text: string) =         
    text.ToLowerInvariant()
    |> split
    |> List.ofArray
    |> List.map parseItem

let addItems state items = { state with sInput = items @ state.sInput }

let parse text state = parseText text |> addItems state

let unaryStackOp op state =
    match state.sStack with
    | []    -> Choice2Of2 StackUnderflow
    | x::xs -> Choice1Of2 { state with sStack = op x @ xs}

let binaryStackOp op state =
    match state.sStack with
    | x::y::xs -> Choice1Of2 { state with sStack = op x y @ xs}
    | _        -> Choice2Of2 StackUnderflow

let toBinaryStackOp op x y = [op y x]

let divOp state = 
    match state.sStack with
    | 0::_     -> Choice2Of2 DivisionByZero
    | x::y::xs -> Choice1Of2 { state with sStack = (y / x) :: xs }
    | _        -> Choice2Of2 StackUnderflow

let applyOp op state =
    match op with
    | Plus  -> binaryStackOp (toBinaryStackOp (+)) state
    | Minus -> binaryStackOp (toBinaryStackOp (-)) state
    | Mult  -> binaryStackOp (toBinaryStackOp (*)) state
    | Div   -> divOp state
    | Dup   -> unaryStackOp (List.replicate 2) state
    | Drop  -> unaryStackOp (fun _ -> []) state
    | Swap  -> binaryStackOp (fun x y -> [y; x]) state
    | Over  -> binaryStackOp (fun x y -> [y; x; y]) state
    | User terms -> addItems state terms |> Choice1Of2

let evalWord word state = 
    match Map.tryFind word state.sMapping with
    | None -> UnknownWord word |> Choice2Of2 
    | Some op -> applyOp op state

let rec evalState state =
    match state with
    | Choice2Of2 _ -> state
    | Choice1Of2 s ->
        match s.sInput with
        | [] -> state
        | (Value v)::xs -> { s with sStack = v::s.sStack; sInput = xs } |> Choice1Of2 |> evalState
        | (Word w)::xs ->
            match w with
            | ":" -> 
                match breakBy (fun c -> c = Word ";") xs with
                | ((Word userWord::operations), remainder) ->
                    { s with sInput = List.tail remainder; sMapping = Map.add (userWord.ToLower()) (User operations) s.sMapping } 
                    |> Choice1Of2
                    |> evalState
                | _ -> Choice2Of2 InvalidWord
            | ";" -> Choice2Of2 InvalidWord
            | _   -> evalWord w { s with sInput = xs } |> evalState

let eval text state =     
    parse text state 
    |> Choice1Of2
    |> evalState