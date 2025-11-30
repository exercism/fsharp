module RolePlayingGame

type Player = { 
    Name: string option
    Level: int
    Health: int
    Mana: int option
}

let introduce (player: Player): string = 
    failwith "Please implement this function"

let revive (player: Player): Player option = 
    failwith "Please implement this function"

let castSpell (manaCost: int) (player: Player): Player * int =
    failwith "Please implement this function"
