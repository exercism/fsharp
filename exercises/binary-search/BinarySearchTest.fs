module BinarySearchTest

open Xunit
open FsUnit

open BinarySearch

[<Fact>]
let ``Should return None when an empty array is searched`` () =
    let input = [||]
    binarySearch input 6 |> should equal None

[<Fact(Skip = "Remove to run test")>]
let ``Should be able to find a value in a single element array with one access`` () =
    let input = [|6|]
    binarySearch input 6 |> should equal <| Some 0
    
[<Fact(Skip = "Remove to run test")>]
let ``Should return None if a value is less than the element in a single element array`` () =
    let input = [|94|]
    binarySearch input 6 |> should equal None
    
[<Fact(Skip = "Remove to run test")>]
let ``Should return None if a value is greater than the element in a single element array`` () =
    let input = [|94|]
    binarySearch input 602 |> should equal None

[<Fact(Skip = "Remove to run test")>]
let ``Should find an element in a longer array`` () =
    let input = [|6; 67; 123; 345; 456; 457; 490; 2002; 54321; 54322|]
    binarySearch input 2002 |> should equal <| Some 7

[<Fact(Skip = "Remove to run test")>]
let ``Should find elements at the beginning of an array`` () =
    let input = [|6; 67; 123; 345; 456; 457; 490; 2002; 54321; 54322|]
    binarySearch input 6 |> should equal <| Some 0

[<Fact(Skip = "Remove to run test")>]
let ``Should find elements at the end of an array`` () =
    let input = [|6; 67; 123; 345; 456; 457; 490; 2002; 54321; 54322|]
    binarySearch input 54322 |> should equal <| Some 9

[<Fact(Skip = "Remove to run test")>]
let ``Should return None if a value is less than all elements in a long array`` () =
    let input = [|6; 67; 123; 345; 456; 457; 490; 2002; 54321; 54322|]
    binarySearch input 2 |> should equal None

[<Fact(Skip = "Remove to run test")>]
let ``Should return None if a value is greater than all elements in a long array`` () =
    let input = [|6; 67; 123; 345; 456; 457; 490; 2002; 54321; 54322|]
    binarySearch input 54323 |> should equal None
