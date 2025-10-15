using ParcialPOO.Models;
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        //Tipos y construcción: instanciación con constructores y propiedades
        Estudiante e1 = new Estudiante("Ana Torres", "E001", "Psicología");
        Estudiante e2 = new Estudiante("Luis Gómez", "E002", "Ingeniería");

        EstudianteBecado eb1 = new EstudianteBecado("María López", "E003", "Medicina", 75);

        Materia m1 = new Materia("Matemáticas", "MAT101", 3, 30, 25);
        Materia m2 = new Materia("Biología", "BIO201", 4, 40, 38);
        Materia m3 = new Materia("Filosofía", "FIL301", 2, 20, 18);

        // Validaciones de tipo/rango (se activan si hay errores)
        try
        {
            m1.Creditos = 3; // > 0
            m2.Cupos = 40;   // ≥ 0
            m2.Inscritos = 38; // ≤ Cupos
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error de validación: {ex.Message}");
        }

        //Vinculación: relacionar Calificacion con Estudiante y Materia
        Calificacion c1 = new Calificacion(e1, m1, 85); // nota válida
        Calificacion c2 = new Calificacion(e2, m2, 92);
        Calificacion c3 = new Calificacion(eb1, m3, 78);

        // Agregar calificaciones a cada estudiante
        e1.Calificaciones.Add(c1);
        e2.Calificaciones.Add(c2);
        eb1.Calificaciones.Add(c3);

        //Operaciones aritméticas
        double promedioE1 = e1.CalcularPromedio();
        Console.WriteLine($"\nPromedio de {e1.Name}: {promedioE1:F2}");

        int cargaM2 = m2.CalcularCargaSemanal(3);
        Console.WriteLine($"Carga semanal de {m2.Name}: {cargaM2} horas");

        double puntosC2 = c2.CalcularPuntos();
        Console.WriteLine($"Puntos obtenidos por {e2.Name} en {m2.Name}: {puntosC2:F2}");

        double matriculaConDescuento = eb1.CalcularMatriculaConDescuento(1200);
        Console.WriteLine($"Matrícula con descuento para {eb1.Name}: ${matriculaConDescuento:F2}");

        // Polimorfismo: lista de objetos IMostrable
        List<IMostrable> items = new List<IMostrable>
        {
            e1, e2, eb1,
            m1, m2, m3,
            c1, c2, c3
        };

        Console.WriteLine("\nMostrando todos los elementos con polimorfismo:");
        foreach (IMostrable i in items)
        {
            Console.WriteLine("────────────────────────────");
            i.MostrarDatos();
        }
    }
}
