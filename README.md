# Builder Example

Цей репозиторій містить приклад патерну проектування "Будівельник".

## Патерн Будівельник (Builder)

Патерн "Будівельник" відокремлює створення складного об'єкта від його представлення, дозволяючи будувати різні об'єкти одним і тим же процесом.

### Приклад коду:

```csharp
// Product
public class House
{
    public string Walls { get; set; }
    public string Roof { get; set; }
    public string Foundation { get; set; }
    public string Interior { get; set; }

    public override string ToString()
    {
        return $"House with {Walls} walls, {Roof} roof, {Foundation} foundation, and {Interior} interior.";
    }
}
