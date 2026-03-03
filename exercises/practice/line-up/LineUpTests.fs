module LineUpTests

open FsUnit.Xunit
open Xunit

open LineUp

[<Fact>]
let ``Format smallest non-exceptional ordinal numeral 4`` () =
    format "Gianna" 4 |> should equal "Gianna, you are the 4th customer we serve today. Thank you!"

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Format greatest single digit non-exceptional ordinal numeral 9`` () =
    format "Maarten" 9 |> should equal "Maarten, you are the 9th customer we serve today. Thank you!"

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Format non-exceptional ordinal numeral 5`` () =
    format "Petronila" 5 |> should equal "Petronila, you are the 5th customer we serve today. Thank you!"

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Format non-exceptional ordinal numeral 6`` () =
    format "Attakullakulla" 6 |> should equal "Attakullakulla, you are the 6th customer we serve today. Thank you!"

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Format non-exceptional ordinal numeral 7`` () =
    format "Kate" 7 |> should equal "Kate, you are the 7th customer we serve today. Thank you!"

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Format non-exceptional ordinal numeral 8`` () =
    format "Maximiliano" 8 |> should equal "Maximiliano, you are the 8th customer we serve today. Thank you!"

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Format exceptional ordinal numeral 1`` () =
    format "Mary" 1 |> should equal "Mary, you are the 1st customer we serve today. Thank you!"

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Format exceptional ordinal numeral 2`` () =
    format "Haruto" 2 |> should equal "Haruto, you are the 2nd customer we serve today. Thank you!"

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Format exceptional ordinal numeral 3`` () =
    format "Henriette" 3 |> should equal "Henriette, you are the 3rd customer we serve today. Thank you!"

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Format smallest two digit non-exceptional ordinal numeral 10`` () =
    format "Alvarez" 10 |> should equal "Alvarez, you are the 10th customer we serve today. Thank you!"

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Format non-exceptional ordinal numeral 11`` () =
    format "Jacqueline" 11 |> should equal "Jacqueline, you are the 11th customer we serve today. Thank you!"

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Format non-exceptional ordinal numeral 12`` () =
    format "Juan" 12 |> should equal "Juan, you are the 12th customer we serve today. Thank you!"

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Format non-exceptional ordinal numeral 13`` () =
    format "Patricia" 13 |> should equal "Patricia, you are the 13th customer we serve today. Thank you!"

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Format exceptional ordinal numeral 21`` () =
    format "Washi" 21 |> should equal "Washi, you are the 21st customer we serve today. Thank you!"

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Format exceptional ordinal numeral 62`` () =
    format "Nayra" 62 |> should equal "Nayra, you are the 62nd customer we serve today. Thank you!"

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Format exceptional ordinal numeral 100`` () =
    format "John" 100 |> should equal "John, you are the 100th customer we serve today. Thank you!"

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Format exceptional ordinal numeral 101`` () =
    format "Zeinab" 101 |> should equal "Zeinab, you are the 101st customer we serve today. Thank you!"

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Format non-exceptional ordinal numeral 112`` () =
    format "Knud" 112 |> should equal "Knud, you are the 112th customer we serve today. Thank you!"

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Format exceptional ordinal numeral 123`` () =
    format "Yma" 123 |> should equal "Yma, you are the 123rd customer we serve today. Thank you!"

