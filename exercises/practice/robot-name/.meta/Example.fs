module RobotName

let random = System.Random()

type Robot = { name: string }

let letters = ['A'..'Z']
let digits = ['0'..'9']

let NumberOfLetters = 2;
let NumberOfDigits = 3  

let mutable usedNames = Set.empty<string>

let takeRandomElements xs length = List.init length (fun _ -> List.item (random.Next(List.length xs)) xs)
let generateRandomString chars length = new System.String(takeRandomElements chars length |> List.toArray)
let generateLetters() = generateRandomString letters NumberOfLetters
let generateDigits() = generateRandomString digits NumberOfDigits
let generateName() = generateLetters() + generateDigits()
let generateUniqueName() = 
    let nextName = 
        Seq.initInfinite (fun _ -> generateName())
        |> Seq.filter (fun name -> not (usedNames.Contains name))
        |> Seq.item 0
    usedNames <- usedNames.Add(nextName)
    nextName

let mkRobot() = { name = generateUniqueName() }

let name robot = robot.name
let reset _ = mkRobot()