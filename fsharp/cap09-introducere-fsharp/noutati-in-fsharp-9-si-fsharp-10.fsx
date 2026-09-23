// F# 9: proprietăți .Is* generate automat pentru cazurile unei uniuni
type Contact =
    | Email of string
    | Telefon of string

let contacte = [Email "ana@upt.ro"; Telefon "0721123456"; Email "ion@upt.ro"]
let emailuri = contacte |> List.filter _.IsEmail
printfn $"Contacte de tip email: {emailuri.Length}"

// F# 9: un active pattern parțial poate returna direct bool
let (|Par|_|) n = n % 2 = 0
let paritate n = match n with Par -> "par" | _ -> "impar"
printfn $"7 este {paritate 7}, 10 este {paritate 10}"
