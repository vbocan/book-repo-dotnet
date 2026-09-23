module Validare =
    [<CompiledName("EsteEmailValid")>]
    let esteEmailValid (email: string) =
        email.Contains("@") && email.Contains(".")

    [<CompiledName("EsteNotaValida")>]
    let esteNotaValida nota =
        nota >= 1 && nota <= 10

// Din F#: Validare.esteEmailValid "test@upt.ro"
// Din C#: Validare.EsteEmailValid("test@upt.ro")

printfn "Email valid: %b" (Validare.esteEmailValid "ana@upt.ro")
printfn "Notă validă: %b" (Validare.esteNotaValida 9)
