using System;

namespace WpfAppForEmployees
{
    public static class Programm
    {
        [STAThread]
        public static void Main()
        {
            var app = new App();
            app.InitializeComponent();
            app.Run();
        }
    }
}
