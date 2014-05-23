module Triangle

type TriangleKind =
    | Equilateral
    | Isosceles
    | Scalene

type Triangle(side1: decimal, side2: decimal, side3: decimal) =
    let hasSidesAsZeroes() = 
        side1 = 0m && side2 = 0m && side3 = 0m

    let hasSidesLessThanZero() =
        side1 < 0m || side2 < 0m || side3 < 0m

    let hasTriangleInequality() =
        side1 + side2 <= side3 || side1 + side3 <= side2 || side2 + side3 <= side1

    member this.Kind() =
        if hasSidesAsZeroes() || hasSidesLessThanZero() || hasTriangleInequality() then invalidOp "Invalid sides for triangle."

        Seq.distinct [side1; side2; side3]
            |> Seq.length
            |> function
                | 1 -> TriangleKind.Equilateral
                | 2 -> TriangleKind.Isosceles
                | _ -> TriangleKind.Scalene