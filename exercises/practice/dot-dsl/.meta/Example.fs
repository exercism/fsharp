module DotDsl

type Attribute = string * string

type Element =
    | Attr of Attribute
    | Node of string * Attribute list
    | Edge of string * string * Attribute list

type Graph = Element list

let graph children = children |> List.sort

let attr key value = Attr (key, value)
let node key attrs = Node (key, attrs)
let edge left right attrs = Edge (left, right, attrs)

let isAttr element =
    match element with
    | Attr _ -> Some element
    | _      -> None

let isNode element =
    match element with
    | Node _ -> Some element
    | _      -> None

let isEdge element =
    match element with
    | Edge _ -> Some element
    | _      -> None

let attrs graph = List.choose isAttr graph
let nodes graph = List.choose isNode graph
let edges graph = List.choose isEdge graph

