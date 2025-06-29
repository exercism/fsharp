import "allergies"

-- Testing for eggs allergy - not allergic to anything
-- ==
-- input { 0 "Eggs" }
-- output { false }

-- Testing for eggs allergy - allergic only to eggs
-- ==
-- input { 1 "Eggs" }
-- output { true }

-- Testing for eggs allergy - allergic to eggs and something else
-- ==
-- input { 3 "Eggs" }
-- output { true }

-- Testing for eggs allergy - allergic to something, but not eggs
-- ==
-- input { 2 "Eggs" }
-- output { false }

-- Testing for eggs allergy - allergic to everything
-- ==
-- input { 255 "Eggs" }
-- output { true }

-- Testing for peanuts allergy - not allergic to anything
-- ==
-- input { 0 "Peanuts" }
-- output { false }

-- Testing for peanuts allergy - allergic only to peanuts
-- ==
-- input { 2 "Peanuts" }
-- output { true }

-- Testing for peanuts allergy - allergic to peanuts and something else
-- ==
-- input { 7 "Peanuts" }
-- output { true }

-- Testing for peanuts allergy - allergic to something, but not peanuts
-- ==
-- input { 5 "Peanuts" }
-- output { false }

-- Testing for peanuts allergy - allergic to everything
-- ==
-- input { 255 "Peanuts" }
-- output { true }

-- Testing for shellfish allergy - not allergic to anything
-- ==
-- input { 0 "Shellfish" }
-- output { false }

-- Testing for shellfish allergy - allergic only to shellfish
-- ==
-- input { 4 "Shellfish" }
-- output { true }

-- Testing for shellfish allergy - allergic to shellfish and something else
-- ==
-- input { 14 "Shellfish" }
-- output { true }

-- Testing for shellfish allergy - allergic to something, but not shellfish
-- ==
-- input { 10 "Shellfish" }
-- output { false }

-- Testing for shellfish allergy - allergic to everything
-- ==
-- input { 255 "Shellfish" }
-- output { true }

-- Testing for strawberries allergy - not allergic to anything
-- ==
-- input { 0 "Strawberries" }
-- output { false }

-- Testing for strawberries allergy - allergic only to strawberries
-- ==
-- input { 8 "Strawberries" }
-- output { true }

-- Testing for strawberries allergy - allergic to strawberries and something else
-- ==
-- input { 28 "Strawberries" }
-- output { true }

-- Testing for strawberries allergy - allergic to something, but not strawberries
-- ==
-- input { 20 "Strawberries" }
-- output { false }

-- Testing for strawberries allergy - allergic to everything
-- ==
-- input { 255 "Strawberries" }
-- output { true }

-- Testing for tomatoes allergy - not allergic to anything
-- ==
-- input { 0 "Tomatoes" }
-- output { false }

-- Testing for tomatoes allergy - allergic only to tomatoes
-- ==
-- input { 16 "Tomatoes" }
-- output { true }

-- Testing for tomatoes allergy - allergic to tomatoes and something else
-- ==
-- input { 56 "Tomatoes" }
-- output { true }

-- Testing for tomatoes allergy - allergic to something, but not tomatoes
-- ==
-- input { 40 "Tomatoes" }
-- output { false }

-- Testing for tomatoes allergy - allergic to everything
-- ==
-- input { 255 "Tomatoes" }
-- output { true }

-- Testing for chocolate allergy - not allergic to anything
-- ==
-- input { 0 "Chocolate" }
-- output { false }

-- Testing for chocolate allergy - allergic only to chocolate
-- ==
-- input { 32 "Chocolate" }
-- output { true }

-- Testing for chocolate allergy - allergic to chocolate and something else
-- ==
-- input { 112 "Chocolate" }
-- output { true }

-- Testing for chocolate allergy - allergic to something, but not chocolate
-- ==
-- input { 80 "Chocolate" }
-- output { false }

-- Testing for chocolate allergy - allergic to everything
-- ==
-- input { 255 "Chocolate" }
-- output { true }

-- Testing for pollen allergy - not allergic to anything
-- ==
-- input { 0 "Pollen" }
-- output { false }

-- Testing for pollen allergy - allergic only to pollen
-- ==
-- input { 64 "Pollen" }
-- output { true }

-- Testing for pollen allergy - allergic to pollen and something else
-- ==
-- input { 224 "Pollen" }
-- output { true }

-- Testing for pollen allergy - allergic to something, but not pollen
-- ==
-- input { 160 "Pollen" }
-- output { false }

-- Testing for pollen allergy - allergic to everything
-- ==
-- input { 255 "Pollen" }
-- output { true }

-- Testing for cats allergy - not allergic to anything
-- ==
-- input { 0 "Cats" }
-- output { false }

-- Testing for cats allergy - allergic only to cats
-- ==
-- input { 128 "Cats" }
-- output { true }

-- Testing for cats allergy - allergic to cats and something else
-- ==
-- input { 192 "Cats" }
-- output { true }

-- Testing for cats allergy - allergic to something, but not cats
-- ==
-- input { 64 "Cats" }
-- output { false }

-- Testing for cats allergy - allergic to everything
-- ==
-- input { 255 "Cats" }
-- output { true }

-- List - no allergies
-- ==
-- input { 0 }
-- output { empty([0]u8) }

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

