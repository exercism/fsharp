module PigLatin

open System.Text.RegularExpressions

let vowelPattern = @"(?<vowel>a|e|i|o|u|yt|xr)"
let consonantPattern = @"(?<consonant>wh|ch|qu|thr|th|rh|sch|yt|\wqu|\w)"
let pigLatinRegex = Regex($"(?:{vowelPattern}|{consonantPattern})(?<rest>\\w+)")

let translate (sentence: string) = 
    pigLatinRegex.Replace(sentence, "${vowel}${rest}${consonant}ay")
