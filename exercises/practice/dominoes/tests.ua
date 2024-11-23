module DominoesTests



let ``Empty input = empty output`` () =
    let dominoes = []
    canChain dominoes |> should equal true

let ``Singleton input = singleton output`` () =
    let dominoes = [(1, 1)]
    canChain dominoes |> should equal true

let ``Singleton that can't be chained`` () =
    let dominoes = [(1, 2)]
    canChain dominoes |> should equal false

let ``Three elements`` () =
    let dominoes = [(1, 2); (3, 1); (2, 3)]
    canChain dominoes |> should equal true

let ``Can reverse dominoes`` () =
    let dominoes = [(1, 2); (1, 3); (2, 3)]
    canChain dominoes |> should equal true

let ``Can't be chained`` () =
    let dominoes = [(1, 2); (4, 1); (2, 3)]
    canChain dominoes |> should equal false

let ``Disconnected - simple`` () =
    let dominoes = [(1, 1); (2, 2)]
    canChain dominoes |> should equal false

let ``Disconnected - double loop`` () =
    let dominoes = [(1, 2); (2, 1); (3, 4); (4, 3)]
    canChain dominoes |> should equal false

let ``Disconnected - single isolated`` () =
    let dominoes = [(1, 2); (2, 3); (3, 1); (4, 4)]
    canChain dominoes |> should equal false

let ``Need backtrack`` () =
    let dominoes = [(1, 2); (2, 3); (3, 1); (2, 4); (2, 4)]
    canChain dominoes |> should equal true

let ``Separate loops`` () =
    let dominoes = [(1, 2); (2, 3); (3, 1); (1, 1); (2, 2); (3, 3)]
    canChain dominoes |> should equal true

let ``Nine elements`` () =
    let dominoes = [(1, 2); (5, 3); (3, 1); (1, 2); (2, 4); (1, 6); (2, 3); (3, 4); (5, 6)]
    canChain dominoes |> should equal true

let ``Separate three-domino loops`` () =
    let dominoes = [(1, 2); (2, 3); (3, 1); (4, 5); (5, 6); (6, 4)]
    canChain dominoes |> should equal false

