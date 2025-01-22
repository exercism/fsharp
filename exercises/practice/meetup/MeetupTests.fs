source("./meetup.R")
library(testthat)

test_that("When teenth Monday is the 13th, the first day of the teenth week", {
  expect_equal(meetup 2013 5 Week.Teenth DayOfWeek.Monday, (DateTime(2013, 5, 13)))
})

test_that("When teenth Monday is the 19th, the last day of the teenth week", {
  expect_equal(meetup 2013 8 Week.Teenth DayOfWeek.Monday, (DateTime(2013, 8, 19)))
})

test_that("When teenth Monday is some day in the middle of the teenth week", {
  expect_equal(meetup 2013 9 Week.Teenth DayOfWeek.Monday, (DateTime(2013, 9, 16)))
})

test_that("When teenth Tuesday is the 19th, the last day of the teenth week", {
  expect_equal(meetup 2013 3 Week.Teenth DayOfWeek.Tuesday, (DateTime(2013, 3, 19)))
})

test_that("When teenth Tuesday is some day in the middle of the teenth week", {
  expect_equal(meetup 2013 4 Week.Teenth DayOfWeek.Tuesday, (DateTime(2013, 4, 16)))
})

test_that("When teenth Tuesday is the 13th, the first day of the teenth week", {
  expect_equal(meetup 2013 8 Week.Teenth DayOfWeek.Tuesday, (DateTime(2013, 8, 13)))
})

test_that("When teenth Wednesday is some day in the middle of the teenth week", {
  expect_equal(meetup 2013 1 Week.Teenth DayOfWeek.Wednesday, (DateTime(2013, 1, 16)))
})

test_that("When teenth Wednesday is the 13th, the first day of the teenth week", {
  expect_equal(meetup 2013 2 Week.Teenth DayOfWeek.Wednesday, (DateTime(2013, 2, 13)))
})

test_that("When teenth Wednesday is the 19th, the last day of the teenth week", {
  expect_equal(meetup 2013 6 Week.Teenth DayOfWeek.Wednesday, (DateTime(2013, 6, 19)))
})

test_that("When teenth Thursday is some day in the middle of the teenth week", {
  expect_equal(meetup 2013 5 Week.Teenth DayOfWeek.Thursday, (DateTime(2013, 5, 16)))
})

test_that("When teenth Thursday is the 13th, the first day of the teenth week", {
  expect_equal(meetup 2013 6 Week.Teenth DayOfWeek.Thursday, (DateTime(2013, 6, 13)))
})

test_that("When teenth Thursday is the 19th, the last day of the teenth week", {
  expect_equal(meetup 2013 9 Week.Teenth DayOfWeek.Thursday, (DateTime(2013, 9, 19)))
})

test_that("When teenth Friday is the 19th, the last day of the teenth week", {
  expect_equal(meetup 2013 4 Week.Teenth DayOfWeek.Friday, (DateTime(2013, 4, 19)))
})

test_that("When teenth Friday is some day in the middle of the teenth week", {
  expect_equal(meetup 2013 8 Week.Teenth DayOfWeek.Friday, (DateTime(2013, 8, 16)))
})

test_that("When teenth Friday is the 13th, the first day of the teenth week", {
  expect_equal(meetup 2013 9 Week.Teenth DayOfWeek.Friday, (DateTime(2013, 9, 13)))
})

test_that("When teenth Saturday is some day in the middle of the teenth week", {
  expect_equal(meetup 2013 2 Week.Teenth DayOfWeek.Saturday, (DateTime(2013, 2, 16)))
})

test_that("When teenth Saturday is the 13th, the first day of the teenth week", {
  expect_equal(meetup 2013 4 Week.Teenth DayOfWeek.Saturday, (DateTime(2013, 4, 13)))
})

test_that("When teenth Saturday is the 19th, the last day of the teenth week", {
  expect_equal(meetup 2013 10 Week.Teenth DayOfWeek.Saturday, (DateTime(2013, 10, 19)))
})

test_that("When teenth Sunday is the 19th, the last day of the teenth week", {
  expect_equal(meetup 2013 5 Week.Teenth DayOfWeek.Sunday, (DateTime(2013, 5, 19)))
})

test_that("When teenth Sunday is some day in the middle of the teenth week", {
  expect_equal(meetup 2013 6 Week.Teenth DayOfWeek.Sunday, (DateTime(2013, 6, 16)))
})

test_that("When teenth Sunday is the 13th, the first day of the teenth week", {
  expect_equal(meetup 2013 10 Week.Teenth DayOfWeek.Sunday, (DateTime(2013, 10, 13)))
})

test_that("When first Monday is some day in the middle of the first week", {
  expect_equal(meetup 2013 3 Week.First DayOfWeek.Monday, (DateTime(2013, 3, 4)))
})

test_that("When first Monday is the 1st, the first day of the first week", {
  expect_equal(meetup 2013 4 Week.First DayOfWeek.Monday, (DateTime(2013, 4, 1)))
})

test_that("When first Tuesday is the 7th, the last day of the first week", {
  expect_equal(meetup 2013 5 Week.First DayOfWeek.Tuesday, (DateTime(2013, 5, 7)))
})

test_that("When first Tuesday is some day in the middle of the first week", {
  expect_equal(meetup 2013 6 Week.First DayOfWeek.Tuesday, (DateTime(2013, 6, 4)))
})

test_that("When first Wednesday is some day in the middle of the first week", {
  expect_equal(meetup 2013 7 Week.First DayOfWeek.Wednesday, (DateTime(2013, 7, 3)))
})

test_that("When first Wednesday is the 7th, the last day of the first week", {
  expect_equal(meetup 2013 8 Week.First DayOfWeek.Wednesday, (DateTime(2013, 8, 7)))
})

test_that("When first Thursday is some day in the middle of the first week", {
  expect_equal(meetup 2013 9 Week.First DayOfWeek.Thursday, (DateTime(2013, 9, 5)))
})

test_that("When first Thursday is another day in the middle of the first week", {
  expect_equal(meetup 2013 10 Week.First DayOfWeek.Thursday, (DateTime(2013, 10, 3)))
})

test_that("When first Friday is the 1st, the first day of the first week", {
  expect_equal(meetup 2013 11 Week.First DayOfWeek.Friday, (DateTime(2013, 11, 1)))
})

test_that("When first Friday is some day in the middle of the first week", {
  expect_equal(meetup 2013 12 Week.First DayOfWeek.Friday, (DateTime(2013, 12, 6)))
})

test_that("When first Saturday is some day in the middle of the first week", {
  expect_equal(meetup 2013 1 Week.First DayOfWeek.Saturday, (DateTime(2013, 1, 5)))
})

test_that("When first Saturday is another day in the middle of the first week", {
  expect_equal(meetup 2013 2 Week.First DayOfWeek.Saturday, (DateTime(2013, 2, 2)))
})

test_that("When first Sunday is some day in the middle of the first week", {
  expect_equal(meetup 2013 3 Week.First DayOfWeek.Sunday, (DateTime(2013, 3, 3)))
})

test_that("When first Sunday is the 7th, the last day of the first week", {
  expect_equal(meetup 2013 4 Week.First DayOfWeek.Sunday, (DateTime(2013, 4, 7)))
})

test_that("When second Monday is some day in the middle of the second week", {
  expect_equal(meetup 2013 3 Week.Second DayOfWeek.Monday, (DateTime(2013, 3, 11)))
})

test_that("When second Monday is the 8th, the first day of the second week", {
  expect_equal(meetup 2013 4 Week.Second DayOfWeek.Monday, (DateTime(2013, 4, 8)))
})

test_that("When second Tuesday is the 14th, the last day of the second week", {
  expect_equal(meetup 2013 5 Week.Second DayOfWeek.Tuesday, (DateTime(2013, 5, 14)))
})

test_that("When second Tuesday is some day in the middle of the second week", {
  expect_equal(meetup 2013 6 Week.Second DayOfWeek.Tuesday, (DateTime(2013, 6, 11)))
})

test_that("When second Wednesday is some day in the middle of the second week", {
  expect_equal(meetup 2013 7 Week.Second DayOfWeek.Wednesday, (DateTime(2013, 7, 10)))
})

test_that("When second Wednesday is the 14th, the last day of the second week", {
  expect_equal(meetup 2013 8 Week.Second DayOfWeek.Wednesday, (DateTime(2013, 8, 14)))
})

test_that("When second Thursday is some day in the middle of the second week", {
  expect_equal(meetup 2013 9 Week.Second DayOfWeek.Thursday, (DateTime(2013, 9, 12)))
})

test_that("When second Thursday is another day in the middle of the second week", {
  expect_equal(meetup 2013 10 Week.Second DayOfWeek.Thursday, (DateTime(2013, 10, 10)))
})

test_that("When second Friday is the 8th, the first day of the second week", {
  expect_equal(meetup 2013 11 Week.Second DayOfWeek.Friday, (DateTime(2013, 11, 8)))
})

test_that("When second Friday is some day in the middle of the second week", {
  expect_equal(meetup 2013 12 Week.Second DayOfWeek.Friday, (DateTime(2013, 12, 13)))
})

test_that("When second Saturday is some day in the middle of the second week", {
  expect_equal(meetup 2013 1 Week.Second DayOfWeek.Saturday, (DateTime(2013, 1, 12)))
})

test_that("When second Saturday is another day in the middle of the second week", {
  expect_equal(meetup 2013 2 Week.Second DayOfWeek.Saturday, (DateTime(2013, 2, 9)))
})

test_that("When second Sunday is some day in the middle of the second week", {
  expect_equal(meetup 2013 3 Week.Second DayOfWeek.Sunday, (DateTime(2013, 3, 10)))
})

test_that("When second Sunday is the 14th, the last day of the second week", {
  expect_equal(meetup 2013 4 Week.Second DayOfWeek.Sunday, (DateTime(2013, 4, 14)))
})

test_that("When third Monday is some day in the middle of the third week", {
  expect_equal(meetup 2013 3 Week.Third DayOfWeek.Monday, (DateTime(2013, 3, 18)))
})

test_that("When third Monday is the 15th, the first day of the third week", {
  expect_equal(meetup 2013 4 Week.Third DayOfWeek.Monday, (DateTime(2013, 4, 15)))
})

test_that("When third Tuesday is the 21st, the last day of the third week", {
  expect_equal(meetup 2013 5 Week.Third DayOfWeek.Tuesday, (DateTime(2013, 5, 21)))
})

test_that("When third Tuesday is some day in the middle of the third week", {
  expect_equal(meetup 2013 6 Week.Third DayOfWeek.Tuesday, (DateTime(2013, 6, 18)))
})

test_that("When third Wednesday is some day in the middle of the third week", {
  expect_equal(meetup 2013 7 Week.Third DayOfWeek.Wednesday, (DateTime(2013, 7, 17)))
})

test_that("When third Wednesday is the 21st, the last day of the third week", {
  expect_equal(meetup 2013 8 Week.Third DayOfWeek.Wednesday, (DateTime(2013, 8, 21)))
})

test_that("When third Thursday is some day in the middle of the third week", {
  expect_equal(meetup 2013 9 Week.Third DayOfWeek.Thursday, (DateTime(2013, 9, 19)))
})

test_that("When third Thursday is another day in the middle of the third week", {
  expect_equal(meetup 2013 10 Week.Third DayOfWeek.Thursday, (DateTime(2013, 10, 17)))
})

test_that("When third Friday is the 15th, the first day of the third week", {
  expect_equal(meetup 2013 11 Week.Third DayOfWeek.Friday, (DateTime(2013, 11, 15)))
})

test_that("When third Friday is some day in the middle of the third week", {
  expect_equal(meetup 2013 12 Week.Third DayOfWeek.Friday, (DateTime(2013, 12, 20)))
})

test_that("When third Saturday is some day in the middle of the third week", {
  expect_equal(meetup 2013 1 Week.Third DayOfWeek.Saturday, (DateTime(2013, 1, 19)))
})

test_that("When third Saturday is another day in the middle of the third week", {
  expect_equal(meetup 2013 2 Week.Third DayOfWeek.Saturday, (DateTime(2013, 2, 16)))
})

test_that("When third Sunday is some day in the middle of the third week", {
  expect_equal(meetup 2013 3 Week.Third DayOfWeek.Sunday, (DateTime(2013, 3, 17)))
})

test_that("When third Sunday is the 21st, the last day of the third week", {
  expect_equal(meetup 2013 4 Week.Third DayOfWeek.Sunday, (DateTime(2013, 4, 21)))
})

test_that("When fourth Monday is some day in the middle of the fourth week", {
  expect_equal(meetup 2013 3 Week.Fourth DayOfWeek.Monday, (DateTime(2013, 3, 25)))
})

test_that("When fourth Monday is the 22nd, the first day of the fourth week", {
  expect_equal(meetup 2013 4 Week.Fourth DayOfWeek.Monday, (DateTime(2013, 4, 22)))
})

test_that("When fourth Tuesday is the 28th, the last day of the fourth week", {
  expect_equal(meetup 2013 5 Week.Fourth DayOfWeek.Tuesday, (DateTime(2013, 5, 28)))
})

test_that("When fourth Tuesday is some day in the middle of the fourth week", {
  expect_equal(meetup 2013 6 Week.Fourth DayOfWeek.Tuesday, (DateTime(2013, 6, 25)))
})

test_that("When fourth Wednesday is some day in the middle of the fourth week", {
  expect_equal(meetup 2013 7 Week.Fourth DayOfWeek.Wednesday, (DateTime(2013, 7, 24)))
})

test_that("When fourth Wednesday is the 28th, the last day of the fourth week", {
  expect_equal(meetup 2013 8 Week.Fourth DayOfWeek.Wednesday, (DateTime(2013, 8, 28)))
})

test_that("When fourth Thursday is some day in the middle of the fourth week", {
  expect_equal(meetup 2013 9 Week.Fourth DayOfWeek.Thursday, (DateTime(2013, 9, 26)))
})

test_that("When fourth Thursday is another day in the middle of the fourth week", {
  expect_equal(meetup 2013 10 Week.Fourth DayOfWeek.Thursday, (DateTime(2013, 10, 24)))
})

test_that("When fourth Friday is the 22nd, the first day of the fourth week", {
  expect_equal(meetup 2013 11 Week.Fourth DayOfWeek.Friday, (DateTime(2013, 11, 22)))
})

test_that("When fourth Friday is some day in the middle of the fourth week", {
  expect_equal(meetup 2013 12 Week.Fourth DayOfWeek.Friday, (DateTime(2013, 12, 27)))
})

test_that("When fourth Saturday is some day in the middle of the fourth week", {
  expect_equal(meetup 2013 1 Week.Fourth DayOfWeek.Saturday, (DateTime(2013, 1, 26)))
})

test_that("When fourth Saturday is another day in the middle of the fourth week", {
  expect_equal(meetup 2013 2 Week.Fourth DayOfWeek.Saturday, (DateTime(2013, 2, 23)))
})

test_that("When fourth Sunday is some day in the middle of the fourth week", {
  expect_equal(meetup 2013 3 Week.Fourth DayOfWeek.Sunday, (DateTime(2013, 3, 24)))
})

test_that("When fourth Sunday is the 28th, the last day of the fourth week", {
  expect_equal(meetup 2013 4 Week.Fourth DayOfWeek.Sunday, (DateTime(2013, 4, 28)))
})

test_that("Last Monday in a month with four Mondays", {
  expect_equal(meetup 2013 3 Week.Last DayOfWeek.Monday, (DateTime(2013, 3, 25)))
})

test_that("Last Monday in a month with five Mondays", {
  expect_equal(meetup 2013 4 Week.Last DayOfWeek.Monday, (DateTime(2013, 4, 29)))
})

test_that("Last Tuesday in a month with four Tuesdays", {
  expect_equal(meetup 2013 5 Week.Last DayOfWeek.Tuesday, (DateTime(2013, 5, 28)))
})

test_that("Last Tuesday in another month with four Tuesdays", {
  expect_equal(meetup 2013 6 Week.Last DayOfWeek.Tuesday, (DateTime(2013, 6, 25)))
})

test_that("Last Wednesday in a month with five Wednesdays", {
  expect_equal(meetup 2013 7 Week.Last DayOfWeek.Wednesday, (DateTime(2013, 7, 31)))
})

test_that("Last Wednesday in a month with four Wednesdays", {
  expect_equal(meetup 2013 8 Week.Last DayOfWeek.Wednesday, (DateTime(2013, 8, 28)))
})

test_that("Last Thursday in a month with four Thursdays", {
  expect_equal(meetup 2013 9 Week.Last DayOfWeek.Thursday, (DateTime(2013, 9, 26)))
})

test_that("Last Thursday in a month with five Thursdays", {
  expect_equal(meetup 2013 10 Week.Last DayOfWeek.Thursday, (DateTime(2013, 10, 31)))
})

test_that("Last Friday in a month with five Fridays", {
  expect_equal(meetup 2013 11 Week.Last DayOfWeek.Friday, (DateTime(2013, 11, 29)))
})

test_that("Last Friday in a month with four Fridays", {
  expect_equal(meetup 2013 12 Week.Last DayOfWeek.Friday, (DateTime(2013, 12, 27)))
})

test_that("Last Saturday in a month with four Saturdays", {
  expect_equal(meetup 2013 1 Week.Last DayOfWeek.Saturday, (DateTime(2013, 1, 26)))
})

test_that("Last Saturday in another month with four Saturdays", {
  expect_equal(meetup 2013 2 Week.Last DayOfWeek.Saturday, (DateTime(2013, 2, 23)))
})

test_that("Last Sunday in a month with five Sundays", {
  expect_equal(meetup 2013 3 Week.Last DayOfWeek.Sunday, (DateTime(2013, 3, 31)))
})

test_that("Last Sunday in a month with four Sundays", {
  expect_equal(meetup 2013 4 Week.Last DayOfWeek.Sunday, (DateTime(2013, 4, 28)))
})

test_that("When last Wednesday in February in a leap year is the 29th", {
  expect_equal(meetup 2012 2 Week.Last DayOfWeek.Wednesday, (DateTime(2012, 2, 29)))
})

test_that("Last Wednesday in December that is also the last day of the year", {
  expect_equal(meetup 2014 12 Week.Last DayOfWeek.Wednesday, (DateTime(2014, 12, 31)))
})

test_that("When last Sunday in February in a non-leap year is not the 29th", {
  expect_equal(meetup 2015 2 Week.Last DayOfWeek.Sunday, (DateTime(2015, 2, 22)))
})

test_that("When first Friday is the 7th, the last day of the first week", {
  expect_equal(meetup 2012 12 Week.First DayOfWeek.Friday, (DateTime(2012, 12, 7)))
})
