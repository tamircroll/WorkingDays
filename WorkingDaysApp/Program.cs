using WorkingDaysApp.FormUI;
using WorkingDaysApp.Logic;

namespace WorkingDaysApp
{
    static class Program
    {
        static void Main()
        {
            var wd = new WorkingDays();
            wd.start();
            new MainForm().ShowDialog();
        }
    }
}
