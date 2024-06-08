using ComprimirYDescomprimir;

namespace ProgramComprimir
{
    public class ComprimirProgram
    {
        public static void Main(string[] args)
        {
            //TestZipMethod();
            //TestUnZipMethod();
            //TestZipListMethod();
            //TestConvertNumber();
            TestNumberConvert();
        }


        public static void TestZipMethod()
        {
            string carpeta = @"C:\Comprimir\miarchivo";
            string archivoComprimido = @"C:\Comprimir\miarchivo.zip";

            ComprimirLibrary oZip = new ComprimirLibrary();
            oZip.ZipFolder(carpeta, archivoComprimido);

            foreach (var message in oZip.oMessages)
            {
                //message.ToString();
                oZip.oMessages.Add(message);
                //Console.WriteLine(message.ToString());
                string jsonMessage = message.ToJson();
                Console.WriteLine("Mensaje serializado: " + jsonMessage);
            }

        }


        public static void TestUnZipMethod()
        {
            string archivoComprimido = @"C:\Comprimir\miarchivo.zip";
            //string archivoComprimido = @"C:\Comprimir\archivosComp.zip";
            string carpetaDestino = @"C:\Comprimir\miarchivo_descomprimido";

            ComprimirLibrary oZip = new ComprimirLibrary();
            oZip.UnZip(archivoComprimido, carpetaDestino);


            foreach (var message in oZip.oMessages)
            {
                Console.WriteLine(message.ToString());
                string jsonMessage = message.ToJson();
                Console.WriteLine("Mensaje serializado: " + jsonMessage);
            }
        }


        public static void TestZipListMethod()
        {
            List<string> archivos = new List<string>
            {
                @"C:\Comprimir\archivo1",
                @"C:\Comprimir\archivo2",
                @"C:\Comprimir\archivo3"

            };
            string archivoComprimidoLista = @"C:\Comprimir\archivosComp.zip";

            ComprimirLibrary oZip = new ComprimirLibrary();
            oZip.ZipList(archivos, archivoComprimidoLista);
            foreach (var message in oZip.oMessages)
            {
                Console.WriteLine(message.ToString());
                string jsonMessage = message.ToJson();
                Console.WriteLine("Mensaje serializado: " + jsonMessage);
            }
        }

        public static void TestConvertNumber()
        {
            ConvertNumber oConvertNumber = new ConvertNumber();
            oConvertNumber.convertNumber(20);

            foreach (var message in oConvertNumber.oMessages)
            {

                oConvertNumber.oMessages.ToString();
                Console.WriteLine(message.ToString());

                string jsonMessage = message.ToJson();
                Console.WriteLine("Mensaje serializado: " + jsonMessage);

                Message deserializedMessage = Message.FromJson(jsonMessage);
                Console.WriteLine("Mensaje deserializado: " + deserializedMessage.ToString());

            }
        }


        public static void TestNumberConvert()
        {
            NumberConvert oNumberConvert = new NumberConvert();

            oNumberConvert.ConvertNumber(3221111);
            //for (int i = 9999; i <= 10000; i++)
            //{
            //    oNumberConvert.ConvertNumber(i);
            //}

            //long[] testNumbers = { 1, 10, 21, 29, 30, 42, 111, 110, 1000 };

            //foreach (var num in testNumbers)
            //{
            //    oNumberConvert.ConvertNumber(num);
            //    foreach (var message in oNumberConvert.oMessages)
            //    {
            //        Console.WriteLine(message.ToString());
            //    }
            //}


            //foreach (var message in oNumberConvert.oMessages)
            //{
            //    Console.WriteLine(message.ToString());
            //}
        }

    }
}


//1234, 1000, 1010, 2023, 3029, 25000, 300000, 1500000, 10000001, 999999999
// 2334, 2222, 2020, 2345, 2789, 2009, 2001, 2000, 1000, 9999, 10000, 100000, 999999, 2829291,