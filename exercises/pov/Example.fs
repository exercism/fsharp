module Pov

type Graph<'a> = { value: 'a; children: Graph<'a> list }
type Crumb<'a> = Crumb of 'a * Graph<'a> list * Graph<'a> list
type Zipper<'a> = Graph<'a> * Crumb<'a> list

let mkGraph value children = { value = value; children = children }

let graphToZipper graph = (graph, [])

let crumbValue (Crumb (x, _, _)) = x

let zipperToPath (focus, crumbs) = 
    let crumbValues = List.map crumbValue crumbs |> List.rev
    crumbValues @ [focus.value]

let goDown zipper = 
    match zipper with
    | ({ value = x; children = y::ys }, crumbs) -> Some (y, Crumb (x, [], ys)::crumbs)
    | _ -> None

let goRight zipper =
    match zipper with
    | (current, Crumb (x, left, r::right)::crumbs) -> Some (r, Crumb (x, (left @ [current]), right)::crumbs)
    | _ -> None

let rec findNode x zipper =
    let (focus, _) = zipper
    if focus.value = x then Some zipper
    else 
        match goDown zipper |> Option.bind (findNode x) with
        | Some x -> Some x
        | None -> goRight zipper |> Option.bind (findNode x)

let rec changeParent zipper = 
    match zipper with 
    | (focus, []) -> focus
    | ({ value = x; children = xs }, Crumb (a, left, right)::crumbs) -> 
        let parentGraph = changeParent (mkGraph a (left @ right), crumbs)
        let ys = xs @ [parentGraph]
        mkGraph x ys
        
let fromPOV x = graphToZipper >> findNode x >> Option.map changeParent
        
let tracePathBetween node1 node2 graph = 
    fromPOV node1 graph 
    |> Option.bind (graphToZipper >> findNode node2 >> Option.map zipperToPath)