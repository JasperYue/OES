using System;
using System.Windows.Forms;
using UI.UserService;
using System.Threading;

namespace UI
{
    static class Program
    {
        public static User user;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormLogin());

            /*
            user = new User();
            user.Id = 2;
            user.Name = "Japser.Yue";
            Application.Run(new DemoPanelLoop());
             * */
        }
    }
}
