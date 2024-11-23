~ "gigasecond.ua" ~ Gigasecond

# Date only specification of time
⍤⤙≍ (DateTime(2043, 1, 1, 1, 46, 40)) add (DateTime(2011, 4, 25))

# Second test for date only specification of time
⍤⤙≍ (DateTime(2009, 2, 19, 1, 46, 40)) add (DateTime(1977, 6, 13))

# Third test for date only specification of time
⍤⤙≍ (DateTime(1991, 3, 27, 1, 46, 40)) add (DateTime(1959, 7, 19))

# Full time specified
⍤⤙≍ (DateTime(2046, 10, 2, 23, 46, 40)) add (DateTime(2015, 1, 24, 22, 0, 0))

# Full time with day roll-over
⍤⤙≍ (DateTime(2046, 10, 3, 1, 46, 39)) add (DateTime(2015, 1, 24, 23, 59, 59))

