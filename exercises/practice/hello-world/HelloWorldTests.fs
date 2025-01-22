source("./hello-world.R")
library(testthat)

let ``Say Hi!`` () =
    hello |> should equal "Hello, World!"

