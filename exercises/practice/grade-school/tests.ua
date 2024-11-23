~ "grade-school.ua" ~ GradeSchool

# Roster is empty when no student is added
    let school = empty
⍤⤙≍ [] roster school

# Student is added to the roster
    let school = 
        empty
        |> add "Aimee" 2
⍤⤙≍ ["Aimee"] roster school

# Multiple students in the same grade are added to the roster
    let school = 
        empty
        |> add "Blair" 2
        |> add "James" 2
        |> add "Paul" 2
⍤⤙≍ ["Blair" "James" "Paul"] roster school

# Student not added to same grade in the roster more than once
    let school = 
        empty
        |> add "Blair" 2
        |> add "James" 2
        |> add "James" 2
        |> add "Paul" 2
⍤⤙≍ ["Blair" "James" "Paul"] roster school

# Students in multiple grades are added to the roster
    let school = 
        empty
        |> add "Chelsea" 3
        |> add "Logan" 7
⍤⤙≍ ["Chelsea" "Logan"] roster school

# Student not added to multiple grades in the roster
    let school = 
        empty
        |> add "Blair" 2
        |> add "James" 2
        |> add "James" 3
        |> add "Paul" 3
⍤⤙≍ ["Blair" "James" "Paul"] roster school

# Students are sorted by grades in the roster
    let school = 
        empty
        |> add "Jim" 3
        |> add "Peter" 2
        |> add "Anna" 1
⍤⤙≍ ["Anna" "Peter" "Jim"] roster school

# Students are sorted by name in the roster
    let school = 
        empty
        |> add "Peter" 2
        |> add "Zoe" 2
        |> add "Alex" 2
⍤⤙≍ ["Alex" "Peter" "Zoe"] roster school

# Students are sorted by grades and then by name in the roster
    let school = 
        empty
        |> add "Peter" 2
        |> add "Anna" 1
        |> add "Barb" 1
        |> add "Zoe" 2
        |> add "Alex" 2
        |> add "Jim" 3
        |> add "Charlie" 1
⍤⤙≍ ["Anna" "Barb" "Charlie" "Alex" "Peter" "Zoe" "Jim"] roster school

# Grade is empty if no students in the roster
    let school = empty
⍤⤙≍ [] grade 1 school

# Grade is empty if no students in that grade
    let school = 
        empty
        |> add "Peter" 2
        |> add "Zoe" 2
        |> add "Alex" 2
        |> add "Jim" 3
⍤⤙≍ [] grade 1 school

# Student not added to same grade more than once
    let school = 
        empty
        |> add "Blair" 2
        |> add "James" 2
        |> add "James" 2
        |> add "Paul" 2
⍤⤙≍ ["Blair" "James" "Paul"] grade 2 school

# Student not added to multiple grades
    let school = 
        empty
        |> add "Blair" 2
        |> add "James" 2
        |> add "James" 3
        |> add "Paul" 3
⍤⤙≍ ["Blair" "James"] grade 2 school

# Student not added to other grade for multiple grades
    let school = 
        empty
        |> add "Blair" 2
        |> add "James" 2
        |> add "James" 3
        |> add "Paul" 3
⍤⤙≍ ["Paul"] grade 3 school

# Students are sorted by name in a grade
    let school = 
        empty
        |> add "Franklin" 5
        |> add "Bradley" 5
        |> add "Jeff" 1
⍤⤙≍ ["Bradley" "Franklin"] grade 5 school

