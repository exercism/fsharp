~ "eliuds-eggs.ua" ~ EliudsEggs

# 0 eggs
    eggCount 0 |> should equal 0

# 1 egg
    eggCount 16 |> should equal 1

# 4 eggs
    eggCount 89 |> should equal 4

# 13 eggs
    eggCount 2000000000 |> should equal 13

