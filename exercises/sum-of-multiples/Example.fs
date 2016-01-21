module SumOfMultiples

type SumOfMultiples(multiples) = 
    let isMultiple(input: int) = 
        multiples |> List.exists(fun multiple -> input % multiple = 0)

    new() = SumOfMultiples([3; 5])

    member this.Multiples = multiples

    member this.To(limit: int) = 
        [1..limit - 1] 
            |> List.filter(fun item -> isMultiple(item)) 
            |> List.sum