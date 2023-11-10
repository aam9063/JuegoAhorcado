using System;

class Ahorcado
{
    static void Main()
    {
        string palabraSecreta = ObtenerPalabraSecreta();
        char[] letrasDescubiertas = new char[palabraSecreta.Length];

        InicializarLetrasDescubiertas(letrasDescubiertas);

        int intentosMaximos = 6;
        int intentosRestantes = intentosMaximos;

        while (intentosRestantes > 0)
        {
            MostrarEstadoJuego(letrasDescubiertas, intentosRestantes);

            Console.Write("\nIngresa una letra: ");
            char letraIngresada = Console.ReadKey().KeyChar;

            if (YaAdivinada(letraIngresada, letrasDescubiertas))
            {
                Console.WriteLine("\nYa has ingresado esa letra. Intenta con otra.");
                continue;
            }

            bool letraCorrecta = ActualizarLetrasDescubiertas(palabraSecreta, letrasDescubiertas, letraIngresada);

            if (!letraCorrecta)
            {
                intentosRestantes--;
                Console.WriteLine("\nLetra incorrecta. Te quedan {0} intentos.", intentosRestantes);
            }
            else
            {
                Console.WriteLine("\n¡Letra correcta!");
            }

            if (PalabraDescubierta(letrasDescubiertas))
            {
                Console.WriteLine("\n¡Felicidades! Has descubierto la palabra secreta: {0}", palabraSecreta);
                break;
            }
        }

        if (intentosRestantes == 0)
        {
            Console.WriteLine("\n¡Oh no! Has agotado todos tus intentos. La palabra secreta era: {0}", palabraSecreta);
        }
    }

    static string ObtenerPalabraSecreta()
    {
        string[] palabras = { "programacion", "computadora", "ahorcado", "visualstudio", "csharp", "desarrollo" };
        Random random = new Random();
        int indice = random.Next(palabras.Length);
        return palabras[indice];
    }

    static void InicializarLetrasDescubiertas(char[] letrasDescubiertas)
    {
        for (int i = 0; i < letrasDescubiertas.Length; i++)
        {
            letrasDescubiertas[i] = '_';
        }
    }

    static void MostrarEstadoJuego(char[] letrasDescubiertas, int intentosRestantes)
    {
        Console.WriteLine("\nPalabra: {0}", string.Join(" ", letrasDescubiertas));
        Console.WriteLine("Intentos restantes: {0}", intentosRestantes);
    }

    static bool YaAdivinada(char letra, char[] letrasDescubiertas)
    {
        return Array.IndexOf(letrasDescubiertas, letra) != -1;
    }

    static bool ActualizarLetrasDescubiertas(string palabraSecreta, char[] letrasDescubiertas, char letra)
    {
        bool letraCorrecta = false;

        for (int i = 0; i < palabraSecreta.Length; i++)
        {
            if (palabraSecreta[i] == letra)
            {
                letrasDescubiertas[i] = letra;
                letraCorrecta = true;
            }
        }

        return letraCorrecta;
    }

    static bool PalabraDescubierta(char[] letrasDescubiertas)
    {
        return Array.IndexOf(letrasDescubiertas, '_') == -1;
    }
}
