module KindergartenGarden

type Plant = Violets | Radishes | Clover | Grass

let plantsPerChildPerRow = 2
let rowSeparator = '\n'

let private defaultChildren = ["Alice"; "Bob"; "Charlie"; "David";
                               "Eve"; "Fred"; "Ginny"; "Harriet";
                               "Ileana"; "Joseph"; "Kincaid"; "Larry"]

let private plantFromCode code =
    match code with
    | 'V' -> Plant.Violets
    | 'R' -> Plant.Radishes
    | 'C' -> Plant.Clover
    | 'G' -> Plant.Grass
    | x -> failwithf "%c is an invalid plant code" x

let private plantsInRow (row: string) = 
    Seq.map plantFromCode row 
    |> Seq.chunkBySize plantsPerChildPerRow
    |> Seq.map List.ofArray

let toGarden children (windowSills: string) =     
    let rows = windowSills.Split rowSeparator
    let row1 = plantsInRow rows.[0]
    let row2 = plantsInRow rows.[1]
    Seq.zip3 (children |> List.sort) row1 row2 
    |> Seq.map (fun (child, plants1, plants2) -> (child, plants1 @ plants2))
    |> Map.ofSeq

let plantsForCustomStudents diagram student students = 
    let garden = toGarden students diagram
    defaultArg (Map.tryFind student garden) []

let plantsForDefaultStudents diagram student = plantsForCustomStudents diagram student defaultChildren