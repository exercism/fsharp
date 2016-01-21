module Grains

type Grains() =
    member this.square(number: int) =
        2I ** (number - 1)

    member this.total() =
        [1I..64I] |> List.reduce(fun accumulator element -> accumulator + this.square(int element))