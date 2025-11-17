module RolePlayingGame

type Player = { 
    Name: Option<string>
    Level: int
    Health: int
    Mana: Option<int>
}


let introduce (player: Player): string = 
    failwith "Please implement this function"


let revive (player: Player): Option<Player> = 
    failwith "Please implement this function"


let castSpell (manaCost: int) (player: Player): Player * int =
    failwith "Please implement this function"
