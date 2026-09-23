// Struct tuple — tip valoare, fără alocare pe heap
let punctStruct = struct (10.0, 20.0)

// Deconstrucție
let struct (x, y) = punctStruct
printfn $"Punct struct: ({x}, {y})"
