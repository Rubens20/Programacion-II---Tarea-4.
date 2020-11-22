using System;
using System.Collections.Generic;
using System.Text;

namespace PatronSingleton_CSharp
{
    public class Calculadora
    {
        private readonly Logger _logger;
        public Calculadora()
        {
            _logger = Logger.GetLogger();
        }

        public void Dividir(int a, int b)
        {
            try 
            {
                var resultado = a / b;
                Console.WriteLine(resultado);           
            }
            catch (Exception exception)
            {
                _logger.Log(exception.Message);
            }
        
        }          
    }
}
