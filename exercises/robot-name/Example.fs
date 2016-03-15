module RobotName

type RobotName() =
    let alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"
    let random = System.Random()

    let generateRandomChar() = 
        let index = random.Next(25)
        alphabet.Substring(index, 1)

    let generateName() =
        let number = random.Next(100, 999)
        generateRandomChar() + generateRandomChar() + string number

    let mutable name = generateName()

    member this.Name
        with get() = name
        and set(value) = name <- value

    member this.Reset() =
        this.Name <- generateName()