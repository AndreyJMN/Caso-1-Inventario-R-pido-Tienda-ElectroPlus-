using System;
using System.Collections.Generic;

namespace Caso_1_Inventario_Rápido___Tienda__ElectroPlus_
{
    class Producto // comentario1
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
    }

    class Program // Segundo comentario
    {
        static void Main(string[] args)
        {
            List<Producto> inventario = new List<Producto>();
            bool salir = false;

            while (!salir)
            {
                Console.WriteLine("--Menú ElectroPlus--");
                Console.WriteLine("1. Agregar producto.");
                Console.WriteLine("2. Listar productos.");
                Console.WriteLine("3. Buscar producto por código.");
                Console.WriteLine("4. Mostrar productos sin stock");
                Console.WriteLine("5. Salir.");
                Console.WriteLine("Seleccione una opción: ");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":

                        Producto p = new Producto();

                        do
                        {
                            Console.Write("Ingrese código: ");
                            p.Codigo = Console.ReadLine();
                            if (string.IsNullOrWhiteSpace(p.Codigo))
                            {
                                Console.WriteLine("Error: El código no puede estar vacío.");
                            }
                        } while (string.IsNullOrWhiteSpace(p.Codigo));

                        do
                        {
                            Console.Write("Ingrese nombre: ");
                            p.Nombre = Console.ReadLine();
                            if (string.IsNullOrWhiteSpace(p.Nombre))
                            {
                                Console.WriteLine("Error: El nombre no puede estar vacío.");
                            }
                        } while (string.IsNullOrWhiteSpace(p.Nombre));

                        while (true)
                        {
                            try
                            {
                                Console.Write("Ingrese precio: ");
                                p.Precio = decimal.Parse(Console.ReadLine());
                                if (p.Precio < 0)
                                {
                                    Console.WriteLine("Error: El precio no puede ser negativo.");
                                    continue;
                                }
                                break; 
                            }
                            catch
                            {
                                Console.WriteLine("Error: Debe ingresar un número válido para el precio.");
                            }
                        }

                        while (true)
                        {
                            try
                            {
                                Console.Write("Ingrese cantidad: ");
                                p.Cantidad = int.Parse(Console.ReadLine());
                                if (p.Cantidad < 0)
                                {
                                    Console.WriteLine("Error: La cantidad no puede ser negativa.");
                                    continue;
                                }
                                break; 
                            }
                            catch
                            {
                                Console.WriteLine("Error: Debe ingresar un número válido para la cantidad.");
                            }
                        }

                        inventario.Add(p);
                        Console.WriteLine("Producto agregado con éxito!");
                        break;

                    case "2":
                        Console.WriteLine("\nCódigo | Nombre | Precio | Cantidad");
                        foreach (var prod in inventario)
                        {
                            Console.WriteLine($"{prod.Codigo} | {prod.Nombre} | {prod.Precio} | {prod.Cantidad}");
                        }
                        break;

                    case "3":
                        Console.Write("Ingrese código a buscar: ");
                        string codigoBuscado = Console.ReadLine();
                        bool encontrado = false;
                        foreach (var prod in inventario)
                        {
                            if (prod.Codigo == codigoBuscado)
                            {
                                Console.WriteLine($"Encontrado: {prod.Codigo} | {prod.Nombre} | {prod.Precio} | {prod.Cantidad}");
                                encontrado = true;
                                break;
                            }
                        }
                        if (!encontrado)
                        {
                            Console.WriteLine("Producto no encontrado.");
                        }
                        break;

                    case "4":
                        Console.WriteLine("\nProductos sin stock:");
                        foreach (var prod in inventario)
                        {
                            if (prod.Cantidad == 0)
                            {
                                Console.WriteLine($"{prod.Codigo} | {prod.Nombre} | {prod.Precio} | {prod.Cantidad}");
                            }
                        }
                        break;

                    case "5":
                        salir = true;
                        Console.WriteLine("Saliendo del programa...");
                        break;

                    default:
                        Console.WriteLine("Opción inválida, intente de nuevo.");
                        break;
                }
            }
        }

    }
}
// tercer comentario