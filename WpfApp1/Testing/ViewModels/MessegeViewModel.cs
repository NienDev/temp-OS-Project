using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfApp1.Testing.Command;

namespace WpfApp1.Testing.ViewModels
{
    public class MessageViewModel
    {
		//public string MessageText { get; set; }

		public MessageCommand DisplayMessageCommand { get; private set; }

		public MessageViewModel()
		{
			DisplayMessageCommand = new MessageCommand(DisplayMessage);
		}

		public void DisplayMessage(string MessageText)
		{
			MessageBox.Show(MessageText);
		}
	}
}
