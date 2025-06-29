import "allergies"

let ``Testing for eggs allergy - not allergic to anything`` () =
    allergicTo 0 "Eggs" |> should equal false

let ``Testing for eggs allergy - allergic only to eggs`` () =
    allergicTo 1 "Eggs" |> should equal true

let ``Testing for eggs allergy - allergic to eggs and something else`` () =
    allergicTo 3 "Eggs" |> should equal true

let ``Testing for eggs allergy - allergic to something, but not eggs`` () =
    allergicTo 2 "Eggs" |> should equal false

let ``Testing for eggs allergy - allergic to everything`` () =
    allergicTo 255 "Eggs" |> should equal true

let ``Testing for peanuts allergy - not allergic to anything`` () =
    allergicTo 0 "Peanuts" |> should equal false

let ``Testing for peanuts allergy - allergic only to peanuts`` () =
    allergicTo 2 "Peanuts" |> should equal true

let ``Testing for peanuts allergy - allergic to peanuts and something else`` () =
    allergicTo 7 "Peanuts" |> should equal true

let ``Testing for peanuts allergy - allergic to something, but not peanuts`` () =
    allergicTo 5 "Peanuts" |> should equal false

let ``Testing for peanuts allergy - allergic to everything`` () =
    allergicTo 255 "Peanuts" |> should equal true

let ``Testing for shellfish allergy - not allergic to anything`` () =
    allergicTo 0 "Shellfish" |> should equal false

let ``Testing for shellfish allergy - allergic only to shellfish`` () =
    allergicTo 4 "Shellfish" |> should equal true

let ``Testing for shellfish allergy - allergic to shellfish and something else`` () =
    allergicTo 14 "Shellfish" |> should equal true

let ``Testing for shellfish allergy - allergic to something, but not shellfish`` () =
    allergicTo 10 "Shellfish" |> should equal false

let ``Testing for shellfish allergy - allergic to everything`` () =
    allergicTo 255 "Shellfish" |> should equal true

let ``Testing for strawberries allergy - not allergic to anything`` () =
    allergicTo 0 "Strawberries" |> should equal false

let ``Testing for strawberries allergy - allergic only to strawberries`` () =
    allergicTo 8 "Strawberries" |> should equal true

let ``Testing for strawberries allergy - allergic to strawberries and something else`` () =
    allergicTo 28 "Strawberries" |> should equal true

let ``Testing for strawberries allergy - allergic to something, but not strawberries`` () =
    allergicTo 20 "Strawberries" |> should equal false

let ``Testing for strawberries allergy - allergic to everything`` () =
    allergicTo 255 "Strawberries" |> should equal true

let ``Testing for tomatoes allergy - not allergic to anything`` () =
    allergicTo 0 "Tomatoes" |> should equal false

let ``Testing for tomatoes allergy - allergic only to tomatoes`` () =
    allergicTo 16 "Tomatoes" |> should equal true

let ``Testing for tomatoes allergy - allergic to tomatoes and something else`` () =
    allergicTo 56 "Tomatoes" |> should equal true

let ``Testing for tomatoes allergy - allergic to something, but not tomatoes`` () =
    allergicTo 40 "Tomatoes" |> should equal false

let ``Testing for tomatoes allergy - allergic to everything`` () =
    allergicTo 255 "Tomatoes" |> should equal true

let ``Testing for chocolate allergy - not allergic to anything`` () =
    allergicTo 0 "Chocolate" |> should equal false

let ``Testing for chocolate allergy - allergic only to chocolate`` () =
    allergicTo 32 "Chocolate" |> should equal true

let ``Testing for chocolate allergy - allergic to chocolate and something else`` () =
    allergicTo 112 "Chocolate" |> should equal true

let ``Testing for chocolate allergy - allergic to something, but not chocolate`` () =
    allergicTo 80 "Chocolate" |> should equal false

let ``Testing for chocolate allergy - allergic to everything`` () =
    allergicTo 255 "Chocolate" |> should equal true

let ``Testing for pollen allergy - not allergic to anything`` () =
    allergicTo 0 "Pollen" |> should equal false

let ``Testing for pollen allergy - allergic only to pollen`` () =
    allergicTo 64 "Pollen" |> should equal true

let ``Testing for pollen allergy - allergic to pollen and something else`` () =
    allergicTo 224 "Pollen" |> should equal true

let ``Testing for pollen allergy - allergic to something, but not pollen`` () =
    allergicTo 160 "Pollen" |> should equal false

let ``Testing for pollen allergy - allergic to everything`` () =
    allergicTo 255 "Pollen" |> should equal true

let ``Testing for cats allergy - not allergic to anything`` () =
    allergicTo 0 "Cats" |> should equal false

let ``Testing for cats allergy - allergic only to cats`` () =
    allergicTo 128 "Cats" |> should equal true

let ``Testing for cats allergy - allergic to cats and something else`` () =
    allergicTo 192 "Cats" |> should equal true

let ``Testing for cats allergy - allergic to something, but not cats`` () =
    allergicTo 64 "Cats" |> should equal false

let ``Testing for cats allergy - allergic to everything`` () =
    allergicTo 255 "Cats" |> should equal true

let ``List - no allergies`` () =
    list 0 |> should be Empty

-- List - just eggs
-- ==
-- input { 1 }
-- output { ["Eggs"] }

-- List - just peanuts
-- ==
-- input { 2 }
-- output { ["Peanuts"] }

-- List - just strawberries
-- ==
-- input { 8 }
-- output { ["Strawberries"] }

-- List - eggs and peanuts
-- ==
-- input { 3 }
-- output { ["Eggs"; "Peanuts"] }

-- List - more than eggs but not peanuts
-- ==
-- input { 5 }
-- output { ["Eggs"; "Shellfish"] }

-- List - lots of stuff
-- ==
-- input { 248 }
-- output { ["Strawberries"; "Tomatoes"; "Chocolate"; "Pollen"; "Cats"] }

-- List - everything
-- ==
-- input { 255 }
-- output { ["Eggs"; "Peanuts"; "Shellfish"; "Strawberries"; "Tomatoes"; "Chocolate"; "Pollen"; "Cats"] }

-- List - no allergen score parts
-- ==
-- input { 509 }
-- output { ["Eggs"; "Shellfish"; "Strawberries"; "Tomatoes"; "Chocolate"; "Pollen"; "Cats"] }

-- List - no allergen score parts without highest valid score
-- ==
-- input { 257 }
-- output { ["Eggs"] }

