using System;
using System.Collections.Generic;


namespace ComprimirYDescomprimir
{
    public class NumberConvert
    {
        string[] UnitaryNumber =    { "", "uno", "dos", "tres", "cuatro", "cinco", "seis", "siete", "ocho", "nueve" };

        string[] EspecialNumber =   { "once", "doce", "trece", "catorce", "quince", "dieciséis", "diecisiete", "dieciocho", "diecinueve"};

        string[] TensNumber =       { "diez", "veinte", "treinta", "cuarenta", "cincuenta", "sesenta", "setenta", "ochenta", "noventa" };

        string[] HundredNumber =    { "", "ciento", "doscientos", "trescientos", "cuatrocientos", "quinientos", "seiscientos", "setecientos", "ochocientos", "novecientos" };

        public List<Message> oMessages = new List<Message>();

        public long number { get; set; }

        public NumberConvert()
        {
            number = 0;
        }

        public void ConvertNumber(long number)
        {
            if (number < 0 || number > 999999999)
            {
                oMessages.AddMessage(2, "Número fuera de rango", TypeMessages.warning);
                return;
            }
            if (number == 0)
            {
                Console.WriteLine("cero".ToUpper());
                return;
            }

            try
            {
                string letrasNum = number.ToString();
                int length = letrasNum.Length;

                string result;
                switch (length)
                {
                    case 1:
                        result = Unidad(number);
                        break;
                    case 2:
                        result = Decena(number);
                        break;
                    case 3:
                        result = Centena(number);
                        break;
                     case 4:
                        result = Mil(number);
                        break;
                    case 5:
                        result = DecenaMil(number);
                        break;
                    case 6:
                        result = CentenaMil(number);
                        break;
                    case 7:
                        result = Millon(number);
                        break;

                    default:
                        result = "Número fuera de rango";
                        break;
                }

                Console.WriteLine(result.ToUpper());
            }
            catch (Exception ex)
            {
                oMessages.AddMessage(999, ex.Message, TypeMessages.error);
            }
        }



        public string Unidad(long number)
        { 
            return UnitaryNumber[number];
        }

        public string Decena(long number)
        {
            if (number < 10) return Unidad(number);
            if (number >= 11 && number <= 19) return EspecialNumber[number - 11];
            if (number >= 21 && number <= 29) return "veinti" + Unidad(number % 10);

            long unidad = number % 10;
            long decena = number / 10;
            return unidad == 0 ? TensNumber[decena - 1] : TensNumber[decena - 1] + " y " + Unidad(unidad);
        }

        public string Centena(long number)
        {
            if (number == 100) return "cien";
            long centena = number / 100;
            long resto = number % 100;
            return resto == 0 ? HundredNumber[centena] : HundredNumber[centena] + " " + Decena(resto);
        }

        public string Mil(long number)
        {
            long miles = number / 1000;
            long resto = number % 1000;

            string mil = (miles == 1) ? "mil" : Unidad(miles) + " mil";

            return resto == 0 ? mil : mil + " " + Centena(resto);
        }
        public string DecenaMil(long number)
        {
            long decenaMil = number / 1000;
            long resto = number % 1000;
            return Decena(decenaMil) + " mil " + (resto == 0 ? "" : Centena(resto));
        }
        public string CentenaMil(long number)
        {
            long centenaMil = number / 1000;
            long resto = number % 1000;
            return Centena(centenaMil) + " mil " + (resto == 0 ? "" : Centena(resto));
        }
        public string Millon(long number)
        {
            long millon = number / 1000000;
            long resto = number % 1000000;
            string millonText = millon == 1 ? "un millón" : Unidad(millon) + " millones";
            return resto == 0 ? millonText : millonText + " " + CentenaMil(resto);
        }
    }
}
