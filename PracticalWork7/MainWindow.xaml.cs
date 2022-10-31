using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Пять
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        Liquid liquid1;
        Alcohol alcohol1;
        Beer beer1;
        char whatIsIt1;
        private void btn_Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Double.TryParse(hopCont.Text, out double hopContent);
                Double.TryParse(str.Text, out double strength);
                if (hopContent > 0)
                {
                    whatIsIt1 = 'b';
                    beer1 = new Beer(Convert.ToString(name.Text), Convert.ToDouble(dens.Text),
                    Convert.ToDouble(vol.Text), strength, hopContent);
                    liquid1_info.Text = beer1.LiquidInfo();
                }
                else
                {
                    hopCont.Text = "0";
                    if (strength > 0)
                    {
                        whatIsIt1 = 'a';
                        alcohol1 = new Alcohol(Convert.ToString(name.Text), Convert.ToDouble(dens.Text), 
                            Convert.ToDouble(vol.Text), strength);
                        liquid1_info.Text = alcohol1.LiquidInfo();
                    }
                    else
                    {
                        whatIsIt1 = 'l';
                        str.Text = "0";
                        liquid1 = new Liquid(Convert.ToString(name.Text), Convert.ToDouble(dens.Text), 
                            Convert.ToDouble(vol.Text));
                        liquid1_info.Text = liquid1.LiquidInfo();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        Liquid liquid2;
        Alcohol alcohol2;
        Beer beer2;
        char whatIsIt2;
        private void btn_Add2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Double.TryParse(l2_hopCont.Text, out double hopContent);
                Double.TryParse(l2_str.Text, out double strength);
                if (hopContent > 0)
                {
                    whatIsIt2 = 'b';
                    beer2 = new Beer(Convert.ToString(l2_name.Text), Convert.ToDouble(l2_dens.Text),
                    Convert.ToDouble(l2_vol.Text), strength, hopContent);
                    liquid2_info.Text = beer2.LiquidInfo();
                }
                else
                {
                    l2_hopCont.Text = "0";
                    if (strength > 0)
                    {
                        whatIsIt2 = 'a';
                        alcohol2 = new Alcohol(Convert.ToString(l2_name.Text), Convert.ToDouble(l2_dens.Text),
                            Convert.ToDouble(l2_vol.Text), strength);
                        liquid2_info.Text = alcohol2.LiquidInfo();
                    }
                    else
                    {
                        whatIsIt2 = 'l';
                        l2_str.Text = "0";
                        liquid2 = new Liquid(Convert.ToString(l2_name.Text), Convert.ToDouble(l2_dens.Text),
                            Convert.ToDouble(l2_vol.Text));
                        liquid2_info.Text = liquid2.LiquidInfo();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_Edit2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string name = l2_name.Text;
                Double.TryParse(l2_dens.Text, out double dens);
                Double.TryParse(l2_vol.Text, out double vol);
                Double.TryParse(l2_hopCont.Text, out double hopContent);
                Double.TryParse(l2_str.Text, out double strength);
                if (whatIsIt2 == 'l')
                {
                    liquid2.SetParams(name, dens, vol);
                    liquid2_info.Text = liquid2.LiquidInfo();
                }
                else if (whatIsIt2 == 'b')
                {
                    beer2.SetParams(name, dens, vol, strength, hopContent);
                    liquid2_info.Text = beer2.LiquidInfo();
                }
                else
                {
                    alcohol2.SetParams(name, dens, vol, strength);
                    liquid2_info.Text = alcohol2.LiquidInfo();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_Edit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string lName = name.Text;
                Double.TryParse(dens.Text, out double density);
                Double.TryParse(vol.Text, out double volume);
                Double.TryParse(hopCont.Text, out double hopContent);
                Double.TryParse(str.Text, out double strength);
                if (whatIsIt1 == 'l')
                {
                    liquid1.SetParams(lName, density, volume);
                    liquid1_info.Text = liquid1.LiquidInfo();
                }
                else if (whatIsIt1 == 'b')
                {
                    beer1.SetParams(lName, density, volume, strength, hopContent);
                    liquid1_info.Text = beer1.LiquidInfo();
                }
                else
                {
                    alcohol1.SetParams(lName, density, volume, strength);
                    liquid1_info.Text = alcohol1.LiquidInfo();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void about_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Практическая работа №7\n\nДунаева М.И\n\nВариант 14\n\n" +
                " Использовать класс Liquid (жидкость), имеющий поля названия, плотности и " +
                "объема.Создать необходимые методы и свойства.Создать перегруженные методы" +
                "SetParams, для установки параметров жидкости.Создать производный класс" +
                "Alcohol(спирт), имеющий крепость.Из класса Alcohol создать производный класс" +
                "Beer(пиво), имеющий процент содержания хмеля.Определить методы " +
                "переназначения и изменения крепости и процента хмеля.");
        }

        private void btn_decr_Click(object sender, RoutedEventArgs e)
        {
            if (whatIsIt1 == 'l')
            {
                liquid1--;
                liquid1_info.Text = liquid1.LiquidInfo();
            }
            else if (whatIsIt1 == 'b')
            {
                beer1--;
                liquid1_info.Text = beer1.LiquidInfo();
            }
            else
            {
                alcohol1--;
                liquid1_info.Text = alcohol1.LiquidInfo();
            }
        }

        private void btn_inc_Click(object sender, RoutedEventArgs e)
        {
            if (whatIsIt1 == 'l')
            {
                liquid1++;
                liquid1_info.Text = liquid1.LiquidInfo();
            }
            else if (whatIsIt1 == 'b')
            {
                beer1++;
                liquid1_info.Text = beer1.LiquidInfo();
            }
            else
            {
                alcohol1++;
                liquid1_info.Text = alcohol1.LiquidInfo();
            }
        }

        private void btn_inc2_Click(object sender, RoutedEventArgs e)
        {
            if (whatIsIt2 == 'l')
            {
                liquid2++;
                liquid2_info.Text = liquid2.LiquidInfo();
            }
            else if (whatIsIt1 == 'b')
            {
                beer2++;
                liquid2_info.Text = beer2.LiquidInfo();
            }
            else
            {
                alcohol2++;
                liquid2_info.Text = alcohol2.LiquidInfo();
            }
        }

        private void btn_decr2_Click(object sender, RoutedEventArgs e)
        {
            if (whatIsIt2 == 'l')
            {
                liquid2--;
                liquid2_info.Text = liquid2.LiquidInfo();
            }
            else if (whatIsIt1 == 'b')
            {
                beer2--;
                liquid2_info.Text = beer2.LiquidInfo();
            }
            else
            {
                alcohol2--;
                liquid2_info.Text = alcohol2.LiquidInfo();
            }
        }
    }
}
