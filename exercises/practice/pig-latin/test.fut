import "pig_latin"

-- Word beginning with a
-- ==
-- input { "apple" }
-- output { "appleay" }

-- Word beginning with e
-- ==
-- input { "ear" }
-- output { "earay" }

-- Word beginning with i
-- ==
-- input { "igloo" }
-- output { "iglooay" }

-- Word beginning with o
-- ==
-- input { "object" }
-- output { "objectay" }

-- Word beginning with u
-- ==
-- input { "under" }
-- output { "underay" }

-- Word beginning with a vowel and followed by a qu
-- ==
-- input { "equal" }
-- output { "equalay" }

-- Word beginning with p
-- ==
-- input { "pig" }
-- output { "igpay" }

-- Word beginning with k
-- ==
-- input { "koala" }
-- output { "oalakay" }

-- Word beginning with x
-- ==
-- input { "xenon" }
-- output { "enonxay" }

-- Word beginning with q without a following u
-- ==
-- input { "qat" }
-- output { "atqay" }

-- Word beginning with ch
-- ==
-- input { "chair" }
-- output { "airchay" }

-- Word beginning with qu
-- ==
-- input { "queen" }
-- output { "eenquay" }

-- Word beginning with qu and a preceding consonant
-- ==
-- input { "square" }
-- output { "aresquay" }

-- Word beginning with th
-- ==
-- input { "therapy" }
-- output { "erapythay" }

-- Word beginning with thr
-- ==
-- input { "thrush" }
-- output { "ushthray" }

-- Word beginning with sch
-- ==
-- input { "school" }
-- output { "oolschay" }

-- Word beginning with yt
-- ==
-- input { "yttria" }
-- output { "yttriaay" }

-- Word beginning with xr
-- ==
-- input { "xray" }
-- output { "xrayay" }

-- Y is treated like a consonant at the beginning of a word
-- ==
-- input { "yellow" }
-- output { "ellowyay" }

-- Y is treated like a vowel at the end of a consonant cluster
-- ==
-- input { "rhythm" }
-- output { "ythmrhay" }

-- Y as second letter in two letter word
-- ==
-- input { "my" }
-- output { "ymay" }

-- A whole phrase
-- ==
-- input { "quick fast run" }
-- output { "ickquay astfay unray" }

