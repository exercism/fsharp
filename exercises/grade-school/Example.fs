module School

type School() =

    let mutable rosterMap : Map<int, string list> = Map.empty

    member this.roster = rosterMap
    member this.grade(mark:int) = if this.roster.ContainsKey(mark) then this.roster.[mark] else []
    member this.add(student:string, mark:int): unit = 
        rosterMap <- Map.add mark (student :: this.grade mark |> List.sort) rosterMap