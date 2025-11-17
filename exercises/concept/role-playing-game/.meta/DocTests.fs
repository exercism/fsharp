module DocTests

open FsUnit.Xunit
open Xunit

open RolePlayingGame


[<Fact>]
let testKeepIfPositive () =
    let keepIfPositive (a: int) : Option<int> =
        if a > 0 then Some a else None
    keepIfPositive 2 |> should equal (Some 2)
    keepIfPositive -3 |> should equal None


[<Fact>]
let testSayHello() =
    let sayHello (optionalName: Option<string>): string = 
        match optionalName with
        | Some name -> "Hello, " + name + "!"
        | None -> "Hello, you!"
    sayHello (Some "Matthieu") |> should equal "Hello, Matthieu!"
    sayHello None |> should equal "Hello, you!"


[<Fact>]
let testDefault1() = 
    Option.defaultValue "" (Some "F#") |> should equal "F#"
    Option.defaultValue 0 None |> should equal 0


[<Fact>]
let testIntroduceExample1() = 
    introduce { Name = None; Level = 2; Health = 8; Mana = None }
    |> should equal "Mighty Magician"


[<Fact>]
let testIntroduceExample2() =
    introduce { Name = Some "Merlin"; Level = 2; Health = 8; Mana = None }
    |> should equal "Merlin"


[<Fact>]
let testReviveExample1() =
    let deadPlayer = { Name = None; Level = 2; Health = 0; Mana = None }
    revive deadPlayer
    |> should equal (Some { Name = None; Level = 2; Health = 100; Mana = None })


[<Fact>]
let testReviveExample2() =
    let alivePlayer = { Name = None; Level = 2; Health = 42; Mana = None }
    revive alivePlayer |> should equal None


[<Fact>]
let testCastSpellExample() = 
    let wizard = { Name = None; Level = 18; Health = 123; Mana = Some 30 }
    let updatedWizard, damage = castSpell 14 wizard
    updatedWizard.Mana |> should equal (Some 16)
    damage |> should equal 28
