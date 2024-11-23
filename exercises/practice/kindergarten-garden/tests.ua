~ "kindergarten-garden.ua" ~ KindergartenGarden

# Partial garden - garden with single student
    let student = "Alice"
    let diagram = "RC\nGG"
    let expected = [Plant.Radishes Plant.Clover Plant.Grass Plant.Grass]
⍤⤙≍ expected plants diagram student

# Partial garden - different garden with single student
    let student = "Alice"
    let diagram = "VC\nRC"
    let expected = [Plant.Violets Plant.Clover Plant.Radishes Plant.Clover]
⍤⤙≍ expected plants diagram student

# Partial garden - garden with two students
    let student = "Bob"
    let diagram = "VVCG\nVVRC"
    let expected = [Plant.Clover Plant.Grass Plant.Radishes Plant.Clover]
⍤⤙≍ expected plants diagram student

# Partial garden - multiple students for the same garden with three students - second student's garden
    let student = "Bob"
    let diagram = "VVCCGG\nVVCCGG"
    let expected = [Plant.Clover Plant.Clover Plant.Clover Plant.Clover]
⍤⤙≍ expected plants diagram student

# Partial garden - multiple students for the same garden with three students - third student's garden
    let student = "Charlie"
    let diagram = "VVCCGG\nVVCCGG"
    let expected = [Plant.Grass Plant.Grass Plant.Grass Plant.Grass]
⍤⤙≍ expected plants diagram student

# Full garden - for Alice, first student's garden
    let student = "Alice"
    let diagram = "VRCGVVRVCGGCCGVRGCVCGCGV\nVRCCCGCRRGVCGCRVVCVGCGCV"
    let expected = [Plant.Violets Plant.Radishes Plant.Violets Plant.Radishes]
⍤⤙≍ expected plants diagram student

# Full garden - for Bob, second student's garden
    let student = "Bob"
    let diagram = "VRCGVVRVCGGCCGVRGCVCGCGV\nVRCCCGCRRGVCGCRVVCVGCGCV"
    let expected = [Plant.Clover Plant.Grass Plant.Clover Plant.Clover]
⍤⤙≍ expected plants diagram student

# Full garden - for Charlie
    let student = "Charlie"
    let diagram = "VRCGVVRVCGGCCGVRGCVCGCGV\nVRCCCGCRRGVCGCRVVCVGCGCV"
    let expected = [Plant.Violets Plant.Violets Plant.Clover Plant.Grass]
⍤⤙≍ expected plants diagram student

# Full garden - for David
    let student = "David"
    let diagram = "VRCGVVRVCGGCCGVRGCVCGCGV\nVRCCCGCRRGVCGCRVVCVGCGCV"
    let expected = [Plant.Radishes Plant.Violets Plant.Clover Plant.Radishes]
⍤⤙≍ expected plants diagram student

# Full garden - for Eve
    let student = "Eve"
    let diagram = "VRCGVVRVCGGCCGVRGCVCGCGV\nVRCCCGCRRGVCGCRVVCVGCGCV"
    let expected = [Plant.Clover Plant.Grass Plant.Radishes Plant.Grass]
⍤⤙≍ expected plants diagram student

# Full garden - for Fred
    let student = "Fred"
    let diagram = "VRCGVVRVCGGCCGVRGCVCGCGV\nVRCCCGCRRGVCGCRVVCVGCGCV"
    let expected = [Plant.Grass Plant.Clover Plant.Violets Plant.Clover]
⍤⤙≍ expected plants diagram student

# Full garden - for Ginny
    let student = "Ginny"
    let diagram = "VRCGVVRVCGGCCGVRGCVCGCGV\nVRCCCGCRRGVCGCRVVCVGCGCV"
    let expected = [Plant.Clover Plant.Grass Plant.Grass Plant.Clover]
⍤⤙≍ expected plants diagram student

# Full garden - for Harriet
    let student = "Harriet"
    let diagram = "VRCGVVRVCGGCCGVRGCVCGCGV\nVRCCCGCRRGVCGCRVVCVGCGCV"
    let expected = [Plant.Violets Plant.Radishes Plant.Radishes Plant.Violets]
⍤⤙≍ expected plants diagram student

# Full garden - for Ileana
    let student = "Ileana"
    let diagram = "VRCGVVRVCGGCCGVRGCVCGCGV\nVRCCCGCRRGVCGCRVVCVGCGCV"
    let expected = [Plant.Grass Plant.Clover Plant.Violets Plant.Clover]
⍤⤙≍ expected plants diagram student

# Full garden - for Joseph
    let student = "Joseph"
    let diagram = "VRCGVVRVCGGCCGVRGCVCGCGV\nVRCCCGCRRGVCGCRVVCVGCGCV"
    let expected = [Plant.Violets Plant.Clover Plant.Violets Plant.Grass]
⍤⤙≍ expected plants diagram student

# Full garden - for Kincaid, second to last student's garden
    let student = "Kincaid"
    let diagram = "VRCGVVRVCGGCCGVRGCVCGCGV\nVRCCCGCRRGVCGCRVVCVGCGCV"
    let expected = [Plant.Grass Plant.Clover Plant.Clover Plant.Grass]
⍤⤙≍ expected plants diagram student

# Full garden - for Larry, last student's garden
    let student = "Larry"
    let diagram = "VRCGVVRVCGGCCGVRGCVCGCGV\nVRCCCGCRRGVCGCRVVCVGCGCV"
    let expected = [Plant.Grass Plant.Violets Plant.Clover Plant.Violets]
⍤⤙≍ expected plants diagram student

