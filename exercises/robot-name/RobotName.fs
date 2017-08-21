module RobotName

let random = System.Random()

type Robot = { name: string }

let letters = ['A'..'Z']
let digits = ['0'..'9']

let NumberOfLetters = 2;
let NumberOfDigits = 3    

let takeRandomElements xs length = List.init length (fun _ -> List.item (random.Next(List.length xs)) xs)
let generateRandomString chars length = new System.String(takeRandomElements chars length |> List.toArray)
let generateLetters() = generateRandomString letters NumberOfLetters
let generateDigits() = generateRandomString digits NumberOfDigits
let generateName() = generateLetters() + generateDigits()

let mkRobot() = { name = generateName() }

let name robot = robot.name
let reset _ = mkRobot()