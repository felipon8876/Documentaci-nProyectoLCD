
/*Documentación Program.cs*/
/// <summary>
/// Funcionamiento de  una pantalla LCD.
/// </summary>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PantallaLCD
{
    class Program
    {
        static string[] vector = new String[1000]; // Creación del objeto vector de tipo cadena con tamaño de 1000 posiciones.
        
        static void Main(string[] args) // Función principal donde se centraliza el llamado de procedimientos y funciones.
        {
            Console.WriteLine("Bienvenido al programa de impresión estilo pantalla LCD.\n");  // Impresión de mensaje en consola que brinda la Bienvenida.
            Console.WriteLine("Favor Ingrese el primer número seguido de una ',' el cual hace referencia al tamaño, después ingrese " +
                "el resto de " + "números que desea ver impresos, finalice ingresando '0,0' para ver la impresión de los números.\n"); // Impresión de mensaje en consola  que solicita la inserción de datos que se insertarán en el vector.

            LLenar(); // Llamado del método tipo procedimiento con Marca 1, que realizará el llenado del vector.

            Mostrar(); // Llamado del  método tipo  procedimiento con Marca 2, que imprimirá el vector lleno.
            
            Console.ReadKey(); // Instrucción que captura la presión de una tecla por parte del usuario para que el programa pueda continuar.

        }
        
        
      /* Marca 5*/

        static bool analizoSiEsNumero(string q) // metodo que al ingresar un caracter verifica si es numero o no.
        {
            bool num = false;

            if (q == "0" ||
                q == "1" ||
                q == "2" ||
                q == "3" ||
                q == "4" ||
                q == "5" ||
                q == "6" ||
                q == "7" ||
                q == "8" ||
                q == "9"
                )
            {
                num = true;
            }

            return num;
        }
        
        /*Marca 3  Método tipo función donde llega el parámetro de tipo cadena definido como "z" y donde retornará un valor Booleano (V-F) */
        
        static bool analizoCantidad(string z) 
        {
            int y = z.Length;   //Definición de variable numérica entera llamada "y" e inicializada con el tamaño de caracteres que trajo la variable cadena "z".

            int i;  //  Definición de variable numérica entera llamada "i" que funciona como un indice de posición.
            string koma = ","; // Definición de variable  tipo cadena llamada "koma" asignada con valor caracter ","
.            int posiKoma = 0; // Definición de variable numérica entera llamada "posiKoma" inicializada en 0 y funciona como la marca de la posición donde estará presente el caracter ",".
            int digitoUno;  // Definición de variable numérica entera llamada "digitoUno" .
            bool zoom = false; // Definición de variable booleana  llamada "zoom" inicializada con valor en falso.

            for (i = 0; i < y; i++)   // Ciclo Para, donde se va a hallar la posición de la coma.
            {
                if (koma == z.Substring(i, 1)) // Validación condicional para comparar si la variable "koma" es igual a lo que está almacenado en la subcadena que tiene la variable "z" .
                {
                    posiKoma = i;  // Asignación del valor del indice "i" a la variable "posiKoma" que inició en un principio en 0.
                    i = y; // Asignación del valor que tiene la variable "y" a la variable "i".
                }
            }

            if (posiKoma == 1) // Validación condicional para comparar si la variable "posikoma" (Posición de la coma) es igual a 1
            {
                if (analizoSiEsNumero(z.Substring(0, 1))) // Validación condicional que llama al método tipo función "analizoSiEsNumero" (Marca 5) enviando el parámetro de la variable "z" con lo almacenado en el subvector de carácteres en posición 0,1
                {
                    zoom = true; // Asignación de valor verdadero a la variable zoom.
                    digitoUno = int.Parse(z.Substring(0, 1)); // Conversión a valor numérico de lo asignado en subvector de cadena almacenado en "z" posición 0,1  y posteriormente pasado a la variable numérica entera "digitoUno" .
                }
                else // En caso de no cumplirse la condición anterior (Es decir si no es un número).
                {
                    Console.WriteLine("El símbolo '" + z.Substring(0, 1) + "' en la posición 1 no es un número"); // Impresión de mensaje en consola indicando que lo almacenado en el subvector "z" posición 0,1 no es número.
                }
            }

            if (posiKoma == 2)
            {
                if (analizoSiEsNumero(z.Substring(0, 1)))
                {
                    if (analizoSiEsNumero(z.Substring(1, 1)))
                    {
                        digitoUno = int.Parse(z.Substring(0, 2));
                        if (digitoUno <= 10)
                        {
                            zoom = true;
                        }
                        else
                        {
                            Console.WriteLine("Mal digitado, el tamaño maximo de visualización es 10");
                        }
                    }
                    else
                    {
                        Console.WriteLine("El símbolo '" + z.Substring(0, 1) + "' en la posición 2 no es un número");
                    }
                }
                else
                {
                    Console.WriteLine("El símbolo '" + z.Substring(0, 1) + "' en la posición 2 no es un número");
                }
            }

            if (zoom)
            {
                i = posiKoma + 1;
                while (i < y)
                {
                    if (analizoSiEsNumero(z.Substring(i, 1)))
                    {
                        i = i + 1;
                    }
                    else
                    {
                        zoom = false;
                        Console.WriteLine("el digito: " + z.Substring(i, 1) + " no es un número, juajuajua");
                        i = y;
                    }
                }
            }

            if (posiKoma == 0 || posiKoma > 2)
            {
                Console.WriteLine("Numero ingresado no cumple los requisitos");
            }

            return zoom;
        }

        /* Marca 1: Método tipo procedimiento que realizará el llenado del vector. */ 
        
        static void LLenar() 
        {
            int cont = 0;  // Definición de variable numérica Entera llamada contador e inicializada en 0.
            string fila = "A"; // Definición de variable cadena llamada fila e inicializada en A.    

            while (fila != "0,0") // Ciclo mientras que validará que la variable fila sea diferente de 0,0 para asi permitir guardar valores en  cada una de las posiciones del vector */
               {
                fila = Console.ReadLine(); // Captura del valor ingresado por teclado y asignado a la variable fila.
                if (analizoCantidad(fila)) // Validación condicional que llama al método tipo función "analizoCantidad" (Marca 3) donde se envía el parámetro fila para analizar la cantidad de caracteres del valor ingresado .
                {
                    vector[cont] = fila; // Asignación del valor que esté almacenado en la variable fila hacia el vector creado en la posición que esté en el momento el contador: "cont".
                    cont = cont + 1; // Aumento de 1 en 1 de la variable contador: "cont".
                }
            }
        }

        /* Marca 2: Método tipo procedimiento que realizará la impresión del vector. */ 
        
        static void Mostrar()
        {
            int i = 0; // Definición de variable numérica Entera llamada i e inicializada en 0, utilizada como indice.
            while (vector[i] != null)  // Ciclo mientras que irá recorriendo el vector, validando que la posición del mismo en la que esté el indice tenga valores almacenados y asi poder ser mostrados.
            {
                ImprimirEnLCD(vector[i]); // Llamado al método tipo función "ImprimirEnLCD"  (Marca 4) donde se envía el parámetro vector con la posición en la que esté el indice. 
                i = i + 1; // Aumento de 1 en 1 de la variable indice: "i" que marca la posición.
            }
        }

        
        
        
        static void ImprimirEnLCD(string r)
        {
            int digito;
            int size;
            int longitud;

            size = int.Parse(r.Substring(0, 1));
            longitud = r.Length;

            string[] filaSuperior =                { "-", " ", "-", "-", " ", "-", "-", "-", "-", "-" };
            string[] columnaSuperiorIzquierda =    { "|", " ", " ", " ", "|", "|", "|", " ", "|", "|" };
            string[] columnaSuperiorDerecha =      { "|", "|", "|", "|", "|", " ", " ", "|", "|", "|" };
            string[] filaIntermedia =              { " ", " ", "-", "-", "-", "-", "-", " ", "-", "-" };
            string[] columnaInferiorIzquierda =    { "|", " ", "|", " ", " ", " ", "|", " ", "|", " " };
            string[] columnaInferiorDerecha =      { "|", "|", " ", "|", "|", "|", "|", "|", "|", "|" };
            string[] filaInferior =                { "-", " ", "-", "-", " ", "-", "-", " ", "-", " " };

            for (int i = 0; i < (2 * size + 3); i++)               //For que indica el numero de filas dependiendo del grosor ingresado
            {
                if (i == 0)                                          //Hallo la fila superior
                {
                    for (int j = 0; j < (longitud - 2); j++)                // Relleno primera Fila (= FilaSuperior)
                    {
                        digito = int.Parse(r.Substring(j + 2, 1));

                        Console.Write(" ");
                        for (int k = 0; k < size; k++)                   // For para rellenar el interior de los digitos
                        {
                            Console.Write(filaSuperior[digito]);
                        }
                        Console.Write("  ");
                    }
                }
                // Relleno Filas entre la Superior y la Intermedia
                if ((i > 0) && (i < (size + 1)))                    // Se le suma 1 a (2 * size + 3) para hallar la mitad o sea queda --> 2 * size + 4
                {
                    for (int j = 0; j < (longitud - 2); j++)
                    {
                        digito = int.Parse(r.Substring(j + 2, 1));

                        Console.Write(columnaSuperiorIzquierda[digito]);
                        for (int k = 0; k < size; k++)
                        {
                            Console.Write(" ");
                        }
                        Console.Write(columnaSuperiorDerecha[digito] + " ");
                    }
                }

                if (i == (size + 1))
                {
                    for (int j = 0; j < (longitud - 2); j++)                // Relleno Fila intermedia
                    {
                        digito = int.Parse(r.Substring(j + 2, 1));

                        Console.Write(" ");
                        for (int k = 0; k < size; k++)                   // For para rellenar el interior de los digitos
                        {
                            Console.Write(filaIntermedia[digito]);
                        }
                        Console.Write("  ");
                    }
                }

                if ((i > (size + 1)) && (i < (2 * size + 3 - 1)))      // Relleno Filas entre la intermedia y la inferior
                {
                    for (int j = 0; j < (longitud - 2); j++)
                    {
                        digito = int.Parse(r.Substring(j + 2, 1));

                        Console.Write(columnaInferiorIzquierda[digito]);
                        for (int k = 0; k < size; k++)
                        {
                            Console.Write(" ");
                        }
                        Console.Write(columnaInferiorDerecha[digito] + " ");
                    }
                }

                if (i == (2 * size + 3 - 1))
                {
                    for (int j = 0; j < (longitud - 2); j++)                // Relleno Fila inferior
                    {
                        digito = int.Parse(r.Substring(j + 2, 1));

                        Console.Write(" ");
                        for (int k = 0; k < size; k++)                   // For para rellenar el interior de los digitos
                        {
                            Console.Write(filaInferior[digito]);
                        }
                        Console.Write("  ");
                    }
                }

                Console.WriteLine();


            }


        }

    }
}
