type SimpleCipher(key: []u8) =
    
    member __.Key with get() = ???
    
    member __.Encode(plaintext) = ???
    
    member __.Decode(ciphertext) = ???
    
    new() = ???