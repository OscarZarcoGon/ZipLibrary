using System;
using System.IO.Compression;
using System.IO;
using System.Collections.Generic;


namespace ComprimirYDescomprimir
{
    public class ComprimirLibrary
    {
        int codeError = 0;
        public int CodeError { get => codeError; set => codeError = value; }

        public List<Message>oMessages = new List<Message>();

       

        public void ZipFolder(string carpeta, string archivoComprimido)
        {
            if (!Directory.Exists(carpeta))
            {
                oMessages.AddMessage(1, "No existe la carpeta", TypeMessages.warning);
                return;
            }

            if (File.Exists(archivoComprimido))
            {
                oMessages.AddMessage(2, "Ya existe la carpeta", TypeMessages.info);
                return;
            }

            try
            {
                ZipFile.CreateFromDirectory(carpeta, archivoComprimido);
                oMessages.AddMessage(0, "Hecho", TypeMessages.success);

            }
            catch (Exception ex)
            {
                oMessages.AddMessage(999, ex.Message, TypeMessages.error);
            }
        }



        public void UnZip(string archivoComprimido, string carpetaDestino)
        {
            if (!File.Exists(archivoComprimido))
            {
                oMessages.AddMessage(1, "No existe el archivo", TypeMessages.warning);
                return;
            }

            try
            {
                ZipFile.ExtractToDirectory(archivoComprimido, carpetaDestino);
                oMessages.AddMessage(0, "Hecho", TypeMessages.success);

            }
            catch (Exception ex)
            {
                oMessages.AddMessage(999, ex.Message, TypeMessages.error);
            }
        }



        public void ZipList(List<string> archivos, string archivoComprimidoLista)
        {
            if (archivos.Count == 0)
            {
                oMessages.AddMessage(1, "No existe la carpeta", TypeMessages.warning);
                return;
            }

            foreach (string archivo in archivos)
            {
                if (!Directory.Exists(archivo))
                {
                    oMessages.AddMessage(1, "No existe", TypeMessages.warning);
                    return;
                }
            }

            try
            {
                using (ZipArchive zip = ZipFile.Open(archivoComprimidoLista, ZipArchiveMode.Create))
                {
                    foreach (string archivo in archivos)
                    {
                        DirectoryInfo di = new DirectoryInfo(archivo);
                        foreach (FileInfo file in di.GetFiles())
                        {
                            zip.CreateEntryFromFile(file.FullName, Path.Combine(di.Name, file.Name));
                        }
                    }
                }
            }
            catch
            {
                oMessages.AddMessage(2, "Ya existe el archivo", TypeMessages.info);

            }
        }
    }
}



























/*  G U Í A    P A R A    R E P A S A R    Y    E S T U D I A R

using (ZipArchive zip = ZipFile.Open(archivoComprimidoLista, ZipArchiveMode.Create))            // Abre un archivo ZIP para escritura y asegura que se cierre correctamente al finalizar (Para esto es el using; se puede usar también el Dispose)
{
    foreach (string archivo in archivos)                                                        // Recorre cada elemento en la lista de archivos
    {
        if (Directory.Exists(archivo))                                                          // Si el elemento es una carpeta
        {
            DirectoryInfo di = new DirectoryInfo(archivo);                                      // Obtiene información sobre la carpeta
            
            foreach (FileInfo file in di.GetFiles())                                            // Luego, recorre cada archivo dentro de la carpeta
            {
                zip.CreateEntryFromFile(file.FullName, Path.Combine(di.Name, file.Name));       // Y agrega el archivo al archivo .zip con la ruta dentro del .zip
            }
        }
    }
}



LO DE HASTA ARRIBA:
Son propiedades que se hacen para devolverle a quien consuma la libreria los errores y mensajes








 public void ShowMessage()
        {
            switch (codeError)
            {
                case 0:
                    Console.WriteLine("El proceso se realizó correctamente.");
                    break;
                case 1:
                    Console.WriteLine("La carpeta especificada no existe.");
                    break;
                default:
                    break;
            }
        }
*/