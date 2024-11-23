~ "SOLUTION" ~ RobotName
# Robot has a name     
robot = mkRobot()
⍤⤙≍ 1 Regex.IsMatch(name robot, @"^[A-Z]{2}\d{3}$")
    
# Name is the same each time     
robot = mkRobot()
⍤⤙≍ (name robot) name robot
    
# 2 Different robots have different names 
robot = mkRobot()
robot2 = mkRobot()
    name robot |> should not' (equal (name robot2))

# 2500 Different robots have different names
robotCount = 2500
    seq { 1 .. robotCount }
    |> Seq.map (fun _ -> mkRobot())
    |> Seq.map (fun robot -> name robot)
    |> Set
    |> Set.count
⍤⤙≍ robotCount  
    
# Can reset the name  
robot = mkRobot()
originalName = name robot
resetRobot = reset robot
    originalName |> should not' (equal (name resetRobot))
