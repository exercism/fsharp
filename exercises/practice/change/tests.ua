~ "change.ua" ~ Change

# Change for 1 cent
coins    ← [1 5 10 25]
target   ← 1
expected ← [1]
⍤⤙≍ expected ⌕FewestCoins coins target

# Single coin change
coins    ← [1 5 10 25 100]
target   ← 25
expected ← [25]
⍤⤙≍ expected ⌕FewestCoins coins target

# Multiple coin change
coins    ← [1 5 10 25 100]
target   ← 15
expected ← [5 10]
⍤⤙≍ expected ⌕FewestCoins coins target

# Change with Lilliputian Coins
coins    ← [1 4 15 20 50]
target   ← 23
expected ← [4 4 15]
⍤⤙≍ expected ⌕FewestCoins coins target

# Change with Lower Elbonia Coins
coins    ← [1 5 10 21 25]
target   ← 63
expected ← [21 21 21]
⍤⤙≍ expected ⌕FewestCoins coins target

# Large target values
coins    ← [1 2 5 10 20 50 100]
target   ← 999
expected ← [2 2 5 20 20 50 100 100 100 100 100 100 100 100 100]
⍤⤙≍ expected ⌕FewestCoins coins target

# Possible change without unit coins available
coins    ← [2 5 10 20 50]
target   ← 21
expected ← [2 2 2 5 10]
⍤⤙≍ expected ⌕FewestCoins coins target

# Another possible change without unit coins available
coins    ← [4 5]
target   ← 27
expected ← [4 4 4 5 5 5]
⍤⤙≍ expected ⌕FewestCoins coins target

# No coins make 0 change
coins  ← [1 5 10 21 25]
target ← 0
expected: int list option = []
⍤⤙≍ expected ⌕FewestCoins coins target

# Error testing for change smaller than the smallest of coins
coins  ← [5 10]
target ← 3
⍤⤙≍ "TODO: insert error message" ⍣(⌕FewestCoins coins target)

# Error if no combination can add up to target
coins  ← [5 10]
target ← 94
⍤⤙≍ "TODO: insert error message" ⍣(⌕FewestCoins coins target)

# Cannot find negative change values
coins  ← [1 2 5]
target ← -5
⍤⤙≍ "TODO: insert error message" ⍣(⌕FewestCoins coins target)
