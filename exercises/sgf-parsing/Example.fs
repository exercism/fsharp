module SgfParsing

open FParsec

type Data = Map<string, string list>
type Tree = Node of Data * Tree list

let mkTree node children = Node (node, children)

let propertyToData = 
    function 
    | Some (prop, values) -> Map.ofList [(prop, values)]
    | None -> Map.empty

let rec nodesToTree (nodes, trees) = 
    match nodes with
    | [] -> failwith "Can only create tree from non-empty nodes list"
    | x::[] -> Node (x, trees)
    | x::xs -> Node (x, [nodesToTree (xs, trees)])

// We create a parser forwarder in order to allow us to 
// define a recursive parser later on
let expr, exprImpl = createParserForwardedToRef()

let normalChar = satisfy (fun c -> c <> '\\' && c <> ']')
let escapedChar = pchar '\\' >>. anyChar 
let cValueType = manyChars (normalChar <|> escapedChar)
let propValue = between (pchar '[') (pchar ']') cValueType
let propIdent = asciiUpper
let property = (propIdent |>> string) .>>. many1 propValue
let node = (pchar ';') >>. opt property |>> propertyToData
let gameTree = (pchar '(') >>. (many1 node) .>>. (many expr) .>> (pchar ')') |>> nodesToTree

exprImpl := gameTree

let parseSgf (sgfLine: string) = 
    let sgf = sgfLine.Replace("\t", " ")
    match run gameTree sgf with
    | Success (result, _, _) -> Some result
    | Failure _ -> None