module Raindrops

open System
open System.Globalization

let convert (number:int) =
    let factors = [(3, "Pling"); (5, "Plang"); (7, "Plong")]
    let factorStrings = [for (factor, str) in factors do if number % factor = 0 then yield str]
    match factorStrings with
    | [] -> number.ToString(CultureInfo.InvariantCulture)
    | xs -> String.concat "" xs