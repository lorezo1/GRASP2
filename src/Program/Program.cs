//-------------------------------------------------------------------------
// <copyright file="Program.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//-------------------------------------------------------------------------

using System;
using System.Collections;
using System.Linq;
using Full_GRASP_And_SOLID.Library;

namespace Full_GRASP_And_SOLID
{
    public class Program
    {
        private static ArrayList productCatalog = new ArrayList();

        private static ArrayList equipmentCatalog = new ArrayList();

        public static void Main(string[] args)
        {
            PopulateCatalogs();

            Recipe recipe = new Recipe();
            recipe.FinalProduct = GetProduct("Café con leche");// buscar "cafe con leche" en el catalogo y guardarlo como FinalProduct
            recipe.AddStep(new Step(GetProduct("Café"), 100, GetEquipment("Cafetera"), 120));// 100 de cantidad de cafe por 120 de tiempo en la cafetera
            recipe.AddStep(new Step(GetProduct("Leche"), 200, GetEquipment("Hervidor"), 60));// 200 de cantidad de leche por 60 de tiempo en hervidor
            ConsolePrinter printer = new ConsolePrinter();
            printer.Print(recipe);
        }

        private static void PopulateCatalogs()
        {
            // función PopulateCatalo(), añade un monton de productos y equipos al catalogo
            AddProductToCatalog("Café", 100);
            AddProductToCatalog("Leche", 200);
            AddProductToCatalog("Café con leche", 300);

            AddEquipmentToCatalog("Cafetera", 1000);
            AddEquipmentToCatalog("Hervidor", 2000);
        }

        private static void AddProductToCatalog(string description, double unitCost)
        {
            productCatalog.Add(new Product(description, unitCost));
            // funcion AddProductToCatalog(), agrega un producto al catalogo de productos, tiene una descripcion y un costo
            // crea un nuevo objeto Producto con esa descripcion y costo y lo añade al catalogo
        }

        private static void AddEquipmentToCatalog(string description, double hourlyCost)
        {
            // funcion AddEquipmentToCatalog(), agrega un equipamiento al catalogo de equipamientos, tiene una descripcion y un costo horario
            // crea un nuevo objeto Equipment con esa descripcion y costo horario y lo añade al catalogo
            equipmentCatalog.Add(new Equipment(description, hourlyCost));
        }

        private static Product ProductAt(int index)
        {
            // función ProductAt(), le pasamos un indice y retorna el producto en esa posicion del catalogo
            return productCatalog[index] as Product;
        }

        private static Equipment EquipmentAt(int index)
        {
            // función EquipmentAt(), le pasamos un indice y retorna el equipamiento en esa posicion del catalogo
            return equipmentCatalog[index] as Equipment;
        }

        private static Product GetProduct(string description)
        {
            // asignar a "query" un "product" de tipo Product que esté en el productCatalog si su descripcion es igual a la que le pasamos a la funcion
            var query = from Product product in productCatalog where product.Description == description select product;
            // retorna el valor de query, si no habia un producto no retorna nada
            return query.FirstOrDefault();
        }

        private static Equipment GetEquipment(string description)
        {
            // asignar a "query" un "equipment" de tipo Equipment que esté en el equipmentCatalog si su descripcion es igual a la que le pasamos a la funcion
            var query = from Equipment equipment in equipmentCatalog where equipment.Description == description select equipment;
            // retorna el valor de query, si no habia un equipamiento no retorna nada
            return query.FirstOrDefault();
        }
    }
}
// El principio que se utiliza en las clases es el de expert
