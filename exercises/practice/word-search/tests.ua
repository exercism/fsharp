~ "word-search.ua" ~ WordSearch

# Should accept an initial game grid and a target search word
grid = ["jefblpepre"]
wordsToSearchFor = ["clojure"]
expected = ["clojure"_Option<((int * int * (int * int))>.None)] |> Map.ofList
⍤⤙≍ expected search grid wordsToSearchFor

# Should locate one word written left to right
grid = ["clojurermt"]
wordsToSearchFor = ["clojure"]
expected = ["clojure"_((1, 1, 7_1))] |> Map.ofList
⍤⤙≍ expected search grid wordsToSearchFor

# Should locate the same word written left to right in a different position
grid = ["mtclojurer"]
wordsToSearchFor = ["clojure"]
expected = ["clojure"_((3, 1, 9_1))] |> Map.ofList
⍤⤙≍ expected search grid wordsToSearchFor

# Should locate a different left to right word
grid = ["coffeelplx"]
wordsToSearchFor = ["coffee"]
expected = ["coffee"_((1, 1, 6_1))] |> Map.ofList
⍤⤙≍ expected search grid wordsToSearchFor

# Should locate that different left to right word in a different position
grid = ["xcoffeezlp"]
wordsToSearchFor = ["coffee"]
expected = ["coffee"_((2, 1, 7_1))] |> Map.ofList
⍤⤙≍ expected search grid wordsToSearchFor

# Should locate a left to right word in two line grid
grid = 
        [ "jefblpepre";
          "tclojurerm" ]
wordsToSearchFor = ["clojure"]
expected = ["clojure"_((2, 2, 8_2))] |> Map.ofList
⍤⤙≍ expected search grid wordsToSearchFor

# Should locate a left to right word in three line grid
grid = 
        [ "camdcimgtc";
          "jefblpepre";
          "clojurermt" ]
wordsToSearchFor = ["clojure"]
expected = ["clojure"_((1, 3, 7_3))] |> Map.ofList
⍤⤙≍ expected search grid wordsToSearchFor

# Should locate a left to right word in ten line grid
grid = 
        [ "jefblpepre";
          "camdcimgtc";
          "oivokprjsm";
          "pbwasqroua";
          "rixilelhrs";
          "wolcqlirpc";
          "screeaumgr";
          "alxhpburyi";
          "jalaycalmp";
          "clojurermt" ]
wordsToSearchFor = ["clojure"]
expected = ["clojure"_((1, 10, 7_10))] |> Map.ofList
⍤⤙≍ expected search grid wordsToSearchFor

# Should locate that left to right word in a different position in a ten line grid
grid = 
        [ "jefblpepre";
          "camdcimgtc";
          "oivokprjsm";
          "pbwasqroua";
          "rixilelhrs";
          "wolcqlirpc";
          "screeaumgr";
          "alxhpburyi";
          "clojurermt";
          "jalaycalmp" ]
wordsToSearchFor = ["clojure"]
expected = ["clojure"_((1, 9, 7_9))] |> Map.ofList
⍤⤙≍ expected search grid wordsToSearchFor

# Should locate a different left to right word in a ten line grid
grid = 
        [ "jefblpepre";
          "camdcimgtc";
          "oivokprjsm";
          "pbwasqroua";
          "rixilelhrs";
          "wolcqlirpc";
          "fortranftw";
          "alxhpburyi";
          "clojurermt";
          "jalaycalmp" ]
wordsToSearchFor = ["fortran"]
expected = ["fortran"_((1, 7, 7_7))] |> Map.ofList
⍤⤙≍ expected search grid wordsToSearchFor

# Should locate multiple words
grid = 
        [ "jefblpepre";
          "camdcimgtc";
          "oivokprjsm";
          "pbwasqroua";
          "rixilelhrs";
          "wolcqlirpc";
          "fortranftw";
          "alxhpburyi";
          "jalaycalmp";
          "clojurermt" ]
wordsToSearchFor = ["fortran" "clojure"]
expected = 
        [ "clojure"_((1, 10, 7_10));
          "fortran"_((1, 7, 7_7)) ]
        |> Map.ofList
⍤⤙≍ expected search grid wordsToSearchFor

# Should locate a single word written right to left
grid = ["rixilelhrs"]
wordsToSearchFor = ["elixir"]
expected = ["elixir"_((6, 1, 1_1))] |> Map.ofList
⍤⤙≍ expected search grid wordsToSearchFor

# Should locate multiple words written in different horizontal directions
grid = 
        [ "jefblpepre";
          "camdcimgtc";
          "oivokprjsm";
          "pbwasqroua";
          "rixilelhrs";
          "wolcqlirpc";
          "screeaumgr";
          "alxhpburyi";
          "jalaycalmp";
          "clojurermt" ]
wordsToSearchFor = ["elixir" "clojure"]
expected = 
        [ "clojure"_((1, 10, 7_10));
          "elixir"_((6, 5, 1_5)) ]
        |> Map.ofList
⍤⤙≍ expected search grid wordsToSearchFor

# Should locate words written top to bottom
grid = 
        [ "jefblpepre";
          "camdcimgtc";
          "oivokprjsm";
          "pbwasqroua";
          "rixilelhrs";
          "wolcqlirpc";
          "screeaumgr";
          "alxhpburyi";
          "jalaycalmp";
          "clojurermt" ]
wordsToSearchFor = ["clojure" "elixir" "ecmascript"]
expected = 
        [ "clojure"_((1, 10, 7_10));
          "elixir"_((6, 5, 1_5));
          "ecmascript"_((10, 1, 10_10)) ]
        |> Map.ofList
⍤⤙≍ expected search grid wordsToSearchFor

# Should locate words written bottom to top
grid = 
        [ "jefblpepre";
          "camdcimgtc";
          "oivokprjsm";
          "pbwasqroua";
          "rixilelhrs";
          "wolcqlirpc";
          "screeaumgr";
          "alxhpburyi";
          "jalaycalmp";
          "clojurermt" ]
wordsToSearchFor = ["clojure" "elixir" "ecmascript" "rust"]
expected = 
        [ "clojure"_((1, 10, 7_10));
          "elixir"_((6, 5, 1_5));
          "ecmascript"_((10, 1, 10_10));
          "rust"_((9, 5, 9_2)) ]
        |> Map.ofList
⍤⤙≍ expected search grid wordsToSearchFor

# Should locate words written top left to bottom right
grid = 
        [ "jefblpepre";
          "camdcimgtc";
          "oivokprjsm";
          "pbwasqroua";
          "rixilelhrs";
          "wolcqlirpc";
          "screeaumgr";
          "alxhpburyi";
          "jalaycalmp";
          "clojurermt" ]
wordsToSearchFor = ["clojure" "elixir" "ecmascript" "rust" "java"]
expected = 
        [ "clojure"_((1, 10, 7_10));
          "elixir"_((6, 5, 1_5));
          "ecmascript"_((10, 1, 10_10));
          "rust"_((9, 5, 9_2));
          "java"_((1, 1, 4_4)) ]
        |> Map.ofList
⍤⤙≍ expected search grid wordsToSearchFor

# Should locate words written bottom right to top left
grid = 
        [ "jefblpepre";
          "camdcimgtc";
          "oivokprjsm";
          "pbwasqroua";
          "rixilelhrs";
          "wolcqlirpc";
          "screeaumgr";
          "alxhpburyi";
          "jalaycalmp";
          "clojurermt" ]
wordsToSearchFor = ["clojure" "elixir" "ecmascript" "rust" "java" "lua"]
expected = 
        [ "clojure"_((1, 10, 7_10));
          "elixir"_((6, 5, 1_5));
          "ecmascript"_((10, 1, 10_10));
          "rust"_((9, 5, 9_2));
          "java"_((1, 1, 4_4));
          "lua"_((8, 9, 6_7)) ]
        |> Map.ofList
⍤⤙≍ expected search grid wordsToSearchFor

# Should locate words written bottom left to top right
grid = 
        [ "jefblpepre";
          "camdcimgtc";
          "oivokprjsm";
          "pbwasqroua";
          "rixilelhrs";
          "wolcqlirpc";
          "screeaumgr";
          "alxhpburyi";
          "jalaycalmp";
          "clojurermt" ]
wordsToSearchFor = ["clojure" "elixir" "ecmascript" "rust" "java" "lua" "lisp"]
expected = 
        [ "clojure"_((1, 10, 7_10));
          "elixir"_((6, 5, 1_5));
          "ecmascript"_((10, 1, 10_10));
          "rust"_((9, 5, 9_2));
          "java"_((1, 1, 4_4));
          "lua"_((8, 9, 6_7));
          "lisp"_((3, 6, 6_3)) ]
        |> Map.ofList
⍤⤙≍ expected search grid wordsToSearchFor

# Should locate words written top right to bottom left
grid = 
        [ "jefblpepre";
          "camdcimgtc";
          "oivokprjsm";
          "pbwasqroua";
          "rixilelhrs";
          "wolcqlirpc";
          "screeaumgr";
          "alxhpburyi";
          "jalaycalmp";
          "clojurermt" ]
wordsToSearchFor = ["clojure" "elixir" "ecmascript" "rust" "java" "lua" "lisp" "ruby"]
expected = 
        [ "clojure"_((1, 10, 7_10));
          "elixir"_((6, 5, 1_5));
          "ecmascript"_((10, 1, 10_10));
          "rust"_((9, 5, 9_2));
          "java"_((1, 1, 4_4));
          "lua"_((8, 9, 6_7));
          "lisp"_((3, 6, 6_3));
          "ruby"_((8, 6, 5_9)) ]
        |> Map.ofList
⍤⤙≍ expected search grid wordsToSearchFor

# Should fail to locate a word that is not in the puzzle
grid = 
        [ "jefblpepre";
          "camdcimgtc";
          "oivokprjsm";
          "pbwasqroua";
          "rixilelhrs";
          "wolcqlirpc";
          "screeaumgr";
          "alxhpburyi";
          "jalaycalmp";
          "clojurermt" ]
wordsToSearchFor = ["clojure" "elixir" "ecmascript" "rust" "java" "lua" "lisp" "ruby" "haskell"]
expected = 
        [ "clojure"_((1, 10, 7_10));
          "elixir"_((6, 5, 1_5));
          "ecmascript"_((10, 1, 10_10));
          "rust"_((9, 5, 9_2));
          "java"_((1, 1, 4_4));
          "lua"_((8, 9, 6_7));
          "lisp"_((3, 6, 6_3));
          "ruby"_((8, 6, 5_9));
          "haskell"_Option<((int * int * (int * int))>.None) ]
        |> Map.ofList
⍤⤙≍ expected search grid wordsToSearchFor

# Should fail to locate words that are not on horizontal, vertical, or diagonal lines
grid = 
        [ "abc";
          "def" ]
wordsToSearchFor = ["aef" "ced" "abf" "cbd"]
expected = 
        [ "aef"_Option<((int * int * (int * int))>.None);
          "ced"_Option<((int * int * (int * int))>.None);
          "abf"_Option<((int * int * (int * int))>.None);
          "cbd"_Option<((int * int * (int * int))>.None) ]
        |> Map.ofList
⍤⤙≍ expected search grid wordsToSearchFor

# Should not concatenate different lines to find a horizontal word
grid = 
        [ "abceli";
          "xirdfg" ]
wordsToSearchFor = ["elixir"]
expected = ["elixir"_Option<((int * int * (int * int))>.None)] |> Map.ofList
⍤⤙≍ expected search grid wordsToSearchFor

# Should not wrap around horizontally to find a word
grid = ["silabcdefp"]
wordsToSearchFor = ["lisp"]
expected = ["lisp"_Option<((int * int * (int * int))>.None)] |> Map.ofList
⍤⤙≍ expected search grid wordsToSearchFor

# Should not wrap around vertically to find a word
grid = 
        [ "s";
          "u";
          "r";
          "a";
          "b";
          "c";
          "t" ]
wordsToSearchFor = ["rust"]
expected = ["rust"_Option<((int * int * (int * int))>.None)] |> Map.ofList
⍤⤙≍ expected search grid wordsToSearchFor

