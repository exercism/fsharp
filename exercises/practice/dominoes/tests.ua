~ "dominoes.ua" ~ Dominoes

# Empty input = empty output
dominoes = []
⍤⤙≍ 1 canChain dominoes

# Singleton input = singleton output
dominoes = [1_1]
⍤⤙≍ 1 canChain dominoes

# Singleton that can't be chained
dominoes = [1_2]
⍤⤙≍ 0 canChain dominoes

# Three elements
dominoes = [1_2 3_1 2_3]
⍤⤙≍ 1 canChain dominoes

# Can reverse dominoes
dominoes = [1_2 1_3 2_3]
⍤⤙≍ 1 canChain dominoes

# Can't be chained
dominoes = [1_2 4_1 2_3]
⍤⤙≍ 0 canChain dominoes

# Disconnected - simple
dominoes = [1_1 2_2]
⍤⤙≍ 0 canChain dominoes

# Disconnected - double loop
dominoes = [1_2 2_1 3_4 4_3]
⍤⤙≍ 0 canChain dominoes

# Disconnected - single isolated
dominoes = [1_2 2_3 3_1 4_4]
⍤⤙≍ 0 canChain dominoes

# Need backtrack
dominoes = [1_2 2_3 3_1 2_4 2_4]
⍤⤙≍ 1 canChain dominoes

# Separate loops
dominoes = [1_2 2_3 3_1 1_1 2_2 3_3]
⍤⤙≍ 1 canChain dominoes

# Nine elements
dominoes = [1_2 5_3 3_1 1_2 2_4 1_6 2_3 3_4 5_6]
⍤⤙≍ 1 canChain dominoes

# Separate three-domino loops
dominoes = [1_2 2_3 3_1 4_5 5_6 6_4]
⍤⤙≍ 0 canChain dominoes

