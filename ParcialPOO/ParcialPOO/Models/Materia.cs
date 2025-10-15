using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ParcialPOO.Models
{
    internal class Materia: IMostrable
    {
        private string name;
        private string codigo;
        private int creditos;
        private int cupos;
        private int inscritos;

        public string Name 
        {
            get=> name; 
            set=> name= value; 
        }
        public string Codigo 
        { 
            get => codigo; 
            set => codigo = value; 
        }
        public int Creditos 
        { 
            get => creditos;
            set
            {
                if (value > 0)
                    creditos = value;
                else
                    throw new ArgumentException("Creditos insuficientes");
            } 
        }
        public int Cupos 
        {
            get => cupos;
            set
            {
                if (value >= 0)
                    cupos = value;
                else
                    throw new ArgumentException("Cupos debe poseer valores positivos");
            }
        }
        public int Inscritos 
        { 
            get => inscritos; 
            set
            {
                if (value >= 0 && value <= cupos)
                    inscritos = value;
                else
                    throw new ArgumentException("Los inscritos deben estar entre 0 y el numero de cupos");
            }
        }

        public Materia(string name, string codigo, int creditos, int cupos = 0, int
            inscritos = 0)
        {
             Name = name;
             Codigo = codigo;
             Creditos = creditos;
            Cupos = cupos;
            Inscritos = inscritos;
        }

        public Materia()
        {
            name = "";
            codigo = "";
            creditos = 1;
            cupos = 0;
            inscritos = 0;
        }

        public int CalcularCargaSemanal(int horasPorCredito)
        {
            return Creditos * horasPorCredito;

        }

        public void MostrarDatos()
        {
            Console.WriteLine($"Nombre: {Name}");
            Console.WriteLine($"Código: {Codigo}");
            Console.WriteLine($"Créditos: {Creditos}");
            Console.WriteLine($"Cupos: {Cupos}");
            Console.WriteLine($"Inscritos: {Inscritos}");
        }
    }
}
