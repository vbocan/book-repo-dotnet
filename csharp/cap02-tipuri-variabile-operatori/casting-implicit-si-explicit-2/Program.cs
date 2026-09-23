double valoareReala = 9.78;
int valoareIntreaga = (int)valoareReala;  // trunchierea părții zecimale
Console.WriteLine($"double {valoareReala} → int {valoareIntreaga}");

int numarMare = 300;
byte numarMic = (byte)numarMare;  // overflow! 300 nu încape în byte
Console.WriteLine($"int {numarMare} → byte {numarMic}");

long valoareLunga = 3_000_000_000L;
int valoareScurta = (int)valoareLunga;  // overflow!
Console.WriteLine($"long {valoareLunga} → int {valoareScurta}");
