module GradeSchool

let empty = Map.empty<int, string list>

let add student grade school = 
    match Map.tryFind grade school with
    | Some existing -> Map.add grade (student :: existing |> List.sort) school
    | None -> Map.add grade [student] school

let roster school = school |> Map.toSeq

let grade number school = 
    match Map.tryFind number school with
    | Some students -> students
    | None -> []