using static lab4.CalculAPI;
namespace lab4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CalculAPI calcul = getInstance();
            // по задумке тестерование должно происходить с Nunit
            // testcase получим с json, и можно запихнуть в тест метод
            // вся подготовка пройтет в методе с атрибутом setupы
        }
    }
}
