namespace ctrujilloTS2A.Views;

public partial class vPrincipal : ContentPage
{
	public vPrincipal()
	{
		InitializeComponent();
	}

    private void btnNotaFinal_Clicked(object sender, EventArgs e)
    {
		try
		{
			if (pkEstudiantes.SelectedIndex == -1)
			{
				DisplayAlert("Error", "El estudiante no existe", "Cerrar");
			}
			else
			{
				string estudiante = pkEstudiantes.Items[pkEstudiantes.SelectedIndex].ToString();

                if (!double.TryParse(txtSeguimiento_1.Text, out double seguimiento1) ||
					!double.TryParse(txtExamen_1.Text, out double examen1) ||
					!double.TryParse(txtSeguimiento_2.Text, out double seguimiento2) ||
					!double.TryParse(txtExamen_2.Text, out double examen2))

				{
					DisplayAlert("Error", "Todas las notas deben ser datos numericos", "Cerrar");
					return;
				}

                if (txtSeguimiento_1.Text.Contains(".") ||
					txtExamen_1.Text.Contains(".") ||
					txtSeguimiento_2.Text.Contains(".") ||
					txtExamen_2.Text.Contains("."))
                {
                    DisplayAlert("Error", "Use coma (,) como separador decimal, no punto (.)", "Cerrar");
                    return;
                }

                if (seguimiento1 < 0 || seguimiento1 > 10 ||
					examen1 < 0 || examen1 > 10 ||
					seguimiento2 < 0 || seguimiento2 > 10 ||
					examen2 < 0 || examen2 > 10)

				{
					DisplayAlert("Error", "Las notas deben estar entre 0 y 10", "Cerrar");
					return;
				}

				double parcial1 = seguimiento1 * 0.3 + examen1 * 0.2;
				double parcial2 = seguimiento2 * 0.3 + examen2 * 0.2;
				double notaFinal = parcial1 + parcial2;

				string estado = "";

				if (notaFinal >= 7)
					estado = "Aprobado";
				else if (notaFinal >= 5 && notaFinal <= 6.9)
					estado = "Complementario";
				else 
					estado = "Reprobado";

                string fecha = dpkFecha.Date.ToString("yyyy-MM-dd");

                lblResultado.Text = $"Nombre: {estudiante}\n" +
									$"Fecha: {fecha}\n" +
									$"Nota Parcial 1: {parcial1:F2}\n" +
									$"Nota Parcial 2: {parcial2:F2}\n" +
									$"Nota Final: {notaFinal:F2}\n" +
									$"Estado: {estado}";

                DisplayAlert("Resultado", lblResultado.Text, "Cerrar");
            }
		}
		catch (Exception ex)
		{
			DisplayAlert("Error", ex.Message, "Cerrar");
		}
    }
}