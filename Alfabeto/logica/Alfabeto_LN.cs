using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace logica
{
	public class Alfabeto_LN
	{
		private static Dictionary<char, int> AlfabetoDictionary = new Dictionary<char, int>();

		public Alfabeto_LN() => InicializarRandomAlfabeto();

		public int ObtenerSumatoriaLetras(string palabra) => string.IsNullOrEmpty(palabra)  ? 0 
																							: palabra.ToCharArray().Sum(c => AlfabetoDictionary[char.ToLower(c)]);


		private void InicializarRandomAlfabeto()
		{
			char[] letras = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
			List<int> valores = Enumerable.Range(1, 26).ToList();
			Random random = new Random();

			char[] alfabetoDesordenado = letras.OrderBy(o => random.Next()).ToArray();

			AlfabetoDictionary = alfabetoDesordenado.Select(y => new { letra = y, valor = valores[Array.IndexOf(alfabetoDesordenado, y)] }).ToDictionary(k => k.letra, k => k.valor);
		}
	}
}
