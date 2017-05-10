using BusinessLogic;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF_Demo.ViewModel.Interface;

namespace WPF_Demo.ViewModel
{
    [Export(typeof(IRegistroPersonaViewModel))]
    public class RegistroPersonaViewModel : BindableBase, IRegistroPersonaViewModel
    {
        [ImportingConstructor]
        public RegistroPersonaViewModel()
        {
            ListSexo();
            FechaNacimiento = DateTime.Now;
            ListarPersonas();
        }


        #region Entities
        private string _nombre;

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; OnPropertyChanged(() => Nombre); }
        }

        private string _apellido;

        public string Apellido
        {
            get { return _apellido; }
            set { _apellido = value; OnPropertyChanged(() => Apellido); }
        }

        private ListaSexo _ListaSexo;

        public ListaSexo ListaSexo
        {
            get { return _ListaSexo; }
            set { _ListaSexo = value; OnPropertyChanged(() => ListaSexo); }
        }

        private DateTime _FechaNacimiento;

        public DateTime FechaNacimiento
        {
            get { return _FechaNacimiento; }
            set { _FechaNacimiento = value; OnPropertyChanged(() => FechaNacimiento); }
        }


        private Sexo _Sexo;

        public Sexo Sexo
        {
            get { return _Sexo; }
            set { _Sexo = value; OnPropertyChanged(() => Sexo); }
        }

        private ListaPersona _ListaPersona;

        public ListaPersona ListaPersona
        {
            get { return _ListaPersona; }
            set { _ListaPersona = value; OnPropertyChanged(() => ListaPersona); }
        }
        #endregion

        #region Commands

        public ICommand CommandRegistrarPersona
        {
            get { return new DelegateCommand(RegistrarPersonaCommand); }
        }


        #endregion


        #region Methods

        private void RegistrarPersonaCommand()
        {
            Persona oPersona = new Persona();
            oPersona.Nombre = Nombre;
            oPersona.Apellido = Apellido;
            oPersona.Sexo = new Sexo() { ValorSexo = Sexo.ValorSexo };
            oPersona.FechaNacimiento = FechaNacimiento;
            var registro = new PersonaBusinessLogic().RegistrarPersona(oPersona);
            ListarPersonas();
        }

        private void ListSexo()
        {
            ListaSexo oListaSexo = new ListaSexo();
            oListaSexo.Add(new Sexo() { ValorSexo = true, SexoNombre = "MALE" });
            oListaSexo.Add(new Sexo() { ValorSexo = false, SexoNombre = "FEMALE" });
            ListaSexo = oListaSexo;
            Sexo = ListaSexo.FirstOrDefault();
        }

        private void ListarPersonas()
        {
            ListaPersona = new PersonaBusinessLogic().ListarPersona();
        }


        #endregion

    }
}
