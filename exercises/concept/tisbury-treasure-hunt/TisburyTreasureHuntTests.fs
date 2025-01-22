source("./tisbury-treasure-hunt.R")
library(testthat)

[<Task(1)>]
let ``Get coordinate for Scrimshaw Whale's Tooth`` () =
    getCoordinate ("Scrimshaw Whale's Tooth", "2A") |> should equal "2A"

[<Task(1)>]
let ``Get coordinate for Brass Spyglass`` () =
    getCoordinate ("Brass Spyglass", "4B") |> should equal "4B"

[<Task(1)>]
let ``Get coordinate for Robot Parrot`` () =
    getCoordinate ("Robot Parrot", "1C") |> should equal "1C"

[<Task(1)>]
let ``Get coordinate for Glass Starfish`` () =
    getCoordinate ("Glass Starfish", "6D") |> should equal "6D"

[<Task(1)>]
let ``Get coordinate for Crystal Crab`` () =
    getCoordinate ("Crystal Crab", "6A") |> should equal "6A"

[<Task(1)>]
let ``Get coordinate for Angry Monkey Figurine`` () =
    getCoordinate ("Angry Monkey Figurine", "5B") |> should equal "5B"

[<Task(2)>]
let ``Convert coordinate for 2A`` () =
    convertCoordinate "2A" |> should equal (2, 'A')

[<Task(2)>]
let ``Convert coordinate for 4B`` () =
    convertCoordinate "4B" |> should equal (4, 'B')

[<Task(2)>]
let ``Convert coordinate for 6A`` () =
    convertCoordinate "6A" |> should equal (6, 'A')

[<Task(3)>]
let ``Compare records for first matched records returns true`` () =
    azarasData <- ("Scrimshaw Whale's Tooth", "2A")
    ruisData <- ("Deserted Docks", (2, 'A'), "Blue")   
    compareRecords azarasData ruisData |> should equal true

[<Task(3)>]
let ``Compare records for second matched records returns true`` () =
    azarasData <- ("Glass Starfish", "6D")
    ruisData <- ("Tangled Seaweed Patch", (6, 'D'), "Orange")
    compareRecords azarasData ruisData |> should equal true

[<Task(3)>]
let ``Compare records for third matched records returns true`` () =
    azarasData <- ("Vintage Pirate Hat", "7E")
    ruisData <- ("Quiet Inlet (Island of Mystery)", (7, 'E'), "Orange")
    compareRecords azarasData ruisData |> should equal true

[<Task(3)>]
let ``Compare records for forth matched records returns true`` () =
    azarasData <- ("Glass Starfish", "6D")
    ruisData <- ("Tangled Seaweed Patch", (6, 'D'), "Orange")
    compareRecords azarasData ruisData |> should equal true

[<Task(3)>]
let ``Compare records for first unmatched records returns true`` () =
    azarasData <- ("Angry Monkey Figurine", "5B")
    ruisData <- ("Aqua Lagoon (Island of Mystery)", (1, 'F'), "Yellow")
    compareRecords azarasData ruisData |> should equal false

[<Task(3)>]
let ``Compare records for second unmatched records returns true`` () =
    azarasData <- ("Brass Spyglass", "4B")
    ruisData <- ("Spiky Rocks", (3, 'D'), "Yellow")
    compareRecords azarasData ruisData |> should equal false

[<Task(3)>]
let ``Compare records for third unmatched records returns true`` () =
    azarasData <- ("Angry Monkey Figurine", "5B")
    ruisData <- ("Aqua Lagoon (Island of Mystery)", (1, 'F'), "Yellow")
    compareRecords azarasData ruisData |> should equal false

[<Task(4)>]
let ``Create Record for first matched records returns correct tuple`` () =
    azarasData <- ("Scrimshaw Whale's Tooth", "2A")
    ruisData <- ("Deserted Docks", (2, 'A'), "Blue")
    expected <- ("2A", "Deserted Docks", "Blue", "Scrimshaw Whale's Tooth")
    createRecord azarasData ruisData |> should equal expected

[<Task(4)>]
let ``Compare records for second matched records returns correct tuple`` () =
    azarasData <- ("Glass Starfish", "6D")
    ruisData <- ("Tangled Seaweed Patch", (6, 'D'), "Orange")
    expected <- ("6D", "Tangled Seaweed Patch", "Orange", "Glass Starfish")
    createRecord azarasData ruisData |> should equal expected

[<Task(4)>]
let ``Compare records for third matched records returns correct tuple`` () =
    azarasData <- ("Vintage Pirate Hat", "7E")
    ruisData <- ("Quiet Inlet (Island of Mystery)", (7, 'E'), "Orange")
    expected <- ("7E", "Quiet Inlet (Island of Mystery)", "Orange", "Vintage Pirate Hat")
    createRecord azarasData ruisData |> should equal expected

[<Task(4)>]
let ``Compare records for forth matched records returns correct tuple`` () =
    azarasData <- ("Glass Starfish", "6D")
    ruisData <- ("Tangled Seaweed Patch", (6, 'D'), "Orange")
    expected <- ("6D", "Tangled Seaweed Patch", "Orange", "Glass Starfish")
    createRecord azarasData ruisData |> should equal expected

[<Task(4)>]
let ``Compare records for first unmatched records returns correct empty tuple`` () =
    azarasData <- ("Angry Monkey Figurine", "5B")
    ruisData <- ("Aqua Lagoon (Island of Mystery)", (1, 'F'), "Yellow")
    expected <- ("", "", "", "")
    createRecord azarasData ruisData |> should equal expected

[<Task(4)>]
let ``Compare records for second unmatched records returns correct empty tuple`` () =
    azarasData <- ("Brass Spyglass", "4B")
    ruisData <- ("Spiky Rocks", (3, 'D'), "Yellow")
    expected <- ("", "", "", "")
    createRecord azarasData ruisData |> should equal expected

[<Task(4)>]
let ``Compare records for third unmatched records returns correct empty tuple`` () =
    azarasData <- ("Angry Monkey Figurine", "5B")
    ruisData <- ("Aqua Lagoon (Island of Mystery)", (1, 'F'), "Yellow")
    expected <- ("", "", "", "")
    createRecord azarasData ruisData |> should equal expected
