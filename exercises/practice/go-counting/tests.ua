~ "go-counting.ua" ~ GoCounting

# Black corner territory on 5x5 board
board = 
        [ "  B  ";
          " B B ";
          "B W B";
          " W W ";
          "  W  " ]
position = (0, 1)
expected = Option.Some (Owner.Black, [(0, 0) (0, 1) (1, 0)])
⍤⤙≍ expected territory board position

# White center territory on 5x5 board
board = 
        [ "  B  ";
          " B B ";
          "B W B";
          " W W ";
          "  W  " ]
position = (2, 3)
expected = Option.Some (Owner.White, [(2, 3)])
⍤⤙≍ expected territory board position

#board = 
        [ "  B  ";
          " B B ";
          "B W B";
          " W W ";
          "  W  " ]
position = (1, 4)
expected = Option.Some (Owner.None, [(0, 3) (0, 4) (1, 4)])
⍤⤙≍ expected territory board position

# A stone and not a territory on 5x5 board
board = 
        [ "  B  ";
          " B B ";
          "B W B";
          " W W ";
          "  W  " ]
position = (1, 1)
expected: (Owner * (int * int) list) option = Option.Some (Owner.None, [])
⍤⤙≍ expected territory board position

# Invalid because X is too low for 5x5 board
board = 
        [ "  B  ";
          " B B ";
          "B W B";
          " W W ";
          "  W  " ]
position = (-1, 1)
expected = Option.None
⍤⤙≍ expected territory board position

# Invalid because X is too high for 5x5 board
board = 
        [ "  B  ";
          " B B ";
          "B W B";
          " W W ";
          "  W  " ]
position = (5, 1)
expected = Option.None
⍤⤙≍ expected territory board position

# Invalid because Y is too low for 5x5 board
board = 
        [ "  B  ";
          " B B ";
          "B W B";
          " W W ";
          "  W  " ]
position = (1, -1)
expected = Option.None
⍤⤙≍ expected territory board position

# Invalid because Y is too high for 5x5 board
board = 
        [ "  B  ";
          " B B ";
          "B W B";
          " W W ";
          "  W  " ]
position = (1, 5)
expected = Option.None
⍤⤙≍ expected territory board position

# One territory is the whole board
board = [" "]
expected = 
        [ (Owner.Black, []);
          (Owner.White, []);
          (Owner.None, [(0, 0)]) ]
        |> Map.ofList
⍤⤙≍ expected territories board

# Two territory rectangular board
board = 
        [ " BW ";
          " BW " ]
expected = 
        [ (Owner.Black, [(0, 0) (0, 1)]);
          (Owner.White, [(3, 0) (3, 1)]);
          (Owner.None, []) ]
        |> Map.ofList
⍤⤙≍ expected territories board

# Two region rectangular board
board = [" B "]
expected = 
        [ (Owner.Black, [(0, 0) (2, 0)]);
          (Owner.White, []);
          (Owner.None, []) ]
        |> Map.ofList
⍤⤙≍ expected territories board

