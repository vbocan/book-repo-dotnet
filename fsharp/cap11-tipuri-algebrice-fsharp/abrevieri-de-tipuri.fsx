type Nume = string
type Varsta = int
type ListaStudenti = (Nume * Varsta) list
type Transformator<'a> = 'a -> 'a

let studenti: ListaStudenti = [ ("Ana", 21); ("Ion", 22); ("Maria", 20) ]

let incrementeaza: Transformator<int> = fun x -> x + 1
let capitalizeaza: Transformator<string> = fun (s: string) -> s.ToUpper()

printfn "Studenți: %A" studenti
printfn "incrementeaza 5 = %d" (incrementeaza 5)
printfn "capitalizeaza \"ana\" = %s" (capitalizeaza "ana")
