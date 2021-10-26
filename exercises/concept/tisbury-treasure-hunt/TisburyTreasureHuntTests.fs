module TisburyTreasureHuntTests

open FsUnit.Xunit
open Xunit
open Exercism.Tests

open TisburyTreasureHunt

[<Task(1)>]
[<Fact>]
let ``Test getCoordinate Scrimshaw Whale\"s Tooth`` () =
    let (treasure, coordinates, expected) = ("Scrimshaw Whale\"s Tooth", "2A", "2A")

    let result = getCoordinate (treasure, coordinates)

    Assert.Equal(expected, result)

[<Task(1)>]
[<Fact>]
let ``Test getCoordinate Brass Spyglass`` () =
    let (treasure, coordinates, expected) = ("Brass Spyglass", "4B", "4B")

    let result = getCoordinate (treasure, coordinates)

    Assert.Equal(expected, result)

[<Task(1)>]
[<Fact>]
let ``Test getCoordinate Robot Parrot`` () =
    let (treasure, coordinates, expected) = ("Robot Parrot", "1C", "1C")

    let result = getCoordinate (treasure, coordinates)

    Assert.Equal(expected, result)

[<Task(1)>]
[<Fact>]
let ``Test getCoordinate Glass Starfish`` () =
    let (treasure, coordinates, expected) = ("Glass Starfish", "6D", "6D")

    let result = getCoordinate (treasure, coordinates)

    Assert.Equal(expected, result)

[<Task(1)>]
[<Fact>]
let ``Test getCoordinate Crystal Crab`` () =
    let (treasure, coordinates, expected) = ("Crystal Crab", "6A", "6A")

    let result = getCoordinate (treasure, coordinates)

    Assert.Equal(expected, result)

[<Task(1)>]
[<Fact>]
let ``Test getCoordinate Angry Monkey Figurine`` () =
    let (treasure, coordinates, expected) = ("Angry Monkey Figurine", "5B", "5B")

    let result = getCoordinate (treasure, coordinates)

    Assert.Equal(expected, result)

[<Fact>]
[<Task(2)>]
let ``Convert coordinate for 2A gives correct data`` () =
    let result = convertCoordinate "2A"
    
    Assert.Equal((2, 'A'), result)

[<Fact>]
[<Task(2)>]
let ``Convert coordinate for 4B gives correct data`` () =
    let result = convertCoordinate "4B"
    
    Assert.Equal((4, 'B'), result)

[<Fact>]
[<Task(2)>]
let ``Convert coordinate for 6A gives correct data`` () =
    let result = convertCoordinate "6A"
    
    Assert.Equal((6, 'A'), result)

[<Fact>]
[<Task(3)>]
let ``Compare Records for first matched records returns true`` () =
    let azarasData = ("Scrimshaw Whale's Tooth", "2A")
    let ruisData = ("Deserted Docks", (2, 'A'), "Blue")
    let result = compareRecords azarasData ruisData
    
    Assert.True(result)

[<Fact>]
[<Task(3)>]
let ``Compare Records for second matched records returns true`` () =
    let azarasData = ("Glass Starfish", "6D")
    let ruisData = ("Tangled Seaweed Patch", (6, 'D'), "Orange")
    let result = compareRecords azarasData ruisData
    
    Assert.True(result)

[<Fact>]
[<Task(3)>]
let ``Compare Records for third matched records returns true`` () =
    let azarasData = ("Vintage Pirate Hat", "7E")
    let ruisData = ("Quiet Inlet (Island of Mystery)", (7, 'E'), "Orange")
    let result = compareRecords azarasData ruisData
    
    Assert.True(result)

[<Fact>]
[<Task(3)>]
let ``Compare Records for forth matched records returns true`` () =
    let azarasData = ("Glass Starfish", "6D")
    let ruisData = ("Tangled Seaweed Patch", (6, 'D'), "Orange")
    let result = compareRecords azarasData ruisData
    
    Assert.True(result)

[<Fact>]
[<Task(3)>]
let ``Compare Records for first unmatched records returns true`` () =
    let azarasData = ("Angry Monkey Figurine", "5B")
    let ruisData = ("Aqua Lagoon (Island of Mystery)", (1, 'F'), "Yellow")
    let result = compareRecords azarasData ruisData
    
    Assert.False(result)

[<Fact>]
[<Task(3)>]
let ``Compare Records for second unmatched records returns true`` () =
    let azarasData = ("Brass Spyglass", "4B")
    let ruisData = ("Spiky Rocks", (3, 'D'), "Yellow")
    let result = compareRecords azarasData ruisData
    
    Assert.False(result)

[<Fact>]
[<Task(3)>]
let ``Compare Records for third unmatched records returns true`` () =
    let azarasData = ("Angry Monkey Figurine", "5B")
    let ruisData = ("Aqua Lagoon (Island of Mystery)", (1, 'F'), "Yellow")
    let result = compareRecords azarasData ruisData
    
    Assert.False(result)

[<Fact>]
[<Task(3)>]
let ``Create Record for first matched records returns correct tuple`` () =
    let azarasData = ("Scrimshaw Whale's Tooth", "2A")
    let ruisData = ("Deserted Docks", (2, 'A'), "Blue")
    let result = createRecord azarasData ruisData
    let expected = ("2A", "Deserted Docks", "Blue", "Scrimshaw Whale's Tooth")
    Assert.Equal(expected, result)

[<Fact>]
[<Task(3)>]
let ``Compare Records for second matched records returns correct tuple`` () =
    let azarasData = ("Glass Starfish", "6D")
    let ruisData = ("Tangled Seaweed Patch", (6, 'D'), "Orange")
    let result = createRecord azarasData ruisData
    let expected = ("6D", "Tangled Seaweed Patch", "Orange", "Glass Starfish")
    Assert.Equal(expected, result)

[<Fact>]
[<Task(3)>]
let ``Compare Records for third matched records returns correct tuple`` () =
    let azarasData = ("Vintage Pirate Hat", "7E")
    let ruisData = ("Quiet Inlet (Island of Mystery)", (7, 'E'), "Orange")
    let result = createRecord azarasData ruisData
    let expected = ("7E", "Quiet Inlet (Island of Mystery)", "Orange", "Vintage Pirate Hat")
    Assert.Equal(expected, result)

[<Fact>]
[<Task(3)>]
let ``Compare Records for forth matched records returns correct tuple`` () =
    let azarasData = ("Glass Starfish", "6D")
    let ruisData = ("Tangled Seaweed Patch", (6, 'D'), "Orange")
    let result = createRecord azarasData ruisData
    let expected = ("6D", "Tangled Seaweed Patch", "Orange", "Glass Starfish")
    Assert.Equal(expected, result)

[<Fact>]
[<Task(3)>]
let ``Compare Records for first unmatched records returns correct empty tuple`` () =
    let azarasData = ("Angry Monkey Figurine", "5B")
    let ruisData = ("Aqua Lagoon (Island of Mystery)", (1, 'F'), "Yellow")
    let result = createRecord azarasData ruisData
    let expected = ("", "", "", "")
    Assert.Equal(expected, result)

[<Fact>]
[<Task(3)>]
let ``Compare Records for second unmatched records returns correct empty tuple`` () =
    let azarasData = ("Brass Spyglass", "4B")
    let ruisData = ("Spiky Rocks", (3, 'D'), "Yellow")
    let result = createRecord azarasData ruisData
    let expected = ("", "", "", "")
    Assert.Equal(expected, result)

[<Fact>]
[<Task(3)>]
let ``Compare Records for third unmatched records returns correct empty tuple`` () =
    let azarasData = ("Angry Monkey Figurine", "5B")
    let ruisData = ("Aqua Lagoon (Island of Mystery)", (1, 'F'), "Yellow")
    let result = createRecord azarasData ruisData
    let expected = ("", "", "", "")
    Assert.Equal(expected, result)
