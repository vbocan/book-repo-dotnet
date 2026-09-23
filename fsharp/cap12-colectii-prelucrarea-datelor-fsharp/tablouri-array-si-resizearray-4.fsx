let studenti = ResizeArray<string>()
studenti.Add("Ana")
studenti.Add("Ion")
studenti.Add("Maria")

printfn "Studenți: %A" (studenti |> Seq.toList)
printfn "Număr: %d" studenti.Count

studenti.RemoveAt(1)
printfn "După ștergere: %A" (studenti |> Seq.toList)
