module RolePlayingGame

type Player = { 
    Name: string option
    Level: int
    Health: int
    Mana: int option
}

let introduce (player: Player): string = 
    Option.defaultValue "Mighty Magician" player.Name

let revive (player: Player): Player option = 
    if player.Health > 0 then
        None

    elif player.Level >= 10 then
        Some { player with Health = 100; Mana = Some 100 }

    else
        Some { player with Health = 100; Mana = None }

let castSpell (manaCost: int) (player: Player): Player * int =
    match player.Mana with
    | None ->
        { player with Health = max 0 (player.Health - manaCost) }, 0

    | Some mana ->
        if mana >= manaCost then
            { player with Mana = Some (mana - manaCost) }, 2 * manaCost

        else
            player, 0
