using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using User_Serialization.Commands;

namespace User_Serialization.ViewModels
{
    public class FileViewModel
    {
        public DelegateCommand SaveCommand { get; set; }
        public FileViewModel()
        {
            SaveCommand = new DelegateCommand(Save, null);
        }
        public void Save(object o)
        {
            MessageBox.Show("Saving file...");
        }
    }
}
