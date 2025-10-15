using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ParcialPOO.Models
{
    internal class Estudiante: IMostrable
    {
        private string name;
        private string id;
        private string carrera;
        private List<Calificacion> calificaciones;

        public string Name { get; set; }
        public string Id { get; set; }
        public string Carrera { get; set; }

        public List<Calificacion> Calificaciones { get; set; }

        public Estudiante(string name, string id, string carrera)
        {
            this.name = name;
            this.id = id;
            this.carrera = carrera;
        }

        public double CalcularPromedio()
        {
            double totalCreditos = calificaciones.Sum(c => c.Materia.Creditos);
            if (totalCreditos == 0) return 0;

            double sumaPonderada = calificaciones.Sum(c => c.Nota * c.Materia.Creditos);
            return sumaPonderada / totalCreditos;
        }

        public void MostrarDatos()
        {
            Console.WriteLine($"Nombre: {name}");
            Console.WriteLine($"ID: {id}");
            Console.WriteLine($"Carrera: {carrera}");
            Console.WriteLine($"Pormedio: {CalcularPromedio(): F2}");
        }
    }
}
