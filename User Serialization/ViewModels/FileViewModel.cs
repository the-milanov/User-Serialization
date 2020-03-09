using Microsoft.Win32;
using System.IO;
using System.Windows;
using User_Serialization.Commands;
using User_Serialization.Factories;
using User_Serialization.Mediators;
using System.Linq;

namespace User_Serialization.ViewModels
{
    public class FileViewModel
    {
        public DelegateCommand NewCommand { get; set; }
        public DelegateCommand SaveCommand { get; set; }
        public DelegateCommand SaveAsCommand { get; set; }

        private string saveFileName;
        private SaveFileDialog saveFileDialog = new SaveFileDialog() { Filter = "Data files (*.xml;*.json;*.bin)|*.xml;*.json;*.bin" };
        public GetUsersMediator GetUsers { get; set; }
        public FileViewModel()
        {
            NewCommand = new DelegateCommand(New, null);
            SaveCommand = new DelegateCommand(Save, CanSave);
            SaveAsCommand = new DelegateCommand(SaveAs, CanSave);
        }
        private void New(object o)
        {
            saveFileName = string.Empty;
            GetUsers.Users.Clear();
        }
        private void Save(object o)
        {
            if (string.IsNullOrEmpty(saveFileName) || !Path.HasExtension(saveFileName))
            {
                if (saveFileDialog.ShowDialog() == true)
                {
                    saveFileName = saveFileDialog.FileName;
                    SaveFile();
                }
            }
            else SaveFile();
        }
        private void SaveAs(object o)
        {
            if (saveFileDialog.ShowDialog() == true)
            {
                saveFileName = saveFileDialog.FileName;
                SaveFile();
            }
        }
        private bool CanSave(object o) => GetUsers.Users.Count() >= 1;
        private void SaveFile()
        {
            var serializer = UserSerializerFactory.Create(Path.GetExtension(saveFileName));
            if (serializer != null)
            {
                serializer.Serialize(GetUsers.Users, saveFileName);
            }
            else
            {
                MessageBox.Show("Invalid save parameters.");
            }
        }
    }
}
