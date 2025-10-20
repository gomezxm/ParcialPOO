using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcialPOO.Models
{
    // Clase que representa una materia académica
    public class Materia : IMostrable
    {
        // Atributos privados con encapsulamiento
        private string name;
        private string codigo;
        private int creditos;
        private int cupos;
        private int inscritos;

        // Propiedad pública para el nombre, con valor por defecto para evitar nullabilidad
        public string Name
        {
            get => name;
            set => name = value ?? throw new ArgumentNullException(nameof(Name));
        }

        // Propiedad pública para el código, con validación de null
        public string Codigo
        {
            get => codigo;
            set => codigo = value ?? throw new ArgumentNullException(nameof(Codigo));
        }

        // Propiedad con validación de rango (> 0)
        public int Creditos
        {
            get => creditos;
            set
            {
                if (value > 0)
                    creditos = value;
                else
                    throw new ArgumentException("Créditos insuficientes");
            }
        }

        // Propiedad con validación de valores positivos
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

        // Propiedad con validación dependiente de Cupos
        public int Inscritos
        {
            get => inscritos;
            set
            {
                if (value >= 0 && value <= cupos)
                    inscritos = value;
                else
                    throw new ArgumentException("Los inscritos deben estar entre 0 y el número de cupos");
            }
        }

        // Constructor completo que obliga a inicializar todos los campos
        public Materia(string name, string codigo, int creditos, int cupos = 0, int inscritos = 0)
        {
            Name = name;
            Codigo = codigo;
            Creditos = creditos;
            Cupos = cupos;
            Inscritos = inscritos;
        }

        // Constructor por defecto que evita valores nulos
        public Materia()
        {
            name = "";
            codigo = "";
            creditos = 1;
            cupos = 0;
            inscritos = 0;
        }

        // Método que calcula la carga semanal según horas por crédito
        public int CalcularCargaSemanal(int horasPorCredito)
        {
            return Creditos * horasPorCredito;
        }

        // Método que muestra los datos de la materia
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