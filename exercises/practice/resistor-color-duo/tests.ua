~ "resistor-color-duo.ua" ~ ResistorColorDuo

# Brown and black
    value ["brown" "black"] |> should equal 10

# Blue and grey
    value ["blue" "grey"] |> should equal 68

# Yellow and violet
    value ["yellow" "violet"] |> should equal 47

# White and red
    value ["white" "red"] |> should equal 92

# Orange and orange
    value ["orange" "orange"] |> should equal 33

# Ignore additional colors
    value ["green" "brown" "orange"] |> should equal 51

# Black and brown, one-digit
    value ["black" "brown"] |> should equal 1

