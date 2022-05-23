using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DavidCabezasS7.Modelo;
using SQLite;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DavidCabezasS7
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
        
    {
        private SQLiteAsyncConnection conn;
        public Login()
        {
            InitializeComponent();
            conn = DependencyService.Get<DataBase>().GetConnection();  
        }
       

        public static IEnumerable<Estudiante> SELECT_WHERE(SQLiteConnection db, string usuario, string contrasenia)
        {
            return db.Query<Estudiante>("SELECT * FROM Estudiante where Usurio = ? and Contrasenia=?", usuario, contrasenia);
        }

      
       

      

        private async void btnRegistrar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Registrar());
        }

        private void btnInciar_Clicked(object sender, EventArgs e)
        {
            {
                try
                {
                    var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
                    var db = new SQLiteConnection(databasePath);
                    db.CreateTable<Estudiante>();
                    IEnumerable<Estudiante> resultado = SELECT_WHERE(db, txtUsuario.Text, txtContrasenia.Text);
                    if (resultado.Count() > 0)
                    {
                        Navigation.PushAsync(new ConsultaRegistro());
                    }
                    else
                    {
                        DisplayAlert("Alerta", "Usuario o Contrasena Incorrectos", "ok");
                    }
                }
                catch (Exception)
                {

                    throw;
                }

            }
        }
    }
}