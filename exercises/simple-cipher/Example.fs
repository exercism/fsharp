module SimpleCipher

open System

let private letters = ['a'..'z']
let private keyLength = 100

let private random = System.Random()

let private generateKey() = 
    let numberOfLetters = List.length letters 
    Array.init keyLength (fun _ -> List.item (random.Next(numberOfLetters)) letters) 
    |> String

let private modulo x y = ((x % y) + y) % y

let private charToInt (c:char) = (int c) - (int 'a')
let private intToChar (i:int) = (char)((int 'a') + (modulo i 26))

let private shiftChar operation key char = operation (charToInt char) (charToInt key) |> intToChar

let shift operation (key:string) (input:string) =
    input
    |> Seq.mapi (fun i c -> shiftChar operation key.[i % key.Length] c) 
    |> Seq.toArray
    |> String
    
let encode key input = shift (+) key input   
let decode key input = shift (-) key input

type SimpleCipher(key: string) =
    member __.Key with get() = key
    
    member __.Encode(plaintext: string) = encode key plaintext
    
    member __.Decode(ciphertext: string) = decode key ciphertext
    
    new() = SimpleCipher(generateKey())