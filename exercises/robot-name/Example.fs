module RobotName

type RobotName() =
    let alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"
    let random = System.Random()

    let generateRandomChar() = 
        alphabet.Chars(random.Next(25)).ToString()

    let generateName() =
        generateRandomChar() + generateRandomChar() + random.Next(100, 999).ToString()

    let mutable name = generateName()

    member this.Name
        with get() = name
        and set(value) = name <- value

    member this.Reset() =
        this.Name <- generateName()