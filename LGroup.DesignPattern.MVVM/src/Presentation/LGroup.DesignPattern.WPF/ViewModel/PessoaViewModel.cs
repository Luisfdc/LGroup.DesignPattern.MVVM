using LGroup.DesignPattern.WPF.Commands;
using LGroup.DesignPattern.WPF.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LGroup.DesignPattern.WPF.ViewModel
{
    public class PessoaViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Pessoa> Pessoas { get; set; }
        private Pessoa _pessoa { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChenge(string propertyName)
        {
            var handler = PropertyChanged;

            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        public Pessoa Pessoa
        {
            get
            {
                return _pessoa;
            }
            set
            {
                _pessoa = value;
                OnPropertyChenge("Pessoa");
            }
        }

        public SalvarPessoaCommand SalvarPessoaCommand { get; set; }

        public PessoaViewModel()
        {
            Pessoas = new ObservableCollection<Pessoa>();
            Pessoa = new Pessoa();
            SalvarPessoaCommand = new SalvarPessoaCommand(this.SalvarPessoa);
        }

        public void SalvarPessoa(Pessoa pessoa)
        {
            var pessoaLocal = new Pessoa
            {
                Email = pessoa.Email,
                Nome = pessoa.Nome
            };
            Pessoas.Add(pessoaLocal);
            Pessoa = new Pessoa();
        }
    }
}
