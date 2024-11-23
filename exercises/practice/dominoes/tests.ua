~ "dominoes.ua" ~ Dominoes

# Empty input = empty output
    let dominoes = []
⍤⤙≍ true canChain dominoes

# Singleton input = singleton output
    let dominoes = [(1, 1)]
⍤⤙≍ true canChain dominoes

# Singleton that can't be chained
    let dominoes = [(1, 2)]
⍤⤙≍ false canChain dominoes

# Three elements
    let dominoes = [(1, 2) (3, 1) (2, 3)]
⍤⤙≍ true canChain dominoes

# Can reverse dominoes
    let dominoes = [(1, 2) (1, 3) (2, 3)]
⍤⤙≍ true canChain dominoes

# Can't be chained
    let dominoes = [(1, 2) (4, 1) (2, 3)]
⍤⤙≍ false canChain dominoes

# Disconnected - simple
    let dominoes = [(1, 1) (2, 2)]
⍤⤙≍ false canChain dominoes

# Disconnected - double loop
    let dominoes = [(1, 2) (2, 1) (3, 4) (4, 3)]
⍤⤙≍ false canChain dominoes

# Disconnected - single isolated
    let dominoes = [(1, 2) (2, 3) (3, 1) (4, 4)]
⍤⤙≍ false canChain dominoes

# Need backtrack
    let dominoes = [(1, 2) (2, 3) (3, 1) (2, 4) (2, 4)]
⍤⤙≍ true canChain dominoes

# Separate loops
    let dominoes = [(1, 2) (2, 3) (3, 1) (1, 1) (2, 2) (3, 3)]
⍤⤙≍ true canChain dominoes

# Nine elements
    let dominoes = [(1, 2) (5, 3) (3, 1) (1, 2) (2, 4) (1, 6) (2, 3) (3, 4) (5, 6)]
⍤⤙≍ true canChain dominoes

# Separate three-domino loops
    let dominoes = [(1, 2) (2, 3) (3, 1) (4, 5) (5, 6) (6, 4)]
⍤⤙≍ false canChain dominoes

