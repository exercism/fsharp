module GradeSchool

type School = Map<int, string list>
let empty = Map.empty<int, string list>

let add student grade school = 
    match Map.tryFind grade school with
    | Some existing -> Map.add grade (student :: existing |> List.sort) school
    | None -> Map.add grade [student] school

let roster school =
    school
    |> Map.toList
    |> List.sortBy fst
    |> List.map snd
    |> List.fold (fun finalList listItem -> finalList @ (List.sort listItem)) []

let grade number school = 
    match Map.tryFind number school with
    | Some students -> students
    | None -> []