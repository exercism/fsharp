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

type DndCharacter() =
    let strength = ability()
    let dexterity = ability()
    let constitution = ability()
    let intelligence = ability()
    let wisdom = ability()
    let charisma = ability()
    let hitpoints = 10 + modifier(constitution)
    member __.Strength with get() = strength
    member __.Dexterity with get() = dexterity
    member __.Constitution with get() = constitution
    member __.Intelligence with get() = intelligence
    member __.Wisdom with get() = wisdom
    member __.Charisma with get() = charisma
    member __.Hitpoints with get() = hitpoints

