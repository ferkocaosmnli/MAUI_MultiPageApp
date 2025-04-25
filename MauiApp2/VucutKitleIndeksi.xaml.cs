using System;
using Microsoft.Maui.Controls;
using System.Globalization;

namespace MauiApp2
{
    public partial class VucutKitleIndeksi : ContentPage
    {
        public VucutKitleIndeksi()
        {
            InitializeComponent();
        }

        private void OnCalculateClicked(object sender, EventArgs e)
        {
            string weightText = weightEntry.Text?.Replace(',', '.');
            string heightText = heightEntry.Text?.Replace(',', '.');

            if (double.TryParse(weightText, NumberStyles.Any, CultureInfo.InvariantCulture, out double weight) &&
                double.TryParse(heightText, NumberStyles.Any, CultureInfo.InvariantCulture, out double height) &&
                height > 0 && weight > 0)
            {
                double bmi = weight / (height * height);

                resultLabel.Text = $"Vücut Kitle İndeksi (BMI): {bmi:F2}";
                categoryLabel.Text = $"Kategori: {DetermineBMICategory(bmi)}";
            }
            else
            {
                resultLabel.Text = "❗ Lütfen geçerli bir kilo ve boy giriniz!";
                categoryLabel.Text = "";
            }
        }

        private string DetermineBMICategory(double bmi)
        {
            if (bmi < 16) return "İleri derecede zayıf";
            else if (bmi < 17) return "Orta derecede zayıf";
            else if (bmi < 18.5) return "Hafif zayıf";
            else if (bmi < 25) return "Normal kilolu";
            else if (bmi < 30) return "Fazla kilolu";
            else if (bmi < 35) return "1. Derece obez";
            else if (bmi < 40) return "2. Derece obez";
            else return "3. Derece obez (morbid obez)";
        }
    }
}