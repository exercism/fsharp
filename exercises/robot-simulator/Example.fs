module RobotSimulator

type Direction = North | East | South | West
type Position = int * int
type Robot = { direction: Direction; position: Position }

let create bearing position = { direction = bearing; position = position }

let private turnLeft robot = 
    match robot.direction with
    | North -> { robot with direction = West  }
    | East  -> { robot with direction = North }
    | South -> { robot with direction = East  }
    | West  -> { robot with direction = South }

let private turnRight robot = 
    match robot.direction with
    | North -> { robot with direction = East  }
    | East  -> { robot with direction = South }
    | South -> { robot with direction = West  }
    | West  -> { robot with direction = North }

let private advance robot = 
    let (x, y) = robot.position

    match robot.direction with
    | North -> { robot with position = (x    , y + 1) }
    | East  -> { robot with position = (x + 1, y    ) }
    | South -> { robot with position = (x    , y - 1) }
    | West  -> { robot with position = (x - 1, y    ) }
    
let private applyInstruction robot instruction =
    match instruction with
    | 'L' -> turnLeft robot
    | 'R' -> turnRight robot
    | 'A' -> advance robot
    | _   -> failwith "Invalid instruction"

let move instructions robot = Seq.fold applyInstruction robot instructions