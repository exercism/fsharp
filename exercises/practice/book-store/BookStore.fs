module BookStore

let getDiscount =
    function
    | 2 -> 0.95m
    | 3 -> 0.90m
    | 4 -> 0.8m
    | 5 -> 0.75m
    | _ -> 1m

let computeForFiveOrLess books =
    let distinct = List.distinct books |> List.length
    (books |> List.length |> decimal) * 8m * getDiscount distinct

let computePrice books =
    0m

let total books =
    match List.length books with
    | n when n <= 5 -> computeForFiveOrLess books
    | _ -> computePrice books
