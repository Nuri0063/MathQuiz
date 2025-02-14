﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MathQuiz
{
    public partial class Form1 : Form
    {
        Random randomizer = new Random();


        int addend1;
        int addend2;

        int minuend;
        int subtrahend;

        int multiplicand;
        int multiplier;

        int dividend;
        int divisor;

        int timeLeft;

        public Form1()
        {
            InitializeComponent();
        }

        public void StartTheQuiz()
        {
            timeLabel.BackColor = Color.Red;
            //toplama işlemlerinde kullanıcak iki sayıyı random olarak elde ettik
            //NumericUpDown değerini 0 verdik 
            //aynı işemleri aşağıda çıkartma, çarpma ve bölme içinde gerçekleştirdik
            addend1 = randomizer.Next(51);
            addend2 = randomizer.Next(51);
            plusLeftLabel.Text = addend1.ToString();
            plusRightLabel.Text = addend2.ToString();
            sum.Value = 0;

            minuend = randomizer.Next(1, 101);
            subtrahend=randomizer.Next(1,minuend);
            minusLeftLabel.Text = minuend.ToString();
            minusRightLabel.Text = subtrahend.ToString();
            difference.Value = 0;

            multiplicand = randomizer.Next(2, 11);
            multiplier = randomizer.Next(2, 11);
            timesLeftLabel.Text = multiplicand.ToString();
            timesRightLabel.Text = multiplier.ToString();
            product.Value = 0;

            divisor = randomizer.Next(2, 11);
            int temporaryQuotient = randomizer.Next(2, 11); //burda rastgele bir sayı üretilip int olarak tutuluyor
            dividend = divisor * temporaryQuotient;         //tutulan sayı bölüm ile çarpılıyor bölene ekleniyor. Bunun sebebi tam bölünsün diye
            dividedLeftLabel.Text = dividend.ToString();
            dividedRightLabel.Text = divisor.ToString();
            quotient.Value = 0;

            timeLeft = 30;
            timeLabel.Text = "30 seconds";
            timer1.Start();



        }

        private bool CheckTheAnswer()
        {
            if((addend1+addend2==sum.Value)
                &&(minuend-subtrahend==difference.Value)
                &&(multiplicand*multiplier==product.Value) 
                && (dividend/divisor==quotient.Value))
                return true;
            else
                return false;
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            StartTheQuiz();
            startButton.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (CheckTheAnswer())
            {

                timer1.Stop();
                MessageBox.Show("Bütün soruları doğru bildiniz. Tebrikler!");
                startButton.Enabled = true;
            }
            else if (timeLeft > 0)
            {
                timeLeft -= 1;
                timeLabel.Text = timeLeft + "seconds";

            }
            else
            {
                timer1.Stop();
                timeLabel.Text = "Time's Up!";
                MessageBox.Show("Zamanında bitiremedin", "sağlık olsun..");
                sum.Value = addend1 + addend2;
                difference.Value = minuend - subtrahend;
                product.Value = multiplicand * multiplier;
                quotient.Value = dividend / divisor;
                startButton.Enabled = true;
            }
        }

        private void answer_Enter(object sender, EventArgs e)
        {
            //bu metod clik ve enter propertilerine eklenmiştir
            //yani NumericUpDown ın içine tıklayarak ve klavye ile girilidiği anda çalışacak
            //bu moetod çağırıldığı zaman NumericUpDown ın içinde yazanların 0. indeksinden yazının uzunluğuna kadar olan kısmı seçer
            NumericUpDown answerBox; 
            answerBox= sender as NumericUpDown;

            if (answerBox != null)
            {
                int lengthOfAnswer = answerBox.Value.ToString().Length;
                answerBox.Select(0, lengthOfAnswer);
            }
        }
    }
}
