module RobotSimulator

type Bearing = North | East | South | West
type Coordinate = int * int

type Robot = { bearing: Bearing; coordinate: Coordinate }

let createRobot bearing coordinate = failwith "You need to implement this function."

let turnLeft robot = failwith "You need to implement this function."

let turnRight robot = failwith "You need to implement this function."

let advance robot = failwith "You need to implement this function."

let simulate robot instructions = failwith "You need to implement this function."