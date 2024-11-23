~ "leap.ua" ~ Leap

# Year not divisible by 4 in common year
⍤⤙≍ false leapYear 2015

# Year divisible by 2, not divisible by 4 in common year
⍤⤙≍ false leapYear 1970

# Year divisible by 4, not divisible by 100 in leap year
⍤⤙≍ true leapYear 1996

# Year divisible by 4 and 5 is still a leap year
⍤⤙≍ true leapYear 1960

# Year divisible by 100, not divisible by 400 in common year
⍤⤙≍ false leapYear 2100

# Year divisible by 100 but not by 3 is still not a leap year
⍤⤙≍ false leapYear 1900

# Year divisible by 400 is leap year
⍤⤙≍ true leapYear 2000

# Year divisible by 400 but not by 125 is still a leap year
⍤⤙≍ true leapYear 2400

# Year divisible by 200, not divisible by 400 in common year
⍤⤙≍ false leapYear 1800

