module Triangle

open System

type TriangleKind =
    | Equilateral
    | Isosceles
    | Scalene

let kind (x: decimal) (y: decimal) (z: decimal) = 
    let hasZeroSides = x = 0m && y = 0m && z = 0m
    let hasNegativeSide = x < 0m || y < 0m || z < 0m
    let violatesTriangleEquality = x + y <= z || x + z <= y || y + z <= x

    let isInvalid = hasZeroSides || hasNegativeSide || violatesTriangleEquality
    let isEquilateral = x = y && y = z
    let isIsosceles = x = y || y = z || x = z

    if   isInvalid     then invalidOp "Invalid triangle."
    elif isEquilateral then TriangleKind.Equilateral
    elif isIsosceles   then TriangleKind.Isosceles
    else TriangleKind.Scalene