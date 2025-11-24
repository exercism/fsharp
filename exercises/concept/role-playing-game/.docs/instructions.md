# Instructions

In this exercise, you'll be implementing mechanics of a role-playing game.
A player's character is represented by the following type:

```fsharp
type Player = {
    Name: Option<string>
    Level: int
    Health: int
    Mana: Option<int>
}
```

Players in this game must reach level 10 before they unlock a mana pool so that they can start casting spells.
You'll be working on two pieces of functionality in this game: the revive mechanic and the spell casting mechanic.

## 1. Introduce yourself

Write the content of the `introduce` function.
Note that the `Name` field of the `Player` record is an `Option`.
Stealthy players might want to hide their name by leaving it set to `None` -- such players will be introduced as `"Mighty Magician"`.
Otherwise, just use your name to introduce yourself.

```fsharp
introduce { Name = None; Level = 2; Health = 8; Mana = None }
    --> "Mighty Magician"

introduce { Name = Some "Merlin"; Level = 2; Health = 8; Mana = None }
    --> "Merlin"
```

## 2. Implement the revive mechanic

The `revive` function should check that the player's character is indeed dead (their health has reached 0).
If they are, it should return a new `Player` instance with 100 health.
Otherwise, if the player's character isn't dead, the `revive` function returns `None`.

If the player's level is 10 or above, they should also be revived with 100 mana.
If the player's level is below 10, their mana should be `None`.
The `revive` function should preserve the player's level.

```fsharp
let deadPlayer = { Name = None; Level = 2; Health = 0; Mana = None }

revive deadPlayer
    --> Some { Name = None; Level = 2; Health = 100; Mana = None }
```

If the `revive` method is called on a player whose health is 1 or above, then the function should return `None`.

```fsharp
let alivePlayer = { Name = None; Level = 2; Health = 42; Mana = None }

revive alivePlayer
    --> None
```

## 3. Implement the spell casting mechanic

The `castSpell` function takes as arguments an `int` indicating how much mana the spell costs as well as a `Player`.
It returns the updated player, as well as the amount of damage that the cast spell inflicts.
A successful spell cast does damage equal to two times the mana cost of the spell.
However, if the player has insufficient mana, nothing happens, the player is unchanged and no damage is done.
If the player does not even have a mana pool, attempting to cast the spell must decrease their health by the mana cost of the spell and does no damage.

```fsharp
let wizard = { Name = None; Level = 18; Health = 123; Mana = Some 30 }

let updatedWizard, damage = castSpell 14 wizard

updatedWizard.Mana --> Some 16
damage             --> 28
```
