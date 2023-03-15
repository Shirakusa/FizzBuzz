using NUnit.Framework;
using System.Text;

namespace FizzBuzz
{
    public class FizzBuzzUnitTest
    {
        private Dictionary<int, string[]> entradaSaida = new Dictionary<int, string[]>
        {
            { 1, new[] { "1" } },
            { 3, new[] { "1", "2", "Fizz" } },
            { 5, new[] { "1","2","Fizz","4","Buzz" } },
            { 15, new[] {"1","2","Fizz","4","Buzz","Fizz","7","8","Fizz","Buzz","11","Fizz","13","14","FizzBuzz" } }
        };

        [TestCase(1)]
        [TestCase(3)]
        [TestCase(5)]
        [TestCase(15)]
        public void Teste(int numeroTeste)
        {
            var resultado = FizzBuzz(numeroTeste).ToArray();

            //Assert
            var saidaEsperada = entradaSaida[numeroTeste];

            Assert.AreEqual(saidaEsperada.Length, resultado.Count());

            for (int i = 0; i < saidaEsperada.Length; i++)
            {
                Assert.AreEqual(saidaEsperada[i], resultado[i]);
            }
        }

        public static IEnumerable<string> FizzBuzz(int valor)
        {
            List<string> resultado = new List<string>();

            for (var r = 1; r <= valor; r++)
            {
                StringBuilder stringBuilder = new StringBuilder();

                if (r % 3 == 0)
                    stringBuilder.Append("Fizz");
                if (r % 5 == 0)
                    stringBuilder.Append("Buzz");

                resultado.Add(string.IsNullOrEmpty(stringBuilder.ToString()) ? r.ToString() : stringBuilder.ToString());
            }

            return resultado;
        }
    }
}