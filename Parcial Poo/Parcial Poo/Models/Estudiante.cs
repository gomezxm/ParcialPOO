using ParcialPOO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ParcialPOO.Models
{
    public class Estudiante : IMostrable
    {
        public string Name { get; set; }
        public string Id { get; set; } = "";
        public string Carrera { get; set; }
        public List<Calificacion> Calificaciones { get; set; } = new List<Calificacion>();

        public Estudiante(string name, string id, string carrera)
        {
            Name = name;
            Id = id;
            Carrera = carrera;
        }

        public double CalcularPromedio()
        {
            double totalCreditos = Calificaciones.Sum(c => c.Materia.Creditos);
            if (totalCreditos == 0) return 0;

            double sumaPonderada = Calificaciones.Sum(c => c.Nota * c.Materia.Creditos);
            return sumaPonderada / totalCreditos;
        }

        public virtual void MostrarDatos()
        {
            Console.WriteLine($"Nombre: {Name}");
            Console.WriteLine($"ID: {Id}");
            Console.WriteLine($"Carrera: {Carrera}");
            Console.WriteLine($"Promedio: {CalcularPromedio():F2}");
        }
    }

}