module TisburyTreasureHuntTests

open FsUnit.Xunit
open Xunit
open Exercism.Tests

open TisburyTreasureHunt

[<Task(1)>]
[<Theory>]
[<InlineData("Scrimshaw Whale\"s Tooth", "2A", "2A")>]
[<InlineData("Brass Spyglass", "4B", "4B")>]
[<InlineData("Robot Parrot", "1C", "1C")>]
[<InlineData("Glass Starfish", "6D", "6D")>]
[<InlineData("Vintage Pirate Hat", "7E", "7E")>]
[<InlineData("Pirate Flag", "7F", "7F")>]
[<InlineData("Crystal Crab", "6A", "6A")>]
[<InlineData("Model Ship in Large Bottle", "8A", "8A")>]
[<InlineData("Angry Monkey Figurine", "5B", "5B")>]
[<InlineData("Carved Wooden Elephant", "8C", "8C")>]
[<InlineData("Amethyst  Octopus", "1F", "1F")>]
[<InlineData("Antique Glass Fishnet Float", "3D", "3D")>]
[<InlineData("Silver Seahorse", "4E", "4E")>]
let ``Test getCoordinate`` treasure coordinates expected =
    let inputData = (treasure, coordinates)

    let result = getCoordinate inputData

    Assert.Equal(expected, result)

[<Fact>]
[<Task(2)>]
let ``Convert coordinate for 2A gives correct data`` () =
    let result = convertCoordinate "2A"
    
    Assert.Equal(("2", "A"), result)

[<Fact>]
[<Task(2)>]
let ``Convert coordinate for 4B gives correct data`` () =
    let result = convertCoordinate "4B"
    
    Assert.Equal(("4", "B"), result)

[<Fact>]
[<Task(2)>]
let ``Convert coordinate for 6A gives correct data`` () =
    let result = convertCoordinate "6A"
    
    Assert.Equal(("6", "A"), result)

[<Fact>]
[<Task(3)>]
let ``Compare Records for first matched records returns true`` () =
    let azarasData = ("Scrimshaw Whale's Tooth", "2A")
    let ruisData = ("Deserted Docks", ("2", "A"), "Blue")
    let result = compareRecords azarasData ruisData
    
    Assert.True(result)

[<Fact>]
[<Task(3)>]
let ``Compare Records for second matched records returns true`` () =
    let azarasData = ("Glass Starfish", "6D")
    let ruisData = ("Tangled Seaweed Patch", ("6", "D"), "Orange")
    let result = compareRecords azarasData ruisData
    
    Assert.True(result)

[<Fact>]
[<Task(3)>]
let ``Compare Records for third matched records returns true`` () =
    let azarasData = ("Vintage Pirate Hat", "7E")
    let ruisData = ("Quiet Inlet (Island of Mystery)", ("7", "E"), "Orange")
    let result = compareRecords azarasData ruisData
    
    Assert.True(result)

[<Fact>]
[<Task(3)>]
let ``Compare Records for forth matched records returns true`` () =
    let azarasData = ("Glass Starfish", "6D")
    let ruisData = ("Tangled Seaweed Patch", ("6", "D"), "Orange")
    let result = compareRecords azarasData ruisData
    
    Assert.True(result)

[<Fact>]
[<Task(3)>]
let ``Compare Records for first unmatched records returns true`` () =
    let azarasData = ("Angry Monkey Figurine", "5B")
    let ruisData = ("Aqua Lagoon (Island of Mystery)", ("1", "F"), "Yellow")
    let result = compareRecords azarasData ruisData
    
    Assert.False(result)

[<Fact>]
[<Task(3)>]
let ``Compare Records for second unmatched records returns true`` () =
    let azarasData = ("Brass Spyglass", "4B")
    let ruisData = ("Spiky Rocks", ("3", "D"), "Yellow")
    let result = compareRecords azarasData ruisData
    
    Assert.False(result)

[<Fact>]
[<Task(3)>]
let ``Compare Records for third unmatched records returns true`` () =
    let azarasData = ("Angry Monkey Figurine", "5B")
    let ruisData = ("Aqua Lagoon (Island of Mystery)", ("1", "F"), "Yellow")
    let result = compareRecords azarasData ruisData
    
    Assert.False(result)

[<Fact>]
[<Task(3)>]
let ``Create Record for first matched records returns correct tuple`` () =
    let azarasData = ("Scrimshaw Whale's Tooth", "2A")
    let ruisData = ("Deserted Docks", ("2", "A"), "Blue")
    let result = createRecord azarasData ruisData
    let expected = ("Scrimshaw Whale's Tooth", "2A", "Deserted Docks", ("2", "A"), "Blue")
    Assert.Equal(expected, result)

[<Fact>]
[<Task(3)>]
let ``Compare Records for second matched records returns correct tuple`` () =
    let azarasData = ("Glass Starfish", "6D")
    let ruisData = ("Tangled Seaweed Patch", ("6", "D"), "Orange")
    let result = createRecord azarasData ruisData
    let expected = ("Glass Starfish", "6D", "Tangled Seaweed Patch", ("6", "D"), "Orange")
    Assert.Equal(expected, result)

[<Fact>]
[<Task(3)>]
let ``Compare Records for third matched records returns correct tuple`` () =
    let azarasData = ("Vintage Pirate Hat", "7E")
    let ruisData = ("Quiet Inlet (Island of Mystery)", ("7", "E"), "Orange")
    let result = createRecord azarasData ruisData
    let expected = ("Vintage Pirate Hat", "7E", "Quiet Inlet (Island of Mystery)", ("7", "E"), "Orange")
    Assert.Equal(expected, result)

[<Fact>]
[<Task(3)>]
let ``Compare Records for forth matched records returns correct tuple`` () =
    let azarasData = ("Glass Starfish", "6D")
    let ruisData = ("Tangled Seaweed Patch", ("6", "D"), "Orange")
    let result = createRecord azarasData ruisData
    let expected = ("Glass Starfish", "6D", "Tangled Seaweed Patch", ("6", "D"), "Orange")
    Assert.Equal(expected, result)

[<Fact>]
[<Task(3)>]
let ``Compare Records for first unmatched records returns correct empty tuple`` () =
    let azarasData = ("Angry Monkey Figurine", "5B")
    let ruisData = ("Aqua Lagoon (Island of Mystery)", ("1", "F"), "Yellow")
    let result = createRecord azarasData ruisData
    let expected = ("", "", "", ("", ""), "")
    Assert.Equal(expected, result)

[<Fact>]
[<Task(3)>]
let ``Compare Records for second unmatched records returns correct empty tuple`` () =
    let azarasData = ("Brass Spyglass", "4B")
    let ruisData = ("Spiky Rocks", ("3", "D"), "Yellow")
    let result = createRecord azarasData ruisData
    let expected = ("", "", "", ("", ""), "")
    Assert.Equal(expected, result)

[<Fact>]
[<Task(3)>]
let ``Compare Records for third unmatched records returns correct empty tuple`` () =
    let azarasData = ("Angry Monkey Figurine", "5B")
    let ruisData = ("Aqua Lagoon (Island of Mystery)", ("1", "F"), "Yellow")
    let result = createRecord azarasData ruisData
    let expected = ("", "", "", ("", ""), "")
    Assert.Equal(expected, result)
