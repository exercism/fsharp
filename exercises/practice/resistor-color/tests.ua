~ "resistor-color.ua" ~ ResistorColor

# Black
    colorCode "black" |> should equal 0

# White
    colorCode "white" |> should equal 9

# Orange
    colorCode "orange" |> should equal 3

# Colors
    colors |> should equal ["black" "brown" "red" "orange" "yellow" "green" "blue" "violet" "grey" "white"]

