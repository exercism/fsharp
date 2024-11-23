~ "kindergarten-garden.ua" ~ KindergartenGarden

# Partial garden - garden with single student
student = "Alice"
diagram = "RC\nGG"
expected = [Plant.Radishes Plant.Clover Plant.Grass Plant.Grass]
⍤⤙≍ expected plants diagram student

# Partial garden - different garden with single student
student = "Alice"
diagram = "VC\nRC"
expected = [Plant.Violets Plant.Clover Plant.Radishes Plant.Clover]
⍤⤙≍ expected plants diagram student

# Partial garden - garden with two students
student = "Bob"
diagram = "VVCG\nVVRC"
expected = [Plant.Clover Plant.Grass Plant.Radishes Plant.Clover]
⍤⤙≍ expected plants diagram student

# Partial garden - multiple students for the same garden with three students - second student's garden
student = "Bob"
diagram = "VVCCGG\nVVCCGG"
expected = [Plant.Clover Plant.Clover Plant.Clover Plant.Clover]
⍤⤙≍ expected plants diagram student

# Partial garden - multiple students for the same garden with three students - third student's garden
student = "Charlie"
diagram = "VVCCGG\nVVCCGG"
expected = [Plant.Grass Plant.Grass Plant.Grass Plant.Grass]
⍤⤙≍ expected plants diagram student

# Full garden - for Alice, first student's garden
student = "Alice"
diagram = "VRCGVVRVCGGCCGVRGCVCGCGV\nVRCCCGCRRGVCGCRVVCVGCGCV"
expected = [Plant.Violets Plant.Radishes Plant.Violets Plant.Radishes]
⍤⤙≍ expected plants diagram student

# Full garden - for Bob, second student's garden
student = "Bob"
diagram = "VRCGVVRVCGGCCGVRGCVCGCGV\nVRCCCGCRRGVCGCRVVCVGCGCV"
expected = [Plant.Clover Plant.Grass Plant.Clover Plant.Clover]
⍤⤙≍ expected plants diagram student

# Full garden - for Charlie
student = "Charlie"
diagram = "VRCGVVRVCGGCCGVRGCVCGCGV\nVRCCCGCRRGVCGCRVVCVGCGCV"
expected = [Plant.Violets Plant.Violets Plant.Clover Plant.Grass]
⍤⤙≍ expected plants diagram student

# Full garden - for David
student = "David"
diagram = "VRCGVVRVCGGCCGVRGCVCGCGV\nVRCCCGCRRGVCGCRVVCVGCGCV"
expected = [Plant.Radishes Plant.Violets Plant.Clover Plant.Radishes]
⍤⤙≍ expected plants diagram student

# Full garden - for Eve
student = "Eve"
diagram = "VRCGVVRVCGGCCGVRGCVCGCGV\nVRCCCGCRRGVCGCRVVCVGCGCV"
expected = [Plant.Clover Plant.Grass Plant.Radishes Plant.Grass]
⍤⤙≍ expected plants diagram student

# Full garden - for Fred
student = "Fred"
diagram = "VRCGVVRVCGGCCGVRGCVCGCGV\nVRCCCGCRRGVCGCRVVCVGCGCV"
expected = [Plant.Grass Plant.Clover Plant.Violets Plant.Clover]
⍤⤙≍ expected plants diagram student

# Full garden - for Ginny
student = "Ginny"
diagram = "VRCGVVRVCGGCCGVRGCVCGCGV\nVRCCCGCRRGVCGCRVVCVGCGCV"
expected = [Plant.Clover Plant.Grass Plant.Grass Plant.Clover]
⍤⤙≍ expected plants diagram student

# Full garden - for Harriet
student = "Harriet"
diagram = "VRCGVVRVCGGCCGVRGCVCGCGV\nVRCCCGCRRGVCGCRVVCVGCGCV"
expected = [Plant.Violets Plant.Radishes Plant.Radishes Plant.Violets]
⍤⤙≍ expected plants diagram student

# Full garden - for Ileana
student = "Ileana"
diagram = "VRCGVVRVCGGCCGVRGCVCGCGV\nVRCCCGCRRGVCGCRVVCVGCGCV"
expected = [Plant.Grass Plant.Clover Plant.Violets Plant.Clover]
⍤⤙≍ expected plants diagram student

# Full garden - for Joseph
student = "Joseph"
diagram = "VRCGVVRVCGGCCGVRGCVCGCGV\nVRCCCGCRRGVCGCRVVCVGCGCV"
expected = [Plant.Violets Plant.Clover Plant.Violets Plant.Grass]
⍤⤙≍ expected plants diagram student

# Full garden - for Kincaid, second to last student's garden
student = "Kincaid"
diagram = "VRCGVVRVCGGCCGVRGCVCGCGV\nVRCCCGCRRGVCGCRVVCVGCGCV"
expected = [Plant.Grass Plant.Clover Plant.Clover Plant.Grass]
⍤⤙≍ expected plants diagram student

# Full garden - for Larry, last student's garden
student = "Larry"
diagram = "VRCGVVRVCGGCCGVRGCVCGCGV\nVRCCCGCRRGVCGCRVVCVGCGCV"
expected = [Plant.Grass Plant.Violets Plant.Clover Plant.Violets]
⍤⤙≍ expected plants diagram student

