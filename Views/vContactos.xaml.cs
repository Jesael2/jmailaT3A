namespace jmailaT3A.Views;

public partial class vContactos : ContentPage
{
	public vContactos()
	{
		InitializeComponent();
	}

    private void pkIdentificacion_SelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = sender as Picker;
        if (picker != null && picker.SelectedIndex != -1)
        {
            // Cambiamos el placeholder del Entry de acuerdo con el valor seleccionado
            switch (picker.SelectedIndex)
            {
                case 0: // CI
                    txtpicker.Placeholder = "C�dula de Identidad";
                    break;
                case 1: // RUC
                    txtpicker.Placeholder = "RUC";
                    break;
                case 2: // PASAPORTE
                    txtpicker.Placeholder = "N�mero de Pasaporte";
                    break;
            }
        }
    }

    private async void btnAporte_Clicked(object sender, EventArgs e)
    {
        // Validar campos vac�os
        if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
            string.IsNullOrWhiteSpace(txtApellido.Text) ||
            string.IsNullOrWhiteSpace(txtCorreo.Text) ||
            string.IsNullOrWhiteSpace(txtpicker.Text) ||
            string.IsNullOrWhiteSpace(txtSalario.Text))
        {
            await DisplayAlert("Error", "Llena todos los campos.", "OK");
            return;
        }

        // Validar salario
        if (!double.TryParse(txtSalario.Text, out double salario))
        {
            await DisplayAlert("Error", "Salario inv�lido. Ingresa solo n�meros.", "OK");
            return;
        }

        // Validar correo electr�nico
        if (!IsValidEmail(txtCorreo.Text))
        {
            await DisplayAlert("Error", "Correo electr�nico inv�lido.", "OK");
            return;
        }

        // Validar tipo de identificaci�n
        var tipoIdentificacion = pkIdentificacion.SelectedItem?.ToString();
        var identificacion = txtpicker.Text;

        if (tipoIdentificacion == "CI")
        {
            if (!identificacion.All(char.IsDigit) || identificacion.Length != 10)
            {
                await DisplayAlert("Error", "La C�dula debe tener exactamente 10 d�gitos num�ricos.", "OK");
                return;
            }
        }
        else if (tipoIdentificacion == "RUC")
        {
            if (!identificacion.All(char.IsDigit) || identificacion.Length != 13)
            {
                await DisplayAlert("Error", "El RUC debe tener exactamente 13 d�gitos num�ricos.", "OK");
                return;
            }
        }
        else if (tipoIdentificacion == "PASAPORTE")
        {
            // Pasaporte: no se valida formato (libre)
        }
        else
        {
            await DisplayAlert("Error", "Selecciona un tipo de identificaci�n.", "OK");
            return;
        }

        // Calcular aporte
        double aporte = salario * 0.0945; // 9.45%

        lblResultado.Text = $"Aporte al IESS: {aporte:F2} USD";

        string nombre = txtNombre.Text;
        string apellido = txtApellido.Text;
        string correo = txtCorreo.Text;
        DateTime fecha = dpkfecha.Date;

        await Navigation.PushAsync(new vDetalle(tipoIdentificacion ?? "", nombre, apellido, correo, fecha, salario, aporte));
    }

    // M�todo auxiliar para validar email
    private bool IsValidEmail(string email)
    {
        try
        {
            var addr = new System.Net.Mail.MailAddress(email);
            return addr.Address == email;
        }
        catch
        {
            return false;
        }
    }
}