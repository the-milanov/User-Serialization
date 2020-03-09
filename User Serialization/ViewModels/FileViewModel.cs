using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using User_Serialization.Commands;
using User_Serialization.Factories;
using User_Serialization.Mediators;

namespace User_Serialization.ViewModels
{
    public class FileViewModel
    {
        public DelegateCommand SaveCommand { get; set; }

        private string saveFileName;
        private SaveFileDialog saveFileDialog = new SaveFileDialog();
        public GetUsersMediator GetUsers { get; set; }
        public FileViewModel()
        {
            SaveCommand = new DelegateCommand(Save, null);
        }
        public void Save(object o)
        {
            if (string.IsNullOrEmpty(saveFileName))
            {
                if (saveFileDialog.ShowDialog() == true)
                {
                    saveFileName = saveFileDialog.FileName;
                    SaveFile();
                }
            }
            else SaveFile();
        }
        private void SaveFile()
        {
            var serializer = UserSerializerFactory.GetUserSerializer(Path.GetExtension(saveFileName));
            if (serializer != null)
            {
                serializer.Serialize(GetUsers.Users, saveFileName);
            }
        }
    }
}
