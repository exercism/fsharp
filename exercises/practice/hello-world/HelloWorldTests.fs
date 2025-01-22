source("./hello-world.R")
library(testthat)

open FsUnit.Xunit
open Xunit

open HelloWorld

let ``Say Hi!`` () =
    hello |> should equal "Hello, World!"

