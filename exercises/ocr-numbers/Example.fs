module OcrNumbers

let characterWidth = 3
let characterHeight = 4

let digitPatterns = 
    Map.ofList 
        [(
          [ " _ ";
            "| |";
            "|_|"; 
            "   " ],
            "0"
        );
        (
          [ "   ";
            "  |";
            "  |";
            "   "],
            "1"
        );
        (
          [ " _ ";
            " _|";
            "|_ ";
            "   " ],
            "2"
        );
        (
          [ " _ ";
            " _|";
            " _|";
            "   " ],
            "3"
        );
        (
          [ "   ";
            "|_|";
            "  |";
            "   " ],
            "4"
        );
        (
          [ " _ ";
            "|_ ";
            " _|";
            "   " ],
            "5"
        );
        (
          [ " _ ";
            "|_ ";
            "|_|";
            "   " ],
            "6"
        );
        (
          [ " _ ";
            "  |";
            "  |";
            "   " ],
            "7"
        );
        (
          [ " _ ";
            "|_|";
            "|_|";
            "   " ],
            "8"
        );
        (
          [ " _ ";
            "|_|";
            " _|";
            "   " ],
            "9"
        )]

let matchCharacter input = 
    match Map.tryFind input digitPatterns with
    | Some x -> x
    | None -> "?"

let rows (input:string list) = List.chunkBySize characterHeight input

let rowToCharacters (row: string list) = 
    let chars = (row |> List.head |> String.length) / characterWidth |> int
    let char i (str: string) = str.Substring(i * characterWidth, characterWidth)

    List.init chars (fun i -> List.map (char i) row)

let characters input = input |> rows |> List.map rowToCharacters

let rowToDigits (row: string list list) = 
    row 
    |> List.map matchCharacter 
    |> List.reduce (fun x y -> x + "" + y)

let invalidNumberOfColumns row = String.length row % characterWidth <> 0

let invalidNumberOfRows rows = List.length rows % characterHeight <> 0

let isInvalid input = invalidNumberOfRows input || List.exists invalidNumberOfColumns input

let convert (input: string list) = 
    if isInvalid input then
        None
    else
        input
        |> characters 
        |> List.map rowToDigits
        |> List.reduce (fun x y -> x + "," + y)
        |> Some