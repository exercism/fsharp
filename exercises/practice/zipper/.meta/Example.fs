module Zipper

type BinTree<'a> = { btValue: 'a; btLeft: BinTree<'a> option; btRight: BinTree<'a> option }

type Crumb<'a> = 
    | LeftCrumb of 'a * BinTree<'a> option
    | RightCrumb of 'a * BinTree<'a> option

type Breadcrumbs<'a> = Crumb<'a> list

type Zipper<'a> = { zValue: 'a; zLeft: BinTree<'a> option; zRight: BinTree<'a> option; zCrumbs: Breadcrumbs<'a> }

let tree value left right = { btValue = value; btLeft = left; btRight = right }
let zipper value left right crumbs = { zValue = value; zLeft = left; zRight = right; zCrumbs = crumbs }

let fromTree t = zipper t.btValue t.btLeft t.btRight []

let toTree z = 
    let rec loop crumbs t =
        match crumbs with
        | [] -> t
        | (LeftCrumb  (tv, tr))::cs -> loop cs (tree tv (Some t) tr) 
        | (RightCrumb (tv, tl))::cs -> loop cs (tree tv tl (Some t)) 
    
    tree z.zValue z.zLeft z.zRight
    |> loop z.zCrumbs

let value zipper = zipper.zValue

let left z =
    match z.zLeft with
    | None -> None
    | Some l -> zipper l.btValue l.btLeft l.btRight ((LeftCrumb (z.zValue, z.zRight))::z.zCrumbs) |> Some

let right z =
    match z.zRight with
    | None -> None
    | Some r -> zipper r.btValue r.btLeft r.btRight ((RightCrumb (z.zValue, z.zLeft))::z.zCrumbs) |> Some

let up z =
    match z.zCrumbs with
    | [] -> None
    | (LeftCrumb  (tv, tr))::cs -> zipper tv (tree z.zValue z.zLeft z.zRight |> Some) tr cs |> Some
    | (RightCrumb (tv, tl))::cs -> zipper tv tl (tree z.zValue z.zLeft z.zRight |> Some) cs |> Some

let setValue tv z = { z with zValue = tv }

let setLeft tl z = { z with zLeft = tl }

let setRight tr z = { z with zRight = tr }