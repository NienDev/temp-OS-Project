using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Testing.ViewModels
{
    public class PersonViewModel : ObservableObject
    {
        private string _name;

        public string Name { 
            get {
                if (string.IsNullOrEmpty(_name)) return "Unknown";
                return _name; 
            } 
            set { 
                _name = value;
                OnPropertyChanged("Name"); 
            } 
        }
    }
}
