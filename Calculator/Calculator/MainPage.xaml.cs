
using System;
using Xamarin.Forms;

namespace Calculator
{
    public partial class MainPage : ContentPage
    {
        int currentState = 1;
        string mathOperator;
        double firstNumber, secondNumber;

        public MainPage()
        {
            //this.OnClear();
            InitializeComponent();
        }

        void OnPressButtonDelete(object sender, EventArgs args)
        {
            this.Screen.Text = "0";
        }

        void OnSelectNumber(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string pressed = button.Text;

            if (this.Screen.Text == "0" || currentState < 0)
            {
                this.Screen.Text = "";
                if (currentState < 0)
                    currentState *= -1;
            }

            this.Screen.Text += pressed;

            double number;
            if (double.TryParse(this.Screen.Text, out number))
            {
                this.Screen.Text = number.ToString();
                if (currentState == 1)
                {
                    firstNumber = number;
                }
                else
                {
                    secondNumber = number;
                }
            }
        }

        void OnSelectOperator(object sender, EventArgs e)
        {
            currentState = -2;
            Button button = (Button)sender;
            string pressed = button.Text;
            mathOperator = pressed;
        }

        void OnClear(object sender, EventArgs e)
        {
            firstNumber = 0;
            secondNumber = 0;
            currentState = 1;
            this.Screen.Text = "0";
        }

        void OnCalculate(object sender, EventArgs e)
        {
            if (currentState == 2)
            {
                var result = SimpleCalculator.Calculate(firstNumber, secondNumber, mathOperator);

                this.Screen.Text = result.ToString();
                firstNumber = result;
                currentState = -1;
            }
        }
    }
}