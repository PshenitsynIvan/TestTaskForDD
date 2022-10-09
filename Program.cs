
using TestTaskForDD;

Menu menu = new Menu();

try
{
    menu.StartApp();
    
}

catch (Exception ex)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine();
    Console.WriteLine($" Ошибка:{ex.Message}");
    Console.ResetColor();
    menu.StartAgain();

}

finally
{
    menu.Dispose();
}

