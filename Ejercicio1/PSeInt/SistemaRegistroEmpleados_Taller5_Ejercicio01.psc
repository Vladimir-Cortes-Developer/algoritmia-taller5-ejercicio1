Algoritmo SistemaRegistroEmpleados
    // Declaración de variables globales
    Definir nombres Como Caracter
    Definir edades, totalEmpleados Como Entero
    Definir salarios Como Real
    Definir opcion Como Entero
    Dimension nombres[10]
    Dimension edades[10]
    Dimension salarios[10]
    
    totalEmpleados <- 0
    
    // Menú principal
    Repetir
        Limpiar Pantalla
        Escribir "??????????????????????????????????????????????"
        Escribir "?   SISTEMA DE REGISTRO DE EMPLEADOS        ?"
        Escribir "??????????????????????????????????????????????"
        Escribir ""
        Escribir "Total de empleados registrados: ", totalEmpleados, "/10"
        Escribir ""
        Escribir "1. Registrar empleado"
        Escribir "2. Calcular promedio de salarios"
        Escribir "3. Encontrar empleado con mayor salario"
        Escribir "4. Aplicar aumento del 10% a salarios < $1000"
        Escribir "5. Mostrar empleados por rango de edad"
        Escribir "6. Salir"
        Escribir ""
        Escribir Sin Saltar "Seleccione una opción: "
        Leer opcion
        
        Segun opcion Hacer
            1:
                RegistrarEmpleado(nombres, edades, salarios, totalEmpleados)
            2:
                MostrarPromedioSalarios(salarios, totalEmpleados)
            3:
                MostrarEmpleadoMayorSalario(nombres, salarios, totalEmpleados)
            4:
                AplicarAumentoSalarios(nombres, salarios, totalEmpleados)
            5:
                MostrarEmpleadosPorEdad(nombres, edades, salarios, totalEmpleados)
            6:
                Escribir ""
                Escribir "¡Gracias por usar el sistema! Saliendo..."
                Esperar 2 Segundos
            De Otro Modo:
                Escribir ""
                Escribir "? Opción inválida. Intente nuevamente."
                Esperar 2 Segundos
        FinSegun
        
    Hasta Que opcion = 6
    
FinAlgoritmo

// ============================================
// PROCEDIMIENTO: Registrar Empleado
// ============================================
SubProceso RegistrarEmpleado(nombres Por Referencia, edades Por Referencia, salarios Por Referencia, totalEmpleados Por Referencia)
    Definir nombre Como Caracter
    Definir edad Como Entero
    Definir salario Como Real
    Definir edadValida, salarioValido Como Logico
    
    Limpiar Pantalla
    Escribir "??????????????????????????????????????????????"
    Escribir "?        REGISTRO DE NUEVO EMPLEADO         ?"
    Escribir "??????????????????????????????????????????????"
    Escribir ""
    
    Si totalEmpleados >= 10 Entonces
        Escribir "? No se pueden registrar más empleados."
        Escribir "   Capacidad máxima alcanzada (10 empleados)."
        Esperar 3 Segundos
    SiNo
        // Ingreso de nombre
        Escribir Sin Saltar "Nombre del empleado: "
        Leer nombre
        
        // Validación de edad (18-70)
        edadValida <- Falso
        Repetir
            Escribir Sin Saltar "Edad (18-70 años): "
            Leer edad
            
            Si edad >= 18 Y edad <= 70 Entonces
                edadValida <- Verdadero
            SiNo
                Escribir "? Error: La edad debe estar entre 18 y 70 años."
            FinSi
        Hasta Que edadValida = Verdadero
        
        // Validación de salario (positivo)
        salarioValido <- Falso
        Repetir
            Escribir Sin Saltar "Salario: $"
            Leer salario
            
            Si salario > 0 Entonces
                salarioValido <- Verdadero
            SiNo
                Escribir "? Error: El salario debe ser mayor a 0."
            FinSi
        Hasta Que salarioValido = Verdadero
        
        // Guardar empleado
        nombres[totalEmpleados] <- nombre
        edades[totalEmpleados] <- edad
        salarios[totalEmpleados] <- salario
        totalEmpleados <- totalEmpleados + 1
        
        Escribir ""
        Escribir "? Empleado registrado exitosamente."
        Esperar 2 Segundos
    FinSi
FinSubProceso

// ============================================
// FUNCIÓN: Calcular Promedio de Salarios
// ============================================
Funcion promedio <- CalcularPromedioSalarios(salarios, total)
    Definir suma, promedio Como Real
    Definir i Como Entero
    
    suma <- 0
    
    Para i <- 0 Hasta total-1 Hacer
        suma <- suma + salarios[i]
    FinPara
    
    Si total > 0 Entonces
        promedio <- suma / total
    SiNo
        promedio <- 0
    FinSi
FinFuncion

// ============================================
// PROCEDIMIENTO: Mostrar Promedio de Salarios
// ============================================
SubProceso MostrarPromedioSalarios(salarios, total)
    Definir promedio Como Real
    
    Limpiar Pantalla
    Escribir "??????????????????????????????????????????????"
    Escribir "?       PROMEDIO DE SALARIOS                ?"
    Escribir "??????????????????????????????????????????????"
    Escribir ""
    
    Si total = 0 Entonces
        Escribir "? No hay empleados registrados."
    SiNo
        promedio <- CalcularPromedioSalarios(salarios, total)
        Escribir "Total de empleados: ", total
        Escribir "Promedio de salarios: $", promedio
    FinSi
    
    Escribir ""
    Escribir "Presione ENTER para continuar..."
    Esperar Tecla
FinSubProceso

// ============================================
// FUNCIÓN: Encontrar Índice del Mayor Salario
// ============================================
Funcion indice <- EncontrarMayorSalario(salarios, total)
    Definir i, indice Como Entero
    Definir mayorSalario Como Real
    
    indice <- 0
    mayorSalario <- salarios[0]
    
    Para i <- 1 Hasta total-1 Hacer
        Si salarios[i] > mayorSalario Entonces
            mayorSalario <- salarios[i]
            indice <- i
        FinSi
    FinPara
FinFuncion

// ============================================
// PROCEDIMIENTO: Mostrar Empleado con Mayor Salario
// ============================================
SubProceso MostrarEmpleadoMayorSalario(nombres, salarios, total)
    Definir indice Como Entero
    
    Limpiar Pantalla
    Escribir "??????????????????????????????????????????????"
    Escribir "?     EMPLEADO CON MAYOR SALARIO            ?"
    Escribir "??????????????????????????????????????????????"
    Escribir ""
    
    Si total = 0 Entonces
        Escribir "? No hay empleados registrados."
    SiNo
        indice <- EncontrarMayorSalario(salarios, total)
        Escribir "Nombre: ", nombres[indice]
        Escribir "Salario: $", salarios[indice]
    FinSi
    
    Escribir ""
    Escribir "Presione ENTER para continuar..."
    Esperar Tecla
FinSubProceso

// ============================================
// FUNCIÓN: Aplicar Aumento de 10% a Salarios < $1000
// ============================================
Funcion empleadosAfectados <- AplicarAumento(salarios Por Referencia, total)
    Definir i, contador Como Entero
    
    contador <- 0
    
    Para i <- 0 Hasta total-1 Hacer
        Si salarios[i] < 1000 Entonces
            salarios[i] <- salarios[i] * 1.10
            contador <- contador + 1
        FinSi
    FinPara
    
    empleadosAfectados <- contador
FinFuncion

// ============================================
// PROCEDIMIENTO: Aplicar y Mostrar Aumento de Salarios
// ============================================
SubProceso AplicarAumentoSalarios(nombres, salarios Por Referencia, total)
    Definir afectados, i Como Entero
    
    Limpiar Pantalla
    Escribir "??????????????????????????????????????????????"
    Escribir "?   AUMENTO DEL 10% A SALARIOS < $1000      ?"
    Escribir "??????????????????????????????????????????????"
    Escribir ""
    
    Si total = 0 Entonces
        Escribir "? No hay empleados registrados."
    SiNo
        afectados <- AplicarAumento(salarios, total)
        
        Si afectados > 0 Entonces
            Escribir "? Se aplicó aumento a ", afectados, " empleado(s)."
            Escribir ""
            Escribir "Empleados con aumento aplicado:"
            Escribir "?????????????????????????????????????????"
            
            Para i <- 0 Hasta total-1 Hacer
                Si salarios[i] < 1100 Entonces // Ajustado por el aumento
                    Escribir nombres[i], " - Nuevo salario: $", salarios[i]
                FinSi
            FinPara
        SiNo
            Escribir "? No hay empleados con salario menor a $1000."
        FinSi
    FinSi
    
    Escribir ""
    Escribir "Presione ENTER para continuar..."
    Esperar Tecla
FinSubProceso

// ============================================
// PROCEDIMIENTO: Mostrar Empleados por Rango de Edad
// ============================================
SubProceso MostrarEmpleadosPorEdad(nombres, edades, salarios, total)
    Definir i, rango Como Entero
    Definir hayEmpleados Como Logico
    
    Limpiar Pantalla
    Escribir "??????????????????????????????????????????????"
    Escribir "?     EMPLEADOS POR RANGO DE EDAD           ?"
    Escribir "??????????????????????????????????????????????"
    Escribir ""
    
    Si total = 0 Entonces
        Escribir "? No hay empleados registrados."
    SiNo
        // Rango 18-30
        Escribir "?? RANGO: 18-30 años ??????????????????????"
        hayEmpleados <- Falso
        Para i <- 0 Hasta total-1 Hacer
            Si edades[i] >= 18 Y edades[i] <= 30 Entonces
                Escribir "? ", nombres[i], " - ", edades[i], " años - $", salarios[i]
                hayEmpleados <- Verdadero
            FinSi
        FinPara
        Si NO hayEmpleados Entonces
            Escribir "? (No hay empleados en este rango)"
        FinSi
        Escribir "????????????????????????????????????????????"
        Escribir ""
        
        // Rango 31-50
        Escribir "?? RANGO: 31-50 años ??????????????????????"
        hayEmpleados <- Falso
        Para i <- 0 Hasta total-1 Hacer
            Si edades[i] >= 31 Y edades[i] <= 50 Entonces
                Escribir "? ", nombres[i], " - ", edades[i], " años - $", salarios[i]
                hayEmpleados <- Verdadero
            FinSi
        FinPara
        Si NO hayEmpleados Entonces
            Escribir "? (No hay empleados en este rango)"
        FinSi
        Escribir "????????????????????????????????????????????"
        Escribir ""
        
        // Rango 51+
        Escribir "?? RANGO: 51+ años ????????????????????????"
        hayEmpleados <- Falso
        Para i <- 0 Hasta total-1 Hacer
            Si edades[i] >= 51 Entonces
                Escribir "? ", nombres[i], " - ", edades[i], " años - $", salarios[i]
                hayEmpleados <- Verdadero
            FinSi
        FinPara
        Si NO hayEmpleados Entonces
            Escribir "? (No hay empleados en este rango)"
        FinSi
        Escribir "????????????????????????????????????????????"
    FinSi
    
    Escribir ""
    Escribir "Presione ENTER para continuar..."
    Esperar Tecla
FinSubProceso