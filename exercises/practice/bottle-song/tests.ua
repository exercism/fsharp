~ "bottle-song.ua" ~ BottleSong

# First generic verse
    let expected = 
        [ "Ten green bottles hanging on the wall,";
          "Ten green bottles hanging on the wall,";
          "And if one green bottle should accidentally fall,";
          "There'll be nine green bottles hanging on the wall." ]
⍤⤙≍ expected recite 10 1

# Last generic verse
    let expected = 
        [ "Three green bottles hanging on the wall,";
          "Three green bottles hanging on the wall,";
          "And if one green bottle should accidentally fall,";
          "There'll be two green bottles hanging on the wall." ]
⍤⤙≍ expected recite 3 1

# Verse with 2 bottles
    let expected = 
        [ "Two green bottles hanging on the wall,";
          "Two green bottles hanging on the wall,";
          "And if one green bottle should accidentally fall,";
          "There'll be one green bottle hanging on the wall." ]
⍤⤙≍ expected recite 2 1

# Verse with 1 bottle
    let expected = 
        [ "One green bottle hanging on the wall,";
          "One green bottle hanging on the wall,";
          "And if one green bottle should accidentally fall,";
          "There'll be no green bottles hanging on the wall." ]
⍤⤙≍ expected recite 1 1

# First two verses
    let expected = 
        [ "Ten green bottles hanging on the wall,";
          "Ten green bottles hanging on the wall,";
          "And if one green bottle should accidentally fall,";
          "There'll be nine green bottles hanging on the wall.";
          "";
          "Nine green bottles hanging on the wall,";
          "Nine green bottles hanging on the wall,";
          "And if one green bottle should accidentally fall,";
          "There'll be eight green bottles hanging on the wall." ]
⍤⤙≍ expected recite 10 2

# Last three verses
    let expected = 
        [ "Three green bottles hanging on the wall,";
          "Three green bottles hanging on the wall,";
          "And if one green bottle should accidentally fall,";
          "There'll be two green bottles hanging on the wall.";
          "";
          "Two green bottles hanging on the wall,";
          "Two green bottles hanging on the wall,";
          "And if one green bottle should accidentally fall,";
          "There'll be one green bottle hanging on the wall.";
          "";
          "One green bottle hanging on the wall,";
          "One green bottle hanging on the wall,";
          "And if one green bottle should accidentally fall,";
          "There'll be no green bottles hanging on the wall." ]
⍤⤙≍ expected recite 3 3

# All verses
    let expected = 
        [ "Ten green bottles hanging on the wall,";
          "Ten green bottles hanging on the wall,";
          "And if one green bottle should accidentally fall,";
          "There'll be nine green bottles hanging on the wall.";
          "";
          "Nine green bottles hanging on the wall,";
          "Nine green bottles hanging on the wall,";
          "And if one green bottle should accidentally fall,";
          "There'll be eight green bottles hanging on the wall.";
          "";
          "Eight green bottles hanging on the wall,";
          "Eight green bottles hanging on the wall,";
          "And if one green bottle should accidentally fall,";
          "There'll be seven green bottles hanging on the wall.";
          "";
          "Seven green bottles hanging on the wall,";
          "Seven green bottles hanging on the wall,";
          "And if one green bottle should accidentally fall,";
          "There'll be six green bottles hanging on the wall.";
          "";
          "Six green bottles hanging on the wall,";
          "Six green bottles hanging on the wall,";
          "And if one green bottle should accidentally fall,";
          "There'll be five green bottles hanging on the wall.";
          "";
          "Five green bottles hanging on the wall,";
          "Five green bottles hanging on the wall,";
          "And if one green bottle should accidentally fall,";
          "There'll be four green bottles hanging on the wall.";
          "";
          "Four green bottles hanging on the wall,";
          "Four green bottles hanging on the wall,";
          "And if one green bottle should accidentally fall,";
          "There'll be three green bottles hanging on the wall.";
          "";
          "Three green bottles hanging on the wall,";
          "Three green bottles hanging on the wall,";
          "And if one green bottle should accidentally fall,";
          "There'll be two green bottles hanging on the wall.";
          "";
          "Two green bottles hanging on the wall,";
          "Two green bottles hanging on the wall,";
          "And if one green bottle should accidentally fall,";
          "There'll be one green bottle hanging on the wall.";
          "";
          "One green bottle hanging on the wall,";
          "One green bottle hanging on the wall,";
          "And if one green bottle should accidentally fall,";
          "There'll be no green bottles hanging on the wall." ]
⍤⤙≍ expected recite 10 10

