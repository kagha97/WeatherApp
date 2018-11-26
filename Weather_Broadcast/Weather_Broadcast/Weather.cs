﻿using System;
using System.Windows.Forms;

namespace Weather_Broadcast
{
    public class Weather
    {
        // Fields to hold View Controls reference
        public Label LabelCityName { get; private set; }
        public Label LabelCurrentDate { get; private set; }
        public Label LabelCurrentTemperature { get; private set; }
        public Label LabelDescription { get; private set; }
        public PictureBox PictureBoxIcon { get; private set; }
        public dynamic WeatherResponseFromAPI { get; private set; }
        public FlowLayoutPanel WeatherForecastPanel { get; private set; }


        public Weather(dynamic dataResponse, Label labelCityName, Label labelDate, Label labelCurrentTemp, Label labelDescription, PictureBox weatherIcon,
                       FlowLayoutPanel weatherForecastPanel)
        {
            // init weather data
            WeatherResponseFromAPI = dataResponse;

            // Init view control reference
            LabelCityName = labelCityName;
            LabelCurrentDate = labelDate;
            LabelCurrentTemperature = labelCurrentTemp;
            LabelDescription = labelDescription;
            PictureBoxIcon = weatherIcon;
            WeatherForecastPanel = weatherForecastPanel;
        }
        
        public void DisplayCurrentWeather()
        {
            DisplayWeather();
            DisplayTemp();
            DisplayCurrentDate();
            DisplayDescription();
            DisplayHumidity();
            DisplayRainChance();
            DisplayDayNight();
            DisplayWindSpeed();
            DisplayIcon();          
        }

        private void DisplayWeather()
        {          
            LabelCityName.Text = WeatherResponseFromAPI.location.name;
        }

        private void DisplayTemp()
        {
            LabelCurrentTemperature.Text = WeatherResponseFromAPI.current.temp_c + " ˚C";
        }

        private void DisplayCurrentDate()
        {
            LabelCurrentDate.Text = WeatherResponseFromAPI.forecast.forecastday[0].date.ToString();
        }

        private void DisplayDescription()
        {
            LabelDescription.Text = WeatherResponseFromAPI.current.condition.text.ToString();
        }

        private void DisplayHumidity()
        {

        }

        private void DisplayRainChance()
        {

        }

        private void DisplayDayNight()
        {

        }

        private void DisplayWindSpeed()
        {

        }

        private void DisplayIcon()
        {
            var UrlPath = WeatherResponseFromAPI.current.condition.icon;
            PictureBoxIcon.Load(@"http:" + UrlPath.ToString());
        }

        public void DisplayWeatherForecast()
        {
            var weatherForecastDaysInfo = WeatherResponseFromAPI.forecast.forecastday;          

            foreach (var dayInfo in weatherForecastDaysInfo)
            {             
                DailyWeatherControl dailyForecastUI = new DailyWeatherControl();
                dailyForecastUI.Date = dayInfo.date;
                dailyForecastUI.WeatherDescription = dayInfo.day.condition.text;
                dailyForecastUI.WeatherIcon = dayInfo.day.condition.icon.ToString();
                dailyForecastUI.TempC = dayInfo.day.maxtemp_c + "˚C";
                WeatherForecastPanel.Controls.Add(dailyForecastUI);
            }
           
        }    
    }

}
