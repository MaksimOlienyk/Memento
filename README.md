# Memento - Патерн Проєктування

Патерн Memento дозволяє зберігати та відновлювати стан об'єкта, не порушуючи інкапсуляцію.  
Об'єкт сам створює "знімок" свого стану і може пізніше повернутися до нього.

## Ідея

- **Originator** має внутрішній стан.
- Він створює об’єкт **Memento**, який зберігає цей стан.
- Клієнт або керуючий код зберігає мементо, але не змінює його.
- Пізніше **Originator** може відновити свій стан з Memento.

## Структура

| Елемент     | Опис |
|------------|------|
| `Originator` | Об’єкт, стан якого зберігається |
| `Memento`   | Зберігає стан Originator |
| Клієнт     | Вирішує, коли зберігати і коли відновлювати стан |

## Код

```csharp
class Memento {
    public string State;
    public Memento(string s) { State = s; }
}

class Originator {
    public string State;
    public Memento Save() => new(State);
    public void Restore(Memento m) => State = m.State;
}

class Program {
    static void Main() {
        var o = new Originator { State = "A" };
        var m = o.Save();   // Зберегли стан

        o.State = "B";      // Змінили стан
        o.Restore(m);       // Відновили стан

        Console.WriteLine(o.State);
    }
}
