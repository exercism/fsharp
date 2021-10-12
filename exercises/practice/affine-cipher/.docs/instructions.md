# Instructions

Create an implementation of the affine cipher,
an ancient encryption system created in the Middle East.

The affine cipher is a type of monoalphabetic substitution cipher.
Each character is mapped to its numeric equivalent, encrypted with
a mathematical function and then converted to the letter relating to
its new numeric value. Although all monoalphabetic ciphers are weak,
the affine cypher is much stronger than the atbash cipher,
because it has many more keys.

## Encoding

The encoding function is:

  `E(x) = (ax + b) mod m`
  -  where `x` is the letter's index from `0` to the length of the alphabet - 1
  -  `m` is the length of the alphabet. For the roman alphabet `m = 26`.
  -  `a` and `b` are integers which make the key
  -  `a` and `m` are coprime (or, relatively prime) - they have number `1` as their only common factor (more information
     about coprime numbers can be found [here](https://en.wikipedia.org/wiki/Coprime_integers)).

Because automatic decoding fails if `a` is not coprime to `m` your
program should return status `1` and `"Error: a and m must be coprime."`
if they are not.  Otherwise it should encode or decode with the
provided key.

Digits are valid input but are not encoded. Spaces and punctuation characters are excluded.

## Decoding

The decoding function is:

  `D(y) = (a^-1)(y - b) mod m`
  -  where `y` is the numeric value of an encrypted letter, ie. `y = E(x)`
  -  it is important to note that `a^-1` is the modular multiplicative inverse (MMI)
     of `a mod m`
  -  the modular multiplicative inverse of `a` only exists if `a` and `m` are
     coprime

The MMI of `a` is `x` such that the remainder after dividing `ax` by `m` is `1`, or:

  `ax mod m = 1`

More details regarding how to find a Modular Multiplicative Inverse
and what it means can be found [here](https://en.wikipedia.org/wiki/Modular_multiplicative_inverse).

Ciphertext is written out in groups of fixed length, the traditional group
size being five letters. This is to make it harder to guess the text based on word boundaries.

## General Examples

 - Encoding `test` gives `ybty` with the key `a = 5`, `b = 7`
 - Decoding `ybty` gives `test` with the key `a = 5`, `b = 7`
 - Decoding `ybty` gives `lqul` with the wrong key `a = 11`, `b = 7`
 - Decoding `kqlfd jzvgy tpaet icdhm rtwly kqlon ubstx`
   - gives `thequickbrownfoxjumpsoverthelazydog` with the key `a = 19`, `b = 13`
 - Encoding `test` with the key `a = 18`, `b = 13`
   - gives `Error: a and m must be coprime.`
   - because `a` and `m` are not relatively prime

## Example of finding a Modular Multiplicative Inverse (MMI)

Example for `a = 15`:
  - `(15 * 7) mod 26 = 1`
  - `7` is the MMI of `15 mod 26`
