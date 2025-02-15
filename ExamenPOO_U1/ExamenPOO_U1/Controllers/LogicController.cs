using Microsoft.AspNetCore.Mvc;

namespace ExamenPOO_U1.Controllers
{
        [ApiController]
        [Route("api/[controller]")]
        public class LogicController : ControllerBase
        {
        // 1) Verificar si un número es primo
            [HttpGet("is-prime/{number}")]
            public IActionResult IsPrime(int number)
            {
                if (number <= 1)
                    return Ok(new { Number = number, IsPrime = false });

                for (int i = 2; i <= Math.Sqrt(number); i++)
                {
                    if (number % i == 0)
                        return Ok(new { Number = number, IsPrime = false });
                }

                return Ok(new { Number = number, IsPrime = true });
            }


        // 2) Calcular el factorial de un número
            [HttpGet("factorial/{number}")]
            public IActionResult Factorial(int number)
            {
                if (number < 0)
                    return BadRequest(new { Message = "El número no debe ser negativo" });

                long factorial = 1;
                for (int i = 1; i <= number; i++)
                {
                    factorial *= i;
                }

                return Ok(new { Number = number, Factorial = factorial });
            }

        // 3) Generar la serie finonacci hasta un número dado
            [HttpGet("fibonacci/{limit}")]
            public IActionResult Fibonacci(int limit)
            {
                if (limit < 0)
                    return BadRequest(new { Message = "El límite no debe ser negativo" });

                var sequence = new List<int> { 0, 1 };
                while (sequence[^1] + sequence[^2] <= limit)
                {
                    sequence.Add(sequence[^1] + sequence[^2]);
                }

                return Ok(new { Limit = limit, Sequence = sequence });
            }

        //4) Contar vocales en una palabra o frase
            [HttpGet("count-vowels")]
            public IActionResult CountVowels([FromQuery] string text)
            {
                if (string.IsNullOrEmpty(text))
                    return BadRequest(new { Message = "El texto no puede estar vacío" });

                int vowelCount = text.Count(c => "aeiouAEIOU".Contains(c));

                return Ok(new { Text = text, VowelCount = vowelCount });
            }

        //5) Verificar si una palabra es palindromo
            [HttpGet("is-palindrome/{word}")]
            public IActionResult IsPalindrome(string word)
            {
                if (string.IsNullOrEmpty(word))
                    return BadRequest(new { Message = "La palabra no puede estar vacía" });

                string reversed = new string(word.Reverse().ToArray());
                bool isPalindrome = string.Equals(word, reversed, StringComparison.OrdinalIgnoreCase);

                return Ok(new { Word = word, IsPalindrome = isPalindrome });
            }
        }
    


}
