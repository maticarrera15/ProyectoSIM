﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Drawing;
using System.ComponentModel;

namespace TP3___SIM.Logica
{
    class GeneradorAleatorios
    {
        private double min;
        private double max;
        private List<double> numeros;
        private object oGeneradorAleatorios;
        public static Random rnd = new Random();
        private double lambda;
        private double media;
        private double desvEstandar;

        //METODOS GET Y SET

        public double Min
        {
            get { return min; }
            set { min = value; }
        }
        public double Max
        {
            get { return max; }
            set { max = value; }
        }
        public List<double> Numeros
        {
            get { return numeros; }
            set { numeros = value; }
        }

        public double Media { get => media; set => media = value; }

        public double DesvEstandar { get => desvEstandar; set => desvEstandar = value; }

        public double Lambda { get => lambda; set => lambda = value; }

        //CONSTRUCTOR
        public GeneradorAleatorios()
        {
            Numeros = new List<double>();
        }


        //Generador Exponencial Negativa
        public List<double> generadorExponencial(int cantidad, double lambda)
        {
            Numeros.Clear();
            List<double> numerosAleatorios = new List<double>();
            
            for (int i = 0; i < cantidad; i++)
            {
                double x = rnd.NextDouble();
                numerosAleatorios.Add(x);
            }

            Lambda = lambda; //Todo: ver 

            for (int i = 0; i < cantidad; i++)
            {
                double x = 0;

                double aleatorio = numerosAleatorios.ElementAt(i);
                if (aleatorio == 1) aleatorio = 0.9999f;

                x = Math.Truncate((Math.Log(1 - aleatorio) / (-lambda)) * 10000) / 10000;

                Numeros.Add(x);
            }

            min = Numeros.Min();
            max = Numeros.Max();

            return Numeros;
        }

        public List<double> generadorNormal(int cant, double media, double desviacion)
        {
            numeros.Clear();

            //La cantidad de numeros rnd uniformes que se necesitan es siempre par
            int cantUniformes = cant; //En principio la cantidad de uniformes es igual a la cantidad de numeros normales a generar
            if (cant % 2 != 0) { cantUniformes++; }//Si la cantidad de normales a generar es impar, la cantidad de uniformes es una unidad  mayor a eso

            List<double> numerosUniformes = new List<double>(generadorUniforme(0, 1, cantUniformes));
            numeros.Clear();

            Media = media;
            DesvEstandar = desviacion;

            for (int i = 0; i < cant; i += 2)
            {
                double rnd1 = numerosUniformes.ElementAt(i);
                double rnd2 = numerosUniformes.ElementAt(i + 1);

                if (rnd1 == 0) rnd1 = 0.00001f;
                if (rnd2 == 0) rnd2 = 0.00001f;

                double N1 = Math.Truncate((((Math.Sqrt(-2 * Math.Log(rnd1))) * Math.Cos(2 * Math.PI * rnd2)) * desvEstandar + media) * 10000) / 10000;
                numeros.Add(N1);

                if (!((i == cant - 1 || i == cant - 2) && (cant % 2 != 0)))
                {
                    double N2 = Math.Truncate((((Math.Sqrt(-2 * Math.Log(rnd1))) * Math.Sin(2 * Math.PI * rnd2)) * desvEstandar + media) * 10000) / 10000;
                    numeros.Add(N2);
                }

            }
            min = numeros.Min();
            max = numeros.Max();
            return numeros;
        }

        public double generadorCS()
        {
            Random rnd = new Random();

            double aleatorio = (rnd.Next(10000));
            double aux = (double)aleatorio / 10000;

            return aux;
        }

        public List<double> generadorUniforme(double a, double b, int cantidad)
        {
            numeros.Clear();

            for (int i = 1; i <= cantidad; i++)
            {
                double x = 0;

                x = Math.Truncate((a + (b - a) * rnd.NextDouble())*10000) / 10000;

                numeros.Add(x);
            }

            min = numeros.Min();
            max = numeros.Max();

            return numeros;
        }     
    }
}
