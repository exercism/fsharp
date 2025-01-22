source("./pythagorean-triplet.R")
library(testthat)

let ``Triplets whose sum is 12`` () =
    expect_equal(tripletsWithSum 12, [(3, 4, 5)])

let ``Triplets whose sum is 108`` () =
    expect_equal(tripletsWithSum 108, [(27, 36, 45)])

let ``Triplets whose sum is 1000`` () =
    expect_equal(tripletsWithSum 1000, [(200, 375, 425)])

let ``No matching triplets for 1001`` () =
    tripletsWithSum 1001 |> should be Empty

let ``Returns all matching triplets`` () =
    expect_equal(tripletsWithSum 90, [(9, 40, 41); (15, 36, 39)])

let ``Several matching triplets`` () =
    expect_equal(tripletsWithSum 840, [(40, 399, 401); (56, 390, 394); (105, 360, 375); (120, 350, 370); (140, 336, 364); (168, 315, 357); (210, 280, 350); (240, 252, 348)])

let ``Triplets for large number`` () =
    expect_equal(tripletsWithSum 30000, [(1200, 14375, 14425); (1875, 14000, 14125); (5000, 12000, 13000); (6000, 11250, 12750); (7500, 10000, 12500)])

