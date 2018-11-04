module RobotSimulator

type Direction = North | East | South | West
type Position = int * int
type Robot = { direction: Direction; position: Position }

let create direction position = failwith "You need to implement this function."

let move instructions robot = failwith "You need to implement this function."