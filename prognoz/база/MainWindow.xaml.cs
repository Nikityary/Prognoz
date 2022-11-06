using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Newtonsoft.Json;
using System.Net;
using System.IO;

namespace Prognoz
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        string q = "";
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window_Loaded(sender, e);
        }
        
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
            q = Search.Text;
            WebRequest request = WebRequest.Create("https://api.openweathermap.org/data/2.5/weather?q=" + q + "&lang=ru&APPID=24675dcb634e0fd2513da5d3f09b9d74");
            request.Method = "POST";
            request.ContentType = "application/x-www-urlencoded";

            WebResponse response = await request.GetResponseAsync();
            string answer = string.Empty;
            using (Stream s = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(s))
                {
                    answer = await reader.ReadToEndAsync();
                }
            }
            response.Close();
            OpenWeather OW = JsonConvert.DeserializeObject<OpenWeather>(answer);
            Davlenie.Content = "Давление: " + ((int)OW.main.pressure).ToString() + " мм";
            Wind_Speed.Content = "Скорость ветра: " + OW.wind.speed.ToString() + " м/с";
            Wind_deg.Content = "Напрвление ветра: " + OW.wind.deg.ToString() + "°";
            Humidity.Content = "Влажность: " + OW.main.humidity.ToString() + "%";
            Temp.Content = OW.main.temp.ToString("0.##") + "°C";
            City.Content = OW.name.ToString();
            Coord.Content = OW.coord.lat.ToString("0.##") + " x " + OW.coord.lon.ToString("0.##");
            switch (OW.weather[0].icon)
            {
                case "01d":
                    {
                        Image.Source = new BitmapImage(new Uri(@"/icons/yasno.png", UriKind.Relative));
                        WeatherType.Content = "Ясно";
                        break;
                    }
                case "01n":
                    {
                        Image.Source = new BitmapImage(new Uri(@"/icons/night.png", UriKind.Relative));
                        WeatherType.Content = "Ясно";
                        break;
                    }
                case "02d":
                    {
                        Image.Source = new BitmapImage(new Uri(@"/icons/mini_oblachno.png", UriKind.Relative));
                        WeatherType.Content = "Небольшая облачность";
                        break;
                    }
                case "02n":
                    {
                        Image.Source = new BitmapImage(new Uri(@"/icons/mini_oblachno.png", UriKind.Relative));
                        WeatherType.Content = "Небольшая облачность";
                        break;
                    }
                case "03d":
                    {
                        Image.Source = new BitmapImage(new Uri(@"/icons/oblachno.png", UriKind.Relative));
                        WeatherType.Content = "Облачно";
                        break;
                    }
                case "03n":
                    {
                        Image.Source = new BitmapImage(new Uri(@"/icons/oblachno.png", UriKind.Relative));
                        WeatherType.Content = "Облачно";
                        break;
                    }
                case "04d":
                    {
                        Image.Source = new BitmapImage(new Uri(@"/icons/oblachno.png", UriKind.Relative));
                        WeatherType.Content = "Сильная облачность";
                        break;
                    }
                case "04n":
                    {
                        Image.Source = new BitmapImage(new Uri(@"/icons/oblachno.png", UriKind.Relative));
                        WeatherType.Content = "Сильная облачность";
                        break;
                    }
                case "09d":
                    {
                        Image.Source = new BitmapImage(new Uri(@"/icons/mega_rain.png", UriKind.Relative));
                        WeatherType.Content = "Сильный дождь";
                        break;
                    }
                case "09n":
                    {
                        Image.Source = new BitmapImage(new Uri(@"/icons/mega_rain.png", UriKind.Relative));
                        WeatherType.Content = "Сильный дождь";
                        break;
                    }
                case "10d":
                    {
                        Image.Source = new BitmapImage(new Uri(@"/icons/rain.png", UriKind.Relative));
                        WeatherType.Content = "Дождь";
                        break;
                    }
                case "10n":
                    {
                        Image.Source = new BitmapImage(new Uri(@"/icons/rain.png", UriKind.Relative));
                        WeatherType.Content = "Дождь";
                        break;
                    }
                case "11d":
                    {
                        Image.Source = new BitmapImage(new Uri(@"/icons/thunder.png", UriKind.Relative));
                        WeatherType.Content = "Гроза";
                        break;
                    }
                case "11n":
                    {
                        Image.Source = new BitmapImage(new Uri(@"/icons/thunder.png", UriKind.Relative));
                        WeatherType.Content = "Гроза";
                        break;
                    }
                case "13d":
                    {
                        Image.Source = new BitmapImage(new Uri(@"/icons/snow.png", UriKind.Relative));
                        WeatherType.Content = "Снег";
                        break;
                    }
                case "13n":
                    {
                        Image.Source = new BitmapImage(new Uri(@"/icons/snow.png", UriKind.Relative));
                        WeatherType.Content = "Снег";
                        break;
                    }
                case "50d":
                    {
                        Image.Source = new BitmapImage(new Uri(@"/icons/tuman.png", UriKind.Relative));
                        WeatherType.Content = "Туман";
                        break;
                    }
                case "50n":
                    {
                        Image.Source = new BitmapImage(new Uri(@"/icons/tuman.png", UriKind.Relative));
                        WeatherType.Content = "Туман";
                        break;
                    }
            }
            }
            catch
            {
                MessageBox.Show("Не найдено");
            }
        }

        private void Fast_Click(object sender, RoutedEventArgs e)
        {
            Search.Text = Fast.Content.ToString();
            Window_Loaded(sender, e);
        }

        private void Fast_Copy_Click(object sender, RoutedEventArgs e)
        {
            Search.Text = Fast_Copy.Content.ToString();
            Window_Loaded(sender, e);
        }

        private void Fast_Copy5_Click(object sender, RoutedEventArgs e)
        {
            Search.Text = Fast_Copy5.Content.ToString();
            Window_Loaded(sender, e);
        }

        private void Fast_Copy1_Click(object sender, RoutedEventArgs e)
        {
            Search.Text = Fast_Copy1.Content.ToString();
            Window_Loaded(sender, e);
        }

        private void Fast_Copy6_Click(object sender, RoutedEventArgs e)
        {
            Search.Text = Fast_Copy6.Content.ToString();
            Window_Loaded(sender, e);
        }

        private void Fast_Copy2_Click(object sender, RoutedEventArgs e)
        {
            Search.Text = Fast_Copy2.Content.ToString();
            Window_Loaded(sender, e);
        }

        private void Fast_Copy7_Click(object sender, RoutedEventArgs e)
        {
            Search.Text = Fast_Copy7.Content.ToString();
            Window_Loaded(sender, e);
        }

        private void Fast_Copy3_Click(object sender, RoutedEventArgs e)
        {
            Search.Text = Fast_Copy3.Content.ToString();
            Window_Loaded(sender, e);
        }

        private void Fast_Copy8_Click(object sender, RoutedEventArgs e)
        {
            Search.Text = Fast_Copy8.Content.ToString();
            Window_Loaded(sender, e);
        }

        private void Fast_Copy4_Click(object sender, RoutedEventArgs e)
        {
            Search.Text = Fast_Copy4.Content.ToString();
            Window_Loaded(sender, e);
        }
    }
}
