~ "grade-school.ua" ~ GradeSchool

# Roster is empty when no student is added
school ← empty
⍤⤙≍ [] roster school

# Student is added to the roster
school ←
empty
| > + "Aimee" 2
⍤⤙≍ ["Aimee"] roster school

# Multiple students in the same grade are added to the roster
school ←
empty
| > + "Blair" 2
| > + "James" 2
| > + "Paul" 2
⍤⤙≍ ["Blair" "James" "Paul"] roster school

# Student not added to same grade in the roster more than once
school ←
empty
| > + "Blair" 2
| > + "James" 2
| > + "James" 2
| > + "Paul" 2
⍤⤙≍ ["Blair" "James" "Paul"] roster school

# Students in multiple grades are added to the roster
school ←
empty
| > + "Chelsea" 3
| > + "Logan" 7
⍤⤙≍ ["Chelsea" "Logan"] roster school

# Student not added to multiple grades in the roster
school ←
empty
| > + "Blair" 2
| > + "James" 2
| > + "James" 3
| > + "Paul" 3
⍤⤙≍ ["Blair" "James" "Paul"] roster school

# Students are sorted by grades in the roster
school ←
empty
| > + "Jim" 3
| > + "Peter" 2
| > + "Anna" 1
⍤⤙≍ ["Anna" "Peter" "Jim"] roster school

# Students are sorted by name in the roster
school ←
empty
| > + "Peter" 2
| > + "Zoe" 2
| > + "Alex" 2
⍤⤙≍ ["Alex" "Peter" "Zoe"] roster school

# Students are sorted by grades and then by name in the roster
school ←
empty
| > + "Peter" 2
| > + "Anna" 1
| > + "Barb" 1
| > + "Zoe" 2
| > + "Alex" 2
| > + "Jim" 3
| > + "Charlie" 1
⍤⤙≍ ["Anna" "Barb" "Charlie" "Alex" "Peter" "Zoe" "Jim"] roster school

# Grade is empty if no students in the roster
school ← empty
⍤⤙≍ [] grade 1 school

# Grade is empty if no students in that grade
school ←
empty
| > + "Peter" 2
| > + "Zoe" 2
| > + "Alex" 2
| > + "Jim" 3
⍤⤙≍ [] grade 1 school

# Student not added to same grade more than once
school ←
empty
| > + "Blair" 2
| > + "James" 2
| > + "James" 2
| > + "Paul" 2
⍤⤙≍ ["Blair" "James" "Paul"] grade 2 school

# Student not added to multiple grades
school ←
empty
| > + "Blair" 2
| > + "James" 2
| > + "James" 3
| > + "Paul" 3
⍤⤙≍ ["Blair" "James"] grade 2 school

# Student not added to other grade for multiple grades
school ←
empty
| > + "Blair" 2
| > + "James" 2
| > + "James" 3
| > + "Paul" 3
⍤⤙≍ ["Paul"] grade 3 school

# Students are sorted by name in a grade
school ←
empty
| > + "Franklin" 5
| > + "Bradley" 5
| > + "Jeff" 1
⍤⤙≍ ["Bradley" "Franklin"] grade 5 school
