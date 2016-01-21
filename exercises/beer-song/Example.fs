module BeerSong

type BeerSong() = 
    member this.verse(number: int) =
        match number with
            | 0 -> "No more bottles of beer on the wall, no more bottles of beer.\nGo to the store and buy some more, 99 bottles of beer on the wall.\n"
            | 1 -> System.String.Format("{0} bottle of beer on the wall, {0} bottle of beer.\nTake it down and pass it around, no more bottles of beer on the wall.\n", number)
            | 2 -> System.String.Format("{0} bottles of beer on the wall, {0} bottles of beer.\nTake one down and pass it around, {1} bottle of beer on the wall.\n", number, number - 1)
            | _ -> System.String.Format("{0} bottles of beer on the wall, {0} bottles of beer.\nTake one down and pass it around, {1} bottles of beer on the wall.\n", number, number - 1)

    member this.sing() =
        this.verses(99, 0)

    member this.verses(starting: int, ending: int) =
        [ending..starting]
            |> List.rev
            |> List.map(fun item -> this.verse(item) + "\n")
            |> List.fold(fun accumulator element -> accumulator + element) ""