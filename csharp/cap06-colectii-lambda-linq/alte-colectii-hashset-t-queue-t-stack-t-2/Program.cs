Queue<string> coadaImprimare = new();
coadaImprimare.Enqueue("Document1.pdf");
coadaImprimare.Enqueue("Raport.docx");
coadaImprimare.Enqueue("Prezentare.pptx");

Console.WriteLine($"Următorul în coadă: {coadaImprimare.Peek()}");

while (coadaImprimare.Count > 0)
{
    string document = coadaImprimare.Dequeue();
    Console.WriteLine($"Imprimare: {document}");
}
