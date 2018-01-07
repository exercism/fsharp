module CustomSet

type Set<'T> = { items: 'T list }

let empty = { items = [] }

let singleton value = { items = [value] }

let isEmpty set = set.items.IsEmpty

let size set = set.items.Length 

let fromList list = { items = list |> List.sort |> List.distinct } 

let toList set = set.items

let contains value set = List.contains value set.items

let insert value set = value::set.items |> fromList

let union left right = left.items @ right.items |> fromList

let intersection left right = left.items |> List.filter (fun x -> List.contains x right.items) |> fromList

let difference left right = left.items |> List.filter (fun x -> List.contains x right.items |> not) |> fromList

let isEqualTo left right = (size left = size right) && (isEmpty (difference left right))

let isSubsetOf left right = left.items |> List.forall (fun x -> List.contains x right.items)

let isDisjointFrom left right = left.items |> List.exists (fun x -> List.contains x right.items) |> not