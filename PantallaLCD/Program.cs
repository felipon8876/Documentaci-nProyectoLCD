
/*Documentación TEST*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PantallaLCD
{
    class Program
    {
        static string[] vector = new String[1000]; // vector que almacena los numeros ingresados correctamente.
        static void Main(string[] args)
        {
            Console.WriteLine("Bienvenido al programa de impresión estilo pantalla LCD.\n");
            Console.WriteLine("Favor Ingrese el primer número seguido de una ',' el cual hace referencia al tamaño, después ingrese " +
                "el resto de " + "números que desea ver impresos, finalice ingresando '0,0' para ver la impresión de los números.\n");

            LLenar();

            Mostrar();

            Console.ReadKey();

        }

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
        static bool analizoCantidad(string z) // metodo que analiza si el numero ingresado es correcto o no
        {
            int y = z.Length;

            int i;
            string koma = ",";
            int posiKoma = 0;
            int digitoUno;
            bool zoom = false;

            for (i = 0; i < y; i++)              //hallo la posición de la coma
            {
                if (koma == z.Substring(i, 1))
                {
                    posiKoma = i;
                    i = y;
                }
            }

            if (posiKoma == 1)
            {
                if (analizoSiEsNumero(z.Substring(0, 1)))
                {
                    zoom = true;
                    digitoUno = int.Parse(z.Substring(0, 1));
                }
                else
                {
                    Console.WriteLine("El símbolo '" + z.Substring(0, 1) + "' en la posición 1 no es un número");
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

        static void LLenar() // metodo que ingresa en las posiciones del vector los numeros correctos
        {
            int cont = 0;
            string fila = "A";              //Se le asigna cualquier valor

            while (fila != "0,0") // mientras sea diferente de 0,0 permita guardar en las posiciones del vector los numeros ingresados
            {
                fila = Console.ReadLine();
                if (analizoCantidad(fila))
                {
                    vector[cont] = fila;
                    cont = cont + 1;
                }
            }
        }

        static void Mostrar()
        {
            int i = 0;
            while (vector[i] != null)
            {
                ImprimirEnLCD(vector[i]);
                i = i + 1;
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
