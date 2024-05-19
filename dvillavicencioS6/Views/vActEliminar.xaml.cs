using dvillavicencioS6.Models;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Net;
using System.Text;
using System.Xml.Linq;
using System.Text.Json;
using System.Net.Http;

namespace dvillavicencioS6.Views;

public partial class vActEliminar : ContentPage
{
    private const string url = "http://192.168.100.137/moviles/wsestudiantes.php";
   /** private readonly HttpClient cliente = new HttpClient();
    private ObservableCollection<Estudiante> est;**/

    public vActEliminar(Estudiante objeto)
	{
		InitializeComponent();
        txtCodigo.Text= objeto.codigo.ToString();
        txtNombre.Text = objeto.nombre;
        txtApellido.Text = objeto.apellido;
        txtEdad.Text = objeto.edad.ToString();
	}

    private void btnActualizar_Clicked(object sender, EventArgs e)
    {
        try
        {

            var codigo = int.Parse(txtCodigo.Text);
            var nombre = txtNombre.Text;
            var apellido = txtApellido.Text;
            var edad = txtEdad.Text;

            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(apellido) || string.IsNullOrEmpty(edad))
            {
                DisplayAlert("Alerta", "Por favor, completa todos los campos.", "Cerrar");
                return;
            }
            var url = $"http://192.168.100.137/moviles/wsEstudiantes.php?codigo={codigo}&nombre={nombre}&apellido={apellido}&edad={edad}";
            HttpRequestMessage request = new(HttpMethod.Put, url);
            using (HttpClient client = new HttpClient())
            {
                var response = client.Send(request);
                DisplayAlert("Alert", "Registro actualizado", "OK");
                Navigation.PushAsync(new vEstudiante());

            }
        }
        catch (Exception ex)
        {
            DisplayAlert("Error", "No se pudo actualizar el registro", "Cerrar");
        }

    }

    private async void btnEliminar_Clicked(object sender, EventArgs e)
    {

        try
        {
            HttpClient cliente = new HttpClient();
            var codigo = txtCodigo.Text; // Obtener el código del estudiante a eliminar
            HttpResponseMessage response = await cliente.DeleteAsync($"http://192.168.100.137/moviles/wsestudiantes.php?codigo={codigo}");

            if (response.IsSuccessStatusCode)
            {
                // Eliminación exitosa, mostrar mensaje de éxito o realizar alguna acción adicional si es necesario
                await DisplayAlert("Éxito", "El estudiante ha sido eliminado correctamente", "Aceptar");
                await Navigation.PushAsync(new vEstudiante());
            }
            else
            {
                // Mostrar un mensaje de error si la eliminación falla
                await DisplayAlert("Error", "No se pudo eliminar el estudiante", "Aceptar");
            }
        }
        catch (Exception ex)
        {
            // Manejar cualquier excepción que pueda ocurrir durante la eliminación
            await DisplayAlert("Error", ex.Message, "Aceptar");
        }

    }
}