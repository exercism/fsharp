~ "clock.ua" ~ Clock

# On the hour
clock ← create 8 0
⍤⤙≍ "08:00" display clock

# Past the hour
clock ← create 11 9
⍤⤙≍ "11:09" display clock

# Midnight is zero hours
clock ← create 24 0
⍤⤙≍ "00:00" display clock

# Hour rolls over
clock ← create 25 0
⍤⤙≍ "01:00" display clock

# Hour rolls over continuously
clock ← create 100 0
⍤⤙≍ "04:00" display clock

# Sixty minutes is next hour
clock ← create 1 60
⍤⤙≍ "02:00" display clock

# Minutes roll over
clock ← create 0 160
⍤⤙≍ "02:40" display clock

# Minutes roll over continuously
clock ← create 0 1723
⍤⤙≍ "04:43" display clock

# Hour and minutes roll over
clock ← create 25 160
⍤⤙≍ "03:40" display clock

# Hour and minutes roll over continuously
clock ← create 201 3001
⍤⤙≍ "11:01" display clock

# Hour and minutes roll over to exactly midnight
clock ← create 72 8640
⍤⤙≍ "00:00" display clock

# Negative hour
clock ← create -1 15
⍤⤙≍ "23:15" display clock

# Negative hour rolls over
clock ← create -25 0
⍤⤙≍ "23:00" display clock

# Negative hour rolls over continuously
clock ← create -91 0
⍤⤙≍ "05:00" display clock

# Negative minutes
clock ← create 1 -40
⍤⤙≍ "00:20" display clock

# Negative minutes roll over
clock ← create 1 -160
⍤⤙≍ "22:20" display clock

# Negative minutes roll over continuously
clock ← create 1 -4820
⍤⤙≍ "16:40" display clock

# Negative sixty minutes is previous hour
clock ← create 2 -60
⍤⤙≍ "01:00" display clock

# Negative hour and minutes both roll over
clock ← create -25 -160
⍤⤙≍ "20:20" display clock

# Negative hour and minutes both roll over continuously
clock ← create -121 -5810
⍤⤙≍ "22:10" display clock

# Add minutes
clock ← create 10 0
⍤⤙≍ "10:03" + 3 clock
| > display

# Add no minutes
clock ← create 6 41
⍤⤙≍ "06:41" + 0 clock
| > display

# Add to next hour
clock ← create 0 45
⍤⤙≍ "01:25" + 40 clock
| > display

# Add more than one hour
clock ← create 10 0
⍤⤙≍ "11:01" + 61 clock
| > display

# Add more than two hours with carry
clock ← create 0 45
⍤⤙≍ "03:25" + 160 clock
| > display

# Add across midnight
clock ← create 23 59
⍤⤙≍ "00:01" + 2 clock
| > display

# Add more than one day (1500 min = 25 hrs)
clock ← create 5 32
⍤⤙≍ "06:32" + 1500 clock
| > display

# Add more than two days
clock ← create 1 1
⍤⤙≍ "11:21" + 3500 clock
| > display

# Subtract minutes
clock ← create 10 3
⍤⤙≍ "10:00" - 3 clock
| > display

# Subtract to previous hour
clock ← create 10 3
⍤⤙≍ "09:33" - 30 clock
| > display

# Subtract more than an hour
clock ← create 10 3
⍤⤙≍ "08:53" - 70 clock
| > display

# Subtract across midnight
clock ← create 0 3
⍤⤙≍ "23:59" - 4 clock
| > display

# Subtract more than two hours
clock ← create 0 0
⍤⤙≍ "21:20" - 160 clock
| > display

# Subtract more than two hours with borrow
clock ← create 6 15
⍤⤙≍ "03:35" - 160 clock
| > display

# Subtract more than one day (1500 min = 25 hrs)
clock ← create 5 32
⍤⤙≍ "04:32" - 1500 clock
| > display

# Subtract more than two days
clock ← create 2 20
⍤⤙≍ "00:20" - 3000 clock
| > display

# Clocks with same time
clock1 = create 15 37
clock2 = create 15 37
⍤⤙≍ 1 clock1 = clock2

# Clocks a minute apart
clock1 = create 15 36
clock2 = create 15 37
⍤⤙≍ 0 clock1 = clock2

# Clocks an hour apart
clock1 = create 14 37
clock2 = create 15 37
⍤⤙≍ 0 clock1 = clock2

# Clocks with hour overflow
clock1 = create 10 37
clock2 = create 34 37
⍤⤙≍ 1 clock1 = clock2

# Clocks with hour overflow by several days
clock1 = create 3 11
clock2 = create 99 11
⍤⤙≍ 1 clock1 = clock2

# Clocks with negative hour
clock1 = create 22 40
clock2 = create -2 40
⍤⤙≍ 1 clock1 = clock2

# Clocks with negative hour that wraps
clock1 = create 17 3
clock2 = create -31 3
⍤⤙≍ 1 clock1 = clock2

# Clocks with negative hour that wraps multiple times
clock1 = create 13 49
clock2 = create -83 49
⍤⤙≍ 1 clock1 = clock2

# Clocks with minute overflow
clock1 = create 0 1
clock2 = create 0 1441
⍤⤙≍ 1 clock1 = clock2

# Clocks with minute overflow by several days
clock1 = create 2 2
clock2 = create 2 4322
⍤⤙≍ 1 clock1 = clock2

# Clocks with negative minute
clock1 = create 2 40
clock2 = create 3 -20
⍤⤙≍ 1 clock1 = clock2

# Clocks with negative minute that wraps
clock1 = create 4 10
clock2 = create 5 -1490
⍤⤙≍ 1 clock1 = clock2

# Clocks with negative minute that wraps multiple times
clock1 = create 6 15
clock2 = create 6 -4305
⍤⤙≍ 1 clock1 = clock2

# Clocks with negative hours and minutes
clock1 = create 7 32
clock2 = create -12 -268
⍤⤙≍ 1 clock1 = clock2

# Clocks with negative hours and minutes that wrap
clock1 = create 18 7
clock2 = create -54 -11513
⍤⤙≍ 1 clock1 = clock2

# Full clock and zeroed clock
clock1 = create 24 0
clock2 = create 0 0
⍤⤙≍ 1 clock1 = clock2
