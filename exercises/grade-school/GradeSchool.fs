module GradeSchool

type School = Map<int, string list>

let empty: School = failwith "You need to implement this function."

let add (student: string) (grade: int) (school: School): School = failwith "You need to implement this function."

let roster (school: School): (int * string list) list = failwith "You need to implement this function."

let grade (number: int) (school: School): string list = failwith "You need to implement this function."
