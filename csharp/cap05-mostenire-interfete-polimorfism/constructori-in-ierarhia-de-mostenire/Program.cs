var obiect = new C();

class A
{
    public A()
    {
        Console.WriteLine("Constructor A");
    }
}

class B : A
{
    public B()
    {
        Console.WriteLine("Constructor B");
    }
}

class C : B
{
    public C()
    {
        Console.WriteLine("Constructor C");
    }
}
