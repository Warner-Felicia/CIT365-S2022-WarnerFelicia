using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace TimeMathQuiz
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Create a Random object called randomizer
        // to generate random numbers.
        Random randomizer = new Random();

        //integers for addition problem
        private int _addend1;
        private int _addend2;

        //integers for subtraction problem
        private int _minuend;
        private int _subtrahend;

        //integers for multiplication problem
        private int _multiplicand;
        private int _multiplier;

        //integers for division problem
        private int _dividend;
        private int _divisor;

        //integar for tracking time left
        private int _timeLeft;

        //check to see if game started
        private bool hasStarted;

        //fill in numbers for math problems and start timer
        public void StartTheQuiz()
        {
            //generate random number for addition problem
            _addend1 = randomizer.Next(51);
            _addend2 = randomizer.Next(51);

            //convert integers to strings to display
            plusLeftLabel.Text = _addend1.ToString();
            plusRightLabel.Text = _addend2.ToString();

            //make sure answer slot value is zero
            sum.Value = 0;

            //generate subtraction problem
            _minuend = randomizer.Next(1,101);
            _subtrahend = randomizer.Next(1, _minuend);
            minusLeftLabel.Text = _minuend.ToString();
            minusRightLabel.Text = _subtrahend.ToString();
            difference.Value = 0;

            //generate multiplication problem
            _multiplicand = randomizer.Next(2, 11);
            _multiplier = randomizer.Next(2, 11);
            timesLeftLabel.Text = _multiplicand.ToString();
            timesRightLabel.Text = _multiplier.ToString();
            product.Value = 0;

            //generate division problem
            _divisor = randomizer.Next(2,11);
            int temporaryQuotient = randomizer.Next(2, 11);
            _dividend = _divisor * temporaryQuotient;
            dividedLeftLabel.Text = _dividend.ToString();
            dividedRightLabel.Text = _divisor.ToString();
            quotient.Value = 0;

            //starts the timer
            _timeLeft = 30;
            timeLabel.Text = @"30 seconds";
            timer1.Start();

            //set hasStarted flag to true
            hasStarted = true;
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            StartTheQuiz();
            startButton.Enabled = false;
        }

        //checks answers, returns true if all correct, false if one or more is incorrect
        private bool CheckTheAnswer()
        {
            if (_addend1 + _addend2 == sum.Value
                && _minuend - _subtrahend == difference.Value
                && _multiplicand * _multiplier == product.Value
                // ReSharper disable once PossibleLossOfFraction (inputs created to avoid loss of fraction)
                && _dividend / _divisor == quotient.Value)
                return true;
            else
                return false;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (CheckTheAnswer())
            {
                //user got answers right, stop the timer and show a MessageBox
                timer1.Stop();
                timeLabel.ResetBackColor();
                MessageBox.Show(@"You got all the answers right!", @"Congratulations!");
               startButton.Enabled = true;
               hasStarted = false;


            }
            else if (_timeLeft > 0)
            {
                //user got at least one answer wrong and there is time left, keep counting down, decrease time left by one second and display new time by updating the Time Left label
                _timeLeft = _timeLeft - 1;
                timeLabel.Text = $@"{_timeLeft} seconds";

                if (_timeLeft <= 5)
                {
                    timeLabel.BackColor = Color.Red;
                }
            }
            else
            {
                //user got at least one answer wrong and ran out of time, stop the timer, show and MessageBox, and fill in the answers
                timer1.Stop();
                timeLabel.ResetBackColor();
                timeLabel.Text = @"Time's Up!";
                MessageBox.Show(@"You didn't finish in time.", @"Sorry!");
                sum.Value = _addend1 + _addend2;
                difference.Value = _minuend - _subtrahend;
                product.Value = _multiplicand * _multiplier;
                quotient.Value = _dividend / _divisor;
                startButton.Enabled = true;
                hasStarted = false;

            }
        }

        private void answer_Enter(object sender, EventArgs e)
        {
            NumericUpDown answerBox = sender as NumericUpDown;

            if (answerBox != null)
            {
                int lengthOfAnswer = answerBox.Value.ToString(CultureInfo.CurrentCulture).Length;
                answerBox.Select(0, lengthOfAnswer);
            }
        }

        private void CorrectSound(object sender, EventArgs e)
        {
            //plays a sound if answer is correct
            NumericUpDown answerBox = sender as NumericUpDown;
            
            if (answerBox != null)
            {
                var type = answerBox.Name;
                switch (type)
                {
                    case "sum":
                    {
                        PlaySound(_addend1 + _addend2 == answerBox.Value ? "correct" : "incorrect");
                        break;
                    }
                    case "difference":
                    {
                        PlaySound(_minuend - _subtrahend == answerBox.Value ? "correct" : "incorrect");
                        break;
                    }
                    case "product":
                    {
                        PlaySound(_multiplicand * _multiplier == answerBox.Value ? "correct" : "incorrect");
                        break;
                    }
                    case "quotient":
                    {
                        // ReSharper disable once PossibleLossOfFraction
                        PlaySound(type: _dividend / _divisor == answerBox.Value ? "correct" : "incorrect");
                        break;
                        }
                }
            }
        }

        //plays sound for correct answers
        private void PlaySound(String type)
        {
            System.Media.SoundPlayer player =
                new System.Media.SoundPlayer();
            player.SoundLocation = $"Sounds/{type}.wav";
            player.Load();
            player.Play();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            String formattedDate = DateTime.Now.ToString("dd MMMM yyyy");
            currentDate.Text = formattedDate;

        }

    }
}
