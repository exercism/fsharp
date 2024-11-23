

let ``Zero is an Armstrong number`` () =
    isArmstrongNumber 0 |> should equal true

let ``Single-digit numbers are Armstrong numbers`` () =
    isArmstrongNumber 5 |> should equal true

let ``There are no two-digit Armstrong numbers`` () =
    isArmstrongNumber 10 |> should equal false

let ``Three-digit number that is an Armstrong number`` () =
    isArmstrongNumber 153 |> should equal true

let ``Three-digit number that is not an Armstrong number`` () =
    isArmstrongNumber 100 |> should equal false

let ``Four-digit number that is an Armstrong number`` () =
    isArmstrongNumber 9474 |> should equal true

let ``Four-digit number that is not an Armstrong number`` () =
    isArmstrongNumber 9475 |> should equal false

let ``Seven-digit number that is an Armstrong number`` () =
    isArmstrongNumber 9926315 |> should equal true

let ``Seven-digit number that is not an Armstrong number`` () =
    isArmstrongNumber 9926314 |> should equal false

