import "rotational_cipher"

-- Rotate a by 0, same output as input
-- ==
-- input { 0 "a" }
-- output { "a" }

-- Rotate a by 1
-- ==
-- input { 1 "a" }
-- output { "b" }

-- Rotate a by 26, same output as input
-- ==
-- input { 26 "a" }
-- output { "a" }

-- Rotate m by 13
-- ==
-- input { 13 "m" }
-- output { "z" }

-- Rotate n by 13 with wrap around alphabet
-- ==
-- input { 13 "n" }
-- output { "a" }

-- Rotate capital letters
-- ==
-- input { 5 "OMG" }
-- output { "TRL" }

-- Rotate spaces
-- ==
-- input { 5 "O M G" }
-- output { "T R L" }

-- Rotate numbers
-- ==
-- input { 4 "Testing 1 2 3 testing" }
-- output { "Xiwxmrk 1 2 3 xiwxmrk" }

-- Rotate punctuation
-- ==
-- input { 21 "Let's eat, Grandma!" }
-- output { "Gzo'n zvo, Bmviyhv!" }

-- Rotate all letters
-- ==
-- input { 13 "The quick brown fox jumps over the lazy dog." }
-- output { "Gur dhvpx oebja sbk whzcf bire gur ynml qbt." }

