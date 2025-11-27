//Jefferson Alexandre e Larissa Cunha
using AppRpgEtec.Models;
using AppRpgEtec.Services.Disputas;
using AppRpgEtec.Services.PersonagemHabilidades;
using AppRpgEtec.Services.Personagens;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AppRpgEtec.ViewModels.Disputas
{
    public class DisputaViewModel : BaseViewModel
    {
        private PersonagemHabilidadeService phService;
        public ObservableCollection<PersonagemHabilidade> Habilidades { get; set; } 
        private DisputaService dService;
        public Disputa DisputaPersonagens {  get; set; }
        private PersonagemService pService;
        public Personagem Atacante { get; set; }
        public Personagem Oponente { get; set; }
        public ObservableCollection<Personagem> PersonagensEncontrados { get; set; }
        public DisputaViewModel()
        {
            string token = Preferences.Get("UsuarioToken", string.Empty);
            phService = new PersonagemHabilidadeService(token);
            pService = new PersonagemService(token);
            dService = new DisputaService(token);
            Atacante = new Personagem();
            Oponente = new Personagem();
            DisputaPersonagens = new Disputa();
            PersonagensEncontrados = new ObservableCollection<Personagem>();
            DisputaGeralCommand = new Command(async () => { await ExecutarDisputaGeral(); });
            DisputaComHabilidadeCommand = new Command(async () => { await ExecutarDisputaHabilidades(); });
            PesquisarPersonagemCommand = new Command<string>(async (string pesquisa) =>
            {
                await PesquisarPersonagens(pesquisa);
            });

            DisputaComArmaCommand = new Command(async () => { await ExecutarDisputaArmada(); });

        }

        public async Task ObterHabilidadeAsync(int personagemId)
        {
            try
            {
                Habilidades = await phService.GetPersonagemHabilidadesAsync(personagemId);
                OnPropertyChanged(nameof(Habilidades));
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Ops", ex.Message + " Detalhes: " + ex.InnerException, "Ok");
            }
        }
        private async Task ExecutarDisputaGeral()
        {
            try
            {
                ObservableCollection<Personagem> lista = await pService.GetPersonagensAsync();
                DisputaPersonagens.ListaIdPersonagens = lista.Select(p => p.Id).ToList();
                DisputaPersonagens.Narracao = "";
                DisputaPersonagens = await dService.PostDisputaGeralAsync(DisputaPersonagens);
                string resultados = string.Join(" | ", DisputaPersonagens.Resultados);
                await Application.Current.MainPage.DisplayAlert("Resultado", resultados, "Ok");

            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Ops", ex.Message + " Detalhes: " + ex.InnerException, "Ok");
            }
        }
        private async Task ExecutarDisputaArmada()
        {
            try
            {
                DisputaPersonagens.AtacanteId = Atacante.Id;
                DisputaPersonagens.OponenteId = Oponente.Id;
                DisputaPersonagens.Narracao = "";
                DisputaPersonagens = await dService.PostDisputaComArmaAsync(DisputaPersonagens);
                await Application.Current.MainPage.DisplayAlert("Resultado", DisputaPersonagens.Narracao, "Ok");
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Ops", ex.Message + " Detalhes: " + ex.InnerException, "Ok");
            } 
        }
        public ICommand DisputaGeralCommand { get; set; }
        public ICommand DisputaComHabilidadeCommand { get; set; }   
        public ICommand PesquisarPersonagemCommand { get; set; }
        public ICommand DisputaComArmaCommand { get; set; }


        #region Propriedades
        private PersonagemHabilidade habilidadeSelecionada;
        public PersonagemHabilidade HabilidadeSelecionada
        {
            get { return habilidadeSelecionada; }
            set
            {
                if (value != null)
                {
                    try
                    {
                        habilidadeSelecionada = value;
                        OnPropertyChanged();
                    }
                    catch (Exception ex)
                    {
                        Application.Current.MainPage
                            .DisplayAlert("Ops", ex.Message + " Detalhes: " + ex.InnerException, "Ok");
                    }
                }
            }
        }
        public string DescricaoPersonagemAtacante
        {
            get => Atacante.Nome;
        }

        public string DescricaoPersonagemOponente
        {
            get => Oponente.Nome;
        }

        private Personagem personagemSelecionado;
        public Personagem PersonagemSelecionado
        {
            set
            {
                if (value != null) 
                { 
                personagemSelecionado = value;
                SelecionarPersonagem(personagemSelecionado);
                OnPropertyChanged();
                PersonagensEncontrados.Clear();
                }
            }
        }

        private string textoBuscaDigitado=string.Empty;
        public string TextoBuscaDigitado
        {
            get => textoBuscaDigitado;
            set
            {
                textoBuscaDigitado = value;
                OnPropertyChanged();

                if (!string.IsNullOrWhiteSpace(textoBuscaDigitado))
                {
                    _ = PesquisarPersonagens(textoBuscaDigitado);
                }
                else
                {
                    PersonagensEncontrados.Clear();
                }
            }
        }


        #endregion






        #region Metodos
        private async Task ExecutarDisputaHabilidades()
        {
            try
            {

                DisputaPersonagens.HabilidadeId = HabilidadeSelecionada.HabilidadeId; 
                DisputaPersonagens.AtacanteId = Atacante.Id;
                DisputaPersonagens.OponenteId = Oponente.Id;
                DisputaPersonagens.Narracao = "";
                DisputaPersonagens = await dService.PostDisputaComHabilidadesAsync(DisputaPersonagens);
                await Application.Current.MainPage.DisplayAlert("Resultado", DisputaPersonagens.Narracao, "Ok");
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Ops", ex.Message + " Detalhes: " + ex.InnerException, "Ok");
            }
        }
        public async Task PesquisarPersonagens(string textoPesquisaPersonagem)
        {
            try
            {
                PersonagensEncontrados = await pService.GetByNomeAproximadoAsync(textoPesquisaPersonagem);
                OnPropertyChanged(nameof(PersonagensEncontrados));
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage
                    .DisplayAlert("Ops", ex.Message + " Detalhes: " + ex.InnerException, "Ok");
            }

        }



        public async void SelecionarPersonagem(Personagem p)
        {
            try
            {
                string tipoCombatente = await Application.Current.MainPage
                    .DisplayActionSheet("Atacante ou Oponente?", "Cancelar", "", "Atacante", "Oponente");

                if (tipoCombatente == "Atacante")
                {
                    await this.ObterHabilidadeAsync(p.Id);
                    Atacante = p;
                    OnPropertyChanged(nameof(DescricaoPersonagemAtacante));
                }
                else if (tipoCombatente == "Oponente")
                {
                    Oponente = p;
                    OnPropertyChanged(nameof(DescricaoPersonagemOponente));
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage
                    .DisplayAlert("Ops", ex.Message + " Detalhes: " + ex.InnerException, "Ok");
            }
        }

        #endregion



    }
}
