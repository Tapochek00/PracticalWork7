﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Пять
{
    class Liquid
    {
        String name;
        double density;
        double volume;

        public String Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public double Density
        {
            get
            {
                return density;
            }
            set
            {
                density = value;
            }
        }

        public Double Volume
        {
            get
            {
                return volume;
            }
            set
            {
                volume = value;
            }
        }

        public Liquid()
        {
            Name = "";
            Density = 0;
            Volume = 0;
        }

        public Liquid(string name, double density, double volume)
        {
            Name = name;
            Density = density;
            Volume = volume;
        }

        /// <summary>
        /// Находит разницу объёмов жидкостей
        /// </summary>
        /// <param name="liquid">Вторая жидкость</param>
        /// <returns>Разницу объёмов</returns>
        public double VolumeDifference(Liquid liquid)
        {
            return Math.Abs(liquid.Volume - Volume);
        }

        /// <summary>
        /// Находит разницу плотностей жидкостей
        /// </summary>
        /// <param name="liquid">Вторая жидкость</param>
        /// <returns>Разницу жидкостей</returns>
        public double DensityDifference(Liquid liquid)
        {
            return Math.Abs(liquid.Density - Density);
        }

        /// <summary>
        /// Изменить назнание, плотность и объём жидкости 
        /// </summary>
        public void SetParams()
        {
            Name = "";
            Density = 0;
            Volume = 0;
        }

        /// <summary>
        /// Изменить назнание, плотность и объём жидкости 
        /// </summary>
        public void SetParams(string name, double density, double volume)
        {
            Name = name;
            Density = density;
            Volume = volume;
        }

        /// <summary>
        /// Возвращает информацию о жидкости, собранную в одну строку
        /// </summary>
        /// <returns>Информация о жидкости</returns>
        public virtual string LiquidInfo()
        {
            return "Название: " + Name + "\n" + "Плотность: " + Density.ToString() + "\n" +
                "Объём: " + Volume.ToString() + "\n" + "Крепость: 0" + "\n" + "Содержание хмеля: 0";
        }

        /// <summary>
        /// Проверка, что сосуды имеют одинаковые жидкости равного объема.
        /// </summary>
        /// <param name="liquid1">Жидкость 1</param>
        /// <param name="liquid2">Жидкость 2</param>
        /// <returns>true, если жидкости одинаковые; false, если жидкости разные</returns>
        public static bool operator ==(Liquid liquid1, Liquid liquid2)
        {
            if (liquid1.Name == liquid2.Name && liquid1.Density == liquid2.Density && liquid1.Volume == liquid2.Volume) return true;
            else return false;
        }

        /// <summary>
        /// Проверка, что сосуды имеют разные жидкости.
        /// </summary>
        /// <param name="liquid1">Жидкость 1</param>
        /// <param name="liquid2">Жидкость 2</param>
        /// <returns>true, если жидкости разные; false, если жидкости одинаковые</returns>
        public static bool operator !=(Liquid liquid1, Liquid liquid2)
        {
            if (liquid1.Name != liquid2.Name || liquid1.Density != liquid2.Density || liquid1.Volume != liquid2.Volume) return true;
            else return false;
        }

        /// <summary>
        /// Увеличивает объём на 1
        /// </summary>
        public static Liquid operator ++(Liquid liquid)
        {
            liquid.Volume += 1;
            return liquid;
        }

        /// <summary>
        /// Уменьшает объём на 1
        /// </summary>
        public static Liquid operator --(Liquid liquid)
        {
            if (liquid.Volume > 0) liquid.Volume -= 1;
            return liquid;
        }
    }

    class Alcohol:Liquid
    {
        double strength;

        public double Strength
        {
            get
            {
                return strength;
            }
            set
            {
                strength = value;
            }
        }

        public Alcohol()
        {
            Name = "";
            Density = 0;
            Volume = 0;
            Strength = 0;
        }

        public Alcohol(string name, double density, double volume, double strength):
            base(name, density, volume)
        {
            Strength = strength;
        }

        public new void SetParams()
        {
            Name = "";
            Density = 0;
            Volume = 0;
            Strength = 0;
        }

        public void SetParams(string name, double density, double volume, double strength)
        {
            Name = name;
            Density = density;
            Volume = volume;
            Strength = strength;
        }

        /// <summary>
        /// Увеличивает объём на 1
        /// </summary>
        public static Alcohol operator ++(Alcohol liquid)
        {
            liquid.Volume += 1;
            return liquid;
        }

        /// <summary>
        /// Уменьшает объём на 1
        /// </summary>
        public static Alcohol operator --(Alcohol liquid)
        {
            if (liquid.Volume > 0) liquid.Volume -= 1;
            return liquid;
        }

        public override string LiquidInfo()
        {
            return "Название: " + Name + "\n" + "Плотность: " + Density.ToString() + "\n" +
                "Объём: " + Volume.ToString() + "\n" + "Крепость: " + Strength.ToString() +
                "\n" + "Содержание хмеля: 0";
        }
    }

    class Beer:Alcohol
    {
        double hopContent;

        public double HopContent
        {
            get
            {
                return hopContent;
            }
            set
            {
                hopContent = value;
            }
        }

        public Beer()
        {
            Name = "";
            Density = 0;
            Volume = 0;
            Strength = 0;
            HopContent = 0;
        }

        public Beer(string name, double density, double volume, double strength, double hopContent) :
            base(name, density, volume, strength)
        {
            HopContent = hopContent;
        }

        public new void SetParams()
        {
            Name = "";
            Density = 0;
            Volume = 0;
            Strength = 0;
            HopContent = 0;
        }

        public void SetParams(string name, double density, double volume, double strength, double hopContent)
        {
            Name = name;
            Density = density;
            Volume = volume;
            Strength = strength;
            HopContent = hopContent;
        }

        public void SetParams(double strength, double hopContent)
        {
            Strength = strength;
            HopContent = hopContent;
        }

        public static Beer operator ++(Beer liquid)
        {
            liquid.Volume += 1;
            return liquid;
        }

        /// <summary>
        /// Уменьшает объём на 1
        /// </summary>
        public static Beer operator --(Beer liquid)
        {
            if (liquid.Volume > 0) liquid.Volume -= 1;
            return liquid;
        }

        public override string LiquidInfo()
        {
            return "Название: " + Name + "\n" + "Плотность: " + Density.ToString() + "\n" +
                "Объём: " + Volume.ToString() + "\n" + "Крепость: " + Strength.ToString() +
                "\n" + "Содержание хмеля: " + HopContent.ToString();
        }
    }
}
