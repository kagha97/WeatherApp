﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Weather_Broadcast
{
    public partial class MainWeatherForm : Form
    {
        Weather weather;
        private string SelectedCity;

        public MainWeatherForm(string city)
        {
            InitializeComponent();

            SelectedCity = city;

            weather = new Weather(SelectedCity,labelMainCity, labelDate, labelMainCurrentTemp, labelMainCurrentDescription, pbMainCurrentIcon);


        }
    }
}
