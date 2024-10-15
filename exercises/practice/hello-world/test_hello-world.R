source("./hello-world.R")
library(testthat)



[<Fact>]
let ``Say Hi!`` () =
    hello |> should equal "Hello, World!"

