using LGroup.DesignPattern.WPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LGroup.DesignPattern.WPF.Commands
{
    //Existe framework como MVVM Ligth que facilita o uso do pattern MVVM
    public class SalvarPessoaCommand : ICommand
    {
        private Action<Pessoa> _executeMethod;

        public event EventHandler CanExecuteChanged;

        public SalvarPessoaCommand(Action<Pessoa> executeMethod)
        {
            _executeMethod = executeMethod;
        }

        //É muito usado em paralelismo
        public bool CanExecute(object parameter)
        {
            return true;
        }

        //Quem vai executar é o evento do command
        public void Execute(object parameter)
        {
            _executeMethod.Invoke((Pessoa)parameter);
        }

    }
}
