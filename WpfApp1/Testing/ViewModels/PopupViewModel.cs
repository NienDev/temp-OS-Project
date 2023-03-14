using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp1.Testing.ViewModels
{
    public class PopupViewModel
    {
        public ObservableCollection<string> MyMessages { get; private set; }

        public RelayCommand MessageBoxCommand { get; private set; }
        public RelayCommand ConsoleLogCommand { get; private set; }

        public PopupViewModel()
        {
            MyMessages = new ObservableCollection<string>()
            {
                "Hello World", "My name is Nien", "My lover is Kim", "Im a message Box!", "Im a console!"
            };

            MessageBoxCommand = new RelayCommand(DisplayPopup, MessageBoxCanUse);
            ConsoleLogCommand = new RelayCommand(DisplayInConsole, ConsoleCanUse);
        }

        public void DisplayPopup(object message)
        {
            MessageBox.Show((string)message);
        }

        public void DisplayInConsole(object message)
        {
            Console.WriteLine((string)message);
        }

        public bool MessageBoxCanUse(object message)
        {
            if ((string)message == "Im a console!") return false;
            return true;
        }

        public bool ConsoleCanUse(object message)
        {
            if ((string)message == "Im a message Box!") return false;
            return true;
        }
    }
}
