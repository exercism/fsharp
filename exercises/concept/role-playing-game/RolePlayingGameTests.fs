module RolePlayingGameTests

open FsUnit.Xunit
open Xunit
open Exercism.Tests

open RolePlayingGame

[<Fact>]
[<Task(1)>]
let ``Introducing a player with a name should return their name`` () =
    introduce { Name = Some "Gandalf"; Level = 1; Health = 42; Mana = None }
    |> should equal "Gandalf"

[<Fact>]
[<Task(1)>]
let ``Introducing an unidentified player should return "Mighty Magician"`` () =
    introduce { Name = None; Level = 1; Health = 42; Mana = None }
    |> should equal "Mighty Magician"

[<Fact>]
[<Task(2)>]
let ``Attempting to revive a player that is alive should return None`` () =
    revive { Name = None; Level = 12; Health = 42; Mana = Some 7 }
    |> should equal None

[<Fact>]
[<Task(2)>]
let ``Reviving a low level player resets its health to 100`` () =
    revive { Name = None; Level = 3; Health = 0; Mana = None }
    |> should equal (Some { Name = None; Level = 3; Health = 100; Mana = None })

[<Fact>]
[<Task(2)>]
let ``Reviving a high level player resets both its health and its mana`` () =
    revive { Name = None; Level = 10; Health = 0; Mana = Some 14 }
    |> should equal (Some { Name = None; Level = 10; Health = 100; Mana = Some 100 })

[<Fact>]
[<Task(3)>]
let ``Casting a spell causes damage of double the mana`` () =
    castSpell 9 { Name = None; Level = 10; Health = 69; Mana = Some 20 }
    |> should equal ( { Name = None; Level = 10; Health = 69; Mana = Some 11 }, 18 )

[<Fact>]
[<Task(3)>]
let ``Attempting to cast a spell with insufficient mana does nothing`` () =
    castSpell 39 { Name = None; Level = 10; Health = 69; Mana = Some 20 }
    |> should equal ( { Name = None; Level = 10; Health = 69; Mana = Some 20 }, 0 )

[<Fact>]
[<Task(3)>]
let ``Attempting to cast a spell without a mana pool decreases the player's health`` () =
    castSpell 7 { Name = None; Level = 5; Health = 58; Mana = None }
    |> should equal ( { Name = None; Level = 5; Health = 51; Mana = None }, 0 )

[<Fact>]
[<Task(3)>]
let ``A player's health cannot go below 0`` () =
    castSpell 12 { Name = None; Level = 5; Health = 6; Mana = None }
    |> should equal ( { Name = None; Level = 5; Health = 0; Mana = None }, 0 )
