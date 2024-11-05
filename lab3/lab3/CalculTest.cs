using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;
using System.Windows;

namespace lab3
{
    internal class CalculTest
    {
        public static AutomationElement calcUI;

        

        public CalculTest()
        {
            var calc = System.Diagnostics.Process.Start("calc");
            //wait for the UI to appear
            calc.WaitForInputIdle(5000);
            System.Threading.Thread.Sleep(2000);

            AutomationElement root = AutomationElement.RootElement;
            System.Windows.Automation.Condition condition = new PropertyCondition(AutomationElement.NameProperty, "Калькулятор");

            calcUI = root.FindFirst(TreeScope.Children, condition);
            if (calcUI != null)
            {
                // get and click the buttons for the calculation                   
                FindAndClickButton("Открывающая круглая скобка");
                
                FindAndClickButton("Два");
                FindAndClickButton("Квадрат");                

                FindAndClickButton("Плюс");

                FindAndClickButton("Один");
                FindAndClickButton("Пять");
                
                FindAndClickButton("Закрывающая круглая скобка");                  
                


                FindAndClickButton("Разделить на");


                FindAndClickButton("Открывающая круглая скобка");

                FindAndClickButton("Два");

                FindAndClickButton("Плюс");

                FindAndClickButton("Девять");

                FindAndClickButton("Закрывающая круглая скобка");

                FindAndClickButton("Квадратный корень");


                FindAndClickButton("Умножить на");


                FindAndClickButton("Один");
                FindAndClickButton("Нуль");
                FindAndClickButton("Квадратный корень");


                FindAndClickButton("Равно");
                //get the result
                System.Windows.Automation.Condition conditionResult = new PropertyCondition(AutomationElement.AutomationIdProperty, "CalculatorResults");
                var result = calcUI.FindFirst(TreeScope.Descendants, conditionResult);
                MessageBox.Show(result.Current.Name);
            }
            else
            {
                Console.WriteLine("Calculator not found");
            }
        }

        private void BaseTest()
        {
            // get and click the buttons for the calculation 
            FindAndClickButton("Открывающая круглая скобка");
            FindAndClickButton("Один");
            FindAndClickButton("Два");
            FindAndClickButton("Три");
            FindAndClickButton("Четыре");
            FindAndClickButton("Пять");
            FindAndClickButton("Шесть");
            FindAndClickButton("Восемь");
            FindAndClickButton("Девять");
            FindAndClickButton("Закрывающая круглая скобка");

            FindAndClickButton("Минус");
            FindAndClickButton("Плюс");
            FindAndClickButton("Умножить на");
            FindAndClickButton("Разделить на");

            FindAndClickButton("Нуль");
            FindAndClickButton("Квадрат");
            FindAndClickButton("Квадратный корень");

            FindAndClickButton("Равно");
            //get the result
            System.Windows.Automation.Condition conditionResult = new PropertyCondition(AutomationElement.AutomationIdProperty, "CalculatorResults");
            var result = calcUI.FindFirst(TreeScope.Descendants, conditionResult);
            MessageBox.Show(result.Current.Name);
        }
        private void FindAndClickButton(string name)
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
