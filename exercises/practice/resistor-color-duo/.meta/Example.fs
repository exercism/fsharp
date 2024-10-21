module ResistorColorDuo

let private colors =
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

let private colorCode color = List.findIndex ((=) color) colors

let value colors =
    colorCode (List.item 0 colors) * 10
    + colorCode (List.item 1 colors)
