using System.Net;

namespace dvillavicencioS6.Views;

public partial class vAgregar : ContentPage
{
	public vAgregar()
	{
		InitializeComponent();
	}

    private void btnGuardar_Clicked(object sender, EventArgs e)
    {
		try
		{
			WebClient cliente = new WebClient();
			var parametros = new System.Collections.Specialized.NameValueCollection();
			parametros.Add("nombre", txtNombre.Text);
            parametros.Add("apellido", txtApellido.Text);
            parametros.Add("edad", txtEdad.Text);
			cliente.UploadValues("http://192.168.100.137/moviles/wsestudiantes.php","POST",parametros);
			Navigation.PushAsync(new vEstudiante());

        }
		catch (Exception ex)
		{

			DisplayAlert("Alerta", ex.Message, "cerrar");
		}
    }

    private void btnGuardar_Clicked_1(object sender, EventArgs e)
    {

    }
}