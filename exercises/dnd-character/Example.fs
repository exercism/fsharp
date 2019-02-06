module DndCharacter

open System

let modifier x =
    if x > 10 then (x-10) / 2 else (x-11) / 2

let ability() = 
        let random = Random()
        [1..4] 
        |> List.map (fun _ -> random.Next(1,6)) 
        |> List.sortDescending 
        |> List.take 3 
        |> List.sum

type DndCharacter() =
    let _strength = ability()
    let _dexterity = ability()
    let _constitution = ability()
    let _intelligence = ability()
    let _wisdom = ability()
    let _charisma = ability()
    let _hitpoints = 10 + modifier(_constitution)
    member __.strength with get() = _strength
    member __.dexterity with get() = _dexterity
    member __.constitution with get() = _constitution
    member __.intelligence with get() = _intelligence
    member __.wisdom with get() = _wisdom
    member __.charisma with get() = _charisma
    member __.hitpoints with get() = _hitpoints

