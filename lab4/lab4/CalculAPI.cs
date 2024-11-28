using System.Windows.Automation;

namespace lab4
{
    public class CalculAPI
    {
        private  AutomationElement calcUI = null;

        private static CalculAPI instance;

        

        public static CalculAPI getInstance()
        {
            if (instance == null)
                instance = new CalculAPI();
            return instance;
        }

        CalculAPI()
        {
            var calc = System.Diagnostics.Process.Start("calc");
            //wait for the UI to appear
            calc.WaitForInputIdle(5000);
            System.Threading.Thread.Sleep(2000);

            AutomationElement root = AutomationElement.RootElement;
            System.Windows.Automation.Condition condition = new PropertyCondition(AutomationElement.NameProperty, "Калькулятор");

            calcUI = root.FindFirst(TreeScope.Children, condition);

            if (calcUI == null)
                throw new NullReferenceException("Calcul not found");
        }

        public static class NumbersButtonRU
        {
            public const string
                Zero = "Нуль",
                One = "Один",
                Two = "Два",
                Three = "Три",
                Four = "Четыре",
                Five = "Пять",
                Six = "Шесть",
                Seven = "Семь",
                Eight = "Восемь",
                Nine = "Девять";
        }
        public static class OperationsButtonRU
        {
            public const string
                Minus = "Минус",
                Plus = "Плюс",
                Multiplication = "Умножить на",
                Division = "Разделить на",
                Square = "Квадрат",
                SquareRoot = "Квадратный корень",
                Equal = "Равно";
        }

        public static class SymbolsButtonRU
        {
            public const string
                OpeningParenthesis = "Открывающая круглая скобка",
                ClosingParenthesis = "Закрывающая круглая скобка";
        }

        public string GetResult()
        {
            System.Windows.Automation.Condition conditionResult = new PropertyCondition(AutomationElement.AutomationIdProperty, "CalculatorResults");
            var result = calcUI.FindFirst(TreeScope.Descendants, conditionResult);
            return result.Current.Name;
        }
        public void FindAndClickButton(string name)
        {
            
            System.Windows.Automation.Condition condition1 = new PropertyCondition(AutomationElement.ClassNameProperty, "Button");
            System.Windows.Automation.Condition condition2 = new PropertyCondition(AutomationElement.NameProperty, name);
            System.Windows.Automation.Condition condition = new AndCondition(condition1, condition2);
            AutomationElement button = calcUI.FindFirst(TreeScope.Descendants, condition);

            if (button == null) Console.WriteLine($"not found '{name}'");
            else
            {
                InvokePattern btnPattern = button.GetCurrentPattern(InvokePattern.Pattern) as InvokePattern;
                btnPattern.Invoke();
            }
        }
    }
}
