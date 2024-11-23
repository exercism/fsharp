~ "rail-fence-cipher.ua" ~ RailFenceCipher

# Encode with two rails
rails = 2
msg = "XOXOXOXOXOXOXOXOXO"
expected = "XXXXXXXXXOOOOOOOOO"
⍤⤙≍ expected encode rails msg

# Encode with three rails
rails = 3
msg = "WEAREDISCOVEREDFLEEATONCE"
expected = "WECRLTEERDSOEEFEAOCAIVDEN"
⍤⤙≍ expected encode rails msg

# Encode with ending in the middle
rails = 4
msg = "EXERCISES"
expected = "ESXIEECSR"
⍤⤙≍ expected encode rails msg

# Decode with three rails
rails = 3
msg = "TEITELHDVLSNHDTISEIIEA"
expected = "THEDEVILISINTHEDETAILS"
⍤⤙≍ expected decode rails msg

# Decode with five rails
rails = 5
msg = "EIEXMSMESAORIWSCE"
expected = "EXERCISMISAWESOME"
⍤⤙≍ expected decode rails msg

# Decode with six rails
rails = 6
msg = "133714114238148966225439541018335470986172518171757571896261"
expected = "112358132134558914423337761098715972584418167651094617711286"
⍤⤙≍ expected decode rails msg

