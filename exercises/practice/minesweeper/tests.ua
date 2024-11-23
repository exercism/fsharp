~ "minesweeper.ua" ~ Minesweeper

# No rows
minefield: string list = []
expected: string list = []
⍤⤙≍ expected annotate minefield

# No columns
minefield = [""]
expected = [""]
⍤⤙≍ expected annotate minefield

# No mines
minefield = 
        [ "   ";
          "   ";
          "   " ]
expected = 
        [ "   ";
          "   ";
          "   " ]
⍤⤙≍ expected annotate minefield

# Minefield with only mines
minefield = 
        [ "***";
          "***";
          "***" ]
expected = 
        [ "***";
          "***";
          "***" ]
⍤⤙≍ expected annotate minefield

# Mine surrounded by spaces
minefield = 
        [ "   ";
          " * ";
          "   " ]
expected = 
        [ "111";
          "1*1";
          "111" ]
⍤⤙≍ expected annotate minefield

# Space surrounded by mines
minefield = 
        [ "***";
          "* *";
          "***" ]
expected = 
        [ "***";
          "*8*";
          "***" ]
⍤⤙≍ expected annotate minefield

# Horizontal line
minefield = [" * * "]
expected = ["1*2*1"]
⍤⤙≍ expected annotate minefield

# Horizontal line, mines at edges
minefield = ["*   *"]
expected = ["*1 1*"]
⍤⤙≍ expected annotate minefield

# Vertical line
minefield = 
        [ " ";
          "*";
          " ";
          "*";
          " " ]
expected = 
        [ "1";
          "*";
          "2";
          "*";
          "1" ]
⍤⤙≍ expected annotate minefield

# Vertical line, mines at edges
minefield = 
        [ "*";
          " ";
          " ";
          " ";
          "*" ]
expected = 
        [ "*";
          "1";
          " ";
          "1";
          "*" ]
⍤⤙≍ expected annotate minefield

# Cross
minefield = 
        [ "  *  ";
          "  *  ";
          "*****";
          "  *  ";
          "  *  " ]
expected = 
        [ " 2*2 ";
          "25*52";
          "*****";
          "25*52";
          " 2*2 " ]
⍤⤙≍ expected annotate minefield

# Large minefield
minefield = 
        [ " *  * ";
          "  *   ";
          "    * ";
          "   * *";
          " *  * ";
          "      " ]
expected = 
        [ "1*22*1";
          "12*322";
          " 123*2";
          "112*4*";
          "1*22*2";
          "111111" ]
⍤⤙≍ expected annotate minefield

