open System.Net.Http

let descarcaPagina (url: string) = task {
    use client = new HttpClient()
    let! continut = client.GetStringAsync(url)
    return continut.Length
}

let afiseazaLungime url = task {
    try
        let! lungime = descarcaPagina url
        printfn "  %s: %d caractere" url lungime
    with
    | ex -> printfn "  %s: Eroare — %s" url ex.Message
}

// Execuție sincronă (pentru demonstrație)
afiseazaLungime "https://httpbin.org/html" |> fun t -> t.Wait()
