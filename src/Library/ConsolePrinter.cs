using System;

namespace Full_GRASP_And_SOLID.Library
{
    public class ConsolePrinter
    {
        // Usamos el principio SRP porque al imprimir la receta la propia receta, le estabamos dando 2 responsabilidades, y usamos este principio
        // para separarla en dos clases para que cada una tenga 1 sola responsabilidad. Esto nos ayuda a poder cambiar la manera en la que
        // funciona el codigo, y facilitar el poder hacer diferentes funciones que impriman diferente.

        public void Print(Recipe receta)
        {
            Console.WriteLine($"Receta de {receta.FinalProduct.Description}:");
            foreach (Step step in receta.GetSteps())
            {
                Console.WriteLine($"{step.Quantity} de '{step.Input.Description}' " +
                    $"usando '{step.Equipment.Description}' durante {step.Time}");
            }
        }
    }
}