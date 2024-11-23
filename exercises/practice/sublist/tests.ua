~ "sublist.ua" ~ Sublist

# Empty lists
    let listOne = []
    let listTwo = []
    sublist listOne listTwo |> should equal SublistType.Equal

# Empty list within non empty list
    let listOne = []
    let listTwo = [1 2 3]
    sublist listOne listTwo |> should equal SublistType.Sublist

# Non empty list contains empty list
    let listOne = [1 2 3]
    let listTwo = []
    sublist listOne listTwo |> should equal SublistType.Superlist

# List equals itself
    let listOne = [1 2 3]
    let listTwo = [1 2 3]
    sublist listOne listTwo |> should equal SublistType.Equal

# Different lists
    let listOne = [1 2 3]
    let listTwo = [2 3 4]
    sublist listOne listTwo |> should equal SublistType.Unequal

# False start
    let listOne = [1 2 5]
    let listTwo = [0 1 2 3 1 2 5 6]
    sublist listOne listTwo |> should equal SublistType.Sublist

# Consecutive
    let listOne = [1 1 2]
    let listTwo = [0 1 1 1 2 1 2]
    sublist listOne listTwo |> should equal SublistType.Sublist

# Sublist at start
    let listOne = [0 1 2]
    let listTwo = [0 1 2 3 4 5]
    sublist listOne listTwo |> should equal SublistType.Sublist

# Sublist in middle
    let listOne = [2 3 4]
    let listTwo = [0 1 2 3 4 5]
    sublist listOne listTwo |> should equal SublistType.Sublist

# Sublist at end
    let listOne = [3 4 5]
    let listTwo = [0 1 2 3 4 5]
    sublist listOne listTwo |> should equal SublistType.Sublist

# At start of superlist
    let listOne = [0 1 2 3 4 5]
    let listTwo = [0 1 2]
    sublist listOne listTwo |> should equal SublistType.Superlist

# In middle of superlist
    let listOne = [0 1 2 3 4 5]
    let listTwo = [2 3]
    sublist listOne listTwo |> should equal SublistType.Superlist

# At end of superlist
    let listOne = [0 1 2 3 4 5]
    let listTwo = [3 4 5]
    sublist listOne listTwo |> should equal SublistType.Superlist

# First list missing element from second list
    let listOne = [1 3]
    let listTwo = [1 2 3]
    sublist listOne listTwo |> should equal SublistType.Unequal

# Second list missing element from first list
    let listOne = [1 2 3]
    let listTwo = [1 3]
    sublist listOne listTwo |> should equal SublistType.Unequal

# First list missing additional digits from second list
    let listOne = [1 2]
    let listTwo = [1 22]
    sublist listOne listTwo |> should equal SublistType.Unequal

# Order matters to a list
    let listOne = [1 2 3]
    let listTwo = [3 2 1]
    sublist listOne listTwo |> should equal SublistType.Unequal

# Same digits but different numbers
    let listOne = [1 0 1]
    let listTwo = [10 1]
    sublist listOne listTwo |> should equal SublistType.Unequal

