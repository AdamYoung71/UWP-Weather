using System;
using System.Collections.Generic;
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
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace Weather
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public  MainPage()
        {
            this.InitializeComponent();

             
        }

        private  void Page_Loaded(object sender, RoutedEventArgs e)
        {
            /*string cityName = "成都";
            var myWeather = await MainAPI.MainAPI.GetWrather(cityName);     //实例化主要天气API
            var mySuggestion = await LifeSuggestionAPI.LifeSuggestionAPI.GetSuggestion(cityName);//实例化生活指数
            var myLocation = await CityToLocation.CityToLocation.GetLocation(cityName);     //使用高德API将城市名转换为经纬度。
            string[] Locations = myLocation.geocodes[0].location.Split(",");        //将用逗号隔开的经纬度分割分别存入。
            double Lat = Convert.ToDouble(Locations[0]);
            double Lon = Convert.ToDouble(Locations[1]);
            var myCurrentWeather = await ProCurrentWeather.ProCurrentWeather.GetProCurrentWeather(Lon, Lat);//实例化高级当前天气API
            var myForecast = await ProForecast.ProForecast.GetProForecast(Lon, Lat);//实例化高级天气预报API

            CurrentTemp.Text = myWeather.results[0].now.temperature + "℃";
            CityName.Text = "成都";

            var weatherCode = "/Assets/WeatherIcons/" + Convert.ToString(myWeather.results[0].now.code) + ".png";
            WeatherImg.Source = new BitmapImage(new Uri(WeatherImg.BaseUri, weatherCode));*/
        }

        private async void AutoSuggestBox_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            try
            {
                string cityName = args.QueryText;
                var myWeather = await MainAPI.MainAPI.GetWrather(cityName);     //实例化主要天气API
                var mySuggestion = await LifeSuggestionAPI.LifeSuggestionAPI.GetSuggestion(cityName);//实例化生活指数
                var myLocation = await CityToLocation.CityToLocation.GetLocation(cityName);     //使用高德API将城市名转换为经纬度。
                string[] Locations = myLocation.geocodes[0].location.Split(",");        //将用逗号隔开的经纬度分割分别存入。
                double Lat = Convert.ToDouble(Locations[0]);
                double Lon = Convert.ToDouble(Locations[1]);
                var myCurrentWeather = await ProCurrentWeather.ProCurrentWeather.GetProCurrentWeather(Lon, Lat);//实例化高级当前天气API
                var myForecast = await ProForecast.ProForecast.GetProForecast(Lon, Lat);//实例化高级天气预报API
                                                                                        /*************************************/

                CurrentTemp.Text = myWeather.results[0].now.temperature + "℃";
                CityName.Text = cityName;

                var weatherCode = "/Assets/WeatherIcons/" + Convert.ToString(myWeather.results[0].now.code) + ".png";
                WeatherImg.Source = new BitmapImage(new Uri(WeatherImg.BaseUri, weatherCode));
            }

            catch
            {
                CityName.Text = "错误！";
                var weatherCode = "Assets/WeatherIcons/99.png";
                WeatherImg.Source = new BitmapImage(new Uri(WeatherImg.BaseUri, weatherCode));
                CurrentTemp.Text = " ";
            }
            /**************实例化API****************/
            
            
        }

        private void AutoSuggestBox_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            if (string.IsNullOrEmpty(sender.Text))
            {

            }
        }

        

       
    }
}
