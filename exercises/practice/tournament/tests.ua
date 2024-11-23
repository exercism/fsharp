~ "tournament.ua" ~ Tournament

# Just the header if no input
≡= []
expected ← ["Team                           | MP |  W |  D |  L |  P"]
⍤⤙≍ expected tally ≡

# A win is three points, a loss is zero points
≡= ["Allegoric Alaskans;Blithering Badgers;win"]
expected ←
["Team                           | MP |  W |  D |  L |  P""Allegoric Alaskans             |  1 |  1 |  0 |  0 |  3""Blithering Badgers             |  1 |  0 |  0 |  1 |  0"]
⍤⤙≍ expected tally ≡

# A win can also be expressed as a loss
≡= ["Blithering Badgers;Allegoric Alaskans;loss"]
expected ←
["Team                           | MP |  W |  D |  L |  P""Allegoric Alaskans             |  1 |  1 |  0 |  0 |  3""Blithering Badgers             |  1 |  0 |  0 |  1 |  0"]
⍤⤙≍ expected tally ≡

# A different team can win
≡= ["Blithering Badgers;Allegoric Alaskans;win"]
expected ←
["Team                           | MP |  W |  D |  L |  P""Blithering Badgers             |  1 |  1 |  0 |  0 |  3""Allegoric Alaskans             |  1 |  0 |  0 |  1 |  0"]
⍤⤙≍ expected tally ≡

# A draw is one point each
≡= ["Allegoric Alaskans;Blithering Badgers;draw"]
expected ←
["Team                           | MP |  W |  D |  L |  P""Allegoric Alaskans             |  1 |  0 |  1 |  0 |  1""Blithering Badgers             |  1 |  0 |  1 |  0 |  1"]
⍤⤙≍ expected tally ≡

# There can be more than one match
≡=
["Allegoric Alaskans;Blithering Badgers;win""Allegoric Alaskans;Blithering Badgers;win"]
expected ←
["Team                           | MP |  W |  D |  L |  P""Allegoric Alaskans             |  2 |  2 |  0 |  0 |  6""Blithering Badgers             |  2 |  0 |  0 |  2 |  0"]
⍤⤙≍ expected tally ≡

# There can be more than one winner
≡=
["Allegoric Alaskans;Blithering Badgers;loss""Allegoric Alaskans;Blithering Badgers;win"]
expected ←
["Team                           | MP |  W |  D |  L |  P""Allegoric Alaskans             |  2 |  1 |  0 |  1 |  3""Blithering Badgers             |  2 |  1 |  0 |  1 |  3"]
⍤⤙≍ expected tally ≡

# There can be more than two teams
≡=
["Allegoric Alaskans;Blithering Badgers;win""Blithering Badgers;Courageous Californians;win""Courageous Californians;Allegoric Alaskans;loss"]
expected ←
["Team                           | MP |  W |  D |  L |  P""Allegoric Alaskans             |  2 |  2 |  0 |  0 |  6""Blithering Badgers             |  2 |  1 |  0 |  1 |  3""Courageous Californians        |  2 |  0 |  0 |  2 |  0"]
⍤⤙≍ expected tally ≡

# Typical input
≡=
["Allegoric Alaskans;Blithering Badgers;win""Devastating Donkeys;Courageous Californians;draw""Devastating Donkeys;Allegoric Alaskans;win""Courageous Californians;Blithering Badgers;loss""Blithering Badgers;Devastating Donkeys;loss""Allegoric Alaskans;Courageous Californians;win"]
expected ←
["Team                           | MP |  W |  D |  L |  P""Devastating Donkeys            |  3 |  2 |  1 |  0 |  7""Allegoric Alaskans             |  3 |  2 |  0 |  1 |  6""Blithering Badgers             |  3 |  1 |  0 |  2 |  3""Courageous Californians        |  3 |  0 |  1 |  2 |  1"]
⍤⤙≍ expected tally ≡

# Incomplete competition (not all pairs have played)
≡=
["Allegoric Alaskans;Blithering Badgers;loss""Devastating Donkeys;Allegoric Alaskans;loss""Courageous Californians;Blithering Badgers;draw""Allegoric Alaskans;Courageous Californians;win"]
expected ←
["Team                           | MP |  W |  D |  L |  P""Allegoric Alaskans             |  3 |  2 |  0 |  1 |  6""Blithering Badgers             |  2 |  1 |  1 |  0 |  4""Courageous Californians        |  2 |  0 |  1 |  1 |  1""Devastating Donkeys            |  1 |  0 |  0 |  1 |  0"]
⍤⤙≍ expected tally ≡

# Ties broken alphabetically
≡=
["Courageous Californians;Devastating Donkeys;win""Allegoric Alaskans;Blithering Badgers;win""Devastating Donkeys;Allegoric Alaskans;loss""Courageous Californians;Blithering Badgers;win""Blithering Badgers;Devastating Donkeys;draw""Allegoric Alaskans;Courageous Californians;draw"]
expected ←
["Team                           | MP |  W |  D |  L |  P""Allegoric Alaskans             |  3 |  2 |  1 |  0 |  7""Courageous Californians        |  3 |  2 |  1 |  0 |  7""Blithering Badgers             |  3 |  0 |  1 |  2 |  1""Devastating Donkeys            |  3 |  0 |  1 |  2 |  1"]
⍤⤙≍ expected tally ≡

# Ensure points sorted numerically
≡=
["Devastating Donkeys;Blithering Badgers;win""Devastating Donkeys;Blithering Badgers;win""Devastating Donkeys;Blithering Badgers;win""Devastating Donkeys;Blithering Badgers;win""Blithering Badgers;Devastating Donkeys;win"]
expected ←
["Team                           | MP |  W |  D |  L |  P""Devastating Donkeys            |  5 |  4 |  0 |  1 | 12""Blithering Badgers             |  5 |  1 |  0 |  4 |  3"]
⍤⤙≍ expected tally ≡
