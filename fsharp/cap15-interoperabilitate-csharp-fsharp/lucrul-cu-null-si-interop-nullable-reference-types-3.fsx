open System

let valoareNullable: Nullable<int> = Nullable(42)
let valoareGoala: Nullable<int> = Nullable()

let optiune1 = Option.ofNullable valoareNullable  // Some 42
let optiune2 = Option.ofNullable valoareGoala      // None

printfn "Nullable(42) -> Option: %A" optiune1
printfn "Nullable() -> Option: %A" optiune2

// Conversie înapoi
let inapoi = Option.toNullable optiune1
printfn "Option -> Nullable: %A (HasValue: %b)" inapoi inapoi.HasValue
