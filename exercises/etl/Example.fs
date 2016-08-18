module ETL

let normalizeLetter (letter:string) = letter.ToLowerInvariant()

let transformLetterWithScore score lettersWithScore (letter:string) = Map.add (normalizeLetter letter) score lettersWithScore

let transformScoreWithLetters lettersWithScore score letters = List.fold (transformLetterWithScore score) lettersWithScore letters

let transform scoresWithLetters: Map<string, int> = Map.fold transformScoreWithLetters Map.empty scoresWithLetters