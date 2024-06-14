namespace DevQuiz.Pages;

public partial class Resultado : ContentPage
{
    string nome = "";
    int soma;

    public Resultado()
    {
        InitializeComponent();
    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();
        nome = await SecureStorage.Default.GetAsync("nome");
        soma = Convert.ToInt32(await SecureStorage.Default.GetAsync("soma"));
        double media = Convert.ToDouble(soma) / 5 * 100;
        lblNome.Text = $"Olá, {nome}";
        lblNota.Text = media.ToString();
    }

    private async void BtnInicio_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage());
    }
}