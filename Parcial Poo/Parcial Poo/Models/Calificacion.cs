using ParcialPOO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcialPOO.Models
{
    // Clase que representa la calificación de un estudiante en una materia
    public class Calificacion : IMostrable
    {
        // Atributos privados con encapsulamiento
        private Estudiante estudiante;
        private Materia materia;
        private double nota;

        // Propiedad pública con validación de nullabilidad
        public Estudiante Estudiante
        {
            get => estudiante;
            set => estudiante = value ?? throw new ArgumentNullException(nameof(Estudiante));
        }

        public Materia Materia
        {
            get => materia;
            set => materia = value ?? throw new ArgumentNullException(nameof(Materia));
        }

        public double Nota
        {
            get => nota;
            set
            {
                if (value >= 0 && value <= 100)
                    nota = value;
                else
                    throw new ArgumentException("La nota debe estar entre 0 y 100");
            }
        }

        // Constructor que obliga a inicializar todos los campos
        public Calificacion(Estudiante estudiante, Materia materia, double nota)
        {
            Estudiante = estudiante;
            Materia = materia;
            Nota = nota;
        }

        // Método que calcula los puntos obtenidos según créditos
        public double CalcularPuntos()
        {
            return Nota * Materia.Creditos;
        }

        // Método que muestra los datos de la calificación
        public void MostrarDatos()
        {
            Console.WriteLine($"Estudiante: {Estudiante.Name}");
            Console.WriteLine($"Materia: {Materia.Name}");
            Console.WriteLine($"Nota: {Nota:F2}");
        }
    }
}
