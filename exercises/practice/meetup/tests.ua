~ "meetup.ua" ~ Meetup

# When teenth Monday is the 13th, the first day of the teenth week
    meetup 2013 5 Week.Teenth DayOfWeek.Monday |> should equal (DateTime(2013, 5, 13))

# When teenth Monday is the 19th, the last day of the teenth week
    meetup 2013 8 Week.Teenth DayOfWeek.Monday |> should equal (DateTime(2013, 8, 19))

# When teenth Monday is some day in the middle of the teenth week
    meetup 2013 9 Week.Teenth DayOfWeek.Monday |> should equal (DateTime(2013, 9, 16))

# When teenth Tuesday is the 19th, the last day of the teenth week
    meetup 2013 3 Week.Teenth DayOfWeek.Tuesday |> should equal (DateTime(2013, 3, 19))

# When teenth Tuesday is some day in the middle of the teenth week
    meetup 2013 4 Week.Teenth DayOfWeek.Tuesday |> should equal (DateTime(2013, 4, 16))

# When teenth Tuesday is the 13th, the first day of the teenth week
    meetup 2013 8 Week.Teenth DayOfWeek.Tuesday |> should equal (DateTime(2013, 8, 13))

# When teenth Wednesday is some day in the middle of the teenth week
    meetup 2013 1 Week.Teenth DayOfWeek.Wednesday |> should equal (DateTime(2013, 1, 16))

# When teenth Wednesday is the 13th, the first day of the teenth week
    meetup 2013 2 Week.Teenth DayOfWeek.Wednesday |> should equal (DateTime(2013, 2, 13))

# When teenth Wednesday is the 19th, the last day of the teenth week
    meetup 2013 6 Week.Teenth DayOfWeek.Wednesday |> should equal (DateTime(2013, 6, 19))

# When teenth Thursday is some day in the middle of the teenth week
    meetup 2013 5 Week.Teenth DayOfWeek.Thursday |> should equal (DateTime(2013, 5, 16))

# When teenth Thursday is the 13th, the first day of the teenth week
    meetup 2013 6 Week.Teenth DayOfWeek.Thursday |> should equal (DateTime(2013, 6, 13))

# When teenth Thursday is the 19th, the last day of the teenth week
    meetup 2013 9 Week.Teenth DayOfWeek.Thursday |> should equal (DateTime(2013, 9, 19))

# When teenth Friday is the 19th, the last day of the teenth week
    meetup 2013 4 Week.Teenth DayOfWeek.Friday |> should equal (DateTime(2013, 4, 19))

# When teenth Friday is some day in the middle of the teenth week
    meetup 2013 8 Week.Teenth DayOfWeek.Friday |> should equal (DateTime(2013, 8, 16))

# When teenth Friday is the 13th, the first day of the teenth week
    meetup 2013 9 Week.Teenth DayOfWeek.Friday |> should equal (DateTime(2013, 9, 13))

# When teenth Saturday is some day in the middle of the teenth week
    meetup 2013 2 Week.Teenth DayOfWeek.Saturday |> should equal (DateTime(2013, 2, 16))

# When teenth Saturday is the 13th, the first day of the teenth week
    meetup 2013 4 Week.Teenth DayOfWeek.Saturday |> should equal (DateTime(2013, 4, 13))

# When teenth Saturday is the 19th, the last day of the teenth week
    meetup 2013 10 Week.Teenth DayOfWeek.Saturday |> should equal (DateTime(2013, 10, 19))

# When teenth Sunday is the 19th, the last day of the teenth week
    meetup 2013 5 Week.Teenth DayOfWeek.Sunday |> should equal (DateTime(2013, 5, 19))

# When teenth Sunday is some day in the middle of the teenth week
    meetup 2013 6 Week.Teenth DayOfWeek.Sunday |> should equal (DateTime(2013, 6, 16))

# When teenth Sunday is the 13th, the first day of the teenth week
    meetup 2013 10 Week.Teenth DayOfWeek.Sunday |> should equal (DateTime(2013, 10, 13))

# When first Monday is some day in the middle of the first week
    meetup 2013 3 Week.First DayOfWeek.Monday |> should equal (DateTime(2013, 3, 4))

# When first Monday is the 1st, the first day of the first week
    meetup 2013 4 Week.First DayOfWeek.Monday |> should equal (DateTime(2013, 4, 1))

# When first Tuesday is the 7th, the last day of the first week
    meetup 2013 5 Week.First DayOfWeek.Tuesday |> should equal (DateTime(2013, 5, 7))

# When first Tuesday is some day in the middle of the first week
    meetup 2013 6 Week.First DayOfWeek.Tuesday |> should equal (DateTime(2013, 6, 4))

# When first Wednesday is some day in the middle of the first week
    meetup 2013 7 Week.First DayOfWeek.Wednesday |> should equal (DateTime(2013, 7, 3))

# When first Wednesday is the 7th, the last day of the first week
    meetup 2013 8 Week.First DayOfWeek.Wednesday |> should equal (DateTime(2013, 8, 7))

# When first Thursday is some day in the middle of the first week
    meetup 2013 9 Week.First DayOfWeek.Thursday |> should equal (DateTime(2013, 9, 5))

# When first Thursday is another day in the middle of the first week
    meetup 2013 10 Week.First DayOfWeek.Thursday |> should equal (DateTime(2013, 10, 3))

# When first Friday is the 1st, the first day of the first week
    meetup 2013 11 Week.First DayOfWeek.Friday |> should equal (DateTime(2013, 11, 1))

# When first Friday is some day in the middle of the first week
    meetup 2013 12 Week.First DayOfWeek.Friday |> should equal (DateTime(2013, 12, 6))

# When first Saturday is some day in the middle of the first week
    meetup 2013 1 Week.First DayOfWeek.Saturday |> should equal (DateTime(2013, 1, 5))

# When first Saturday is another day in the middle of the first week
    meetup 2013 2 Week.First DayOfWeek.Saturday |> should equal (DateTime(2013, 2, 2))

# When first Sunday is some day in the middle of the first week
    meetup 2013 3 Week.First DayOfWeek.Sunday |> should equal (DateTime(2013, 3, 3))

# When first Sunday is the 7th, the last day of the first week
    meetup 2013 4 Week.First DayOfWeek.Sunday |> should equal (DateTime(2013, 4, 7))

# When second Monday is some day in the middle of the second week
    meetup 2013 3 Week.Second DayOfWeek.Monday |> should equal (DateTime(2013, 3, 11))

# When second Monday is the 8th, the first day of the second week
    meetup 2013 4 Week.Second DayOfWeek.Monday |> should equal (DateTime(2013, 4, 8))

# When second Tuesday is the 14th, the last day of the second week
    meetup 2013 5 Week.Second DayOfWeek.Tuesday |> should equal (DateTime(2013, 5, 14))

# When second Tuesday is some day in the middle of the second week
    meetup 2013 6 Week.Second DayOfWeek.Tuesday |> should equal (DateTime(2013, 6, 11))

# When second Wednesday is some day in the middle of the second week
    meetup 2013 7 Week.Second DayOfWeek.Wednesday |> should equal (DateTime(2013, 7, 10))

# When second Wednesday is the 14th, the last day of the second week
    meetup 2013 8 Week.Second DayOfWeek.Wednesday |> should equal (DateTime(2013, 8, 14))

# When second Thursday is some day in the middle of the second week
    meetup 2013 9 Week.Second DayOfWeek.Thursday |> should equal (DateTime(2013, 9, 12))

# When second Thursday is another day in the middle of the second week
    meetup 2013 10 Week.Second DayOfWeek.Thursday |> should equal (DateTime(2013, 10, 10))

# When second Friday is the 8th, the first day of the second week
    meetup 2013 11 Week.Second DayOfWeek.Friday |> should equal (DateTime(2013, 11, 8))

# When second Friday is some day in the middle of the second week
    meetup 2013 12 Week.Second DayOfWeek.Friday |> should equal (DateTime(2013, 12, 13))

# When second Saturday is some day in the middle of the second week
    meetup 2013 1 Week.Second DayOfWeek.Saturday |> should equal (DateTime(2013, 1, 12))

# When second Saturday is another day in the middle of the second week
    meetup 2013 2 Week.Second DayOfWeek.Saturday |> should equal (DateTime(2013, 2, 9))

# When second Sunday is some day in the middle of the second week
    meetup 2013 3 Week.Second DayOfWeek.Sunday |> should equal (DateTime(2013, 3, 10))

# When second Sunday is the 14th, the last day of the second week
    meetup 2013 4 Week.Second DayOfWeek.Sunday |> should equal (DateTime(2013, 4, 14))

# When third Monday is some day in the middle of the third week
    meetup 2013 3 Week.Third DayOfWeek.Monday |> should equal (DateTime(2013, 3, 18))

# When third Monday is the 15th, the first day of the third week
    meetup 2013 4 Week.Third DayOfWeek.Monday |> should equal (DateTime(2013, 4, 15))

# When third Tuesday is the 21st, the last day of the third week
    meetup 2013 5 Week.Third DayOfWeek.Tuesday |> should equal (DateTime(2013, 5, 21))

# When third Tuesday is some day in the middle of the third week
    meetup 2013 6 Week.Third DayOfWeek.Tuesday |> should equal (DateTime(2013, 6, 18))

# When third Wednesday is some day in the middle of the third week
    meetup 2013 7 Week.Third DayOfWeek.Wednesday |> should equal (DateTime(2013, 7, 17))

# When third Wednesday is the 21st, the last day of the third week
    meetup 2013 8 Week.Third DayOfWeek.Wednesday |> should equal (DateTime(2013, 8, 21))

# When third Thursday is some day in the middle of the third week
    meetup 2013 9 Week.Third DayOfWeek.Thursday |> should equal (DateTime(2013, 9, 19))

# When third Thursday is another day in the middle of the third week
    meetup 2013 10 Week.Third DayOfWeek.Thursday |> should equal (DateTime(2013, 10, 17))

# When third Friday is the 15th, the first day of the third week
    meetup 2013 11 Week.Third DayOfWeek.Friday |> should equal (DateTime(2013, 11, 15))

# When third Friday is some day in the middle of the third week
    meetup 2013 12 Week.Third DayOfWeek.Friday |> should equal (DateTime(2013, 12, 20))

# When third Saturday is some day in the middle of the third week
    meetup 2013 1 Week.Third DayOfWeek.Saturday |> should equal (DateTime(2013, 1, 19))

# When third Saturday is another day in the middle of the third week
    meetup 2013 2 Week.Third DayOfWeek.Saturday |> should equal (DateTime(2013, 2, 16))

# When third Sunday is some day in the middle of the third week
    meetup 2013 3 Week.Third DayOfWeek.Sunday |> should equal (DateTime(2013, 3, 17))

# When third Sunday is the 21st, the last day of the third week
    meetup 2013 4 Week.Third DayOfWeek.Sunday |> should equal (DateTime(2013, 4, 21))

# When fourth Monday is some day in the middle of the fourth week
    meetup 2013 3 Week.Fourth DayOfWeek.Monday |> should equal (DateTime(2013, 3, 25))

# When fourth Monday is the 22nd, the first day of the fourth week
    meetup 2013 4 Week.Fourth DayOfWeek.Monday |> should equal (DateTime(2013, 4, 22))

# When fourth Tuesday is the 28th, the last day of the fourth week
    meetup 2013 5 Week.Fourth DayOfWeek.Tuesday |> should equal (DateTime(2013, 5, 28))

# When fourth Tuesday is some day in the middle of the fourth week
    meetup 2013 6 Week.Fourth DayOfWeek.Tuesday |> should equal (DateTime(2013, 6, 25))

# When fourth Wednesday is some day in the middle of the fourth week
    meetup 2013 7 Week.Fourth DayOfWeek.Wednesday |> should equal (DateTime(2013, 7, 24))

# When fourth Wednesday is the 28th, the last day of the fourth week
    meetup 2013 8 Week.Fourth DayOfWeek.Wednesday |> should equal (DateTime(2013, 8, 28))

# When fourth Thursday is some day in the middle of the fourth week
    meetup 2013 9 Week.Fourth DayOfWeek.Thursday |> should equal (DateTime(2013, 9, 26))

# When fourth Thursday is another day in the middle of the fourth week
    meetup 2013 10 Week.Fourth DayOfWeek.Thursday |> should equal (DateTime(2013, 10, 24))

# When fourth Friday is the 22nd, the first day of the fourth week
    meetup 2013 11 Week.Fourth DayOfWeek.Friday |> should equal (DateTime(2013, 11, 22))

# When fourth Friday is some day in the middle of the fourth week
    meetup 2013 12 Week.Fourth DayOfWeek.Friday |> should equal (DateTime(2013, 12, 27))

# When fourth Saturday is some day in the middle of the fourth week
    meetup 2013 1 Week.Fourth DayOfWeek.Saturday |> should equal (DateTime(2013, 1, 26))

# When fourth Saturday is another day in the middle of the fourth week
    meetup 2013 2 Week.Fourth DayOfWeek.Saturday |> should equal (DateTime(2013, 2, 23))

# When fourth Sunday is some day in the middle of the fourth week
    meetup 2013 3 Week.Fourth DayOfWeek.Sunday |> should equal (DateTime(2013, 3, 24))

# When fourth Sunday is the 28th, the last day of the fourth week
    meetup 2013 4 Week.Fourth DayOfWeek.Sunday |> should equal (DateTime(2013, 4, 28))

# Last Monday in a month with four Mondays
    meetup 2013 3 Week.Last DayOfWeek.Monday |> should equal (DateTime(2013, 3, 25))

# Last Monday in a month with five Mondays
    meetup 2013 4 Week.Last DayOfWeek.Monday |> should equal (DateTime(2013, 4, 29))

# Last Tuesday in a month with four Tuesdays
    meetup 2013 5 Week.Last DayOfWeek.Tuesday |> should equal (DateTime(2013, 5, 28))

# Last Tuesday in another month with four Tuesdays
    meetup 2013 6 Week.Last DayOfWeek.Tuesday |> should equal (DateTime(2013, 6, 25))

# Last Wednesday in a month with five Wednesdays
    meetup 2013 7 Week.Last DayOfWeek.Wednesday |> should equal (DateTime(2013, 7, 31))

# Last Wednesday in a month with four Wednesdays
    meetup 2013 8 Week.Last DayOfWeek.Wednesday |> should equal (DateTime(2013, 8, 28))

# Last Thursday in a month with four Thursdays
    meetup 2013 9 Week.Last DayOfWeek.Thursday |> should equal (DateTime(2013, 9, 26))

# Last Thursday in a month with five Thursdays
    meetup 2013 10 Week.Last DayOfWeek.Thursday |> should equal (DateTime(2013, 10, 31))

# Last Friday in a month with five Fridays
    meetup 2013 11 Week.Last DayOfWeek.Friday |> should equal (DateTime(2013, 11, 29))

# Last Friday in a month with four Fridays
    meetup 2013 12 Week.Last DayOfWeek.Friday |> should equal (DateTime(2013, 12, 27))

# Last Saturday in a month with four Saturdays
    meetup 2013 1 Week.Last DayOfWeek.Saturday |> should equal (DateTime(2013, 1, 26))

# Last Saturday in another month with four Saturdays
    meetup 2013 2 Week.Last DayOfWeek.Saturday |> should equal (DateTime(2013, 2, 23))

# Last Sunday in a month with five Sundays
    meetup 2013 3 Week.Last DayOfWeek.Sunday |> should equal (DateTime(2013, 3, 31))

# Last Sunday in a month with four Sundays
    meetup 2013 4 Week.Last DayOfWeek.Sunday |> should equal (DateTime(2013, 4, 28))

# When last Wednesday in February in a leap year is the 29th
    meetup 2012 2 Week.Last DayOfWeek.Wednesday |> should equal (DateTime(2012, 2, 29))

# Last Wednesday in December that is also the last day of the year
    meetup 2014 12 Week.Last DayOfWeek.Wednesday |> should equal (DateTime(2014, 12, 31))

# When last Sunday in February in a non-leap year is not the 29th
    meetup 2015 2 Week.Last DayOfWeek.Sunday |> should equal (DateTime(2015, 2, 22))

# When first Friday is the 7th, the last day of the first week
    meetup 2012 12 Week.First DayOfWeek.Friday |> should equal (DateTime(2012, 12, 7))

