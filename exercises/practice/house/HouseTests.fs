source("./house.R")
library(testthat)

let ``Verse one - the house that jack built`` () =
    expected <- ["This is the house that Jack built."]
    recite 1 1 |> should equal expected

let ``Verse two - the malt that lay`` () =
    expected <- ["This is the malt that lay in the house that Jack built."]
    recite 2 2 |> should equal expected

let ``Verse three - the rat that ate`` () =
    expected <- ["This is the rat that ate the malt that lay in the house that Jack built."]
    recite 3 3 |> should equal expected

let ``Verse four - the cat that killed`` () =
    expected <- ["This is the cat that killed the rat that ate the malt that lay in the house that Jack built."]
    recite 4 4 |> should equal expected

let ``Verse five - the dog that worried`` () =
    expected <- ["This is the dog that worried the cat that killed the rat that ate the malt that lay in the house that Jack built."]
    recite 5 5 |> should equal expected

let ``Verse six - the cow with the crumpled horn`` () =
    expected <- ["This is the cow with the crumpled horn that tossed the dog that worried the cat that killed the rat that ate the malt that lay in the house that Jack built."]
    recite 6 6 |> should equal expected

let ``Verse seven - the maiden all forlorn`` () =
    expected <- ["This is the maiden all forlorn that milked the cow with the crumpled horn that tossed the dog that worried the cat that killed the rat that ate the malt that lay in the house that Jack built."]
    recite 7 7 |> should equal expected

let ``Verse eight - the man all tattered and torn`` () =
    expected <- ["This is the man all tattered and torn that kissed the maiden all forlorn that milked the cow with the crumpled horn that tossed the dog that worried the cat that killed the rat that ate the malt that lay in the house that Jack built."]
    recite 8 8 |> should equal expected

let ``Verse nine - the priest all shaven and shorn`` () =
    expected <- ["This is the priest all shaven and shorn that married the man all tattered and torn that kissed the maiden all forlorn that milked the cow with the crumpled horn that tossed the dog that worried the cat that killed the rat that ate the malt that lay in the house that Jack built."]
    recite 9 9 |> should equal expected

let ``Verse 10 - the rooster that crowed in the morn`` () =
    expected <- ["This is the rooster that crowed in the morn that woke the priest all shaven and shorn that married the man all tattered and torn that kissed the maiden all forlorn that milked the cow with the crumpled horn that tossed the dog that worried the cat that killed the rat that ate the malt that lay in the house that Jack built."]
    recite 10 10 |> should equal expected

let ``Verse 11 - the farmer sowing his corn`` () =
    expected <- ["This is the farmer sowing his corn that kept the rooster that crowed in the morn that woke the priest all shaven and shorn that married the man all tattered and torn that kissed the maiden all forlorn that milked the cow with the crumpled horn that tossed the dog that worried the cat that killed the rat that ate the malt that lay in the house that Jack built."]
    recite 11 11 |> should equal expected

let ``Verse 12 - the horse and the hound and the horn`` () =
    expected <- ["This is the horse and the hound and the horn that belonged to the farmer sowing his corn that kept the rooster that crowed in the morn that woke the priest all shaven and shorn that married the man all tattered and torn that kissed the maiden all forlorn that milked the cow with the crumpled horn that tossed the dog that worried the cat that killed the rat that ate the malt that lay in the house that Jack built."]
    recite 12 12 |> should equal expected

let ``Multiple verses`` () =
    expected <- 
        [ "This is the cat that killed the rat that ate the malt that lay in the house that Jack built.";
          "This is the dog that worried the cat that killed the rat that ate the malt that lay in the house that Jack built.";
          "This is the cow with the crumpled horn that tossed the dog that worried the cat that killed the rat that ate the malt that lay in the house that Jack built.";
          "This is the maiden all forlorn that milked the cow with the crumpled horn that tossed the dog that worried the cat that killed the rat that ate the malt that lay in the house that Jack built.";
          "This is the man all tattered and torn that kissed the maiden all forlorn that milked the cow with the crumpled horn that tossed the dog that worried the cat that killed the rat that ate the malt that lay in the house that Jack built." ]
    recite 4 8 |> should equal expected

let ``Full rhyme`` () =
    expected <- 
        [ "This is the house that Jack built.";
          "This is the malt that lay in the house that Jack built.";
          "This is the rat that ate the malt that lay in the house that Jack built.";
          "This is the cat that killed the rat that ate the malt that lay in the house that Jack built.";
          "This is the dog that worried the cat that killed the rat that ate the malt that lay in the house that Jack built.";
          "This is the cow with the crumpled horn that tossed the dog that worried the cat that killed the rat that ate the malt that lay in the house that Jack built.";
          "This is the maiden all forlorn that milked the cow with the crumpled horn that tossed the dog that worried the cat that killed the rat that ate the malt that lay in the house that Jack built.";
          "This is the man all tattered and torn that kissed the maiden all forlorn that milked the cow with the crumpled horn that tossed the dog that worried the cat that killed the rat that ate the malt that lay in the house that Jack built.";
          "This is the priest all shaven and shorn that married the man all tattered and torn that kissed the maiden all forlorn that milked the cow with the crumpled horn that tossed the dog that worried the cat that killed the rat that ate the malt that lay in the house that Jack built.";
          "This is the rooster that crowed in the morn that woke the priest all shaven and shorn that married the man all tattered and torn that kissed the maiden all forlorn that milked the cow with the crumpled horn that tossed the dog that worried the cat that killed the rat that ate the malt that lay in the house that Jack built.";
          "This is the farmer sowing his corn that kept the rooster that crowed in the morn that woke the priest all shaven and shorn that married the man all tattered and torn that kissed the maiden all forlorn that milked the cow with the crumpled horn that tossed the dog that worried the cat that killed the rat that ate the malt that lay in the house that Jack built.";
          "This is the horse and the hound and the horn that belonged to the farmer sowing his corn that kept the rooster that crowed in the morn that woke the priest all shaven and shorn that married the man all tattered and torn that kissed the maiden all forlorn that milked the cow with the crumpled horn that tossed the dog that worried the cat that killed the rat that ate the malt that lay in the house that Jack built." ]
    recite 1 12 |> should equal expected

