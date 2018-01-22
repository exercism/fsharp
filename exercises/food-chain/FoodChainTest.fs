// This file was auto-generated based on version 2.1.0 of the canonical data.

module FoodChainTest

open FsUnit.Xunit
open Xunit

open FoodChain

[<Fact>]
let ``Fly`` () =
    let expected = 
        [ "I know an old lady who swallowed a fly.";
          "I don't know why she swallowed the fly. Perhaps she'll die." ]
    recite 1 1 |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Spider`` () =
    let expected = 
        [ "I know an old lady who swallowed a spider.";
          "It wriggled and jiggled and tickled inside her.";
          "She swallowed the spider to catch the fly.";
          "I don't know why she swallowed the fly. Perhaps she'll die." ]
    recite 2 2 |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Bird`` () =
    let expected = 
        [ "I know an old lady who swallowed a bird.";
          "How absurd to swallow a bird!";
          "She swallowed the bird to catch the spider that wriggled and jiggled and tickled inside her.";
          "She swallowed the spider to catch the fly.";
          "I don't know why she swallowed the fly. Perhaps she'll die." ]
    recite 3 3 |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Cat`` () =
    let expected = 
        [ "I know an old lady who swallowed a cat.";
          "Imagine that, to swallow a cat!";
          "She swallowed the cat to catch the bird.";
          "She swallowed the bird to catch the spider that wriggled and jiggled and tickled inside her.";
          "She swallowed the spider to catch the fly.";
          "I don't know why she swallowed the fly. Perhaps she'll die." ]
    recite 4 4 |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Dog`` () =
    let expected = 
        [ "I know an old lady who swallowed a dog.";
          "What a hog, to swallow a dog!";
          "She swallowed the dog to catch the cat.";
          "She swallowed the cat to catch the bird.";
          "She swallowed the bird to catch the spider that wriggled and jiggled and tickled inside her.";
          "She swallowed the spider to catch the fly.";
          "I don't know why she swallowed the fly. Perhaps she'll die." ]
    recite 5 5 |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Goat`` () =
    let expected = 
        [ "I know an old lady who swallowed a goat.";
          "Just opened her throat and swallowed a goat!";
          "She swallowed the goat to catch the dog.";
          "She swallowed the dog to catch the cat.";
          "She swallowed the cat to catch the bird.";
          "She swallowed the bird to catch the spider that wriggled and jiggled and tickled inside her.";
          "She swallowed the spider to catch the fly.";
          "I don't know why she swallowed the fly. Perhaps she'll die." ]
    recite 6 6 |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Cow`` () =
    let expected = 
        [ "I know an old lady who swallowed a cow.";
          "I don't know how she swallowed a cow!";
          "She swallowed the cow to catch the goat.";
          "She swallowed the goat to catch the dog.";
          "She swallowed the dog to catch the cat.";
          "She swallowed the cat to catch the bird.";
          "She swallowed the bird to catch the spider that wriggled and jiggled and tickled inside her.";
          "She swallowed the spider to catch the fly.";
          "I don't know why she swallowed the fly. Perhaps she'll die." ]
    recite 7 7 |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Horse`` () =
    let expected = 
        [ "I know an old lady who swallowed a horse.";
          "She's dead, of course!" ]
    recite 8 8 |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Multiple verses`` () =
    let expected = 
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
    recite 1 3 |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Full song`` () =
    let expected = 
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
    recite 1 8 |> should equal expected

