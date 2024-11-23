~ "minesweeper.ua" ~ Minesweeper

# No rows
    let minefield: string list = []
    let expected: string list = []
⍤⤙≍ expected annotate minefield

# No columns
    let minefield = [""]
    let expected = [""]
⍤⤙≍ expected annotate minefield

# No mines
    let minefield = 
        [ "   ";
          "   ";
          "   " ]
    let expected = 
        [ "   ";
          "   ";
          "   " ]
⍤⤙≍ expected annotate minefield

# Minefield with only mines
    let minefield = 
        [ "***";
          "***";
          "***" ]
    let expected = 
        [ "***";
          "***";
          "***" ]
⍤⤙≍ expected annotate minefield

# Mine surrounded by spaces
    let minefield = 
        [ "   ";
          " * ";
          "   " ]
    let expected = 
        [ "111";
          "1*1";
          "111" ]
⍤⤙≍ expected annotate minefield

# Space surrounded by mines
    let minefield = 
        [ "***";
          "* *";
          "***" ]
    let expected = 
        [ "***";
          "*8*";
          "***" ]
⍤⤙≍ expected annotate minefield

# Horizontal line
    let minefield = [" * * "]
    let expected = ["1*2*1"]
⍤⤙≍ expected annotate minefield

# Horizontal line, mines at edges
    let minefield = ["*   *"]
    let expected = ["*1 1*"]
⍤⤙≍ expected annotate minefield

# Vertical line
    let minefield = 
        [ " ";
          "*";
          " ";
          "*";
          " " ]
    let expected = 
        [ "1";
          "*";
          "2";
          "*";
          "1" ]
⍤⤙≍ expected annotate minefield

# Vertical line, mines at edges
    let minefield = 
        [ "*";
          " ";
          " ";
          " ";
          "*" ]
    let expected = 
        [ "*";
          "1";
          " ";
          "1";
          "*" ]
⍤⤙≍ expected annotate minefield

# Cross
    let minefield = 
        [ "  *  ";
          "  *  ";
          "*****";
          "  *  ";
          "  *  " ]
    let expected = 
        [ " 2*2 ";
          "25*52";
          "*****";
          "25*52";
          " 2*2 " ]
⍤⤙≍ expected annotate minefield

# Large minefield
    let minefield = 
        [ " *  * ";
          "  *   ";
          "    * ";
          "   * *";
          " *  * ";
          "      " ]
    let expected = 
        [ "1*22*1";
          "12*322";
          " 123*2";
          "112*4*";
          "1*22*2";
          "111111" ]
⍤⤙≍ expected annotate minefield

