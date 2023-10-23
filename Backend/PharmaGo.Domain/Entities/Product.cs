using System.Text.RegularExpressions;
using PharmaGo.Exceptions;

namespace PharmaGo.Domain.Entities;


public class Product
{
    public int Id { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public Pharmacy? Pharmacy { get; set; }

    public void ValidOrFail()
    {
        if (string.IsNullOrEmpty(Code)|| Code.Length != 5 || !EsNumero(Code) || string.IsNullOrEmpty(Name)|| Name.Length > 30  || string.IsNullOrEmpty(Description) || Description.Length > 70
                || Price <= 0
                ||  Pharmacy == null)
        {
            throw new InvalidResourceException("The product is not correctly created.");
        }
    }

    static private bool EsNumero(string cadena)
    {
        // Utiliza una expresión regular para verificar si la cadena contiene solo números
        // El patrón regular ^\d+$ significa que debe comenzar (^) y terminar ($) con uno o más dígitos (\d).
        return Regex.IsMatch(cadena, @"^\d+$");
    }
}