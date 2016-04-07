module FoodChainTest

open NUnit.Framework

open FoodChain

let combine = List.reduce (fun x y -> x + "\n" + y)

[<Test>]
let ``Verse one`` () =
    let expected = ["I know an old lady who swallowed a fly.";
                    "I don't know why she swallowed the fly. Perhaps she'll die."] |> combine

    Assert.That(verse 1, Is.EqualTo(expected))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Verse two`` () =
    let expected = ["I know an old lady who swallowed a spider.";
                    "It wriggled and jiggled and tickled inside her.";
                    "She swallowed the spider to catch the fly.";
                    "I don't know why she swallowed the fly. Perhaps she'll die."] |> combine

    Assert.That(verse 2, Is.EqualTo(expected))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Verse four`` () =
    let expected = ["I know an old lady who swallowed a cat.";
                    "Imagine that, to swallow a cat!";
                    "She swallowed the cat to catch the bird.";
                    "She swallowed the bird to catch the spider that wriggled and jiggled and tickled inside her.";
                    "She swallowed the spider to catch the fly.";
                    "I don't know why she swallowed the fly. Perhaps she'll die."] |> combine

    Assert.That(verse 4, Is.EqualTo(expected))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Verse eight`` () =
    let expected = ["I know an old lady who swallowed a horse.";
                    "She's dead, of course!"] |> combine

    Assert.That(verse 8, Is.EqualTo(expected))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Complete song`` () =
    let expected = ["I know an old lady who swallowed a fly.";
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
                    "She's dead, of course!"] |> combine

    Assert.That(song, Is.EqualTo(expected))