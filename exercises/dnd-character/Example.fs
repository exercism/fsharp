module DndCharacter

open System

let modifier score =
    if score > 10 then (score-10) / 2 else (score-11) / 2

let ability() = 
        let random = Random()
        [1..4] 
        |> List.map (fun _ -> random.Next(1,6)) 
        |> List.sortDescending 
        |> List.take 3 
        |> List.sum

type DndCharacter = { Strength : int 
                      Dexterity: int
                      Constitution : int
                      Intelligence : int
                      Wisdom : int
                      Charisma : int
                      Hitpoints : int }

let createCharacter() = 
    let constitution = ability()
    { Strength = ability(); 
      Dexterity = ability(); 
      Constitution = constitution; 
      Intelligence = ability() ; 
      Wisdom = ability(); 
      Charisma = ability(); 
      Hitpoints = 10 + modifier(constitution) }
