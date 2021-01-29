module TreeBuilding

type Record = { RecordId: int; ParentId: int }
type Tree = 
    | Branch of int * Tree list
    | Leaf of int

let recordId = function Branch (id, _) | Leaf id -> id

let isBranch = function Branch _ -> true  | Leaf _ -> false

let children = function Branch (_, children') -> children' | Leaf _ -> []

let rootNodeRecordId = 0

let addOrAppend key value map =
    let list = defaultArg (Map.tryFind key map) []
    Map.add key (list @ [value]) map

let invalidNode previous x = 
    match x.RecordId with
    | 0 -> x.ParentId <> rootNodeRecordId
    | _ -> x.ParentId >= x.RecordId || x.RecordId <> previous + 1

let rec recordsToMap previous map remainder =
    match remainder with
    | [] -> 
        map
    | x::_ when invalidNode previous x ->
        failwith "Invalid record"
    | x::xs ->
        let parentId = if x.RecordId = rootNodeRecordId then -1 else x.ParentId
        let updatedMap = addOrAppend parentId x.RecordId map
        recordsToMap x.RecordId updatedMap xs

let rec mapToTree map recordId =
    match Map.tryFind recordId map with
    | Some x -> Branch (recordId, x |> List.map (mapToTree map))
    | None   -> Leaf recordId        

let sortRecords records = List.sortBy (fun x -> x.RecordId) records

let buildTree records = 
    match records with
    | [] -> 
        failwith "Empty input"
    | _ ->
        let parentChildrenMap = recordsToMap -1 Map.empty (sortRecords records)
        mapToTree parentChildrenMap 0