//Declarar arreglos y variables

using System.Runtime.ConstrainedExecution;
// Declaración Global




// Estructura de datos de tipo record
record Empleado(string Nombre, int Edad, decimal Salario);

class SistemaRegistroEmpleados
{
    private static Empleado[] empleados = new Empleado[10];
    private static int totalEmpleados = 0;

    static void Main()
    {
       
        int opcion = 0;
        do
        {
            Console.Clear();
            Console.WriteLine("*********************************");
            Console.WriteLine("        SISTEMA DE EMPLEADOS     ");
            Console.WriteLine("*********************************");
            Console.WriteLine();
            Console.WriteLine($"Total de empleados registrados: n/10");
            Console.WriteLine();
            Console.WriteLine("1. Registrar empleado");
            Console.WriteLine("2. Calcular promedio de los salarios");
            Console.WriteLine("3. Encontrar el empleado con mayor salario");
            Console.WriteLine("4. Aplicar aumento del 10% a salarios < 1000");
            Console.WriteLine("5. Mostrar empleados por rango de edad");
            Console.WriteLine("6. Salir");
            Console.WriteLine();
            Console.WriteLine("Seleccione una opcion");

            opcion = Convert.ToInt32(Console.ReadLine());

            switch (opcion)
            {

                case 1:
                    RegistrarEmpleado();
                    break;
                case 2:
                    MostrarPromedioSalarios();
                    break;
                case 3:
                   MostrarEmpleadoMayorSalario();
                    break;
                case 4:
                    AplicarAumentoSalarios();
                    break;
                case 5:
                    MostrarEmpleadosPorEdad();
                    break;
                case 6:
                    Console.WriteLine("¡Gracias por usar el sistema! Saliendo...");
                    System.Threading.Thread.Sleep(2000);
                    break;
                default:
                    Console.WriteLine("¡Opción inválida. Intente nuevamente!");
                    System.Threading.Thread.Sleep(2000);
                    break;
            }

        } while (opcion != 6);
    }

   static void RegistrarEmpleado()
    {
        Console.Clear();
        Console.WriteLine("╔════════════════════════════════════════════╗");
        Console.WriteLine("║        REGISTRO DE NUEVO EMPLEADO          ║");
        Console.WriteLine("╚════════════════════════════════════════════╝");
        Console.WriteLine();
        if (totalEmpleados >= 10)
        {
            Console.WriteLine("No se pueden registrar más de 10 empleados");
            Console.WriteLine("Capacidad máxima alcanzada (10 empleados)");
            System.Threading.Thread.Sleep(3000);
            return;
        }

        //Ingresar nombre del empleado
        Console.Write("Nombre del empleado: ");
        string nombre = Console.ReadLine() ?? "";

        //Ingreso y validación de la edad.
        int edad = 0;
        do
        {
            Console.Write("Edad (18-70 años): ");
            if (!int.TryParse(Console.ReadLine(), out edad) || edad < 18 || edad > 70)
            {
                Console.WriteLine("Error: la edad debe estar entre 18 y 70 años.");
            }

        } while (edad < 18 || edad > 70);

        //Ingresar y validar el salario
        decimal salario = 0;
        do
        {
            Console.Write("Salario: $");
            if (!decimal.TryParse(Console.ReadLine(), out salario) || salario <= 0)
            {
                Console.WriteLine("Error: el salario no puede ser cero o menor que cero");
            }

        } while (salario <= 0);


        //Guardar empleado
        empleados[totalEmpleados] = new Empleado(nombre, edad,salario);
        totalEmpleados++;
        Console.WriteLine("Empleado registrado correctamente.");
        System.Threading.Thread.Sleep(3000);
    }    


   private static void MostrarEmpleadosPorEdad()
    {
        Console.Clear();
        Console.WriteLine("╔════════════════════════════════════════════╗");
        Console.WriteLine("║    MOSTRAR EMPLEADOS POR RANGO DE EDAD     ║");
        Console.WriteLine("╚════════════════════════════════════════════╝");
        Console.WriteLine();

        if (totalEmpleados == 0)
        {
            Console.WriteLine("No hay empleados registrados");
        }
        else
        {
            MostrarEmpleadosPorRangoEdad("18-30 años", 18, 30);
            Console.WriteLine();
            MostrarEmpleadosPorRangoEdad("31-50 años", 31, 50);
            Console.WriteLine();
            MostrarEmpleadosPorRangoEdad("+51 años", 51, int.MaxValue);
            Console.WriteLine();
        }

        Console.WriteLine();
        Console.WriteLine("Presione una ENTER para continuar ....");
        Console.ReadKey();
    }

    private static void MostrarEmpleadosPorRangoEdad(string titulo, int edadMinima, int edadmaxima)
    {
        Console.WriteLine($"*************** RANGO: {titulo} ***************");
        var empleadosRango = empleados.Take(totalEmpleados)
            .Where(e=>e.Edad>=edadMinima && e.Edad<=edadmaxima)
            .ToList();

        if (empleadosRango.Any())
        {
            foreach (var empl in empleadosRango)
            {
                Console.WriteLine($"|{empl.Nombre} - {empl.Edad} - ${empl.Salario:F2}");
            }
        }
        else
        {
            Console.WriteLine("No hay empleados en este rango") ;
        }

        Console.WriteLine($"********************************************");
    }

    private static void AplicarAumentoSalarios()
    {
        Console.Clear();
        Console.WriteLine("****************************************");
        Console.WriteLine("  APLICAR AUMENTO DEL 10% AL SALARIO    ");
        Console.WriteLine("****************************************");
        Console.WriteLine();

        if (totalEmpleados == 0)
        {
            Console.WriteLine("Ni hay empleados registrados");
        }
        else {
            int afectados = AplicarAumento();

            if (afectados > 0)
            {
                Console.WriteLine($"Se aplico aumento a {afectados} empleado(s).");
                Console.WriteLine();
                Console.WriteLine("Empleados con aumento aplicado");
                Console.WriteLine("___________________________________");

                for (int i = 0; i < totalEmpleados; i++)
                {
                    if (empleados[i].Salario < 1000)
                    {
                        Console.WriteLine($"{empleados[i].Nombre} - Nunvo salario: ${empleados[i].Salario:F2}");
                    }
                }
            }
            else
            {
                Console.WriteLine("No hay empleados con salario mayor qe $ 1000");
            }
        }
        Console.WriteLine();
        Console.WriteLine("Presione una ENTER para continuar ....");
        Console.ReadKey();
    }

    private static int AplicarAumento()
    {
        int contador = 0;
        for (int i = 0;i < totalEmpleados;i++) 
        {
            if (empleados[i].Salario < 1000)
            {
                empleados[i] = empleados[i] with { Salario = empleados[i].Salario * 1.10m };
                contador++;
            }
        }
        return contador;
    }

    private static void MostrarEmpleadoMayorSalario()
    {
        Console.Clear();
        Console.WriteLine("*********************************");
        Console.WriteLine("   EMPLEADO CON MAYOR SALARIO    ");
        Console.WriteLine("*********************************");
        Console.WriteLine();

        if (totalEmpleados == 0)
        {
            Console.WriteLine("No hay empleados registrados");
        }
        else {
            int indice = EncontrarMayorSalario();
            Empleado empleado = empleados[indice];
            Console.WriteLine($"Nombre: {empleado.Nombre}");
            Console.WriteLine($"Salario: ${empleado.Salario:F2}");        
        }
        Console.WriteLine();
        Console.WriteLine("Presione una ENTER para continuar ....");
        Console.ReadKey();
    }

    private static int EncontrarMayorSalario()  // Función que retorna un entero
    {
        int indice = 0;
        decimal mayorSalario = empleados[0].Salario;
        for (int i = 1; i < totalEmpleados; i++) { 
            if (empleados[i].Salario > mayorSalario) {
                
                mayorSalario = empleados[i].Salario;
                indice = i;
            }
        }
        return indice;
    }

    private static void MostrarPromedioSalarios()
    {
        Console.Clear();
        Console.WriteLine("╔════════════════════════════════════════════╗");
        Console.WriteLine("║        PROMEDIO DE SALARIOS                ║");
        Console.WriteLine("╚════════════════════════════════════════════╝");

        if (totalEmpleados == 0)
        {
            Console.WriteLine("No hay empleados registrados");
        }
        else
        {
            var promedio = CalcularPromedioSalarios();
            Console.WriteLine($"Total de empleados: {totalEmpleados}");
            Console.WriteLine($"Promedio de salarios: ${promedio:F2}");
        }

        Console.WriteLine();
        Console.WriteLine("Presione ENTER para continuar...");
        Console.ReadKey();
    }

    private static decimal CalcularPromedioSalarios()
    {
        if (totalEmpleados == 0 )
        {
            return 0;
        }

        return empleados
            .Take(totalEmpleados)
            .Average(e => e.Salario);
    }
}





