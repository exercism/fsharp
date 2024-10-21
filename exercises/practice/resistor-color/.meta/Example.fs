module ResistorColor

let colors =
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

let colorCode color = List.findIndex ((=) color) colors
