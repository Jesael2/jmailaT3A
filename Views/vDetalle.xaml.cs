

namespace jmailaT3A.Views;

public partial class vDetalle : ContentPage
{
    string Exportar;

    public vDetalle(string identificacion, string nombre, string apellido, string correo, DateTime fecha, double salario, double aporte)
	{
        

       
            InitializeComponent();

            lblIdentificacion.Text = $"Identificación: {identificacion}";
            lblNombre.Text = $"Nombre: {nombre}";
            lblApellido.Text = $"Apellido: {apellido}";
            lblCorreo.Text = $"Correo: {correo}";
            lblFecha.Text = $"Fecha: {fecha:MM/dd/yyyy}";
            lblSalario.Text = $"Salario: {salario:F2} USD";
            lblAporte.Text = $"Aporte IESS: {aporte:F2} USD";

            Exportar = $"{lblIdentificacion.Text}\n{lblNombre.Text}\n{lblApellido.Text}\n{lblCorreo.Text}\n{lblFecha.Text}\n{lblSalario.Text}\n{lblAporte.Text}";
        


    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        string filename = Path.Combine(FileSystem.AppDataDirectory, "contacto.txt");
        File.WriteAllText(filename, Exportar);

        await DisplayAlert("Éxito", $"Datos exportados:\n{filename}", "OK");
    }


}