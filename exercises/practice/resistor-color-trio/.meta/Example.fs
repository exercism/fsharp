module ResistorColorTrio

let private allColors =
    [ "black"
      "brown"
      "red"
      "orange"
      "yellow"
      "green"
      "blue"
      "violet"
      "grey"
      "white" ]

let private colorCode color = List.findIndex ((=) color) allColors

let private value colors =
    let first = colorCode (List.item 0 colors) 
    let second = colorCode (List.item 1 colors) 
    let third = colorCode (List.item 2 colors) 
    uint64 (first * 10 + second) * uint64(pown 10 third)

let label colors =
    match value colors with
    | ohms when ohms < 1_000UL -> $"{ohms} ohms"
    | ohms when ohms < 1_000_000UL -> $"{ohms / 1000UL} kiloohms" 
    | ohms when ohms < 1_000_000_000UL -> $"{ohms / 1_000_000UL} megaohms"
    | ohms -> $"{ohms / 1_000_000_000UL} gigaohms"
