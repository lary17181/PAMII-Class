using AppRpgEtec.ViewModels;

namespace AppRpgEtec.Views.Personagens;

public partial class CadastroPersonagemView : ContentPage
{
	public CadastroPersonagemView()
	{
		InitializeComponent();
	}

    private CadastroPersonagemViewModel cadViewModel;
    public CadastroPersonagemViewModel()
    {
        InitializeComponent();

        cadViewModel = new CadastroPersonagemViewModel();
        BindingContext = cadViewModel;
        Title = "Novo Personagem";

    
}