using System.Diagnostics;
using System.Windows.Automation;
namespace lab3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Process p = Process.Start("calc");

            AutomationElement aeDesktop = AutomationElement.RootElement;

            Condition frame = new PropertyCondition(AutomationElement.ClassNameProperty, "CalcFrame");
            AutomationElement c_frame = aeDesktop.FindFirst(TreeScope.Children, frame);

            //Click button
           /* Condition butt = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Button);
            AutomationElement but_sev = c_frame.FindFirst(TreeScope.Children, butt);
            InvokePattern btnSevenPattern = but_sev.GetCurrentPattern(InvokePattern.Pattern) as InvokePattern;
            btnSevenPattern.Invoke();*/


            //Click button equal
            Condition button_eq_condtn = new PropertyCondition(AutomationElement.NameProperty, "Равно");
            AutomationElement button_eq_ae = c_frame.FindFirst(TreeScope.Children, button_eq_condtn);
            Console.WriteLine("Searching equals..");

            if(button_eq_ae != null)
            {
                InvokePattern button_eq_ptrn = button_eq_ae.GetCurrentPattern(InvokePattern.Pattern) as InvokePattern;
                button_eq_ptrn.Invoke();

                Console.WriteLine("OK");
            }
            else {
                Console.WriteLine("err");
            }
            Console.ReadKey();
        }
    }
}
