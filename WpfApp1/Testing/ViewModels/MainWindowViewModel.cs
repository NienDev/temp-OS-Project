using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApp1.Testing;

namespace WpfApp1.Testing.ViewModels
{ 
    public class MainWindowViewModel : ObservableObject
    {
        public ListViewViewModel ListView { get; set; }
        public ICommand RemoveNameCommand { get; set; }

        public MainWindowViewModel()
        {
            ListView = new ListViewViewModel();
            RemoveNameCommand = new WpfApp1.Testing.RelayCommand(RemoveName);

        }
            
        public void RemoveName(object obj)
        {
            ListView.Names.Remove(obj as string);
        }
    }
}
