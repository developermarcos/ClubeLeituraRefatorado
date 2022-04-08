using ClubeLeitura.ConsoleApp.Compartilhado;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace ClubeLeitura.ConsoleApp.BaseDados
{
    public class ConverteObjectJson<T> where T : EntidadeBase
    {
        private static string SerializarObjeto(List<T> registro)
        {
            return JsonConvert.SerializeObject(registro, Formatting.Indented);
        }

        private static T DeserealizarObjecto(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }

        public static void SalvarListaArquivo(List<T> lista, string entidadeNome)
        {
            string fileName = @"C:\Users\marco\source\repos\ClubeLeituraRefatorado\ClubeLeitura.ConsoleApp\BaseDados\"+entidadeNome+".json";
            try
            {
                using (StreamWriter writer = new StreamWriter(fileName))
                {
                    string serializa = SerializarObjeto(lista);
                    writer.WriteLine(serializa);
                }

            }
            catch (Exception exp)
            {
                Console.Write(exp.Message);
            }
        }

        public static List<T> BuscarListaArquivo(string entidadeNome)
        {
            string fileName = @"C:\Users\marco\source\repos\ClubeLeituraRefatorado\ClubeLeitura.ConsoleApp\BaseDados\"+entidadeNome+".json";
            // Create a StreamReader from a FileStream  
            List<T> registros = new List<T>();
            using (StreamReader reader = new StreamReader(new FileStream(fileName, FileMode.Open)))
            {
                registros = JsonConvert.DeserializeObject<List<T>>(reader.ReadToEnd());
            }
            return registros;
        }
    }
}
