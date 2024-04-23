namespace PerfectPay
{
    public partial class MainPage : ContentPage
    {
        decimal bill;
        int tip;
        int noPersons = 1;


        public MainPage()
        {
            InitializeComponent();
        }

        private void txtBill_Completed(object sender, EventArgs e)
        {
            bill = decimal.Parse(txtBill.Text);
            CalculateTotal();
        }

        private void CalculateTotal()
        {
            //Total tio
            var totalTip = (bill * tip) / 100;

            //tip by person
            var tipByPerson = (totalTip / noPersons);
            lblTipByPerson.Text = $"{tipByPerson:C}";

            var subTotal = (bill / noPersons);
            lblSubTotal.Text = $"{subTotal:C}";

            var totalByPerson =(bill + totalTip) / noPersons;
            lblTotal.Text=$"{subTotal:C}";
        }

        private void slTip_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            tip = (int)slTip.Value;
            lblTip.Text = $"Tip: {tip}%";
            CalculateTotal();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (sender is Button)
            {
                var btn = (Button)sender;
                var percentage = int.Parse(btn.Text.Replace("%", ""));
                slTip.Value = percentage;
            }
        }

        private void btnMinus_Clicked(object sender, EventArgs e)
        {
            if (noPersons > 0)
            {
                noPersons--;
            }
            lblNoPersons.Text = noPersons.ToString();
            CalculateTotal();
        }

        private void btnPlus_Clicked(object sender, EventArgs e)
        {
            noPersons++;
            lblNoPersons.Text = noPersons.ToString();
            CalculateTotal();
        }
    }

}
