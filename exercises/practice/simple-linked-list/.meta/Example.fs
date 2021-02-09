module SimpleLinkedList

type LinkedList<'a> = 
    | Nil 
    | Element of datum:'a * next:LinkedList<'a>

let nil = Nil

let create x n = Element (x, n)

let isNil x = 
    match x with
    | Nil -> true
    | _   -> false

let next x = 
    match x with
    | Nil -> Nil
    | Element (_, n) -> n

let datum x = 
    match x with
    | Nil -> failwith "The nil list has no datum."
    | Element (y, _) -> y

let toList x = 
    let rec loop acc item = 
        match item with
        | Nil -> acc |> List.rev
        | Element (b, n) -> loop (b :: acc) n

    loop [] x

let fromList xs = List.foldBack create xs Nil

let reverse x = x |> toList |> List.rev |> fromList