using Assignment1.Entity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Assignment1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private ObservableCollection<Infor> infors;
        public ObservableCollection<Infor> Infors { get => Model.InforModel.GetInfor(); set => Model.InforModel.SetSongs(value); }

        public MainPage()
        {
            this.InitializeComponent();
        }
        private void SaveInfor(object sender, RoutedEventArgs e)
        {
            Infor infor = new Infor();
            infor.Name = this.Name.Text;
            infor.Email = this.Email.Text;
            infor.Phone = this.Phone.Text;
            infor.Avatar = this.Avatar.Text;
            infor.Address = this.Address.Text;
            Model.InforModel.AddInfor(infor);

        }
        private void Song_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Infor selectedSong = (Infor)((StackPanel)sender).Tag;

        }
    }
}
