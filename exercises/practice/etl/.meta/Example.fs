module Etl

open System

let normalizeLetter letter = Char.ToLowerInvariant(letter)

let transformLetterWithScore score lettersWithScore letter = 
    Map.add (normalizeLetter letter) score lettersWithScore

let transformScoreWithLetters lettersWithScore score letters = 
    List.fold (transformLetterWithScore score) lettersWithScore letters

let transform scoresWithLetters: Map<char, int> = 
    Map.fold transformScoreWithLetters Map.empty scoresWithLetters