namespace pr1;


class Menu2
{
    public static void Start()
    {
        int weight, meat;
        (weight, meat) = ReadTwoNumbers();
        Global.Buuz = new Buuzi(weight, meat, "Буззы");
        Global.Wont = new Wontons(weight, meat, "Вонтоны");
        Global.Mant = new Mantas(weight, meat, "Манты");
        Global.Ravi = new Ravioli(weight, meat, "Равиоли");
        Global.Varen = new Vareniki(weight, meat, "Вареники");
        Console.Clear();
        StartMenu();
    }

    public static (int, int) ReadTwoNumbers()
    {
        int number1 = 0, number2 = 0;
        bool validInput = false;

        while (!validInput)
        {
            Console.Clear();
            Console.WriteLine("Введите параметры хинкали: общий вес и вес мяса");
            Console.Write("Введите два числа через пробел: ");
            string? input = Console.ReadLine();
            string[] numbers = input.Split(' ');

            if (numbers.Length == 2 && int.TryParse(numbers[0], out number1) &&
                int.TryParse(numbers[1], out number2) && (number1 > number2) && number1 > 0 && number2 > 0)
            {
                validInput = true;
            }
            else
            {
                Console.WriteLine("Неверный ввод. Пожалуйста, введите два числа через пробел.");
            }
        }

        return (number1, number2);
    }

    static void StartMenu()
    {
        int command;
        while (true)
        {
            MenuVisualiser();
            while (!(int.TryParse(Console.ReadLine(), out command)))
            {
                Console.Clear();
                MenuVisualiser();
            }
            Console.Clear();
            switch (command)
            {
                case 1:
                    MenuFirst();
                    return;
                case 2:
                    MenuSecond();
                    break;
                case 3:
                    MenuThird();
                    break;
                case 4:
                    MenuFourth();
                    break;
                case 0 :
                    return;
            }
        }
    }
        
    static void MenuVisualiser()
    {
        Console.WriteLine("1. Поменять");
        Console.WriteLine("2. Вывод параметров");
        Console.WriteLine("3. Имя?");
        Console.WriteLine("4. Приготовить и добавить соус");
        Console.WriteLine("0. Выход");
        Console.WriteLine("Напишите цифру пункта меню для выбора");
    }

    static void MenuFirst()
    {
        Start();
    }

    static void MenuSecond()
    { 
        Global.Varen.FindOutInformation();
        Global.Mant.FindOutInformation();
        Global.Ravi.FindOutInformation();
        Global.Buuz.FindOutInformation();
        Global.Wont.FindOutInformation();
        Console.ReadKey();
        Console.Clear();
    }

    static void MenuThird()
    {
        Global.Varen.GetName();
        Global.Buuz.GetName();
        Global.Wont.GetName();
        Global.Mant.GetName();
        Global.Ravi.GetName();
        Console.ReadKey();
        Console.Clear();
    }

    static void MenuFourth()
    {
        Global.Buuz.Cook();
        Global.Buuz.AddSauce();
        Global.Mant.Cook();
        Global.Mant.AddSauce();
        Global.Wont.Cook();
        Global.Wont.AddSauce();
        Global.Ravi.Cook();
        Global.Ravi.AddSauce();
        Global.Varen.Cook();
        Global.Varen.AddSauce();
        Console.ReadKey();
        Console.Clear();
    }
}
public abstract class Dumplings
{
    private readonly Size _size;

    private string Name { get; set; }
    private bool _addedSauce = false;
    private int Weight { get; set; }
    public bool Cooked { get; set; } = false;
    private int AmountOfMeat { get; set; }
    private bool PresenceOfCilantro { get; set; }
    private int NumberOfFolds { get; set; }

    private enum Size
    {
        Small,
        Medium,
        Large
    }


    protected Dumplings()
    {
        Name = "";
        _size = Size.Small;
        _addedSauce = false;
        Weight = 0;
        Cooked = false;
        AmountOfMeat = 0;
        PresenceOfCilantro = false;
        NumberOfFolds = 0;
    }

    protected Dumplings(int weight, int meat, string name)
    {
        Weight = weight;
        AmountOfMeat = meat;
        PresenceOfCilantro = true;
        Name = name;
            
        switch (Weight)
        {
            case <= 75 and > 0:
                _size = Size.Small;
                break;
            case > 75 and <= 150:
                _size = Size.Medium;
                break;
            case > 150:
                _size = Size.Large;
                break;
        }
    }

    public virtual void Cook()
    {
        Cooked = true;
        Console.WriteLine($"{Name} готовы");
    }


    public void AddSauce()
    {
        if (_addedSauce)
        {
            Console.WriteLine("А не много будет соуса???");
            return;
        }

        Console.WriteLine("Соус добавлен");
        _addedSauce = true;
    }
    public virtual void FindOutInformation()
    {
        Console.WriteLine(ToString());
        Console.WriteLine($"Начинка: {AmountOfMeat}г, тесто: {Weight - AmountOfMeat}г");
            
        if (PresenceOfCilantro){
            Console.WriteLine("Кинза на месте, отвечаю");
            return;
        }
        Console.WriteLine("Кинзы нет:(");
    }
    public override string ToString()
    {
        return $"{Name}: вес - {Weight}, размер - {_size}, наличие соуса - {_addedSauce}";
    }

    protected void GetBaseName()
    {
        Console.Write(GetType().BaseType.Name + ": ");
    }
}

public sealed class Vareniki : Dumplings
{
    private int MyField { get; set; }
    private void MyMethod()
    {
    }
    public Vareniki(int weight, int meat, string name) : base(weight, meat, name)
    {
    }
    public void Recept()
    {
        Console.WriteLine("Тут должен быть рецепт вареников");
    }
    public override void Cook()
    {
        base.Cook();
    }

    public void GetName()
    {
        GetBaseName();
        Console.WriteLine(GetType().Name);
    }
}
public class Mantas : Dumplings
{
    private int MyField { get; set; }
    private void MyMethod()
    {
    }
    public Mantas(int weight, int meat, string name) : base(weight, meat, name)
    {
    }
    public void Recept()
    {
        Console.WriteLine("Тут должен быть рецепт мант");
    }
    public override void Cook()
    {
        base.Cook();
    }
    public void GetName()
    {
        GetBaseName();
        Console.WriteLine(GetType().Name);
    }
}
public class Buuzi : Dumplings
{
    private int MyField { get; set; }
    private void MyMethod()
    {
    }
    
    public Buuzi(int weight, int meat, string name) : base(weight, meat, name)
    {
    }
    public void Recept()
    {
        Console.WriteLine("Тут должен быть рецепт буззов");
    }
    public override void Cook()
    {
        base.Cook();
    }
    public void GetName()
    {
        GetBaseName();
        Console.WriteLine(GetType().Name);
    }
}
public class Wontons : Dumplings
{
    private int MyField { get; set; }
    private void MyMethod()
    {
    }
    public Wontons(int weight, int meat, string name) : base(weight, meat, name)
    {
    }
    public void Recept()
    {
        Console.WriteLine("Тут должен быть рецепт вонтонов");
    }
    public override void Cook()
    {
        base.Cook();
    }
    public void GetName()
    {
        GetBaseName();
        Console.WriteLine(GetType().Name);
    }
}
public class Ravioli : Dumplings
{
    private int MyField { get; set; }
    private void MyMethod()
    {
    }
    public Ravioli(int weight, int meat, string name) : base(weight, meat, name)
    {
    }
    public void Recept()
    {
        Console.WriteLine("Тут должен быть рецепт равиолей");
    }

    public override void Cook()
    {
        base.Cook();
    }
    public void GetName()
    {
        GetBaseName();
        Console.WriteLine(GetType().Name);
    }
}
