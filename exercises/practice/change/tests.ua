~ "change.ua" ~ Change

# Change for 1 cent
    let coins = [1 5 10 25]
    let target = 1
    let expected = Some [1]
⍤⤙≍ expected findFewestCoins coins target

# Single coin change
    let coins = [1 5 10 25 100]
    let target = 25
    let expected = Some [25]
⍤⤙≍ expected findFewestCoins coins target

# Multiple coin change
    let coins = [1 5 10 25 100]
    let target = 15
    let expected = Some [5 10]
⍤⤙≍ expected findFewestCoins coins target

# Change with Lilliputian Coins
    let coins = [1 4 15 20 50]
    let target = 23
    let expected = Some [4 4 15]
⍤⤙≍ expected findFewestCoins coins target

# Change with Lower Elbonia Coins
    let coins = [1 5 10 21 25]
    let target = 63
    let expected = Some [21 21 21]
⍤⤙≍ expected findFewestCoins coins target

# Large target values
    let coins = [1 2 5 10 20 50 100]
    let target = 999
    let expected = Some [2 2 5 20 20 50 100 100 100 100 100 100 100 100 100]
⍤⤙≍ expected findFewestCoins coins target

# Possible change without unit coins available
    let coins = [2 5 10 20 50]
    let target = 21
    let expected = Some [2 2 2 5 10]
⍤⤙≍ expected findFewestCoins coins target

# Another possible change without unit coins available
    let coins = [4 5]
    let target = 27
    let expected = Some [4 4 4 5 5 5]
⍤⤙≍ expected findFewestCoins coins target

# No coins make 0 change
    let coins = [1 5 10 21 25]
    let target = 0
    let expected: int list option = Some []
⍤⤙≍ expected findFewestCoins coins target

# Error testing for change smaller than the smallest of coins
    let coins = [5 10]
    let target = 3
    let expected = None
⍤⤙≍ expected findFewestCoins coins target

# Error if no combination can add up to target
    let coins = [5 10]
    let target = 94
    let expected = None
⍤⤙≍ expected findFewestCoins coins target

# Cannot find negative change values
    let coins = [1 2 5]
    let target = -5
    let expected = None
⍤⤙≍ expected findFewestCoins coins target

