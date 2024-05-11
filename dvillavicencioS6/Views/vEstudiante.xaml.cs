using dvillavicencioS6.Models;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace dvillavicencioS6.Views;

public partial class vEstudiante : ContentPage
{

	private const string url = "http://192.168.100.137/moviles/wsestudiantes.php";
	private readonly HttpClient cliente = new HttpClient();
	private ObservableCollection<Estudiante> estud;
	public vEstudiante()
	{
		InitializeComponent();
		ObtenerDatos();

    }

	public async void ObtenerDatos()
	{
		var content = await cliente.GetStringAsync(url);
		List<Estudiante> mostrarEst= JsonConvert.DeserializeObject<List<Estudiante>>(content);
		estud = new ObservableCollection<Estudiante>(mostrarEst);
		listEstudiante.ItemsSource = mostrarEst;
	}
}