import "resistor_color"

-- Black
-- ==
-- input { "black" }
-- output { 0 }

-- White
-- ==
-- input { "white" }
-- output { 9 }

-- Orange
-- ==
-- input { "orange" }
-- output { 3 }

let ``Colors`` () =
    colors |> should equal ["black", "brown", "red", "orange", "yellow", "green", "blue", "violet", "grey", "white"]

