let rec map f = function [] -> [] | x :: rest -> (f x) :: (map f rest)
let rec filter pred = function
    | [] -> [] | x :: rest when pred x -> x :: (filter pred rest)
    | _ :: rest -> filter pred rest
let fold f init lista =
    let rec loop acc = function [] -> acc | x :: rest -> loop (f acc x) rest
    loop init lista

let numere = [1 .. 10]
printfn "map (pătrate): %A" (map (fun x -> x * x) numere)
printfn "filter (pare): %A" (filter (fun x -> x % 2 = 0) numere)
printfn "fold (sumă): %d" (fold (fun acc x -> acc + x) 0 numere)
