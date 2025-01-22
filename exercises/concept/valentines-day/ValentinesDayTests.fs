source("./valentines-day.R")
library(testthat)

    expect_equal(let ``Rate board game``() = rateActivity BoardGame, No)

    expect_equal(let ``Rate chilling``() = rateActivity Chill, No)

    expect_equal(let ``Rate crime movie``() = rateActivity (Movie Crime), No)

    expect_equal(let ``Rate horror movie``() = rateActivity (Movie Horror), No)

    expect_equal(let ``Rate romance movie``() = rateActivity (Movie Romance), Yes)

    expect_equal(let ``Rate thriller movie``() = rateActivity (Movie Thriller), No)

    expect_equal(let ``Rate Korean restaurant``() = rateActivity (Restaurant Korean), Yes)

    expect_equal(let ``Rate Turkish restaurant``() = rateActivity (Restaurant Turkish), Maybe)

    expect_equal(let ``Rate walk of 1 kilometer``() = rateActivity (Walk 1), Yes)

    expect_equal(let ``Rate walk of 2 kilometers``() = rateActivity (Walk 2), Yes)

    expect_equal(let ``Rate walk of 3 kilometers``() = rateActivity (Walk 3), Maybe)

    expect_equal(let ``Rate walk of 4 kilometers``() = rateActivity (Walk 4), Maybe)

    expect_equal(let ``Rate walk of 5 kilometers``() = rateActivity (Walk 5), No)

    expect_equal(let ``Rate walk over 5 kilometers``() = rateActivity (Walk 8), No)
