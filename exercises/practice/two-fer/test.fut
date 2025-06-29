import "two_fer"

let ``No name given`` () =
    twoFer None |> should equal "One for you, one for me."

-- A name given
-- ==
-- input { "Alice" }
-- output { "One for Alice, one for me." }

-- Another name given
-- ==
-- input { "Bob" }
-- output { "One for Bob, one for me." }

