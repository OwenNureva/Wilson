using Microsoft.CodeAnalysis.CSharp.Scripting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Wilson.ViewModels;
using Microsoft.CodeAnalysis.Scripting;

namespace Wilson.Commands
{
    public class BilboExecuteCommand : ICommand
    {
        private BilboViewModel _viewModel;

        public BilboExecuteCommand(BilboViewModel viewModel)
        {
            _viewModel = viewModel;
        }
        public async void Execute(object parameter)
        {
            XDocument n;

            var script = _viewModel.ScriptText;
            var scriptOptions = ScriptOptions.Default
                .AddImports(
                    "System",
                    "System.Text",
                    "System.Collections.Generic"
                );

            try
            {
                var result = await CSharpScript.EvaluateAsync(script, scriptOptions);
                _viewModel.ResultText = result?.ToString();
            }
            catch (Exception ex)
            {
                _viewModel.ResultText = "Error";
            }
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}
