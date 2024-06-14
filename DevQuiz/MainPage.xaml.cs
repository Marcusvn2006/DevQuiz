using DevQuiz.Pages;

namespace DevQuiz
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            SecureStorage.Default.RemoveAll();
        }


        private async void btnIniciar_Clicked(object sender, EventArgs e)
        {
            string nome;
            nome = await DisplayPromptAsync("Olá", "Digite seu nome", "Ok", "Cancelar");
            if (nome == null || nome.Trim() == "")
            {
                return;
            }

            await SecureStorage.Default.SetAsync("nome", nome);

            await Navigation.PushAsync(new Pergunta1());
        }
    }

}
