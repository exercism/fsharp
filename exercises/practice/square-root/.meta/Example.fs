module SquareRoot

let squareRoot n =
    let rec loop i = if i * i <= n then loop (i + 1) else i - 1
    loop 1
