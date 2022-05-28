using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using LoginPrueba.ViewModel;
using LoginPrueba.Helpers;
using Xamarin.Essentials;
using LoginPrueba.Models;
using System.Linq;

namespace LoginPrueba.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Retos : ContentPage
    {
        public Retos()
        {
            InitializeComponent();
            data_view.ItemTapped += data_view_ItemTapped;
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            RetosAPI data = new RetosAPI();
            var authKey = Preferences.Get("auth", "default");
            var data1 = await data.GetRetos(authKey);
            data_view.ItemsSource = data1;
            int count = 0;
            foreach (var val in data1)
            {
                if (val.CurrentPoints == val.TotalPoints)
                {
                    count++;
                }
            }
            current_points_lb.Text = count.ToString();
            total_points_lb.Text = data1.Count.ToString();
        }
        private void data_view_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var data = e.Item as Challenge;
            DisplayAlert(data.Title, data.Description, "OK");
        }        
    }
}