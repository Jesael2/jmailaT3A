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
                    txtpicker.Placeholder = "Cédula de Identidad";
                    break;
                case 1: // RUC
                    txtpicker.Placeholder = "RUC";
                    break;
                case 2: // PASAPORTE
                    txtpicker.Placeholder = "Número de Pasaporte";
                    break;
            }
        }
    }

    private void btnAporte_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
            string.IsNullOrWhiteSpace(txtApellido.Text) ||
            string.IsNullOrWhiteSpace(txtCorreo.Text) ||
            string.IsNullOrWhiteSpace(txtSalario.Text))
        {
            DisplayAlert("Error", "Llena todos los campos.", "OK");
            return;
        }
        string nombre = txtNombre.Text;
        string apellido = txtApellido.Text;
        string correo = txtCorreo.Text;
        double salario;
    }
}