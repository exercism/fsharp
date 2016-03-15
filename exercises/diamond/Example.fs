module Diamond

let make letter =     
        
    let makeLine letterCount (row, letter) = 
        let outerSpaces  = "".PadRight(letterCount - row - 1)
        let innerSpaces = "".PadRight(if row = 0 then 0 else row * 2 - 1)

        if letter = 'A' then sprintf "%s%c%s" outerSpaces letter outerSpaces
        else sprintf "%s%c%s%c%s" outerSpaces letter innerSpaces letter outerSpaces
    
    let letters = ['A'..letter] |> List.mapi (fun x y -> x, y)

    letters @ (letters |> List.rev |> List.tail)
    |> List.map (makeLine letters.Length)
    |> List.reduce (fun x y -> sprintf "%s\n%s" x y)