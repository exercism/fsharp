module FoodChain

let joinBy str = List.reduce (fun x y -> x + str + y)

let subjects = 
    [("spider", "It wriggled and jiggled and tickled inside her.");
     ("bird",   "How absurd to swallow a bird!");
     ("cat",    "Imagine that, to swallow a cat!");
     ("dog",    "What a hog, to swallow a dog!");
     ("goat",   "Just opened her throat and swallowed a goat!");
     ("cow",    "I don't know how she swallowed a cow!")]

let history = 
    ["I don't know how she swallowed a cow!";
     "She swallowed the cow to catch the goat.";
     "She swallowed the goat to catch the dog.";
     "She swallowed the dog to catch the cat.";
     "She swallowed the cat to catch the bird.";
     "She swallowed the bird to catch the spider that wriggled and jiggled and tickled inside her.";
     "She swallowed the spider to catch the fly.";
     "I don't know why she swallowed the fly. Perhaps she'll die."]

let verseBegin number =
    match number with
    | 1 -> ["I know an old lady who swallowed a fly."]
    | 8 -> ["I know an old lady who swallowed a horse."]
    | _ ->
        let (subject, followUp) = List.item (number - 2) subjects
        ["I know an old lady who swallowed a " + subject + "."; followUp]

let verseEnd number = 
    match number with
    | 8 -> ["She's dead, of course!"]
    | _ -> 
        history 
        |> List.skip (List.length history - number)
        |> List.take number

let verse number = verseBegin number @ verseEnd number

let recite start stop =
    [start .. stop]
    |> List.map verse
    |> List.reduce (fun x y -> x @ "" :: y)