using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Newtonsoft.Json;
using LoginPrueba.Models;
using System.Net.Http;
using System.Net;
using LoginPrueba.Views;
using System.IO;
using Xamarin.Essentials;

namespace LoginPrueba
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            background_img.Source = ImageSource.FromResource("LoginPrueba.Assets.background.jpg");
            instragram_g.Source = ImageSource.FromResource("LoginPrueba.Assets.instagram_g.png");
            facebook_g.Source = ImageSource.FromResource("LoginPrueba.Assets.facebook_g.png");
            image_pass.Source = ImageSource.FromResource("LoginPrueba.Assets.eye_b.png");            

        }        

        
        private async void Button_Clicked(object sender, EventArgs e)
        {
            Login log = new Login
            {
                email = email_entry.Text,
                password = password_entry.Text,
            };
            Uri RequestUri = new Uri("https://horuschallenges.azurewebsites.net/api/UserSignIn");
            var client = new HttpClient();
            var json = JsonConvert.SerializeObject(log);
            var contentJson = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(RequestUri, contentJson);            
            var test = response.Content.ReadAsStringAsync();
            
            
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var data = JsonConvert.DeserializeObject<Login>(test.Result);
                Preferences.Set("auth", data.authorizationToken);
                await DisplayAlert("Bienvenido", "Bienvenido al sistema" + " " + data.firstname, "OK");
                await Navigation.PushAsync(new Retos());
            }           
            else
            {
                await DisplayAlert("Alerta", "Existe un problema con la conexion o el usuario no existe", "OK");
            }
        }
    }
}
