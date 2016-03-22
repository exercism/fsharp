module OcrNumbers

let characterWidth = 3
let characterHeight = 4

let digitPatterns = 
    Map.ofList 
        [(
          [|" _ ";
            "| |";
            "|_|"; 
            "   "|],
            "0"
        );
        (
          [|"   ";
            "  |";
            "  |";
            "   "|],
            "1"
        );
        (
          [|" _ ";
            " _|";
            "|_ ";
            "   "|],
            "2"
        );
        (
          [|" _ ";
            " _|";
            " _|";
            "   "|],
            "3"
        );
        (
          [|"   ";
            "|_|";
            "  |";
            "   "|],
            "4"
        );
        (
          [|" _ ";
            "|_ ";
            " _|";
            "   "|],
            "5"
        );
        (
          [|" _ ";
            "|_ ";
            "|_|";
            "   "|],
            "6"
        );
        (
          [|" _ ";
            "  |";
            "  |";
            "   "|],
            "7"
        );
        (
          [|" _ ";
            "|_|";
            "|_|";
            "   "|],
            "8"
        );
        (
          [|" _ ";
            "|_|";
            " _|";
            "   "|],
            "9"
        )]

let matchCharacter input = 
    match Map.tryFind input digitPatterns with
    | Some x -> x
    | None -> "?"

let rows (input:string) = 
    input.Split('\n')
    |> Array.chunkBySize characterHeight

let rowToCharacters (row: string[]) = 
    let chars = (row |> Array.head |> String.length) / characterWidth |> int
    let char i (str: string) = str.Substring(i * characterWidth, characterWidth)

    Array.init chars (fun i -> Array.map (char i) row)

let characters input = input |> rows |> Array.map rowToCharacters

let rowToDigits (row: string[] []) = 
    row 
    |> Array.map matchCharacter 
    |> Array.reduce (fun x y -> x + "" + y)

let convert (input: string) =    
    input
    |> characters 
    |> Array.map rowToDigits
    |> Array.reduce (fun x y -> x + "," + y)