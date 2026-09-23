module Student =
    type T =
        { Nume: string
          AnStudiu: int
          Medie: float }

    let creaza nume an medie =
        if an < 1 || an > 6 then
            failwith $"An de studiu invalid: {an}"
        if medie < 1.0 || medie > 10.0 then
            failwith $"Medie invalidă: {medie}"
        { Nume = nume; AnStudiu = an; Medie = medie }

    let estePromovat student = student.Medie >= 5.0

    let promoveaza student =
        if not (estePromovat student) then
            failwith $"{student.Nume} nu este promovat"
        { student with AnStudiu = student.AnStudiu + 1 }

    let formateaza student =
        $"{student.Nume} (anul {student.AnStudiu}, media {student.Medie:F2})"

// Utilizare
let ana = Student.creaza "Ana Popescu" 3 9.50
printfn "%s — promovat: %b" (Student.formateaza ana) (Student.estePromovat ana)

let anaAnul4 = Student.promoveaza ana
printfn "%s" (Student.formateaza anaAnul4)
