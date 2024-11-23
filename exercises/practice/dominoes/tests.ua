~ "dominoes.ua" ~ Dominoes

# Empty input = empty output
    let dominoes = []
    canChain dominoes |> should equal true

# Singleton input = singleton output
    let dominoes = [(1, 1)]
    canChain dominoes |> should equal true

# Singleton that can't be chained
    let dominoes = [(1, 2)]
    canChain dominoes |> should equal false

# Three elements
    let dominoes = [(1, 2) (3, 1) (2, 3)]
    canChain dominoes |> should equal true

# Can reverse dominoes
    let dominoes = [(1, 2) (1, 3) (2, 3)]
    canChain dominoes |> should equal true

# Can't be chained
    let dominoes = [(1, 2) (4, 1) (2, 3)]
    canChain dominoes |> should equal false

# Disconnected - simple
    let dominoes = [(1, 1) (2, 2)]
    canChain dominoes |> should equal false

# Disconnected - double loop
    let dominoes = [(1, 2) (2, 1) (3, 4) (4, 3)]
    canChain dominoes |> should equal false

# Disconnected - single isolated
    let dominoes = [(1, 2) (2, 3) (3, 1) (4, 4)]
    canChain dominoes |> should equal false

# Need backtrack
    let dominoes = [(1, 2) (2, 3) (3, 1) (2, 4) (2, 4)]
    canChain dominoes |> should equal true

# Separate loops
    let dominoes = [(1, 2) (2, 3) (3, 1) (1, 1) (2, 2) (3, 3)]
    canChain dominoes |> should equal true

# Nine elements
    let dominoes = [(1, 2) (5, 3) (3, 1) (1, 2) (2, 4) (1, 6) (2, 3) (3, 4) (5, 6)]
    canChain dominoes |> should equal true

# Separate three-domino loops
    let dominoes = [(1, 2) (2, 3) (3, 1) (4, 5) (5, 6) (6, 4)]
    canChain dominoes |> should equal false

