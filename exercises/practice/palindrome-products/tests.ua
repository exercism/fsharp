~ "palindrome-products.ua" ~ PalindromeProducts

# Find the smallest palindrome from single digit factors
expected = 1_[(1, 1])
⍤⤙≍ expected smallest 1 9

# Find the largest palindrome from single digit factors
expected = 9_[(1, 9 (3, 3])
⍤⤙≍ expected largest 1 9

# Find the smallest palindrome from double digit factors
expected = 121_[(11, 11])
⍤⤙≍ expected smallest 10 99

# Find the largest palindrome from double digit factors
expected = 9009_[(91, 99])
⍤⤙≍ expected largest 10 99

# Find the smallest palindrome from triple digit factors
expected = 10201_[(101, 101])
⍤⤙≍ expected smallest 100 999

# Find the largest palindrome from triple digit factors
expected = 906609_[(913, 993])
⍤⤙≍ expected largest 100 999

# Find the smallest palindrome from four digit factors
expected = 1002001_[(1001, 1001])
⍤⤙≍ expected smallest 1000 9999

# Find the largest palindrome from four digit factors
expected = 99000099_[(9901, 9999])
⍤⤙≍ expected largest 1000 9999

# Empty result for smallest if no palindrome in the range
expected = (None_[]
⍤⤙≍ expected smallest 1002 1003

# Empty result for largest if no palindrome in the range
expected = (None_[]
⍤⤙≍ expected largest 15 15

# Error result for smallest if min is more than max
(fun () -> smallest 10000 1 |> ignore) |> should throw typeof<System.ArgumentException>

# Error result for largest if min is more than max
(fun () -> largest 2 1 |> ignore) |> should throw typeof<System.ArgumentException>

