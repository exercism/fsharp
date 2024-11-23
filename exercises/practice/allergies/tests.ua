~ "allergies.ua" ~ Allergies

# Testing for eggs allergy - not allergic to anything
⍤⤙≍ 0 allergicTo 0 Allergen.Eggs

# Testing for eggs allergy - allergic only to eggs
⍤⤙≍ 1 allergicTo 1 Allergen.Eggs

# Testing for eggs allergy - allergic to eggs and something else
⍤⤙≍ 1 allergicTo 3 Allergen.Eggs

# Testing for eggs allergy - allergic to something, but not eggs
⍤⤙≍ 0 allergicTo 2 Allergen.Eggs

# Testing for eggs allergy - allergic to everything
⍤⤙≍ 1 allergicTo 255 Allergen.Eggs

# Testing for peanuts allergy - not allergic to anything
⍤⤙≍ 0 allergicTo 0 Allergen.Peanuts

# Testing for peanuts allergy - allergic only to peanuts
⍤⤙≍ 1 allergicTo 2 Allergen.Peanuts

# Testing for peanuts allergy - allergic to peanuts and something else
⍤⤙≍ 1 allergicTo 7 Allergen.Peanuts

# Testing for peanuts allergy - allergic to something, but not peanuts
⍤⤙≍ 0 allergicTo 5 Allergen.Peanuts

# Testing for peanuts allergy - allergic to everything
⍤⤙≍ 1 allergicTo 255 Allergen.Peanuts

# Testing for shellfish allergy - not allergic to anything
⍤⤙≍ 0 allergicTo 0 Allergen.Shellfish

# Testing for shellfish allergy - allergic only to shellfish
⍤⤙≍ 1 allergicTo 4 Allergen.Shellfish

# Testing for shellfish allergy - allergic to shellfish and something else
⍤⤙≍ 1 allergicTo 14 Allergen.Shellfish

# Testing for shellfish allergy - allergic to something, but not shellfish
⍤⤙≍ 0 allergicTo 10 Allergen.Shellfish

# Testing for shellfish allergy - allergic to everything
⍤⤙≍ 1 allergicTo 255 Allergen.Shellfish

# Testing for strawberries allergy - not allergic to anything
⍤⤙≍ 0 allergicTo 0 Allergen.Strawberries

# Testing for strawberries allergy - allergic only to strawberries
⍤⤙≍ 1 allergicTo 8 Allergen.Strawberries

# Testing for strawberries allergy - allergic to strawberries and something else
⍤⤙≍ 1 allergicTo 28 Allergen.Strawberries

# Testing for strawberries allergy - allergic to something, but not strawberries
⍤⤙≍ 0 allergicTo 20 Allergen.Strawberries

# Testing for strawberries allergy - allergic to everything
⍤⤙≍ 1 allergicTo 255 Allergen.Strawberries

# Testing for tomatoes allergy - not allergic to anything
⍤⤙≍ 0 allergicTo 0 Allergen.Tomatoes

# Testing for tomatoes allergy - allergic only to tomatoes
⍤⤙≍ 1 allergicTo 16 Allergen.Tomatoes

# Testing for tomatoes allergy - allergic to tomatoes and something else
⍤⤙≍ 1 allergicTo 56 Allergen.Tomatoes

# Testing for tomatoes allergy - allergic to something, but not tomatoes
⍤⤙≍ 0 allergicTo 40 Allergen.Tomatoes

# Testing for tomatoes allergy - allergic to everything
⍤⤙≍ 1 allergicTo 255 Allergen.Tomatoes

# Testing for chocolate allergy - not allergic to anything
⍤⤙≍ 0 allergicTo 0 Allergen.Chocolate

# Testing for chocolate allergy - allergic only to chocolate
⍤⤙≍ 1 allergicTo 32 Allergen.Chocolate

# Testing for chocolate allergy - allergic to chocolate and something else
⍤⤙≍ 1 allergicTo 112 Allergen.Chocolate

# Testing for chocolate allergy - allergic to something, but not chocolate
⍤⤙≍ 0 allergicTo 80 Allergen.Chocolate

# Testing for chocolate allergy - allergic to everything
⍤⤙≍ 1 allergicTo 255 Allergen.Chocolate

# Testing for pollen allergy - not allergic to anything
⍤⤙≍ 0 allergicTo 0 Allergen.Pollen

# Testing for pollen allergy - allergic only to pollen
⍤⤙≍ 1 allergicTo 64 Allergen.Pollen

# Testing for pollen allergy - allergic to pollen and something else
⍤⤙≍ 1 allergicTo 224 Allergen.Pollen

# Testing for pollen allergy - allergic to something, but not pollen
⍤⤙≍ 0 allergicTo 160 Allergen.Pollen

# Testing for pollen allergy - allergic to everything
⍤⤙≍ 1 allergicTo 255 Allergen.Pollen

# Testing for cats allergy - not allergic to anything
⍤⤙≍ 0 allergicTo 0 Allergen.Cats

# Testing for cats allergy - allergic only to cats
⍤⤙≍ 1 allergicTo 128 Allergen.Cats

# Testing for cats allergy - allergic to cats and something else
⍤⤙≍ 1 allergicTo 192 Allergen.Cats

# Testing for cats allergy - allergic to something, but not cats
⍤⤙≍ 0 allergicTo 64 Allergen.Cats

# Testing for cats allergy - allergic to everything
⍤⤙≍ 1 allergicTo 255 Allergen.Cats

# List - no allergies
⍤⤙≍ [] list 0

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

