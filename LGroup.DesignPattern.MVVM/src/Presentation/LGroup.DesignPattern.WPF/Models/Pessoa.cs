using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LGroup.DesignPattern.WPF.Models
{
    //Queremos mapear a view com model
    //Para este precisamos ter um modo de que quando algo acontecer na view/model
    //algo seja disparado ou ambos
    public class Pessoa : INotifyPropertyChanged
    {
        private string _nome;
        
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChenge(string propertyName)
        {
            var handler = PropertyChanged;

            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        public string Nome
        {
            get
            {
                return _nome;
            }
            set
            {
                //toda vez que for mudado algo no meu modelo
                //Devo informar a view
                _nome = value;
                OnPropertyChenge("Nome");
            }

            
        }

        private string _email;
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
                OnPropertyChenge("Email");
            }


        }
    }
}
