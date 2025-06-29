import "queen_attack"

let ``Queen with a valid position`` () =
    create (2, 2) |> should equal true

let ``Queen must have positive row`` () =
    create (-2, 2) |> should equal false

let ``Queen must have row on board`` () =
    create (8, 4) |> should equal false

let ``Queen must have positive column`` () =
    create (2, -2) |> should equal false

let ``Queen must have column on board`` () =
    create (4, 8) |> should equal false

let ``Cannot attack`` () =
    let white_queen = (2, 4)
    let black_queen = (6, 6)
    canAttack blackQueen whiteQueen |> should equal false

let ``Can attack on same row`` () =
    let white_queen = (2, 4)
    let black_queen = (2, 6)
    canAttack blackQueen whiteQueen |> should equal true

let ``Can attack on same column`` () =
    let white_queen = (4, 5)
    let black_queen = (2, 5)
    canAttack blackQueen whiteQueen |> should equal true

let ``Can attack on first diagonal`` () =
    let white_queen = (2, 2)
    let black_queen = (0, 4)
    canAttack blackQueen whiteQueen |> should equal true

let ``Can attack on second diagonal`` () =
    let white_queen = (2, 2)
    let black_queen = (3, 1)
    canAttack blackQueen whiteQueen |> should equal true

let ``Can attack on third diagonal`` () =
    let white_queen = (2, 2)
    let black_queen = (1, 1)
    canAttack blackQueen whiteQueen |> should equal true

let ``Can attack on fourth diagonal`` () =
    let white_queen = (1, 7)
    let black_queen = (0, 6)
    canAttack blackQueen whiteQueen |> should equal true

let ``Cannot attack if falling diagonals are only the same when reflected across the longest falling diagonal`` () =
    let white_queen = (4, 1)
    let black_queen = (2, 5)
    canAttack blackQueen whiteQueen |> should equal false

