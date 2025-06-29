type SimpleCipher(key: []u8) =
    
    member __.Key with get() = failwith "You need to implement this function."
    
    member __.Encode(plaintext) = failwith "You need to implement this function."
    
    member __.Decode(ciphertext) = failwith "You need to implement this function."
    
    new() = failwith "You need to implement this function."