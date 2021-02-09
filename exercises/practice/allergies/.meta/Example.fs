module Allergies

open System

type Allergen = 
   | Eggs = 1
   | Peanuts = 2
   | Shellfish = 4
   | Strawberries = 8
   | Tomatoes = 16
   | Chocolate = 32
   | Pollen = 64
   | Cats = 128

let allergicTo (codedAllergies: int) (allergen: Allergen) = codedAllergies &&& int allergen <> 0

let list (codedAllergies: int) = 
    Enum.GetValues(typeof<Allergen>) 
    |> Seq.cast<Allergen> 
    |> List.ofSeq 
    |> List.filter (allergicTo codedAllergies)