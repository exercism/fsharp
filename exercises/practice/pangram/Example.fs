module Pangram

let isPangram (input: string) = 
    let normalized = input.ToLowerInvariant()
    
    ['a'..'z'] |> List.forall (fun l -> normalized.Contains(l.ToString()))