module annalynsInfiltrationTests

[<Task(1)>]
let ``Cannot execute fast attack if knight is awake``() =
    knightIsAwake <- true
    canFastAttack knightIsAwake |> should equal false

[<Task(1)>]
let ``Can execute fast attack if knight is sleeping``() =
    knightIsAwake <- false
    canFastAttack knightIsAwake |> should equal true

[<Task(2)>]
let ``Cannot spy if everyone is sleeping``() =
    knightIsAwake <- false
    archerIsAwake <- false
    prisonerIsAwake <- false
    canSpy knightIsAwake archerIsAwake prisonerIsAwake |> should equal false

[<Task(2)>]
let ``Can spy if everyone but knight is sleeping``() =
    knightIsAwake <- true
    archerIsAwake <- false
    prisonerIsAwake <- false
    canSpy knightIsAwake archerIsAwake prisonerIsAwake |> should equal true

[<Task(2)>]
let ``Can spy if everyone but archer is sleeping``() =
    knightIsAwake <- false
    archerIsAwake <- true
    prisonerIsAwake <- false
    canSpy knightIsAwake archerIsAwake prisonerIsAwake |> should equal true

[<Task(2)>]
let ``Can spy if everyone but prisoner is sleeping``() =
    knightIsAwake <- false
    archerIsAwake <- false
    prisonerIsAwake <- true
    canSpy knightIsAwake archerIsAwake prisonerIsAwake |> should equal true

[<Task(2)>]
let ``Can spy if only knight is sleeping``() =
    knightIsAwake <- false
    archerIsAwake <- true
    prisonerIsAwake <- true
    canSpy knightIsAwake archerIsAwake prisonerIsAwake |> should equal true

[<Task(2)>]
let ``Can spy if only archer is sleeping``() =
    knightIsAwake <- true
    archerIsAwake <- false
    prisonerIsAwake <- true
    canSpy knightIsAwake archerIsAwake prisonerIsAwake |> should equal true

[<Task(2)>]
let ``Can spy if only prisoner is sleeping``() =
    knightIsAwake <- true
    archerIsAwake <- true
    prisonerIsAwake <- false
    canSpy knightIsAwake archerIsAwake prisonerIsAwake |> should equal true

[<Task(2)>]
let ``Can spy if everyone is awake``() =
    knightIsAwake <- true
    archerIsAwake <- true
    prisonerIsAwake <- true
    canSpy knightIsAwake archerIsAwake prisonerIsAwake |> should equal true

[<Task(3)>]
let ``Can signal prisoner if archer is sleeping and prisoner is awake``() =
    archerIsAwake <- false
    prisonerIsAwake <- true
    canSignalPrisoner archerIsAwake prisonerIsAwake |> should equal true

[<Task(3)>]
let ``Cannot signal prisoner if archer is awake and prisoner is sleeping``() =
    archerIsAwake <- true
    prisonerIsAwake <- false
    canSignalPrisoner archerIsAwake prisonerIsAwake |> should equal false

[<Task(3)>]
let ``Cannot signal prisoner if archer and prisoner are both sleeping``() =
    archerIsAwake <- false
    prisonerIsAwake <- false
    canSignalPrisoner archerIsAwake prisonerIsAwake |> should equal false

[<Task(3)>]
let ``Cannot signal prisoner if archer and prisoner are both awake``() =
    archerIsAwake <- true
    prisonerIsAwake <- true
    canSignalPrisoner archerIsAwake prisonerIsAwake |> should equal false

[<Task(4)>]
let ``Cannot free prisoner if everyone is awake and pet dog is present``() =
    knightIsAwake <- true
    archerIsAwake <- true
    prisonerIsAwake <- true
    petDogIsPresent <- true
    canFreePrisoner knightIsAwake archerIsAwake prisonerIsAwake petDogIsPresent |> should equal false

[<Task(4)>]
let ``Cannot free prisoner if everyone is awake and pet dog is absent``() =
    knightIsAwake <- true
    archerIsAwake <- true
    prisonerIsAwake <- true
    petDogIsPresent <- false
    canFreePrisoner knightIsAwake archerIsAwake prisonerIsAwake petDogIsPresent |> should equal false

[<Task(4)>]
let ``Can free prisoner if everyone is asleep and pet dog is present``() =
    knightIsAwake <- false
    archerIsAwake <- false
    prisonerIsAwake <- false
    petDogIsPresent <- true
    canFreePrisoner knightIsAwake archerIsAwake prisonerIsAwake petDogIsPresent |> should equal true

[<Task(4)>]
let ``Cannot free prisoner if everyone is asleep and pet dog is absent``() =
    knightIsAwake <- false
    archerIsAwake <- false
    prisonerIsAwake <- false
    petDogIsPresent <- false
    canFreePrisoner knightIsAwake archerIsAwake prisonerIsAwake petDogIsPresent |> should equal false

[<Task(4)>]
let ``Can free prisoner if only prisoner is awake and pet dog is present``() =
    knightIsAwake <- false
    archerIsAwake <- false
    prisonerIsAwake <- true
    petDogIsPresent <- true
    canFreePrisoner knightIsAwake archerIsAwake prisonerIsAwake petDogIsPresent |> should equal true

[<Task(4)>]
let ``Can free prisoner if only prisoner is awake and pet dog is absent``() =
    knightIsAwake <- false
    archerIsAwake <- false
    prisonerIsAwake <- true
    petDogIsPresent <- false
    canFreePrisoner knightIsAwake archerIsAwake prisonerIsAwake petDogIsPresent |> should equal true

[<Task(4)>]
let ``Cannot free prisoner if only archer is awake and pet dog is present``() =
    knightIsAwake <- false
    archerIsAwake <- true
    prisonerIsAwake <- false
    petDogIsPresent <- true
    canFreePrisoner knightIsAwake archerIsAwake prisonerIsAwake petDogIsPresent |> should equal false

[<Task(4)>]
let ``Cannot free prisoner if only archer is awake and pet dog is absent``() =
    knightIsAwake <- false
    archerIsAwake <- true
    prisonerIsAwake <- false
    petDogIsPresent <- false
    canFreePrisoner knightIsAwake archerIsAwake prisonerIsAwake petDogIsPresent |> should equal false

[<Task(4)>]
let ``Can free prisoner if only knight is awake and pet dog is present``() =
    knightIsAwake <- true
    archerIsAwake <- false
    prisonerIsAwake <- false
    petDogIsPresent <- true
    canFreePrisoner knightIsAwake archerIsAwake prisonerIsAwake petDogIsPresent |> should equal true

[<Task(4)>]
let ``Cannot free prisoner if only knight is awake and pet dog is absent``() =
    knightIsAwake <- true
    archerIsAwake <- false
    prisonerIsAwake <- false
    petDogIsPresent <- false
    canFreePrisoner knightIsAwake archerIsAwake prisonerIsAwake petDogIsPresent |> should equal false

[<Task(4)>]
let ``Cannot free prisoner if only knight is asleep and pet dog is present``() =
    knightIsAwake <- false
    archerIsAwake <- true
    prisonerIsAwake <- true
    petDogIsPresent <- true
    canFreePrisoner knightIsAwake archerIsAwake prisonerIsAwake petDogIsPresent |> should equal false

[<Task(4)>]
let ``Cannot free prisoner if only knight is asleep and pet dog is absent``() =
    knightIsAwake <- false
    archerIsAwake <- true
    prisonerIsAwake <- true
    petDogIsPresent <- false
    canFreePrisoner knightIsAwake archerIsAwake prisonerIsAwake petDogIsPresent |> should equal false

[<Task(4)>]
let ``Can free prisoner if only archer is asleep and pet dog is present``() =
    knightIsAwake <- true
    archerIsAwake <- false
    prisonerIsAwake <- true
    petDogIsPresent <- true
    canFreePrisoner knightIsAwake archerIsAwake prisonerIsAwake petDogIsPresent |> should equal true

[<Task(4)>]
let ``Cannot free prisoner if only archer is asleep and pet dog is absent``() =
    knightIsAwake <- true
    archerIsAwake <- false
    prisonerIsAwake <- true
    petDogIsPresent <- false
    canFreePrisoner knightIsAwake archerIsAwake prisonerIsAwake petDogIsPresent |> should equal false

[<Task(4)>]
let ``Cannot free prisoner if only prisoner is asleep and pet dog is present``() =
    knightIsAwake <- true
    archerIsAwake <- true
    prisonerIsAwake <- false
    petDogIsPresent <- true
    canFreePrisoner knightIsAwake archerIsAwake prisonerIsAwake petDogIsPresent |> should equal false

[<Task(4)>]
let ``Cannot free prisoner if only prisoner is asleep and pet dog is absent``() =
    knightIsAwake <- true
    archerIsAwake <- true
    prisonerIsAwake <- false
    petDogIsPresent <- false
    canFreePrisoner knightIsAwake archerIsAwake prisonerIsAwake petDogIsPresent |> should equal false
