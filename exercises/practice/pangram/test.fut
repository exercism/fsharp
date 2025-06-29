import "pangram"

-- Empty sentence
-- ==
-- input { "" }
-- output { false }

-- Perfect lower case
-- ==
-- input { "abcdefghijklmnopqrstuvwxyz" }
-- output { true }

-- Only lower case
-- ==
-- input { "the quick brown fox jumps over the lazy dog" }
-- output { true }

-- Missing the letter 'x'
-- ==
-- input { "a quick movement of the enemy will jeopardize five gunboats" }
-- output { false }

-- Missing the letter 'h'
-- ==
-- input { "five boxing wizards jump quickly at it" }
-- output { false }

-- With underscores
-- ==
-- input { "the_quick_brown_fox_jumps_over_the_lazy_dog" }
-- output { true }

-- With numbers
-- ==
-- input { "the 1 quick brown fox jumps over the 2 lazy dogs" }
-- output { true }

-- Missing letters replaced by numbers
-- ==
-- input { "7h3 qu1ck brown fox jumps ov3r 7h3 lazy dog" }
-- output { false }

let ``Mixed case and punctuation`` () =
    isPangram "\"Five quacking Zephyrs jolt my wax bed.\"" |> should equal true

-- A-m and A-M are 26 different characters but not a pangram
-- ==
-- input { "abcdefghijklm ABCDEFGHIJKLM" }
-- output { false }

