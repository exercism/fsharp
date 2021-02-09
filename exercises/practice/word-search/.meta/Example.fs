module WordSearch

let private directions =
    [( 1,  0);
     ( 0,  1);
     (-1,  0);
     ( 0, -1);
     ( 1,  1);
     ( 1, -1);
     (-1,  1);
     (-1, -1)]
     
let private update (x, y) (dx, dy) = x + dx, y + dy

let search (grid: string list) (wordsToSearchFor: string list) =
    let width = List.head grid |> Seq.length
    let height = List.length grid

    let findChar (x, y) = 
        if x > 0 && x <= width && y > 0 && y <= height then 
            Some grid.[y - 1].[x - 1]
        else None
        
    let findWord start direction word =
        let rec helper coord last (remainder: string) =
            if remainder.Length = 0 then Some (start, last)
            elif Some remainder.[0] = findChar coord then helper (update coord direction) coord remainder.[1..]
            else None

        helper start start word

    let tryFindWord word =
        seq { for x in 1 .. width do
                for y in 1 .. height do
                    for dir in directions do
                        let result = findWord (x, y) dir word
                        if Option.isSome result then
                            yield Option.get result }
        |> Seq.tryHead

    wordsToSearchFor
    |> List.map (fun word -> (word, tryFindWord word))
    |> Map.ofList