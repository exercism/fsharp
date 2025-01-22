source("./food-chain.R")
library(testthat)

let ``Fly`` () =
    expected <- 
        [ "I know an old lady who swallowed a fly.";
          "I don't know why she swallowed the fly. Perhaps she'll die." ]
    expect_equal(recite 1 1, expected)

let ``Spider`` () =
    expected <- 
        [ "I know an old lady who swallowed a spider.";
          "It wriggled and jiggled and tickled inside her.";
          "She swallowed the spider to catch the fly.";
          "I don't know why she swallowed the fly. Perhaps she'll die." ]
    expect_equal(recite 2 2, expected)

let ``Bird`` () =
    expected <- 
        [ "I know an old lady who swallowed a bird.";
          "How absurd to swallow a bird!";
          "She swallowed the bird to catch the spider that wriggled and jiggled and tickled inside her.";
          "She swallowed the spider to catch the fly.";
          "I don't know why she swallowed the fly. Perhaps she'll die." ]
    expect_equal(recite 3 3, expected)

let ``Cat`` () =
    expected <- 
        [ "I know an old lady who swallowed a cat.";
          "Imagine that, to swallow a cat!";
          "She swallowed the cat to catch the bird.";
          "She swallowed the bird to catch the spider that wriggled and jiggled and tickled inside her.";
          "She swallowed the spider to catch the fly.";
          "I don't know why she swallowed the fly. Perhaps she'll die." ]
    expect_equal(recite 4 4, expected)

let ``Dog`` () =
    expected <- 
        [ "I know an old lady who swallowed a dog.";
          "What a hog, to swallow a dog!";
          "She swallowed the dog to catch the cat.";
          "She swallowed the cat to catch the bird.";
          "She swallowed the bird to catch the spider that wriggled and jiggled and tickled inside her.";
          "She swallowed the spider to catch the fly.";
          "I don't know why she swallowed the fly. Perhaps she'll die." ]
    expect_equal(recite 5 5, expected)

let ``Goat`` () =
    expected <- 
        [ "I know an old lady who swallowed a goat.";
          "Just opened her throat and swallowed a goat!";
          "She swallowed the goat to catch the dog.";
          "She swallowed the dog to catch the cat.";
          "She swallowed the cat to catch the bird.";
          "She swallowed the bird to catch the spider that wriggled and jiggled and tickled inside her.";
          "She swallowed the spider to catch the fly.";
          "I don't know why she swallowed the fly. Perhaps she'll die." ]
    expect_equal(recite 6 6, expected)

let ``Cow`` () =
    expected <- 
        [ "I know an old lady who swallowed a cow.";
          "I don't know how she swallowed a cow!";
          "She swallowed the cow to catch the goat.";
          "She swallowed the goat to catch the dog.";
          "She swallowed the dog to catch the cat.";
          "She swallowed the cat to catch the bird.";
          "She swallowed the bird to catch the spider that wriggled and jiggled and tickled inside her.";
          "She swallowed the spider to catch the fly.";
          "I don't know why she swallowed the fly. Perhaps she'll die." ]
    expect_equal(recite 7 7, expected)

let ``Horse`` () =
    expected <- 
        [ "I know an old lady who swallowed a horse.";
          "She's dead, of course!" ]
    expect_equal(recite 8 8, expected)

let ``Multiple verses`` () =
    expected <- 
        [ "I know an old lady who swallowed a fly.";
          "I don't know why she swallowed the fly. Perhaps she'll die.";
          "";
          "I know an old lady who swallowed a spider.";
          "It wriggled and jiggled and tickled inside her.";
          "She swallowed the spider to catch the fly.";
          "I don't know why she swallowed the fly. Perhaps she'll die.";
          "";
          "I know an old lady who swallowed a bird.";
          "How absurd to swallow a bird!";
          "She swallowed the bird to catch the spider that wriggled and jiggled and tickled inside her.";
          "She swallowed the spider to catch the fly.";
          "I don't know why she swallowed the fly. Perhaps she'll die." ]
    expect_equal(recite 1 3, expected)

let ``Full song`` () =
    expected <- 
        [ "I know an old lady who swallowed a fly.";
          "I don't know why she swallowed the fly. Perhaps she'll die.";
          "";
          "I know an old lady who swallowed a spider.";
          "It wriggled and jiggled and tickled inside her.";
          "She swallowed the spider to catch the fly.";
          "I don't know why she swallowed the fly. Perhaps she'll die.";
          "";
          "I know an old lady who swallowed a bird.";
          "How absurd to swallow a bird!";
          "She swallowed the bird to catch the spider that wriggled and jiggled and tickled inside her.";
          "She swallowed the spider to catch the fly.";
          "I don't know why she swallowed the fly. Perhaps she'll die.";
          "";
          "I know an old lady who swallowed a cat.";
          "Imagine that, to swallow a cat!";
          "She swallowed the cat to catch the bird.";
          "She swallowed the bird to catch the spider that wriggled and jiggled and tickled inside her.";
          "She swallowed the spider to catch the fly.";
          "I don't know why she swallowed the fly. Perhaps she'll die.";
          "";
          "I know an old lady who swallowed a dog.";
          "What a hog, to swallow a dog!";
          "She swallowed the dog to catch the cat.";
          "She swallowed the cat to catch the bird.";
          "She swallowed the bird to catch the spider that wriggled and jiggled and tickled inside her.";
          "She swallowed the spider to catch the fly.";
          "I don't know why she swallowed the fly. Perhaps she'll die.";
          "";
          "I know an old lady who swallowed a goat.";
          "Just opened her throat and swallowed a goat!";
          "She swallowed the goat to catch the dog.";
          "She swallowed the dog to catch the cat.";
          "She swallowed the cat to catch the bird.";
          "She swallowed the bird to catch the spider that wriggled and jiggled and tickled inside her.";
          "She swallowed the spider to catch the fly.";
          "I don't know why she swallowed the fly. Perhaps she'll die.";
          "";
          "I know an old lady who swallowed a cow.";
          "I don't know how she swallowed a cow!";
          "She swallowed the cow to catch the goat.";
          "She swallowed the goat to catch the dog.";
          "She swallowed the dog to catch the cat.";
          "She swallowed the cat to catch the bird.";
          "She swallowed the bird to catch the spider that wriggled and jiggled and tickled inside her.";
          "She swallowed the spider to catch the fly.";
          "I don't know why she swallowed the fly. Perhaps she'll die.";
          "";
          "I know an old lady who swallowed a horse.";
          "She's dead, of course!" ]
    expect_equal(recite 1 8, expected)

