// Funcție care primește unit și returnează unit
let afiseazaSalut () =
    printfn "Salut din F#!"

// Funcție care primește un parametru și returnează unit
let afiseazaNumar n =
    printfn $"Numărul este: {n}"

// Apeluri
afiseazaSalut ()
afiseazaNumar 42

// Verificarea tipului
let rezultat = afiseazaSalut ()
// Valoarea unit () este reprezentată ca null la rulare, deci rezultat.GetType()
// ar arunca o excepție; interogăm tipul direct cu typeof<unit>
printfn $"Tipul rezultatului: {typeof<unit>.Name}"
