~ "allergies.ua" ~ Allergies

# Testing for eggs allergy - not allergic to anything
⍤⤙≍ false allergicTo 0 Allergen.Eggs

# Testing for eggs allergy - allergic only to eggs
⍤⤙≍ true allergicTo 1 Allergen.Eggs

# Testing for eggs allergy - allergic to eggs and something else
⍤⤙≍ true allergicTo 3 Allergen.Eggs

# Testing for eggs allergy - allergic to something, but not eggs
⍤⤙≍ false allergicTo 2 Allergen.Eggs

# Testing for eggs allergy - allergic to everything
⍤⤙≍ true allergicTo 255 Allergen.Eggs

# Testing for peanuts allergy - not allergic to anything
⍤⤙≍ false allergicTo 0 Allergen.Peanuts

# Testing for peanuts allergy - allergic only to peanuts
⍤⤙≍ true allergicTo 2 Allergen.Peanuts

# Testing for peanuts allergy - allergic to peanuts and something else
⍤⤙≍ true allergicTo 7 Allergen.Peanuts

# Testing for peanuts allergy - allergic to something, but not peanuts
⍤⤙≍ false allergicTo 5 Allergen.Peanuts

# Testing for peanuts allergy - allergic to everything
⍤⤙≍ true allergicTo 255 Allergen.Peanuts

# Testing for shellfish allergy - not allergic to anything
⍤⤙≍ false allergicTo 0 Allergen.Shellfish

# Testing for shellfish allergy - allergic only to shellfish
⍤⤙≍ true allergicTo 4 Allergen.Shellfish

# Testing for shellfish allergy - allergic to shellfish and something else
⍤⤙≍ true allergicTo 14 Allergen.Shellfish

# Testing for shellfish allergy - allergic to something, but not shellfish
⍤⤙≍ false allergicTo 10 Allergen.Shellfish

# Testing for shellfish allergy - allergic to everything
⍤⤙≍ true allergicTo 255 Allergen.Shellfish

# Testing for strawberries allergy - not allergic to anything
⍤⤙≍ false allergicTo 0 Allergen.Strawberries

# Testing for strawberries allergy - allergic only to strawberries
⍤⤙≍ true allergicTo 8 Allergen.Strawberries

# Testing for strawberries allergy - allergic to strawberries and something else
⍤⤙≍ true allergicTo 28 Allergen.Strawberries

# Testing for strawberries allergy - allergic to something, but not strawberries
⍤⤙≍ false allergicTo 20 Allergen.Strawberries

# Testing for strawberries allergy - allergic to everything
⍤⤙≍ true allergicTo 255 Allergen.Strawberries

# Testing for tomatoes allergy - not allergic to anything
⍤⤙≍ false allergicTo 0 Allergen.Tomatoes

# Testing for tomatoes allergy - allergic only to tomatoes
⍤⤙≍ true allergicTo 16 Allergen.Tomatoes

# Testing for tomatoes allergy - allergic to tomatoes and something else
⍤⤙≍ true allergicTo 56 Allergen.Tomatoes

# Testing for tomatoes allergy - allergic to something, but not tomatoes
⍤⤙≍ false allergicTo 40 Allergen.Tomatoes

# Testing for tomatoes allergy - allergic to everything
⍤⤙≍ true allergicTo 255 Allergen.Tomatoes

# Testing for chocolate allergy - not allergic to anything
⍤⤙≍ false allergicTo 0 Allergen.Chocolate

# Testing for chocolate allergy - allergic only to chocolate
⍤⤙≍ true allergicTo 32 Allergen.Chocolate

# Testing for chocolate allergy - allergic to chocolate and something else
⍤⤙≍ true allergicTo 112 Allergen.Chocolate

# Testing for chocolate allergy - allergic to something, but not chocolate
⍤⤙≍ false allergicTo 80 Allergen.Chocolate

# Testing for chocolate allergy - allergic to everything
⍤⤙≍ true allergicTo 255 Allergen.Chocolate

# Testing for pollen allergy - not allergic to anything
⍤⤙≍ false allergicTo 0 Allergen.Pollen

# Testing for pollen allergy - allergic only to pollen
⍤⤙≍ true allergicTo 64 Allergen.Pollen

# Testing for pollen allergy - allergic to pollen and something else
⍤⤙≍ true allergicTo 224 Allergen.Pollen

# Testing for pollen allergy - allergic to something, but not pollen
⍤⤙≍ false allergicTo 160 Allergen.Pollen

# Testing for pollen allergy - allergic to everything
⍤⤙≍ true allergicTo 255 Allergen.Pollen

# Testing for cats allergy - not allergic to anything
⍤⤙≍ false allergicTo 0 Allergen.Cats

# Testing for cats allergy - allergic only to cats
⍤⤙≍ true allergicTo 128 Allergen.Cats

# Testing for cats allergy - allergic to cats and something else
⍤⤙≍ true allergicTo 192 Allergen.Cats

# Testing for cats allergy - allergic to something, but not cats
⍤⤙≍ false allergicTo 64 Allergen.Cats

# Testing for cats allergy - allergic to everything
⍤⤙≍ true allergicTo 255 Allergen.Cats

# List - no allergies
    list 0 |> should be Empty

# List - just eggs
⍤⤙≍ [Allergen.Eggs] list 1

# List - just peanuts
⍤⤙≍ [Allergen.Peanuts] list 2

# List - just strawberries
⍤⤙≍ [Allergen.Strawberries] list 8

# List - eggs and peanuts
⍤⤙≍ [Allergen.Eggs Allergen.Peanuts] list 3

# List - more than eggs but not peanuts
⍤⤙≍ [Allergen.Eggs Allergen.Shellfish] list 5

# List - lots of stuff
⍤⤙≍ [Allergen.Strawberries Allergen.Tomatoes Allergen.Chocolate Allergen.Pollen Allergen.Cats] list 248

# List - everything
⍤⤙≍ [Allergen.Eggs Allergen.Peanuts Allergen.Shellfish Allergen.Strawberries Allergen.Tomatoes Allergen.Chocolate Allergen.Pollen Allergen.Cats] list 255

# List - no allergen score parts
⍤⤙≍ [Allergen.Eggs Allergen.Shellfish Allergen.Strawberries Allergen.Tomatoes Allergen.Chocolate Allergen.Pollen Allergen.Cats] list 509

# List - no allergen score parts without highest valid score
⍤⤙≍ [Allergen.Eggs] list 257

