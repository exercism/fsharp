source("./twelve-days.R")
library(testthat)

test_that("First day a partridge in a pear tree", {
    expected <- c("On the first day of Christmas my true love gave to me: a Partridge in a Pear Tree.")
    expect_equal(recite 1 1, expected)
})

test_that("Second day two turtle doves", {
    expected <- c("On the second day of Christmas my true love gave to me: two Turtle Doves, and a Partridge in a Pear Tree.")
    expect_equal(recite 2 2, expected)
})

test_that("Third day three french hens", {
    expected <- c("On the third day of Christmas my true love gave to me: three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.")
    expect_equal(recite 3 3, expected)
})

test_that("Fourth day four calling birds", {
    expected <- c("On the fourth day of Christmas my true love gave to me: four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.")
    expect_equal(recite 4 4, expected)
})

test_that("Fifth day five gold rings", {
    expected <- c("On the fifth day of Christmas my true love gave to me: five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.")
    expect_equal(recite 5 5, expected)
})

test_that("Sixth day six geese-a-laying", {
    expected <- c("On the sixth day of Christmas my true love gave to me: six Geese-a-Laying, five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.")
    expect_equal(recite 6 6, expected)
})

test_that("Seventh day seven swans-a-swimming", {
    expected <- c("On the seventh day of Christmas my true love gave to me: seven Swans-a-Swimming, six Geese-a-Laying, five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.")
    expect_equal(recite 7 7, expected)
})

test_that("Eighth day eight maids-a-milking", {
    expected <- c("On the eighth day of Christmas my true love gave to me: eight Maids-a-Milking, seven Swans-a-Swimming, six Geese-a-Laying, five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.")
    expect_equal(recite 8 8, expected)
})

test_that("Ninth day nine ladies dancing", {
    expected <- c("On the ninth day of Christmas my true love gave to me: nine Ladies Dancing, eight Maids-a-Milking, seven Swans-a-Swimming, six Geese-a-Laying, five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.")
    expect_equal(recite 9 9, expected)
})

test_that("Tenth day ten lords-a-leaping", {
    expected <- c("On the tenth day of Christmas my true love gave to me: ten Lords-a-Leaping, nine Ladies Dancing, eight Maids-a-Milking, seven Swans-a-Swimming, six Geese-a-Laying, five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.")
    expect_equal(recite 10 10, expected)
})

test_that("Eleventh day eleven pipers piping", {
    expected <- c("On the eleventh day of Christmas my true love gave to me: eleven Pipers Piping, ten Lords-a-Leaping, nine Ladies Dancing, eight Maids-a-Milking, seven Swans-a-Swimming, six Geese-a-Laying, five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.")
    expect_equal(recite 11 11, expected)
})

test_that("Twelfth day twelve drummers drumming", {
    expected <- c("On the twelfth day of Christmas my true love gave to me: twelve Drummers Drumming, eleven Pipers Piping, ten Lords-a-Leaping, nine Ladies Dancing, eight Maids-a-Milking, seven Swans-a-Swimming, six Geese-a-Laying, five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.")
    expect_equal(recite 12 12, expected)
})

test_that("Recites first three verses of the song", {
    expected <- 
        [ "On the first day of Christmas my true love gave to me: a Partridge in a Pear Tree.";
          "On the second day of Christmas my true love gave to me: two Turtle Doves, and a Partridge in a Pear Tree.";
          "On the third day of Christmas my true love gave to me: three French Hens, two Turtle Doves, and a Partridge in a Pear Tree." ]
    expect_equal(recite 1 3, expected)
})

test_that("Recites three verses from the middle of the song", {
    expected <- 
        [ "On the fourth day of Christmas my true love gave to me: four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.";
          "On the fifth day of Christmas my true love gave to me: five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.";
          "On the sixth day of Christmas my true love gave to me: six Geese-a-Laying, five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree." ]
    expect_equal(recite 4 6, expected)
})

test_that("Recites the whole song", {
    expected <- 
        [ "On the first day of Christmas my true love gave to me: a Partridge in a Pear Tree.";
          "On the second day of Christmas my true love gave to me: two Turtle Doves, and a Partridge in a Pear Tree.";
          "On the third day of Christmas my true love gave to me: three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.";
          "On the fourth day of Christmas my true love gave to me: four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.";
          "On the fifth day of Christmas my true love gave to me: five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.";
          "On the sixth day of Christmas my true love gave to me: six Geese-a-Laying, five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.";
          "On the seventh day of Christmas my true love gave to me: seven Swans-a-Swimming, six Geese-a-Laying, five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.";
          "On the eighth day of Christmas my true love gave to me: eight Maids-a-Milking, seven Swans-a-Swimming, six Geese-a-Laying, five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.";
          "On the ninth day of Christmas my true love gave to me: nine Ladies Dancing, eight Maids-a-Milking, seven Swans-a-Swimming, six Geese-a-Laying, five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.";
          "On the tenth day of Christmas my true love gave to me: ten Lords-a-Leaping, nine Ladies Dancing, eight Maids-a-Milking, seven Swans-a-Swimming, six Geese-a-Laying, five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.";
          "On the eleventh day of Christmas my true love gave to me: eleven Pipers Piping, ten Lords-a-Leaping, nine Ladies Dancing, eight Maids-a-Milking, seven Swans-a-Swimming, six Geese-a-Laying, five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.";
          "On the twelfth day of Christmas my true love gave to me: twelve Drummers Drumming, eleven Pipers Piping, ten Lords-a-Leaping, nine Ladies Dancing, eight Maids-a-Milking, seven Swans-a-Swimming, six Geese-a-Laying, five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree." ]
    expect_equal(recite 1 12, expected)
})
