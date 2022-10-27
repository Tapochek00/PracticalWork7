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
        private void btn_Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Double.TryParse(hopCont.Text, out double hopContent);
                Double.TryParse(str.Text, out double strength);
                if (hopContent > 0)
                {
                    liquid1 = new Beer(Convert.ToString(name.Text), Convert.ToDouble(dens.Text),
                    Convert.ToDouble(vol.Text), strength, hopContent);
                }
                else
                {
                    hopCont.Text = "0";
                    if (strength > 0) liquid1 = new Alcohol(Convert.ToString(name.Text), Convert.ToDouble(dens.Text),
                    Convert.ToDouble(vol.Text), strength);
                    else
                    {
                        str.Text = "0";
                        liquid1 = new Liquid(Convert.ToString(name.Text), Convert.ToDouble(dens.Text), Convert.ToDouble(vol.Text));
                    }
                }
                liquid1_info.Text = liquid1.LiquidInfo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_Dif_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (rb_dens.IsChecked == true) result.Text = Convert.ToString(liquid1.DensityDifference(liquid2));
                else result.Text = Convert.ToString(liquid1.VolumeDifference(liquid2));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        Liquid liquid2;
        private void btn_Add2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Double.TryParse(l2_hopCont.Text, out double hopContent);
                Double.TryParse(l2_str.Text, out double strength);
                if (hopContent > 0)
                {
                    liquid2 = new Beer(Convert.ToString(l2_name.Text), Convert.ToDouble(l2_dens.Text),
                    Convert.ToDouble(l2_vol.Text), strength, hopContent);
                }
                else
                {
                    l2_hopCont.Text = "0";
                    if (strength > 0) liquid2 = new Alcohol(Convert.ToString(l2_name.Text), Convert.ToDouble(l2_dens.Text),
                    Convert.ToDouble(l2_vol.Text), strength);
                    else
                    {
                        l2_str.Text = "0";
                        liquid2 = new Liquid(Convert.ToString(l2_name.Text), Convert.ToDouble(l2_dens.Text), Convert.ToDouble(l2_vol.Text));
                    }
                }
                liquid2_info.Text = liquid2.LiquidInfo();
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
                liquid2.SetParams(Convert.ToString(l2_name.Text), Convert.ToDouble(l2_dens.Text), Convert.ToDouble(l2_vol.Text));
                liquid2_info.Text = liquid2.LiquidInfo();
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
                if (hopCont.Text == "0" && str.Text == "0") liquid1.SetParams(Convert.ToString(name.Text), Convert.ToDouble(dens.Text), Convert.ToDouble(vol.Text));
                else if (hopCont.Text != "0") liquid1.SetParams(Convert.ToString(name.Text), Convert.ToDouble(dens.Text), Convert.ToDouble(vol.Text), Convert.ToDouble(str.Text), Convert.ToDouble(hopCont.Text));
                liquid1_info.Text = liquid1.LiquidInfo();
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
            liquid1--;
            liquid1_info.Text = liquid1.LiquidInfo();
        }

        private void btn_inc_Click(object sender, RoutedEventArgs e)
        {
            liquid1++;
            liquid1_info.Text = liquid1.LiquidInfo();
        }

        private void btn_inc2_Click(object sender, RoutedEventArgs e)
        {
            liquid2++;
            liquid2_info.Text = liquid2.LiquidInfo();
        }

        private void btn_decr2_Click(object sender, RoutedEventArgs e)
        {
            liquid2--;
            liquid2_info.Text = liquid2.LiquidInfo();
        }
    }
}
