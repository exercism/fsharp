~ "rail-fence-cipher.ua" ~ RailFenceCipher

# Encode with two rails
    let rails = 2
    let msg = "XOXOXOXOXOXOXOXOXO"
    let expected = "XXXXXXXXXOOOOOOOOO"
⍤⤙≍ expected encode rails msg

# Encode with three rails
    let rails = 3
    let msg = "WEAREDISCOVEREDFLEEATONCE"
    let expected = "WECRLTEERDSOEEFEAOCAIVDEN"
⍤⤙≍ expected encode rails msg

# Encode with ending in the middle
    let rails = 4
    let msg = "EXERCISES"
    let expected = "ESXIEECSR"
⍤⤙≍ expected encode rails msg

# Decode with three rails
    let rails = 3
    let msg = "TEITELHDVLSNHDTISEIIEA"
    let expected = "THEDEVILISINTHEDETAILS"
⍤⤙≍ expected decode rails msg

# Decode with five rails
    let rails = 5
    let msg = "EIEXMSMESAORIWSCE"
    let expected = "EXERCISMISAWESOME"
⍤⤙≍ expected decode rails msg

# Decode with six rails
    let rails = 6
    let msg = "133714114238148966225439541018335470986172518171757571896261"
    let expected = "112358132134558914423337761098715972584418167651094617711286"
⍤⤙≍ expected decode rails msg

