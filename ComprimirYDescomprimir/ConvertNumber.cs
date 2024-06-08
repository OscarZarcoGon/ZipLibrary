using System;
using System.Collections.Generic;
using Humanizer;

namespace ComprimirYDescomprimir
{
    public class ConvertNumber
    {
        public int number { get; set; }
        public string word { get; set; }

        public List<Message> oMessages = new List<Message>();

        public ConvertNumber()
        {
            number = 0;
            word = string.Empty;
        }

        public void convertNumber(int number)
        {
            if (number.GetType() != typeof(int))
            {
                oMessages.AddMessage(3, "No es un número", TypeMessages.error);
                return;
            }

            try
            {
                word = number.ToWords(new System.Globalization.CultureInfo("es-ES"));
                Console.WriteLine(word);
                oMessages.AddMessage(0, "Hecho", TypeMessages.success);

            }
            catch (Exception ex)
            {
                oMessages.AddMessage(999, ex.Message, TypeMessages.error);
            }
        }
    }
}





/*, string input */
//ESTO ES PARA HACER PRUEBAS CON OTROS NÚMEROS
//long number;
//if (!long.TryParse(input, out number))
//{
//    oMessages.AddMessage(3, "No es un número", TypeMessages.danger);
//    return;
//}

//if (input == null || input == "")
//{
//    oMessages.AddMessage(2, "Está vacío", TypeMessages.info);
//    return;
//}