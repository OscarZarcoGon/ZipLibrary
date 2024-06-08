using System;
using System.Collections.Generic;
using Newtonsoft.Json;


namespace ComprimirYDescomprimir
{
    public class Message
    {
        //codeError = 0 Completado
        //codeError = 1 No existe
        //codeError = 2 Ya existe
        //codeError = 3 falló
        //codeError = 999 Error / Excepcion
        public int ID { get; set; }
        public string Description { get; set; }
        public TypeMessages Type { get; set; }


        //public string ToJson() => JsonConvert.SerializeObject(this);

        public string ToJson()
        {
            var json = JsonConvert.SerializeObject(this);
            return json != null || json != "" ? json : null;
        }


        public static Message FromJson(string json) => !string.IsNullOrEmpty(json) ? JsonConvert.DeserializeObject<Message>(json) : null;

        //public static Message FromJson(string json)
        //{
        //    return !string.IsNullOrEmpty(json) ? JsonConvert.DeserializeObject<Message>(json) : null;
        //}

        public override string ToString() => $"Code: {ID}, Description: {Description}, Type: {Type}";


    }

    public static class MessageHelper
    {
        public static void AddMessage(this List<Message> omenssage, int ID, string Description, TypeMessages typeMe)
        {
            Message tmp = new Message();
            tmp.ID = ID;
            tmp.Description = Description;
            tmp.Type = typeMe;
            omenssage.Add(tmp);
        }

        public static string ListToJson(this List<Message> messages) => JsonConvert.SerializeObject(messages);
        public static List<Message> ListFromJson(string json) => JsonConvert.DeserializeObject<List<Message>>(json);

    }
    public enum TypeMessages
    {
        success = 0,
        warning = 1,
        info = 2,
        danger = 3,
        error = 999,
    }
}
