module Student =
    type T =
        { Nume: string
          AnStudiu: int
          Medie: float }

    let creaza nume an medie =
        { Nume = nume; AnStudiu = an; Medie = medie }

    let estePromovat student = student.Medie >= 5.0
    let formateaza student = $"{student.Nume} (anul {student.AnStudiu}, media {student.Medie:F2})"

let studenti =
    [ Student.creaza "Ana" 3 9.50
      Student.creaza "Ion" 3 4.80
      Student.creaza "Maria" 3 7.25
      Student.creaza "Vlad" 3 3.90 ]

studenti
|> List.filter Student.estePromovat
|> List.map Student.formateaza
|> List.iter (printfn "  %s")
