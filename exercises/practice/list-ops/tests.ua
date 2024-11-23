~ "list-ops.ua" ~ ListOps

# append empty lists
    append [] [] |> should be Empty

# append list to empty list
    append [] [1; 2; 3; 4] |> should equal [1; 2; 3; 4]

# append empty list to list
    append [1; 2; 3; 4] [] |> should equal [1; 2; 3; 4]

# append non-empty lists
    append [1; 2] [2; 3; 4; 5] |> should equal [1; 2; 2; 3; 4; 5]

# concat empty list
    concat [] |> should be Empty

# concat list of lists
    concat [[1; 2]; [3]; []; [4; 5; 6]] |> should equal [1; 2; 3; 4; 5; 6]

# concat list of nested lists
    concat [[[1]; [2]]; [[3]]; [[]]; [[4; 5; 6]]] |> should equal [[1]; [2]; [3]; []; [4; 5; 6]]

# filter empty list
    filter (fun acc -> acc % 2 = 1) [] |> should be Empty

# filter non-empty list
    filter (fun acc -> acc % 2 = 1) [1; 2; 3; 5] |> should equal [1; 3; 5]

# length empty list
    length [] |> should equal 0

# length non-empty list
    length [1; 2; 3; 4] |> should equal 4

# map empty list
    map (fun acc -> acc + 1) [] |> should be Empty

# map non-empty list
    map (fun acc -> acc + 1) [1; 3; 5; 7] |> should equal [2; 4; 6; 8]

# foldl empty list
    foldl (fun acc el -> el * acc) 2 [] |> should equal 2

# foldl direction independent function applied to non-empty list
    foldl (fun acc el -> el + acc) 5 [1; 2; 3; 4] |> should equal 15

# foldr empty list
    foldr (fun acc el -> el * acc) 2 [] |> should equal 2

# foldr direction independent function applied to non-empty list
    foldr (fun acc el -> el + acc) 5 [1; 2; 3; 4] |> should equal 15

# reverse empty list
    reverse [] |> should be Empty

# reverse non-empty list
    reverse [1; 3; 5; 7] |> should equal [7; 5; 3; 1]

# reverse list of lists is not flattened
    reverse [[1; 2]; [3]; []; [4; 5; 6]] |> should equal [[4; 5; 6]; []; [3]; [1; 2]]

