// Tema 2 — Calculator simplu cu pattern matching
// Capitolul 9: Introducere în F#
// Rulare: dotnet fsi fsharp/cap09-introducere-fsharp/tema-pentru-acasa-2.fsx

// Returnează Some rezultat sau None (împărțire/rest cu zero, operator necunoscut)
let calculeaza (a: float) (operator: string) (b: float) : float option =
    match operator with
    | "+" -> Some(a + b)
    | "-" -> Some(a - b)
    | "*" -> Some(a * b)
    | "/" when b = 0.0 -> None
    | "/" -> Some(a / b)
    | "%" when b = 0.0 -> None
    | "%" -> Some(a % b)
    | "^" -> Some(a ** b)
    | _ -> None

let operatii =
    [ (10.0, "+", 3.0)
      (10.0, "-", 3.0)
      (10.0, "*", 3.0)
      (10.0, "/", 3.0)
      (10.0, "/", 0.0)
      (10.0, "%", 3.0)
      (2.0, "^", 10.0)
      (5.0, "&", 3.0) ]

printfn "=== Calculator ==="
for (a, op, b) in operatii do
    match calculeaza a op b with
    | Some rezultat -> printfn "  %g %s %g = %.2f" a op b rezultat
    | None -> printfn "  %g %s %g = eroare (operator invalid sau împărțire la zero)" a op b
