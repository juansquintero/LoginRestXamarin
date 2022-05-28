using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using LoginPrueba.Models;
using LoginPrueba.Views;
using LoginPrueba.Helpers;
using Xamarin.Essentials;

namespace LoginPrueba.ViewModel
{    
    public class RetosViewModel
    {
        public async void FillData()
        {
            RetosAPI data = new RetosAPI();
            var authKey = Preferences.Get("auth", "default");
            var data1 = await data.GetRetos(authKey);            
        }
    }        
}
