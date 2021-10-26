# Instructions

Aazra and Rui are teammates competing in a pirate-themed treasure hunt.
One has a list of treasures with map coordinates, the other a list of location names with map coordinates.
They've also been given blank maps with a starting place marked YOU ARE HERE.

<br>
<table>
<tr><th>Azara's List</th><th></th><th>Rui's List</th></tr>
<tr><td>

| Treasure                    | Coordinates |
| --------------------------- | ----------- |
| Amethyst Octopus            | 1F          |
| Angry Monkey Figurine       | 5B          |
| Antique Glass Fishnet Float | 3D          |
| Brass Spyglass              | 4B          |
| Carved Wooden Elephant      | 8C          |
| Crystal Crab                | 6A          |
| Glass Starfish              | 6D          |
| Model Ship in Large Bottle  | 8A          |
| Pirate Flag                 | 7F          |
| Robot Parrot                | 1C          |
| Scrimshaw Whale's Tooth     | 2A          |
| Silver Seahorse             | 4E          |
| Vintage Pirate Hat          | 7E          |

</td><td></td><td>

| Location Name                         | Coordinates | Quandrant |
| ------------------------------------- | ----------- | --------- |
| Seaside Cottages                      | ("1", "C")  | Blue      |
| Aqua Lagoon (Island of Mystery)       | ("1", "F")  | Yellow    |
| Deserted Docks                        | ("2", "A")  | Blue      |
| Spiky Rocks                           | ("3", "D")  | Yellow    |
| Abandoned Lighthouse                  | ("4", "B")  | Blue      |
| Hidden Spring (Island of Mystery)     | ("4", "E")  | Yellow    |
| Stormy Breakwater                     | ("5", "B")  | Purple    |
| Old Schooner                          | ("6", "A")  | Purple    |
| Tangled Seaweed Patch                 | ("6", "D")  | Orange    |
| Quiet Inlet (Island of Mystery)       | ("7", "E")  | Orange    |
| Windswept Hilltop (Island of Mystery) | ("7", "F")  | Orange    |
| Harbor Managers Office                | ("8", "A")  | Purple    |
| Foggy Seacave                         | ("8", "C")  | Purple    |

</td></tr>
</table>

<br>

But things are a bit disorganized: Azara's coordinates appear to be formatted and sorted differently from Rui's, and they have to keep looking from one list to the other to figure out which treasures go with which locations.
Being budding fsharpistas, they have come to you for help in writing a small program (a set of functions, really) to better organize their hunt information.


## 1. Extract coordinates

Implement the `getCooordinate()` function that takes a `(treasure, coordinate)` pair from Azaras list and returns only the extracted map coordinate.

```fsharp
getCoordinate ("Scrimshaw Whale's Tooth", "2A")
// "2A"
```

## 2. Format coordinates

Implement the `convertCoordinate()` function that takes a coordinate in the format "2A" and returns a tuple in the format `("2", "A")`.

```fsharp
convertCoordinate "2A"
// ("2", "A")
```

## 3. Match coordinates

Implement the `compareRecords()` function that takes a `(treasure, coordinate)` pair and a `(location, coordinate, quadrant)` record and compares coordinates from each.
Return **`true`** if the coordinates "match", and return **`false`** if they do not.
Re-format coordinates as needed for accurate comparison.

```fsharp
compareRecords ("Brass Spyglass", "4B") ("Seaside Cottages", ("1", "C"), "blue")
// false

compareRecords ("Model Ship in Large Bottle", "8A") ("Harbor Managers Office", ("8", "A"), "purple")
// true
```

## 4. Combine matched records

Implement the `createrecord()` function that takes a `(treasure, coordinate)` pair from Azara's list and a `(location, coordinate, quadrant)` record from Rui's list and returns `(treasure, coordinate, location, coordinate, quadrant)` **if the coordinates match**.
If the coordinates _do not_ match, return the tuple of same shape but filled with `""`
Re-format the coordinate as needed for accurate comparison.

```fsharp
createRecord ("Brass Spyglass", "4B") ("Abandoned Lighthouse", ("4", "B"), "Blue")
("Brass Spyglass", "4B", "Abandoned Lighthouse", ("4", "B"), "Blue")

createRecord ("Brass Spyglass", "4B") ("Seaside Cottages", ("1", "C"), "Blue")
("", "", "", ("", ""), "")
```
