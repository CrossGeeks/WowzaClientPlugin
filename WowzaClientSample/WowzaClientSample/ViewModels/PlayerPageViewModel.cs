using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Plugin.WowzaClient;
using WowzaClientSample.Models;
using Xamarin.Forms;

namespace WowzaClientSample.ViewModels
{
    public class PlayerPageViewModel : INotifyPropertyChanged
    {
        public ICommand OnPlayButtonCommand { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        public PlayerPageViewModel()
        {
            CrossWowzaClient.Current.Setup(new WowzaCloudConfig());

            OnPlayButtonCommand = new Command(() =>
            {
                if (!CrossWowzaClient.Current.IsPlaying)
                {
                    CrossWowzaClient.Current.Play();
                }
                else
                    CrossWowzaClient.Current.Stop();
            });
        }
    }
}
