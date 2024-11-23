~ "go-counting.ua" ~ GoCounting

# Black corner territory on 5x5 board
board = 
        [ "  B  ";
          " B B ";
          "B W B";
          " W W ";
          "  W  " ]
position = 0_1
expected = Option.Some Owner.Black_[(0, 0 0_1 1_0])
⍤⤙≍ expected territory board position

# White center territory on 5x5 board
board = 
        [ "  B  ";
          " B B ";
          "B W B";
          " W W ";
          "  W  " ]
position = 2_3
expected = Option.Some Owner.White_[(2, 3])
⍤⤙≍ expected territory board position

#board = 
        [ "  B  ";
          " B B ";
          "B W B";
          " W W ";
          "  W  " ]
position = 1_4
expected = Option.Some Owner.None_[(0, 3 0_4 1_4])
⍤⤙≍ expected territory board position

# A stone and not a territory on 5x5 board
board = 
        [ "  B  ";
          " B B ";
          "B W B";
          " W W ";
          "  W  " ]
position = 1_1
expected: Owner * (int * int) list) option = Option.Some (Owner.None_[]
⍤⤙≍ expected territory board position

# Invalid because X is too low for 5x5 board
board = 
        [ "  B  ";
          " B B ";
          "B W B";
          " W W ";
          "  W  " ]
position = -1_1
expected = Option.None
⍤⤙≍ expected territory board position

# Invalid because X is too high for 5x5 board
board = 
        [ "  B  ";
          " B B ";
          "B W B";
          " W W ";
          "  W  " ]
position = 5_1
expected = Option.None
⍤⤙≍ expected territory board position

# Invalid because Y is too low for 5x5 board
board = 
        [ "  B  ";
          " B B ";
          "B W B";
          " W W ";
          "  W  " ]
position = 1_-1
expected = Option.None
⍤⤙≍ expected territory board position

# Invalid because Y is too high for 5x5 board
board = 
        [ "  B  ";
          " B B ";
          "B W B";
          " W W ";
          "  W  " ]
position = 1_5
expected = Option.None
⍤⤙≍ expected territory board position

# One territory is the whole board
board = [" "]
expected = 
        [ Owner.Black_[];
          Owner.White_[];
          Owner.None_[(0, 0]) ]
        |> Map.ofList
⍤⤙≍ expected territories board

# Two territory rectangular board
board = 
        [ " BW ";
          " BW " ]
expected = 
        [ Owner.Black_[(0, 0 0_1]);
          Owner.White_[(3, 0 3_1]);
          Owner.None_[] ]
        |> Map.ofList
⍤⤙≍ expected territories board

# Two region rectangular board
board = [" B "]
expected = 
        [ Owner.Black_[(0, 0 2_0]);
          Owner.White_[];
          Owner.None_[] ]
        |> Map.ofList
⍤⤙≍ expected territories board

