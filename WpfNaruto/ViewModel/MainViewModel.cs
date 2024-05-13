using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfNaruto.Commands;
using WpfNaruto.View;

namespace WpfNaruto.ViewModel
{
    public class MainViewModel: INotifyPropertyChanged
    {
		private object currentView;
        private HomeView homeView;
        private UsersView usersView;

        public RelayCommand UsersViewCommand { get; set; }
        public RelayCommand HomeViewCommand { get; set; }


        public event PropertyChangedEventHandler? PropertyChanged;
        
        protected void onPropertyChanged([CallerMemberName] string name=null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }


        public object CurrentView
        {
			get { return currentView; }
			set { 
                currentView = value;
                onPropertyChanged();
               
            }
		}

        public MainViewModel()
        {
            homeView = new HomeView();
            usersView = new UsersView();
            //CurrentView = homeView;
            CurrentView = usersView;

            UsersViewCommand = new RelayCommand(x => CurrentView = usersView);
            HomeViewCommand = new RelayCommand(x=> CurrentView=homeView);
        }
    }
}
