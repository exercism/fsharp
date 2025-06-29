import "scale_generator"

-- Chromatic scale with sharps
-- ==
-- input { "C" }
-- output { ["C", "C#", "D", "D#", "E", "F", "F#", "G", "G#", "A", "A#", "B"] }

-- Chromatic scale with flats
-- ==
-- input { "F" }
-- output { ["F", "Gb", "G", "Ab", "A", "Bb", "B", "C", "Db", "D", "Eb", "E"] }

-- Simple major scale
-- ==
-- input { "MMmMMMm" "C" }
-- output { ["C", "D", "E", "F", "G", "A", "B", "C"] }

-- Major scale with sharps
-- ==
-- input { "MMmMMMm" "G" }
-- output { ["G", "A", "B", "C", "D", "E", "F#", "G"] }

-- Major scale with flats
-- ==
-- input { "MMmMMMm" "F" }
-- output { ["F", "G", "A", "Bb", "C", "D", "E", "F"] }

-- Minor scale with sharps
-- ==
-- input { "MmMMmMM" "f#" }
-- output { ["F#", "G#", "A", "B", "C#", "D", "E", "F#"] }

-- Minor scale with flats
-- ==
-- input { "MmMMmMM" "bb" }
-- output { ["Bb", "C", "Db", "Eb", "F", "Gb", "Ab", "Bb"] }

-- Dorian mode
-- ==
-- input { "MmMMMmM" "d" }
-- output { ["D", "E", "F", "G", "A", "B", "C", "D"] }

-- Mixolydian mode
-- ==
-- input { "MMmMMmM" "Eb" }
-- output { ["Eb", "F", "G", "Ab", "Bb", "C", "Db", "Eb"] }

-- Lydian mode
-- ==
-- input { "MMMmMMm" "a" }
-- output { ["A", "B", "C#", "D#", "E", "F#", "G#", "A"] }

-- Phrygian mode
-- ==
-- input { "mMMMmMM" "e" }
-- output { ["E", "F", "G", "A", "B", "C", "D", "E"] }

-- Locrian mode
-- ==
-- input { "mMMmMMM" "g" }
-- output { ["G", "Ab", "Bb", "C", "Db", "Eb", "F", "G"] }

-- Harmonic minor
-- ==
-- input { "MmMMmAm" "d" }
-- output { ["D", "E", "F", "G", "A", "Bb", "Db", "D"] }

-- Octatonic
-- ==
-- input { "MmMmMmMm" "C" }
-- output { ["C", "D", "D#", "F", "F#", "G#", "A", "B", "C"] }

-- Hexatonic
-- ==
-- input { "MMMMMM" "Db" }
-- output { ["Db", "Eb", "F", "G", "A", "B", "Db"] }

-- Pentatonic
-- ==
-- input { "MMAMA" "A" }
-- output { ["A", "B", "C#", "E", "F#", "A"] }

-- Enigmatic
-- ==
-- input { "mAMMMmm" "G" }
-- output { ["G", "G#", "B", "C#", "D#", "F", "F#", "G"] }

