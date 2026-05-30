using Newtonsoft.Json;
using System;
using System.Collections.Generic; 
using System.Net.Http;
using System.Windows.Forms;

namespace ApiPracting
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void WeatherData()
        {
            using (HttpClient client = new HttpClient())
            {

                try
                {

                    string url = $"https://api.open-meteo.com/v1/forecast?latitude=52.52&longitude=13.41&hourly=temperature_2m,precipitation_probability,precipitation&timezone=auto";

                    string jsonResult = await client.GetStringAsync(url);

                    Weather weathers = JsonConvert.DeserializeObject<Weather>(jsonResult);

                    if (weathers != null && weathers.Hourly != null)
                    {
                     
                        List<HourlyWeatherRow> tableRows = new List<HourlyWeatherRow>();

                        
                        for (int i = 0; i < weathers.Hourly.Time.Count; i++)
                        {
                            tableRows.Add(new HourlyWeatherRow
                            {
                                Time = weathers.Hourly.Time[i],
                                Temperature = weathers.Hourly.Temperature[i],
                                Precipitation = weathers.Hourly.PrecipitationProbability[i]
                            });
                        }

                        
                        dataGridViewCoins.DataSource = null;
                        dataGridViewCoins.DataSource = tableRows;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при получении данных: {ex.Message}");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WeatherData();
        }

        private void Form1_Load(object sender, EventArgs e)
        {


            WeatherData();
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            WeatherData();
        }

        private void dataGridViewCoins_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}