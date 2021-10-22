module TisburyTreasureHunt

let getCoordinate (line: string*string): string = snd line

let convertCoordinate (coordinate: string): string*string = 
    string coordinate.[0], string coordinate.[1]

let compareRecords (azarasData: string*string) (ruisData: string*(string*string)*string) : bool = 
    let azarasCoordinate = getCoordinate azarasData
    let (_,ruisCoordinate,_) = ruisData
    convertCoordinate azarasCoordinate = ruisCoordinate

let createRecord (azarasData: string*string) (ruisData: string*(string*string)*string) : (string*string*string*(string*string)*string) =
    if compareRecords azarasData ruisData then
        match azarasData, ruisData with
        | (treasure, coordinate), (location, coordinates, quadrant) -> 
            (treasure, coordinate, location, coordinates, quadrant)
    else
        ("", "", "", ("", ""), "")
