module PigLatin

open System.Text.RegularExpressions

let vowelPattern = @"(?<begin>^|\s+)(?<vowel>a|e|i|o|u|yt|xr)(?<rest>\w+)"
let consonantPattern = @"(?<begin>^|\s+)(?<consonant>ch|qu|thr|th|rh|sch|yt|\wqu|\w)(?<rest>\w+)"

let vowelReplacement = "${begin}${vowel}${rest}ay";
let consonantReplacement = "${begin}${rest}${consonant}ay";

let translate (sentence: string) = 
    if Regex.IsMatch(sentence, vowelPattern) then
        Regex.Replace(sentence, vowelPattern, vowelReplacement)
    else
        Regex.Replace(sentence, consonantPattern, consonantReplacement)
