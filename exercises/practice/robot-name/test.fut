import "robot_name"
let ``Robot has a name`` () =     
    let robot = mkRobot()
    Regex.IsMatch(name robot, @"^[A-Z]{2}\d{3}$") |> should equal true
    
let ``Name is the same each time`` () =     
    let robot = mkRobot()
    name robot |> should equal (name robot)
    
let ``2 Different robots have different names`` () = 
    let robot = mkRobot()
    let robot2 = mkRobot()
    name robot |> should not' (equal (name robot2))

[<Fact(Skip = "Remove this Skip property to run this test")>] 
let ``2500 Different robots have different names``() =
    let robotCount = 2500
    seq { 1 .. robotCount }
    |> Seq.map (fun _ -> mkRobot())
    |> Seq.map (fun robot -> name robot)
    |> Set
    |> Set.count
    |> should equal robotCount
    
let ``Can reset the name`` () =  
    let robot = mkRobot()
    let originalName = name robot
    let resetRobot = reset robot
    originalName |> should not' (equal (name resetRobot))
