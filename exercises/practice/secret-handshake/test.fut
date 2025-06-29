import "secret_handshake"

-- Wink for 1
-- ==
-- input { 1 }
-- output { ["wink"] }

-- Double blink for 10
-- ==
-- input { 2 }
-- output { ["double blink"] }

-- Close your eyes for 100
-- ==
-- input { 4 }
-- output { ["close your eyes"] }

-- Jump for 1000
-- ==
-- input { 8 }
-- output { ["jump"] }

-- Combine two actions
-- ==
-- input { 3 }
-- output { ["wink", "double blink"] }

-- Reverse two actions
-- ==
-- input { 19 }
-- output { ["double blink", "wink"] }

-- Reversing one action gives the same action
-- ==
-- input { 24 }
-- output { ["jump"] }

let ``Reversing no actions still gives no actions`` () =
    commands 16 |> should be Empty

-- All possible actions
-- ==
-- input { 15 }
-- output { ["wink", "double blink", "close your eyes", "jump"] }

-- Reverse all possible actions
-- ==
-- input { 31 }
-- output { ["jump", "close your eyes", "double blink", "wink"] }

let ``Do nothing for zero`` () =
    commands 0 |> should be Empty

