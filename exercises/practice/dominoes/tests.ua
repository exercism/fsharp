~ "dominoes.ua" ~ Dominoes

# Empty input = empty output
dominoes = []
⍤⤙≍ 1 canChain dominoes

# Singleton input = singleton output
dominoes = [(1, 1)]
⍤⤙≍ 1 canChain dominoes

# Singleton that can't be chained
dominoes = [(1, 2)]
⍤⤙≍ 0 canChain dominoes

# Three elements
dominoes = [(1, 2) (3, 1) (2, 3)]
⍤⤙≍ 1 canChain dominoes

# Can reverse dominoes
dominoes = [(1, 2) (1, 3) (2, 3)]
⍤⤙≍ 1 canChain dominoes

# Can't be chained
dominoes = [(1, 2) (4, 1) (2, 3)]
⍤⤙≍ 0 canChain dominoes

# Disconnected - simple
dominoes = [(1, 1) (2, 2)]
⍤⤙≍ 0 canChain dominoes

# Disconnected - double loop
dominoes = [(1, 2) (2, 1) (3, 4) (4, 3)]
⍤⤙≍ 0 canChain dominoes

# Disconnected - single isolated
dominoes = [(1, 2) (2, 3) (3, 1) (4, 4)]
⍤⤙≍ 0 canChain dominoes

# Need backtrack
dominoes = [(1, 2) (2, 3) (3, 1) (2, 4) (2, 4)]
⍤⤙≍ 1 canChain dominoes

# Separate loops
dominoes = [(1, 2) (2, 3) (3, 1) (1, 1) (2, 2) (3, 3)]
⍤⤙≍ 1 canChain dominoes

# Nine elements
dominoes = [(1, 2) (5, 3) (3, 1) (1, 2) (2, 4) (1, 6) (2, 3) (3, 4) (5, 6)]
⍤⤙≍ 1 canChain dominoes

# Separate three-domino loops
dominoes = [(1, 2) (2, 3) (3, 1) (4, 5) (5, 6) (6, 4)]
⍤⤙≍ 0 canChain dominoes

