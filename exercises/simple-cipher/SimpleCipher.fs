module SimpleCipher

open System

let letters = ['a'..'z']
let keyLength = 100

let random = System.Random()

let isInvalidKey key = Seq.length key = 0 || not (Seq.forall (fun c -> List.contains c letters) key)

let generateKey() = 
    let numberOfLetters = letters |> List.length
    let randomLetters = Array.init keyLength (fun _ -> List.item (random.Next(numberOfLetters)) letters)

    new String(randomLetters)

let modulo x y = ((x % y) + y) % y

let charToInt (c:char) = (int c) - (int 'a')
let intToChar (i:int) = (char)((int 'a') + (modulo i 26))

let shiftChar operation key char = operation (charToInt char) (charToInt key) |> intToChar

let shift operation (key:string) (input:string) =     
    if isInvalidKey key then failwith "Invalid key"
    else new String(Seq.map2 (shiftChar operation) key input |> Seq.toArray)
        
let encode key input = shift (+) key input   
let decode key input = shift (-) key input
    
let encodeRandom input = 
    let key = generateKey()
    (key, encode key input)