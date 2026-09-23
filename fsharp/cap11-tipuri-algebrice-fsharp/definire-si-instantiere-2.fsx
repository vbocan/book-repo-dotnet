type Student =
    { Nume: string
      AnStudiu: int
      Medie: float }

type Profesor =
    { Nume: string
      Departament: string
      AnAngajare: int }

// Calificare explicită — necesară deoarece ambele tipuri au câmpul Nume
let prof: Profesor = { Nume = "Dr. Ionescu"; Departament = "Calculatoare"; AnAngajare = 2015 }
let stud: Student = { Nume = "Ana Dragomir"; AnStudiu = 3; Medie = 9.80 }

printfn "Profesor: %s, departament: %s" prof.Nume prof.Departament
printfn "Student: %s, anul %d" stud.Nume stud.AnStudiu
