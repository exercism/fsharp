module TisburyTreasureHuntTests

open FsUnit.Xunit
open Xunit
open Exercism.Tests

open TisburyTreasureHunt

[<Fact>]
[<Task(1)>]
let ``Get coordinate for Scrimshaw Whale's Tooth`` () =
    getCoordinate ("Scrimshaw Whale's Tooth", "2A") |> should equal "2A"

[<Fact>]
[<Task(1)>]
let ``Get coordinate for Brass Spyglass`` () =
    getCoordinate ("Brass Spyglass", "4B") |> should equal "4B"

[<Fact>]
[<Task(1)>]
let ``Get coordinate for Robot Parrot`` () =
    getCoordinate ("Robot Parrot", "1C") |> should equal "1C"

[<Fact>]
[<Task(1)>]
let ``Get coordinate for Glass Starfish`` () =
    getCoordinate ("Glass Starfish", "6D") |> should equal "6D"

[<Fact>]
[<Task(1)>]
let ``Get coordinate for Crystal Crab`` () =
    getCoordinate ("Crystal Crab", "6A") |> should equal "6A"

[<Fact>]
[<Task(1)>]
let ``Get coordinate for Angry Monkey Figurine`` () =
    getCoordinate ("Angry Monkey Figurine", "5B") |> should equal "5B"

[<Fact>]
[<Task(2)>]
let ``Convert coordinate for 2A`` () =
    convertCoordinate "2A" |> should equal (2, 'A')

[<Fact>]
[<Task(2)>]
let ``Convert coordinate for 4B`` () =
    convertCoordinate "4B" |> should equal (4, 'B')

[<Fact>]
[<Task(2)>]
let ``Convert coordinate for 6A`` () =
    convertCoordinate "6A" |> should equal (6, 'A')

[<Fact>]
[<Task(3)>]
let ``Compare records for first matched records returns true`` () =
    let azarasData = ("Scrimshaw Whale's Tooth", "2A")
    let ruisData = ("Deserted Docks", (2, 'A'), "Blue")   
    compareRecords azarasData ruisData |> should equal true

[<Fact>]
[<Task(3)>]
let ``Compare records for second matched records returns true`` () =
    let azarasData = ("Glass Starfish", "6D")
    let ruisData = ("Tangled Seaweed Patch", (6, 'D'), "Orange")
    compareRecords azarasData ruisData |> should equal true

[<Fact>]
[<Task(3)>]
let ``Compare records for third matched records returns true`` () =
    let azarasData = ("Vintage Pirate Hat", "7E")
    let ruisData = ("Quiet Inlet (Island of Mystery)", (7, 'E'), "Orange")
    compareRecords azarasData ruisData |> should equal true

[<Fact>]
[<Task(3)>]
let ``Compare records for forth matched records returns true`` () =
    let azarasData = ("Glass Starfish", "6D")
    let ruisData = ("Tangled Seaweed Patch", (6, 'D'), "Orange")
    compareRecords azarasData ruisData |> should equal true

[<Fact>]
[<Task(3)>]
let ``Compare records for first unmatched records returns true`` () =
    let azarasData = ("Angry Monkey Figurine", "5B")
    let ruisData = ("Aqua Lagoon (Island of Mystery)", (1, 'F'), "Yellow")
    compareRecords azarasData ruisData |> should equal false

[<Fact>]
[<Task(3)>]
let ``Compare records for second unmatched records returns true`` () =
    let azarasData = ("Brass Spyglass", "4B")
    let ruisData = ("Spiky Rocks", (3, 'D'), "Yellow")
    compareRecords azarasData ruisData |> should equal false

[<Fact>]
[<Task(3)>]
let ``Compare records for third unmatched records returns true`` () =
    let azarasData = ("Angry Monkey Figurine", "5B")
    let ruisData = ("Aqua Lagoon (Island of Mystery)", (1, 'F'), "Yellow")
    compareRecords azarasData ruisData |> should equal false

[<Fact>]
[<Task(4)>]
let ``Create Record for first matched records returns correct tuple`` () =
    let azarasData = ("Scrimshaw Whale's Tooth", "2A")
    let ruisData = ("Deserted Docks", (2, 'A'), "Blue")
    let expected = ("2A", "Deserted Docks", "Blue", "Scrimshaw Whale's Tooth")
    createRecord azarasData ruisData |> should equal expected

[<Fact>]
[<Task(4)>]
let ``Compare records for second matched records returns correct tuple`` () =
    let azarasData = ("Glass Starfish", "6D")
    let ruisData = ("Tangled Seaweed Patch", (6, 'D'), "Orange")
    let expected = ("6D", "Tangled Seaweed Patch", "Orange", "Glass Starfish")
    createRecord azarasData ruisData |> should equal expected

[<Fact>]
[<Task(4)>]
let ``Compare records for third matched records returns correct tuple`` () =
    let azarasData = ("Vintage Pirate Hat", "7E")
    let ruisData = ("Quiet Inlet (Island of Mystery)", (7, 'E'), "Orange")
    let expected = ("7E", "Quiet Inlet (Island of Mystery)", "Orange", "Vintage Pirate Hat")
    createRecord azarasData ruisData |> should equal expected

[<Fact>]
[<Task(4)>]
let ``Compare records for forth matched records returns correct tuple`` () =
    let azarasData = ("Glass Starfish", "6D")
    let ruisData = ("Tangled Seaweed Patch", (6, 'D'), "Orange")
    let expected = ("6D", "Tangled Seaweed Patch", "Orange", "Glass Starfish")
    createRecord azarasData ruisData |> should equal expected

[<Fact>]
[<Task(4)>]
let ``Compare records for first unmatched records returns correct empty tuple`` () =
    let azarasData = ("Angry Monkey Figurine", "5B")
    let ruisData = ("Aqua Lagoon (Island of Mystery)", (1, 'F'), "Yellow")
    let expected = ("", "", "", "")
    createRecord azarasData ruisData |> should equal expected

[<Fact>]
[<Task(4)>]
let ``Compare records for second unmatched records returns correct empty tuple`` () =
    let azarasData = ("Brass Spyglass", "4B")
    let ruisData = ("Spiky Rocks", (3, 'D'), "Yellow")
    let expected = ("", "", "", "")
    createRecord azarasData ruisData |> should equal expected

[<Fact>]
[<Task(4)>]
let ``Compare records for third unmatched records returns correct empty tuple`` () =
    let azarasData = ("Angry Monkey Figurine", "5B")
    let ruisData = ("Aqua Lagoon (Island of Mystery)", (1, 'F'), "Yellow")
    let expected = ("", "", "", "")
    createRecord azarasData ruisData |> should equal expected
