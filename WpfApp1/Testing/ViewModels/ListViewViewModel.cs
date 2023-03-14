using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Testing.ViewModels
{
    public class ListViewViewModel
    {
        public ObservableCollection<string> Names { get; set; }

        public ListViewViewModel()
        {
            Names = new ObservableCollection<string>()
            {
                "Nien",
                "Kim",
                "Kim Nien",
                "Nien Kim",
                "Nien Nien Kim Kim"
            };
        }
    }
}
