module RobotSimulator

type Bearing = North | East | South | West
type Coordinate = int * int

type Robot = { bearing: Bearing; coordinate: Coordinate }

let createRobot bearing coordinate = { bearing = bearing; coordinate = coordinate }

let turnLeft robot = 
    match robot.bearing with
    | North -> { robot with bearing = West  }
    | East  -> { robot with bearing = North }
    | South -> { robot with bearing = East  }
    | West  -> { robot with bearing = South }

let turnRight robot = 
    match robot.bearing with
    | North -> { robot with bearing = East  }
    | East  -> { robot with bearing = South }
    | South -> { robot with bearing = West  }
    | West  -> { robot with bearing = North }

let advance robot = 
    let (x, y) = robot.coordinate

    match robot.bearing with
    | North -> { robot with coordinate = (x    , y + 1) }
    | East  -> { robot with coordinate = (x + 1, y    ) }
    | South -> { robot with coordinate = (x    , y - 1) }
    | West  -> { robot with coordinate = (x - 1, y    ) }
    
let applyInstruction robot instruction =
    match instruction with
    | 'L' -> turnLeft robot
    | 'R' -> turnRight robot
    | 'A' -> advance robot
    | _   -> failwith "Invalid instruction"

let simulate robot instructions = Seq.fold applyInstruction robot instructions