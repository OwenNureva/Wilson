using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Wilson.Commands;

namespace Wilson.ViewModels
{
    public class BilboViewModel : INotifyPropertyChanged
    {
        private string _scriptText;
        private string _resultText;

        public string ScriptText
        {
            get { return _scriptText; }
            set
            {
                _scriptText = value;
                OnPropertyChanged();
            }
        }

        public string ResultText
        {
            get { return _resultText; }
            set
            {
                _resultText = value;
                OnPropertyChanged();
            }
        }

        public ICommand BilboExecuteCommand { get; set; }

        public BilboViewModel()
        {
            ScriptText = string.Empty;

            BilboExecuteCommand = new BilboExecuteCommand(this);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
