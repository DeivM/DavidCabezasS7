using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public partial class ConsultaRegistro : ContentPage
    {
        private SQLiteAsyncConnection conn;
        private ObservableCollection<Estudiante> TablaEstudiante;
        public ConsultaRegistro()
        {
            InitializeComponent();
            conn = DependencyService.Get<DataBase>().GetConnection();
            NavigationPage.SetHasBackButton(this, false);

        }
        protected async override void OnAppearing()
        {
            var ResulRegistros = await conn.Table<Estudiante>().ToListAsync();
            TablaEstudiante = new ObservableCollection<Estudiante>(ResulRegistros);
            ListaUsuarios.ItemsSource = TablaEstudiante;
            base.OnAppearing();
        }
        private void OnSelection(object sender, SelectedItemChangedEventArgs e)
        {
            var Obj = (Estudiante)e.SelectedItem;
            var item =Obj.Id.ToString();
            int ID =Convert.ToInt32(item);
           
            
            try
            {
                Navigation.PushAsync(new Elemento(ID));
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}