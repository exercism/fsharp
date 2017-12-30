module RobotSimulator

type Direction = North | East | South | West
type Position = int * int

type Robot = { direction: Direction; position: Position }

let create direction position = failwith "You need to implement this function."

let turnLeft robot = failwith "You need to implement this function."

let turnRight robot = failwith "You need to implement this function."

let advance robot = failwith "You need to implement this function."

let instructions instructions' robot = failwith "You need to implement this function."