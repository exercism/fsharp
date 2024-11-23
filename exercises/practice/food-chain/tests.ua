~ "food-chain.ua" ~ FoodChain

# Fly
expected = 
        [ "I know an old lady who swallowed a fly.";
          "I don't know why she swallowed the fly. Perhaps she'll die." ]
⍤⤙≍ expected recite 1 1

# Spider
expected = 
        [ "I know an old lady who swallowed a spider.";
          "It wriggled and jiggled and tickled inside her.";
          "She swallowed the spider to catch the fly.";
          "I don't know why she swallowed the fly. Perhaps she'll die." ]
⍤⤙≍ expected recite 2 2

# Bird
expected = 
        [ "I know an old lady who swallowed a bird.";
          "How absurd to swallow a bird!";
          "She swallowed the bird to catch the spider that wriggled and jiggled and tickled inside her.";
          "She swallowed the spider to catch the fly.";
          "I don't know why she swallowed the fly. Perhaps she'll die." ]
⍤⤙≍ expected recite 3 3

# Cat
expected = 
        [ "I know an old lady who swallowed a cat.";
          "Imagine that, to swallow a cat!";
          "She swallowed the cat to catch the bird.";
          "She swallowed the bird to catch the spider that wriggled and jiggled and tickled inside her.";
          "She swallowed the spider to catch the fly.";
          "I don't know why she swallowed the fly. Perhaps she'll die." ]
⍤⤙≍ expected recite 4 4

# Dog
expected = 
        [ "I know an old lady who swallowed a dog.";
          "What a hog, to swallow a dog!";
          "She swallowed the dog to catch the cat.";
          "She swallowed the cat to catch the bird.";
          "She swallowed the bird to catch the spider that wriggled and jiggled and tickled inside her.";
          "She swallowed the spider to catch the fly.";
          "I don't know why she swallowed the fly. Perhaps she'll die." ]
⍤⤙≍ expected recite 5 5

# Goat
expected = 
        [ "I know an old lady who swallowed a goat.";
          "Just opened her throat and swallowed a goat!";
          "She swallowed the goat to catch the dog.";
          "She swallowed the dog to catch the cat.";
          "She swallowed the cat to catch the bird.";
          "She swallowed the bird to catch the spider that wriggled and jiggled and tickled inside her.";
          "She swallowed the spider to catch the fly.";
          "I don't know why she swallowed the fly. Perhaps she'll die." ]
⍤⤙≍ expected recite 6 6

# Cow
expected = 
        [ "I know an old lady who swallowed a cow.";
          "I don't know how she swallowed a cow!";
          "She swallowed the cow to catch the goat.";
          "She swallowed the goat to catch the dog.";
          "She swallowed the dog to catch the cat.";
          "She swallowed the cat to catch the bird.";
          "She swallowed the bird to catch the spider that wriggled and jiggled and tickled inside her.";
          "She swallowed the spider to catch the fly.";
          "I don't know why she swallowed the fly. Perhaps she'll die." ]
⍤⤙≍ expected recite 7 7

# Horse
expected = 
        [ "I know an old lady who swallowed a horse.";
          "She's dead, of course!" ]
⍤⤙≍ expected recite 8 8

# Multiple verses
expected = 
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
⍤⤙≍ expected recite 1 3

# Full song
expected = 
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
⍤⤙≍ expected recite 1 8

