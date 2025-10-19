class Memento { public string State; public Memento(string s) { State = s; } }
class Originator
{
    public string State;
    public Memento Save() => new(State);
    public void Restore(Memento m) => State = m.State;
}

class Program
{
    static void Main()
    {
        var o = new Originator { State = "A" };
        var m = o.Save();
        o.State = "B"; o.Restore(m);
        Console.WriteLine(o.State);
    }
}
