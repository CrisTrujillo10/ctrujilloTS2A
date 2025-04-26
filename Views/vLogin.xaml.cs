using System.Runtime.CompilerServices;

namespace ctrujilloTS2A.Views;

public partial class vLogin : ContentPage
{
	private string[] usuarios = {"Carlos", "Ana", "Jose"};
	private string[] contraseñas = {"carlos123", "ana123", "jose123"};
    public vLogin()
	{
		InitializeComponent();
	}
	 
    private void btnIniciarSesion_Clicked(object sender, EventArgs e)
    {
		string usuario = txtUsuario.Text;
		string contraseña = txtContraseña.Text;

		int index = Array.IndexOf(usuarios, usuario);

		if(index >= 0 && contraseñas[index] == contraseña)
		{
			DisplayAlert("Bienvenido",$"Bienvenido, {usuario}", "Cerrar");
		}
		else
		{
			DisplayAlert("Error", "Usuario y Contraseña incorrectos", "Cerrar");
		}
    }
}