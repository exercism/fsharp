module ETL

let transform (input:Map<int, string list>): Map<string, int> = 
    let transformElement num acc (str:string) = Map.add (str.ToLowerInvariant()) num acc
    Map.fold (fun acc num strings -> List.fold (transformElement num) acc strings) Map.empty input
        