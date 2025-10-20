using ParcialPOO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcialPOO.Models
{
    // Clase derivada que extiende Estudiante y agrega lógica de beca
    public class EstudianteBecado : Estudiante, IMostrable
    {
        // Campo privado para encapsular el porcentaje de beca
        private double porcentajeBeca;

        // Propiedad con validación de rango (0 a 100)
        public double PorcentajeBeca
        {
            get => porcentajeBeca;
            set
            {
                if (value >= 0 && value <= 100)
                    porcentajeBeca = value;
                else
                    throw new ArgumentException("El porcentaje de beca debe estar entre 0 y 100");
            }
        }

        // Constructor que reutiliza el de Estudiante y agrega beca
        public EstudianteBecado(string name, string id, string carrera, double porcentajeBeca)
            : base(name, id, carrera)
        {
            PorcentajeBeca = porcentajeBeca;
        }

        // Método que calcula la matrícula con descuento aplicado
        public double CalcularMatriculaConDescuento(double matriculaBase)
        {
            return matriculaBase * (1 - (PorcentajeBeca / 100.0));
        }

        // Sobrescritura explícita del método MostrarDatos
        public override void MostrarDatos()
        {
            base.MostrarDatos(); // imprime nombre, id, carrera y promedio
            Console.WriteLine($"Porcentaje de beca: {PorcentajeBeca:F2}%");
        }
    }
}
