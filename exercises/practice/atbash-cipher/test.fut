import "atbash_cipher"

-- Encode yes
-- ==
-- input { "yes" }
-- output { "bvh" }

-- Encode no
-- ==
-- input { "no" }
-- output { "ml" }

-- Encode OMG
-- ==
-- input { "OMG" }
-- output { "lnt" }

-- Encode spaces
-- ==
-- input { "O M G" }
-- output { "lnt" }

-- Encode mindblowingly
-- ==
-- input { "mindblowingly" }
-- output { "nrmwy oldrm tob" }

-- Encode numbers
-- ==
-- input { "Testing,1 2 3, testing." }
-- output { "gvhgr mt123 gvhgr mt" }

-- Encode deep thought
-- ==
-- input { "Truth is fiction." }
-- output { "gifgs rhurx grlm" }

-- Encode all the letters
-- ==
-- input { "The quick brown fox jumps over the lazy dog." }
-- output { "gsvjf rxpyi ldmul cqfnk hlevi gsvoz abwlt" }

-- Decode exercism
-- ==
-- input { "vcvix rhn" }
-- output { "exercism" }

-- Decode a sentence
-- ==
-- input { "zmlyh gzxov rhlug vmzhg vkkrm thglm v" }
-- output { "anobstacleisoftenasteppingstone" }

-- Decode numbers
-- ==
-- input { "gvhgr mt123 gvhgr mt" }
-- output { "testing123testing" }

-- Decode all the letters
-- ==
-- input { "gsvjf rxpyi ldmul cqfnk hlevi gsvoz abwlt" }
-- output { "thequickbrownfoxjumpsoverthelazydog" }

-- Decode with too many spaces
-- ==
-- input { "vc vix    r hn" }
-- output { "exercism" }

-- Decode with no spaces
-- ==
-- input { "zmlyhgzxovrhlugvmzhgvkkrmthglmv" }
-- output { "anobstacleisoftenasteppingstone" }

