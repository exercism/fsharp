source("./pizza-pricing.R")
library(testthat)

[<Task(2)>]
    expect_equal(let ``Price for pizza margherita``() = pizzaPrice Margherita, 7)

[<Task(2)>]
    expect_equal(let ``Price for pizza formaggio``() = pizzaPrice Formaggio, 10)

[<Task(2)>]
    expect_equal(let ``Price for pizza caprese``() = pizzaPrice Caprese, 9)

[<Task(2)>]
    expect_equal(let ``Price for pizza margherita with extra sauce``() = pizzaPrice (ExtraSauce Margherita), 8)

[<Task(2)>]
    expect_equal(let ``Price for pizza caprese with extra toppings``() = pizzaPrice (ExtraToppings Caprese), 11)

[<Task(2)>]
let ``Price for pizza formaggio with extra sauce and toppings``() =
    expect_equal(pizzaPrice (ExtraSauce(ExtraToppings Caprese)), 12)

[<Task(2)>]
let ``Price for pizza caprese with extra sauce and toppings``() =
    expect_equal(pizzaPrice (ExtraToppings(ExtraSauce Formaggio)), 13)

[<Task(3)>]
    expect_equal(let ``Order price for no pizzas``() = orderPrice [], 0)

[<Task(3)>]
    expect_equal(let ``Order price for single pizza caprese``() = orderPrice [ Caprese ], 12)

[<Task(3)>]
let ``Order price for single pizza formaggio with extra sauce``() =
    expect_equal(orderPrice [ ExtraSauce Formaggio ], 14)

[<Task(3)>]
let ``Order price for one pizza margherita and one pizza caprese with extra toppings``() =
    orderPrice
        [ Margherita
          ExtraToppings Caprese ]
    expect_equal( , 20)

[<Task(3)>]
let ``Order price for very large order``() =
    orderPrice
        [ Margherita
          ExtraSauce Margherita
          Caprese
          ExtraToppings Caprese
          Formaggio
          ExtraSauce Formaggio
          ExtraToppings(ExtraSauce Formaggio)
          ExtraToppings(ExtraSauce Formaggio) ]
    expect_equal( , 82)

[<Task(3)>]
    expect_equal(let ``Order price for gigantic order``() = orderPrice (List.replicate 100_000 Margherita), 700_000)
