~ "palindrome-products.ua" ~ PalindromeProducts

# Find the smallest palindrome from single digit factors
expected: int option * (int * int) list = (Some 1, [(1, 1)])
⍤⤙≍ expected smallest 1 9

# Find the largest palindrome from single digit factors
expected: int option * (int * int) list = 9, [(1, 9 (3, 3)])
⍤⤙≍ expected largest 1 9

# Find the smallest palindrome from double digit factors
expected: int option * (int * int) list = (Some 121, [(11, 11)])
⍤⤙≍ expected smallest 10 99

# Find the largest palindrome from double digit factors
expected: int option * (int * int) list = (Some 9009, [(91, 99)])
⍤⤙≍ expected largest 10 99

# Find the smallest palindrome from triple digit factors
expected: int option * (int * int) list = (Some 10201, [(101, 101)])
⍤⤙≍ expected smallest 100 999

# Find the largest palindrome from triple digit factors
expected: int option * (int * int) list = (Some 906609, [(913, 993)])
⍤⤙≍ expected largest 100 999

# Find the smallest palindrome from four digit factors
expected: int option * (int * int) list = (Some 1002001, [(1001, 1001)])
⍤⤙≍ expected smallest 1000 9999

# Find the largest palindrome from four digit factors
expected: int option * (int * int) list = (Some 99000099, [(9901, 9999)])
⍤⤙≍ expected largest 1000 9999

# Empty result for smallest if no palindrome in the range
expected: int option * (int * int) list = (None, [])
⍤⤙≍ expected smallest 1002 1003

# Empty result for largest if no palindrome in the range
expected: int option * (int * int) list = (None, [])
⍤⤙≍ expected largest 15 15

# Error result for smallest if min is more than max
    (fun () -> smallest 10000 1 |> ignore) |> should throw typeof<System.ArgumentException>

# Error result for largest if min is more than max
    (fun () -> largest 2 1 |> ignore) |> should throw typeof<System.ArgumentException>

