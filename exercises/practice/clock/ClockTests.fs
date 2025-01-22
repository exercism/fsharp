source("./clock.R")
library(testthat)

let ``On the hour`` () =
    clock <- create 8 0
    display clock |> should equal "08:00"

let ``Past the hour`` () =
    clock <- create 11 9
    display clock |> should equal "11:09"

let ``Midnight is zero hours`` () =
    clock <- create 24 0
    display clock |> should equal "00:00"

let ``Hour rolls over`` () =
    clock <- create 25 0
    display clock |> should equal "01:00"

let ``Hour rolls over continuously`` () =
    clock <- create 100 0
    display clock |> should equal "04:00"

let ``Sixty minutes is next hour`` () =
    clock <- create 1 60
    display clock |> should equal "02:00"

let ``Minutes roll over`` () =
    clock <- create 0 160
    display clock |> should equal "02:40"

let ``Minutes roll over continuously`` () =
    clock <- create 0 1723
    display clock |> should equal "04:43"

let ``Hour and minutes roll over`` () =
    clock <- create 25 160
    display clock |> should equal "03:40"

let ``Hour and minutes roll over continuously`` () =
    clock <- create 201 3001
    display clock |> should equal "11:01"

let ``Hour and minutes roll over to exactly midnight`` () =
    clock <- create 72 8640
    display clock |> should equal "00:00"

let ``Negative hour`` () =
    clock <- create -1 15
    display clock |> should equal "23:15"

let ``Negative hour rolls over`` () =
    clock <- create -25 0
    display clock |> should equal "23:00"

let ``Negative hour rolls over continuously`` () =
    clock <- create -91 0
    display clock |> should equal "05:00"

let ``Negative minutes`` () =
    clock <- create 1 -40
    display clock |> should equal "00:20"

let ``Negative minutes roll over`` () =
    clock <- create 1 -160
    display clock |> should equal "22:20"

let ``Negative minutes roll over continuously`` () =
    clock <- create 1 -4820
    display clock |> should equal "16:40"

let ``Negative sixty minutes is previous hour`` () =
    clock <- create 2 -60
    display clock |> should equal "01:00"

let ``Negative hour and minutes both roll over`` () =
    clock <- create -25 -160
    display clock |> should equal "20:20"

let ``Negative hour and minutes both roll over continuously`` () =
    clock <- create -121 -5810
    display clock |> should equal "22:10"

let ``Add minutes`` () =
    clock <- create 10 0
    add 3 clock |> display |> should equal "10:03"

let ``Add no minutes`` () =
    clock <- create 6 41
    add 0 clock |> display |> should equal "06:41"

let ``Add to next hour`` () =
    clock <- create 0 45
    add 40 clock |> display |> should equal "01:25"

let ``Add more than one hour`` () =
    clock <- create 10 0
    add 61 clock |> display |> should equal "11:01"

let ``Add more than two hours with carry`` () =
    clock <- create 0 45
    add 160 clock |> display |> should equal "03:25"

let ``Add across midnight`` () =
    clock <- create 23 59
    add 2 clock |> display |> should equal "00:01"

let ``Add more than one day (1500 min = 25 hrs)`` () =
    clock <- create 5 32
    add 1500 clock |> display |> should equal "06:32"

let ``Add more than two days`` () =
    clock <- create 1 1
    add 3500 clock |> display |> should equal "11:21"

let ``Subtract minutes`` () =
    clock <- create 10 3
    subtract 3 clock |> display |> should equal "10:00"

let ``Subtract to previous hour`` () =
    clock <- create 10 3
    subtract 30 clock |> display |> should equal "09:33"

let ``Subtract more than an hour`` () =
    clock <- create 10 3
    subtract 70 clock |> display |> should equal "08:53"

let ``Subtract across midnight`` () =
    clock <- create 0 3
    subtract 4 clock |> display |> should equal "23:59"

let ``Subtract more than two hours`` () =
    clock <- create 0 0
    subtract 160 clock |> display |> should equal "21:20"

let ``Subtract more than two hours with borrow`` () =
    clock <- create 6 15
    subtract 160 clock |> display |> should equal "03:35"

let ``Subtract more than one day (1500 min = 25 hrs)`` () =
    clock <- create 5 32
    subtract 1500 clock |> display |> should equal "04:32"

let ``Subtract more than two days`` () =
    clock <- create 2 20
    subtract 3000 clock |> display |> should equal "00:20"

let ``Clocks with same time`` () =
    clock1 <- create 15 37
    clock2 <- create 15 37
    clock1 = clock2 |> should equal true

let ``Clocks a minute apart`` () =
    clock1 <- create 15 36
    clock2 <- create 15 37
    clock1 = clock2 |> should equal false

let ``Clocks an hour apart`` () =
    clock1 <- create 14 37
    clock2 <- create 15 37
    clock1 = clock2 |> should equal false

let ``Clocks with hour overflow`` () =
    clock1 <- create 10 37
    clock2 <- create 34 37
    clock1 = clock2 |> should equal true

let ``Clocks with hour overflow by several days`` () =
    clock1 <- create 3 11
    clock2 <- create 99 11
    clock1 = clock2 |> should equal true

let ``Clocks with negative hour`` () =
    clock1 <- create 22 40
    clock2 <- create -2 40
    clock1 = clock2 |> should equal true

let ``Clocks with negative hour that wraps`` () =
    clock1 <- create 17 3
    clock2 <- create -31 3
    clock1 = clock2 |> should equal true

let ``Clocks with negative hour that wraps multiple times`` () =
    clock1 <- create 13 49
    clock2 <- create -83 49
    clock1 = clock2 |> should equal true

let ``Clocks with minute overflow`` () =
    clock1 <- create 0 1
    clock2 <- create 0 1441
    clock1 = clock2 |> should equal true

let ``Clocks with minute overflow by several days`` () =
    clock1 <- create 2 2
    clock2 <- create 2 4322
    clock1 = clock2 |> should equal true

let ``Clocks with negative minute`` () =
    clock1 <- create 2 40
    clock2 <- create 3 -20
    clock1 = clock2 |> should equal true

let ``Clocks with negative minute that wraps`` () =
    clock1 <- create 4 10
    clock2 <- create 5 -1490
    clock1 = clock2 |> should equal true

let ``Clocks with negative minute that wraps multiple times`` () =
    clock1 <- create 6 15
    clock2 <- create 6 -4305
    clock1 = clock2 |> should equal true

let ``Clocks with negative hours and minutes`` () =
    clock1 <- create 7 32
    clock2 <- create -12 -268
    clock1 = clock2 |> should equal true

let ``Clocks with negative hours and minutes that wrap`` () =
    clock1 <- create 18 7
    clock2 <- create -54 -11513
    clock1 = clock2 |> should equal true

let ``Full clock and zeroed clock`` () =
    clock1 <- create 24 0
    clock2 <- create 0 0
    clock1 = clock2 |> should equal true

