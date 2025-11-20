//Declarar arreglos y variables

using System.Runtime.ConstrainedExecution;

string[] nombres = new string[10];
int[] edades = new int[10];
double[] salarios = new double[10];
int totalEmpleados = 0;
int opcion = 0;


do
{
    Console.Clear();
    Console.WriteLine("*********************************");
    Console.WriteLine("        SISTEMA DE EMPLEADOS     ");
    Console.WriteLine("*********************************");
    Console.WriteLine();
    Console.WriteLine($"Total de empleados registrados: {totalEmpleados}/10");
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
                RegistrarEmpleado(nombres, edades, salarios, ref totalEmpleados);
                break;
            case 2:
                MostrarPromedioSalarios(salarios, totalEmpleados);
                break;
            case 3:
                MostrarEmpleadoMayorSalario(nombres, salarios, totalEmpleados);
                break;
            case 4:
                AplicarAumentoSalarios(nombres, salarios, totalEmpleados);
                break;
            case 5:
                MostrarEmpleadosPorEdad(nombres, edades, salarios, totalEmpleados);
                break;
            case 6:
                Console.WriteLine("¡Gracias por usar el sistema! Saliendo...");
                System.Threading.Thread.Sleep(2000);
            break;
           default:
                Console.WriteLine("? Opción inválida. Intente nuevamente.");
                System.Threading.Thread.Sleep(2000);
            break;
    }

} while (opcion != 6);

void MostrarEmpleadosPorEdad(string[] nombres, int[] edades, double[] salarios, int totalEmpleados)
{
    //throw new NotImplementedException();
    Console.WriteLine("Ingresando al método Mostrar empleados por edad");
}

void AplicarAumentoSalarios(string[] nombres, double[] salarios, int totalEmpleados)
{
    //throw new NotImplementedException();
    Console.WriteLine("Ingresando al método Aplicar Aumento Salarios");
}

void MostrarEmpleadoMayorSalario(string[] nombres, double[] salarios, int totalEmpleados)
{
    //throw new NotImplementedException();
    Console.WriteLine("Ingresando al método Mostrar Empleado Mayor Salario");
}

void MostrarPromedioSalarios(double[] salarios, int totalEmpleados)
{
    //throw new NotImplementedException();
    Console.WriteLine("Ingresando al método Mostrar Promedio salarios");

}

void RegistrarEmpleado(string[] nombres, int[] edades, double[] salarios, ref int totalEmpleados)
{
    //throw new NotImplementedException();

    Console.WriteLine("Ingresando al método Registrar Empleados");
}