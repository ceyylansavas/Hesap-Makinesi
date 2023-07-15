using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace HesapMakinesi
{
    public partial class Form1 : Form
    {
        bool optDrm = false;
        double sonuc = 0;
        double hafiza;
        string isaret = "";
        bool esittirTiklandiMi = false;
        public Form1()
        {
            InitializeComponent();
        }



        private void btn_Number_Click(object sender, EventArgs e)
        {

            if (txt_sonuc.Text == "0" || optDrm)
                txt_sonuc.Clear();

            optDrm = false;
            Button btn = (Button)sender;
            txt_sonuc.Text += btn.Text;
            lb_sonuc.Text += btn.Text;

        }
        private void btn_virgul_Click(object sender, EventArgs e)
        {

            if (!txt_sonuc.Text.Contains(","))
            {
                txt_sonuc.Text += ",";
            }
            optDrm = false;

        }

        private void btn_geriAl_Click(object sender, EventArgs e)
        {

            txt_sonuc.Text = txt_sonuc.Text.Substring(0, txt_sonuc.Text.Length - 1);
            lb_sonuc.Text = lb_sonuc.Text.Substring(0, lb_sonuc.Text.Length - 1);


        }
        private void btn_ce_Click(object sender, EventArgs e)
        {
            txt_sonuc.Text = "0";
            lb_sonuc.Text = "";
            richTextBox1.Text = "";
            isaret = "";
            sonuc = 0;
        }
        private void btn_c_Click(object sender, EventArgs e)
        {
            txt_sonuc.Text = "0";
            richTextBox1.Text = "";
        }


        private void btn_islemler(object sender, EventArgs e)
        {

            optDrm = true;
            Button btn = (Button)sender;
            string yeniOpt = btn.Text;


            switch (isaret)
            {
                case "+": txt_sonuc.Text = (sonuc + Double.Parse(txt_sonuc.Text)).ToString(); break;
                case "-": txt_sonuc.Text = (sonuc - Double.Parse(txt_sonuc.Text)).ToString(); break;
                case "*": txt_sonuc.Text = (sonuc * Double.Parse(txt_sonuc.Text)).ToString(); break;
                case "%":
                    txt_sonuc.Text = ((sonuc / 100) * Double.Parse(txt_sonuc.Text)).ToString();
                    lb_sonuc.Text = txt_sonuc.Text + " " + yeniOpt;
                    break;
                case "^":
                    double sum = 1;

                    if (txt_sonuc.Text != "0")
                    {
                        for (int i = 0; i < Double.Parse(txt_sonuc.Text); i++)
                        {
                            sum *= sonuc;
                        }
                        txt_sonuc.Text = sum.ToString();
                        
                    }
                    else if (txt_sonuc.Text == "0")
                    {
                        MessageBox.Show("İkinci bir sayı girmelisiniz");
                        
                    }


                    break;
                case "/":
                    if (Double.Parse(txt_sonuc.Text) == 0)
                    {
                        txt_sonuc.Text = "HATA!";
                    }
                    else
                    {
                        txt_sonuc.Text = (sonuc / Double.Parse(txt_sonuc.Text)).ToString();
                    }
                    break;
            }

            sonuc = Double.Parse(txt_sonuc.Text);
            txt_sonuc.Text = sonuc.ToString();
            isaret = yeniOpt;

            if (richTextBox1.Text != "")
            {
                lb_sonuc.Text = richTextBox1.Text + yeniOpt;
            }
            else 
            {
                lb_sonuc.Text = txt_sonuc.Text + " " + yeniOpt;
            }

            //txt_sonuc.Text = "0";

        }
        private void btn_Karesi(object sender, EventArgs e)
        {
            double kare = Convert.ToDouble(txt_sonuc.Text);
            kare = Math.Pow(kare, 2);
            isaret = "x²";
            lb_sonuc.Text =txt_sonuc.Text + isaret;
            txt_sonuc.Text = Convert.ToString(kare);
            optDrm = true;
            sonuc = Double.Parse(txt_sonuc.Text);
            txt_sonuc.Text = sonuc.ToString();
        }


        private void btn_Faktoriyeli(object sender, EventArgs e)
        {
            sonuc = 1;
            for (int i = 1; i <= Double.Parse(txt_sonuc.Text); i++)
            {
                sonuc *= i;
            }
            isaret = "!";
            lb_sonuc.Text = txt_sonuc.Text + isaret;
            txt_sonuc.Text = sonuc.ToString();


        }

        private void btn_Karekoku(object sender, EventArgs e)
        {
            double karekok = Convert.ToDouble(txt_sonuc.Text);
            karekok = Math.Sqrt(karekok);
            isaret = "√";
            lb_sonuc.Text = isaret + txt_sonuc.Text;
            txt_sonuc.Text = Convert.ToString(karekok);
            optDrm = true;
            sonuc = Double.Parse(txt_sonuc.Text);
            txt_sonuc.Text = sonuc.ToString();
        }

        private void btn_BirBolu(object sender, EventArgs e)
        {
            double bolum = Convert.ToDouble(txt_sonuc.Text);  
            bolum = 1 / (bolum);
            isaret = "1/";
            lb_sonuc.Text = isaret + txt_sonuc.Text;
            txt_sonuc.Text = Convert.ToString(bolum);
            optDrm = true;
            sonuc = Double.Parse(txt_sonuc.Text);
            txt_sonuc.Text = sonuc.ToString();
        }



        private void btn_sonuc_Click(object sender, EventArgs e)
        {
            optDrm = true;
            Button btn = (Button)sender;
            esittirTiklandiMi = true;
            lb_sonuc.Text = "";




            switch (isaret)
            {
                case "+": txt_sonuc.Text = (sonuc + Double.Parse(txt_sonuc.Text)).ToString(); break;
                case "-": txt_sonuc.Text = (sonuc - Double.Parse(txt_sonuc.Text)).ToString(); break;
                case "*": txt_sonuc.Text = (sonuc * Double.Parse(txt_sonuc.Text)).ToString(); break;
                case "%": txt_sonuc.Text = ((sonuc / 100) * Double.Parse(txt_sonuc.Text)).ToString(); break;
                case "^":

                    double sum = 1;

                    if (txt_sonuc.Text != "0")
                    {
                        for (int i = 0; i < Double.Parse(txt_sonuc.Text); i++)
                        {
                            sum *= sonuc;
                        }
                        txt_sonuc.Text = sum.ToString();
                    }
                    else if (txt_sonuc.Text == "0")
                    {
                        MessageBox.Show("İkinci bir sayı girmelisiniz");
                    }


                    break;
                case "/":
                    if (Double.Parse(txt_sonuc.Text) == 0)
                    {
                        lb_sonuc.Text = "HATA!";
                    }
                    else
                    {
                        txt_sonuc.Text = (sonuc / Double.Parse(txt_sonuc.Text)).ToString();
                    }
                    break;
                case "x²":
                    double kare = Convert.ToDouble(txt_sonuc.Text);
                    sonuc = Math.Pow(kare, 2);
                    txt_sonuc.Text = Convert.ToString(kare);
                    break;
                case "!":
                    sonuc = 1;
                    for (int i = 1; i <= Double.Parse(txt_sonuc.Text); i++)
                    {
                        sonuc *= i;
                    }
                    break;
                case "√":
                    double karekok = Convert.ToDouble(txt_sonuc.Text);
                    sonuc = Math.Sqrt(karekok);
                    txt_sonuc.Text = Convert.ToString(karekok);
                    break;
                case "1/x":
                    double bolum = Convert.ToDouble(txt_sonuc.Text);
                    bolum = 1 / (bolum);
                    txt_sonuc.Text = Convert.ToString(bolum);
                    break;

            }

            sonuc = Double.Parse(txt_sonuc.Text);
            txt_sonuc.Text = sonuc.ToString();

            if (esittirTiklandiMi)
            {
                richTextBox1.Text = "Ans";
            }
            else
            {
                richTextBox1.Text += btn.Text;
            }

            isaret = "";

        }
        private void btn_hafizaIslemleri(object sender, EventArgs e)
        {
            if (txt_sonuc.Text.Length == 0)

            {

                txt_sonuc.Text = "0";

            }

            switch ((sender as Button).Text)

            {

                case "MC":

                    hafiza = 0;
                    lb_hafiza.Text = "";

                    break;

                case "M+":

                    hafiza = hafiza + double.Parse(txt_sonuc.Text);
                    lb_hafiza.Text = "M";

                    break;

                case "M-":

                    hafiza = hafiza - double.Parse(txt_sonuc.Text);
                    lb_hafiza.Text = "M";

                    break;
                case "MS":
                    txt_sonuc.Text = hafiza.ToString();
                    break;

                case "MR":

                    txt_sonuc.Text = hafiza.ToString();
                    lb_hafiza.Text = "M";

                    break;

            }
        }



        public void guncelRenk()
        {
            btn_toplama.BackColor = Color.SaddleBrown;
            btn_cikarma.BackColor = Color.SaddleBrown;
            btn_carpma.BackColor = Color.SaddleBrown;
            btn_bolme.BackColor = Color.SaddleBrown;
        }


        private void btn_ortakRenk_click(object sender, MouseEventArgs e)
        {
            Button btn = (Button)sender;
            guncelRenk();
            btn.BackColor = Color.White;
        }


        private void btnToggleSifirlama(object sender, MouseEventArgs e)
        {
            Button button = (Button)sender;
            guncelRenk();
        }
    
    }
}
    

