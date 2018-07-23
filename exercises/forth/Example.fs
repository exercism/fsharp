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
    
let parseItem (text: string) = 
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
    | []    -> None
    | x::xs -> Some { state with sStack = op x @ xs}

let binaryStackOp op state =
    match state.sStack with
    | x::y::xs -> Some { state with sStack = op x y @ xs}
    | _        -> None

let toBinaryStackOp op x y = [op y x]

let divOp state = 
    match state.sStack with
    | 0::_     -> None
    | x::y::xs -> Some { state with sStack = (y / x) :: xs }
    | _        -> None

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
    | User terms -> addItems state terms |> Some

let evalWord word state = 
    match Map.tryFind word state.sMapping with
    | None -> None
    | Some op -> applyOp op state

let flattenOperation state (operation: Item)  =
    match operation with
    | Word word ->
        match state.sMapping.TryFind word with
        | Some (User operations) -> operations
        | _ -> [operation]
    | Value _ -> [operation]
    
let flattenOperations state (operations: Item list) =
    List.collect (flattenOperation state) operations

let rec evalState state =
    match state with
    | None -> state
    | Some s ->
        match s.sInput with
        | [] -> state
        | (Value v)::xs -> { s with sStack = v::s.sStack; sInput = xs } |> Some |> evalState
        | (Word w)::xs ->
            match w with
            | ":" -> 
                match breakBy (fun c -> c = Word ";") xs with
                | ((Word userWord::operations), remainder) ->
                    let flattenedOperations = flattenOperations s operations
                    { s with sInput = List.tail remainder; sMapping = Map.add (userWord.ToLower()) (User flattenedOperations) s.sMapping } 
                    |> Some
                    |> evalState
                | _ -> None
            | ";" -> None
            | _   -> evalWord w { s with sInput = xs } |> evalState

let rec eval commands (state: ForthState option) =   
    match commands, state with
    | [], _ 
        -> state |> Option.map (fun x -> List.rev x.sStack)
    | x::xs, Some y ->
        let updatedState = 
            parse x y 
            |> Some
            |> evalState

        eval xs updatedState
    | _ -> None    

let evaluate commands = eval commands (Some empty)