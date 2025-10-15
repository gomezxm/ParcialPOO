using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcialPOO.Models
{
    internal class EstudianteBecado: Estudiante, IMostrable
    {
        private double porcentajeBeca;

        public double PorcentajeBeca 
        { 
            get => porcentajeBeca;
            set
            {
                if (value >= 0 && value <= 100)
                    PorcentajeBeca = value;
                else
                    throw new ArgumentException("El porcentaje de beca debe estar entre  y 100");
            }
        }

        public EstudianteBecado(string name, string id, string carrera, double porcentajeBeca)
            :base(name, id, carrera)
        {
            PorcentajeBeca = porcentajeBeca;
        }

        public double CalcularMatriculaConDescuento(double matriculaBase)
        {
            return matriculaBase * (1 - (PorcentajeBeca / 100.0));

        }

        public override void MostrarDatos()
        {
            base.MostrarDatos(); // imprime nombre, id, carrera y promedio
            Console.WriteLine($"Porcentaje de beca: {PorcentajeBeca:F2}%");
        }
    }
}
