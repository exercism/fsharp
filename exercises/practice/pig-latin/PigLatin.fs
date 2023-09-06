module PigLatin

let isVowelSound (c:char) =
    match c with
    | 'a' | 'e' | 'i' | 'o' | 'u' -> true
    | _ -> false
    
let translate (input:string) =
    match (Seq.tryHead input) with
    | Some c when isVowelSound c -> input + "ay"
    | Some _ -> input
    | None -> input