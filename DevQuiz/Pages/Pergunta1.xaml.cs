using Microsoft.Maui.Controls.Shapes;

namespace DevQuiz.Pages;

public partial class Pergunta1 : ContentPage
{
    bool respondeu = false;
    bool acertou = false;
    int soma = 0;

    public Pergunta1()
    {
        InitializeComponent();
    }

    private async void btnResponder_Clicked(object sender, EventArgs e)
    {
        if (acertou)
        {
            rstColor.Stroke = new SolidColorBrush(Color.FromArgb("#00FF00"));
        }
        else
        {
            rstColor.Stroke = new SolidColorBrush(Color.FromArgb("#FF0000"));

        }

        soma = acertou ? soma + 1 : soma;

        await SecureStorage.Default.SetAsync("soma", soma.ToString());
        await Navigation.PushAsync(new Pergunta2());

    }

    private void Verificar(object sender, EventArgs e)
    {
        string valor = "0";

        if (respondeu)
        {
            respondeu = false;
        }
        RadioButton opcao = (RadioButton)sender;
        if (opcao.IsChecked)
        {
            valor = opcao.Value.ToString();
            respondeu = true;

            if (valor == "1")
            {
                acertou = true;
            }
        }
    }

}