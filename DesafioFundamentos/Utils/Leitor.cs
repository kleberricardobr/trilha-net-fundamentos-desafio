namespace DesafioFundamentos.Utils
{
    public class Leitor
    {
        public static T LerValor<T>(string mensagem, Func<string, bool> validar)
        {
            Console.WriteLine(mensagem);
            var valor = Console.ReadLine();

            if (validar(valor))
            {
                //Créditos: https://stackoverflow.com/questions/732677/converting-from-string-to-t
                return (T)Convert.ChangeType(valor, typeof(T));
            }

            Console.WriteLine("Valor inválido!");
            Console.WriteLine("Pressione qualquer tecla para continuar.");
            Console.ReadLine();
            Console.Clear();

            return LerValor<T>(mensagem, validar);
        }

        public static T LerValorMaiorQueZero<T>(string mensagem)
        {
            return LerValor<T>(mensagem, x =>
            {
                try
                {
                    decimal valor = (decimal)Convert.ChangeType(x, TypeCode.Decimal);
                    return valor > 0;
                }
                catch (System.Exception)
                {
                    return false;
                }
            });
        }
        
        public static string LerString(string mensagem, bool permitirEmBranco = false)
        {
            return LerValor<string>(mensagem, x => permitirEmBranco || x.Trim().Length > 0);            
                
        }

    }
}