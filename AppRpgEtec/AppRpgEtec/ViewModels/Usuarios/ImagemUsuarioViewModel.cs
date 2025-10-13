using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppRpgEtec.Models;
using Azure.Storage.Blobs;
using AppRpgEtec.Services.Usuarios;
using System.Windows.Input;

namespace AppRpgEtec.ViewModels.Usuarios
{
    public class ImagemUsuarioViewModel : BaseViewModel
    {
        private UsuarioService uService;
        private static string conexaoAzureStorage = "DefaultEndpointsProtocol=https;AccountName=rpgstorage;AccountKey=5lICnm3gQd9O49dC0y072ADvS/upL2mtE/TznGKfOjlmgCzowNzmhfxB5sfzpOR9IfHyGKbeht5X+AStEpvukQ==;EndpointSuffix=core.windows.net";
        private static string container = "arquivos";

        public ImagemUsuarioViewModel()
        {
            string token = Preferences.Get("UsuarioToken", string.Empty);
            uService = new UsuarioService(token);

            FotografarCommand = new Command(Fotografar);
            SalvarImagemCommand = new Command(SalvarImagemAzure);
        }

        public ICommand FotografarCommand {  get; }
        public ICommand SalvarImagemCommand { get; }

        private ImageSource fonteImagem;

        public ImageSource FonteImagem
        {
            get { return fonteImagem; }
            set
            {
                fonteImagem = value;
                OnPropertyChanged();
            }
        }

        private byte[] foto;

        public byte[] Foto
        {
            get { return foto; }
            set
            {
                foto = value;
                OnPropertyChanged();
            }
        }

         public async void Fotografar()
        {
            try
            {
                if (MediaPicker.Default.IsCaptureSupported)
                {
                    FileResult photo = await MediaPicker.Default.CapturePhotoAsync();

                    if (photo != null)
                    {
                        using (Stream sourceStream = await photo.OpenReadAsync())
                        {
                            using (MemoryStream ms = new MemoryStream())
                            {
                                await sourceStream.CopyToAsync(ms);
                                Foto = ms.ToArray();

                                FonteImagem = ImageSource.FromStream(() => new MemoryStream(ms.ToArray()));
                            }
                        }
                    }
                }

            }
            catch(Exception ex) {
                await Application.Current.MainPage
                    .DisplayAlert("Ops", ex.Message + "Detalhes: " + ex.InnerException, "Ok");

            }
        }

        public async void SalvarImagemAzure()
        {
            try
            {
                Usuario u = new Usuario();
                u.Foto = foto;
                u.Id = Preferences.Get("UsuarioId", 0);

                string fileName = $"{u.Id}.jpg";

                var blobClient = new BlobClient(conexaoAzureStorage, container, fileName);

                if (blobClient.Exists())
                    blobClient.Delete();

                using (var stream = new MemoryStream(u.Foto))
                {
                    blobClient.Upload(stream);
                }

                await Application.Current.MainPage.DisplayAlert("Mensagem", "Dados salvos com sucesso!", "Ok");
                await App.Current.MainPage.Navigation.PopAsync();
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage
                    .DisplayAlert("Ops", ex.Message + "Detalhes: " + ex.InnerException, "Ok");
            }
        }
    }
}
