using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DavidCabezasS7.Modelo;
using SQLite;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DavidCabezasS7
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registrar : ContentPage
    {
        private SQLiteAsyncConnection conn;
        public Registrar()
        {
            InitializeComponent();
            conn = DependencyService.Get<DataBase>().GetConnection();
        }

        private void btnRegistro_Clicked(object sender, EventArgs e)
        {
            var DatosRegistro = new Estudiante { Nombre = txtNombre.Text, Usurio = txtUsuario.Text, Contrasenia = txtContrasenia.Text };
            conn.InsertAsync(DatosRegistro);
            limpiarFormulario();
        }
        void limpiarFormulario()
        {
            txtNombre.Text = "";
            txtUsuario.Text = "";
            txtContrasenia.Text = "";
            DisplayAlert("Alerta", "Se agrego correctamente", "OK");

        }
    }
}