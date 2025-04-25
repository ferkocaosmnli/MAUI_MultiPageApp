using System;
using Microsoft.Maui.Controls;
using System.Globalization;

namespace MauiApp2
{
    public partial class KrediHesaplama : ContentPage
    {
        private const double KKDF_Ihtiyac = 0.15;
        private const double BSMV_Ihtiyac = 0.10;
        private const double KKDF_Tasit = 0.15;
        private const double BSMV_Tasit = 0.05;
        private const double KKDF_Konut = 0.0;
        private const double BSMV_Konut = 0.0;
        private const double KKDF_Ticari = 0.0;
        private const double BSMV_Ticari = 0.05;

        public KrediHesaplama()
        {
            InitializeComponent();
        }

        private void OnCalculateClicked(object sender, EventArgs e)
        {
            if (loanTypePicker.SelectedItem == null)
            {
                DisplayAlert("Hata", "Lütfen kredi türünü seçin.", "Tamam");
                return;
            }

            if (!double.TryParse(loanAmountEntry.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out double loanAmount) ||
                !int.TryParse(loanTermEntry.Text, out int loanTerm) ||
                !double.TryParse(interestRateEntry.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out double interestRate))
            {
                DisplayAlert("Hata", "Lütfen geçerli değerler girin.", "Tamam");
                return;
            }

            if (loanAmount <= 0 || loanTerm <= 0 || interestRate <= 0)
            {
                DisplayAlert("Hata", "Giriş değerleri sıfırdan büyük olmalıdır.", "Tamam");
                return;
            }

            string loanType = loanTypePicker.SelectedItem.ToString();
            double monthlyRate = interestRate / 100;
            double brutFaiz = CalculateBrutFaiz(monthlyRate, loanType);
            double monthlyPayment = CalculateMonthlyPayment(loanAmount, brutFaiz, loanTerm);
            double totalPayment = monthlyPayment * loanTerm;
            double totalInterest = totalPayment - loanAmount;

            resultLabel.Text = $"Aylık Taksit: {monthlyPayment:F2} TL";
            totalPaymentLabel.Text = $"Toplam Ödeme: {totalPayment:F2} TL";
            totalInterestLabel.Text = $"Toplam Faiz: {totalInterest:F2} TL";
        }

        private double CalculateBrutFaiz(double monthlyRate, string loanType)
        {
            double KKDF = 0, BSMV = 0;

            switch (loanType)
            {
                case "İhtiyaç Kredisi":
                    KKDF = KKDF_Ihtiyac;
                    BSMV = BSMV_Ihtiyac;
                    break;
                case "Konut Kredisi":
                    KKDF = KKDF_Konut;
                    BSMV = BSMV_Konut;
                    break;
                case "Taşıt Kredisi":
                    KKDF = KKDF_Tasit;
                    BSMV = BSMV_Tasit;
                    break;
                case "Ticari Kredi":
                    KKDF = KKDF_Ticari;
                    BSMV = BSMV_Ticari;
                    break;
            }

            return monthlyRate * (1 + KKDF + BSMV);
        }

        private double CalculateMonthlyPayment(double principal, double rate, int termMonths)
        {
            if (rate == 0) return principal / termMonths;

            double factor = Math.Pow(1 + rate, termMonths);
            return (principal * factor * rate) / (factor - 1);
        }
    }
}