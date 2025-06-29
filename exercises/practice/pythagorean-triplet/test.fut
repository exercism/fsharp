import "pythagorean_triplet"

-- Triplets whose sum is 12
-- ==
-- input { 12 }
-- output { [(3, 4, 5)] }

-- Triplets whose sum is 108
-- ==
-- input { 108 }
-- output { [(27, 36, 45)] }

-- Triplets whose sum is 1000
-- ==
-- input { 1000 }
-- output { [(200, 375, 425)] }

let ``No matching triplets for 1001`` () =
    tripletsWithSum 1001 |> should be Empty

-- Returns all matching triplets
-- ==
-- input { 90 }
-- output { [(9, 40, 41); (15, 36, 39)] }

-- Several matching triplets
-- ==
-- input { 840 }
-- output { [(40, 399, 401); (56, 390, 394); (105, 360, 375); (120, 350, 370); (140, 336, 364); (168, 315, 357); (210, 280, 350); (240, 252, 348)] }

-- Triplets for large number
-- ==
-- input { 30000 }
-- output { [(1200, 14375, 14425); (1875, 14000, 14125); (5000, 12000, 13000); (6000, 11250, 12750); (7500, 10000, 12500)] }

