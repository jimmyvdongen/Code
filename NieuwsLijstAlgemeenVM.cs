using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SVORacing.ViewModels
{
    public class NieuwsLijstAlgemeenVM : INotifyPropertyChanged
    {
        List<Entiteiten.Nieuws> _nieuwsLijst = new List<Entiteiten.Nieuws>();
        bool _loadingVisibility = true;

        public event PropertyChangedEventHandler PropertyChanged;

        public NieuwsLijstAlgemeenVM()
        {
            Task.Run(async () => await GetItems());
        }

        private bool _isRefreshing = false;
        public bool IsRefreshing
        {
            get { return _isRefreshing; }
            private set
            {
                _isRefreshing = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IsRefreshing"));
            }
        }

        public List<Entiteiten.Nieuws> NieuwsLijst
        {
            private set
            {
                _nieuwsLijst = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("NieuwsLijst"));
            }
            get
            {
                return _nieuwsLijst;
            }
        }

        public bool LoadingVisibility
        {
            private set
            {
                if (_loadingVisibility != value)
                {
                    _loadingVisibility = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("LoadingVisibility"));
                }
            }
            get
            {
                return _loadingVisibility;
            }
        }

        public async Task GetItems()
        {
            await Task.Delay(500);
            RestService con = new RestService();
            NieuwsLijst = con.verkrijgNieuws().Result;
            LoadingVisibility = false;
        }

        public Command GetNieuwsLijst
        {
            get
            {
                return new Command(async () =>
                {
                    await Task.Run(() =>
                    {
                        IsRefreshing = true;
                        RestService con = new RestService();
                        NieuwsLijst = con.verkrijgNieuws().Result;
                        IsRefreshing = false;
                    });
                });
            }
        }
    }
}
