namespace pr1;


public static class Global
{
    public static List<IEatable> Eatable = new List<IEatable>();
    public static Khinkali? Khin { get; set; }
    public static Vareniki? Varen { get; set; }
    public static Mantas? Mant { get; set; }
    public static Buuzi? Buuz { get; set; }
    public static Wontons? Wont { get; set; }
    public static Ravioli? Ravi { get; set; }
}

class Tasks
{
    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.Write("Введите номер задания с помощью цифр 1, 2, 3 или 0 для выхода: ");
            int input;

            if (int.TryParse(Console.ReadLine(), out input) && input >= 0 && input <= 3)
            {
                switch (input)
                {
                    case 1:
                        Menu1.Start();
                        break;
                    case 2:
                        Menu2.Start();
                        break;
                    case 3:
                        Menu3.Start();
                        break;
                    case 0:
                        return;
                }
            }
        }
    }
}
