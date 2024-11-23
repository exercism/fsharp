~ "word-search.ua" ~ WordSearch

# Should accept an initial game grid and a target search word
grid = ["jefblpepre"]
wordsToSearchFor = ["clojure"]
expected = [("clojure", Option<((int * int) * (int * int))>.None)] |> Map.ofList
⍤⤙≍ expected search grid wordsToSearchFor

# Should locate one word written left to right
grid = ["clojurermt"]
wordsToSearchFor = ["clojure"]
expected = [("clojure", ((1, 1), (7, 1)))] |> Map.ofList
⍤⤙≍ expected search grid wordsToSearchFor

# Should locate the same word written left to right in a different position
grid = ["mtclojurer"]
wordsToSearchFor = ["clojure"]
expected = [("clojure", ((3, 1), (9, 1)))] |> Map.ofList
⍤⤙≍ expected search grid wordsToSearchFor

# Should locate a different left to right word
grid = ["coffeelplx"]
wordsToSearchFor = ["coffee"]
expected = [("coffee", ((1, 1), (6, 1)))] |> Map.ofList
⍤⤙≍ expected search grid wordsToSearchFor

# Should locate that different left to right word in a different position
grid = ["xcoffeezlp"]
wordsToSearchFor = ["coffee"]
expected = [("coffee", ((2, 1), (7, 1)))] |> Map.ofList
⍤⤙≍ expected search grid wordsToSearchFor

# Should locate a left to right word in two line grid
grid = 
        [ "jefblpepre";
          "tclojurerm" ]
wordsToSearchFor = ["clojure"]
expected = [("clojure", ((2, 2), (8, 2)))] |> Map.ofList
⍤⤙≍ expected search grid wordsToSearchFor

# Should locate a left to right word in three line grid
grid = 
        [ "camdcimgtc";
          "jefblpepre";
          "clojurermt" ]
wordsToSearchFor = ["clojure"]
expected = [("clojure", ((1, 3), (7, 3)))] |> Map.ofList
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
expected = [("clojure", ((1, 10), (7, 10)))] |> Map.ofList
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
expected = [("clojure", ((1, 9), (7, 9)))] |> Map.ofList
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
expected = [("fortran", ((1, 7), (7, 7)))] |> Map.ofList
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
        [ ("clojure", ((1, 10), (7, 10)));
          ("fortran", ((1, 7), (7, 7))) ]
        |> Map.ofList
⍤⤙≍ expected search grid wordsToSearchFor

# Should locate a single word written right to left
grid = ["rixilelhrs"]
wordsToSearchFor = ["elixir"]
expected = [("elixir", ((6, 1), (1, 1)))] |> Map.ofList
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
        [ ("clojure", ((1, 10), (7, 10)));
          ("elixir", ((6, 5), (1, 5))) ]
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
        [ ("clojure", ((1, 10), (7, 10)));
          ("elixir", ((6, 5), (1, 5)));
          ("ecmascript", ((10, 1), (10, 10))) ]
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
        [ ("clojure", ((1, 10), (7, 10)));
          ("elixir", ((6, 5), (1, 5)));
          ("ecmascript", ((10, 1), (10, 10)));
          ("rust", ((9, 5), (9, 2))) ]
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
        [ ("clojure", ((1, 10), (7, 10)));
          ("elixir", ((6, 5), (1, 5)));
          ("ecmascript", ((10, 1), (10, 10)));
          ("rust", ((9, 5), (9, 2)));
          ("java", ((1, 1), (4, 4))) ]
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
        [ ("clojure", ((1, 10), (7, 10)));
          ("elixir", ((6, 5), (1, 5)));
          ("ecmascript", ((10, 1), (10, 10)));
          ("rust", ((9, 5), (9, 2)));
          ("java", ((1, 1), (4, 4)));
          ("lua", ((8, 9), (6, 7))) ]
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
        [ ("clojure", ((1, 10), (7, 10)));
          ("elixir", ((6, 5), (1, 5)));
          ("ecmascript", ((10, 1), (10, 10)));
          ("rust", ((9, 5), (9, 2)));
          ("java", ((1, 1), (4, 4)));
          ("lua", ((8, 9), (6, 7)));
          ("lisp", ((3, 6), (6, 3))) ]
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
        [ ("clojure", ((1, 10), (7, 10)));
          ("elixir", ((6, 5), (1, 5)));
          ("ecmascript", ((10, 1), (10, 10)));
          ("rust", ((9, 5), (9, 2)));
          ("java", ((1, 1), (4, 4)));
          ("lua", ((8, 9), (6, 7)));
          ("lisp", ((3, 6), (6, 3)));
          ("ruby", ((8, 6), (5, 9))) ]
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
        [ ("clojure", ((1, 10), (7, 10)));
          ("elixir", ((6, 5), (1, 5)));
          ("ecmascript", ((10, 1), (10, 10)));
          ("rust", ((9, 5), (9, 2)));
          ("java", ((1, 1), (4, 4)));
          ("lua", ((8, 9), (6, 7)));
          ("lisp", ((3, 6), (6, 3)));
          ("ruby", ((8, 6), (5, 9)));
          ("haskell", Option<((int * int) * (int * int))>.None) ]
        |> Map.ofList
⍤⤙≍ expected search grid wordsToSearchFor

# Should fail to locate words that are not on horizontal, vertical, or diagonal lines
grid = 
        [ "abc";
          "def" ]
wordsToSearchFor = ["aef" "ced" "abf" "cbd"]
expected = 
        [ ("aef", Option<((int * int) * (int * int))>.None);
          ("ced", Option<((int * int) * (int * int))>.None);
          ("abf", Option<((int * int) * (int * int))>.None);
          ("cbd", Option<((int * int) * (int * int))>.None) ]
        |> Map.ofList
⍤⤙≍ expected search grid wordsToSearchFor

# Should not concatenate different lines to find a horizontal word
grid = 
        [ "abceli";
          "xirdfg" ]
wordsToSearchFor = ["elixir"]
expected = [("elixir", Option<((int * int) * (int * int))>.None)] |> Map.ofList
⍤⤙≍ expected search grid wordsToSearchFor

# Should not wrap around horizontally to find a word
grid = ["silabcdefp"]
wordsToSearchFor = ["lisp"]
expected = [("lisp", Option<((int * int) * (int * int))>.None)] |> Map.ofList
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
expected = [("rust", Option<((int * int) * (int * int))>.None)] |> Map.ofList
⍤⤙≍ expected search grid wordsToSearchFor

