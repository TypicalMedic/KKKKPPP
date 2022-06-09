using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Json.Net;
namespace KKKKPPP.Data
{
    public class Экскурсия
    {
        [Key]
        public int id { get; set; }
        public string Тип { get; set; }
        public string Название { get; set; }
        public string Содержание { get; set; }
        public string Аннотация { get; set; }
        [NotMapped]
        public List<List<Dictionary<string, string>>> content { get; set; }
        [NotMapped]
        public int lastPartIndex { get; set; }
        [NotMapped]
        public int lastRoomIndex { get; set; }
        public void ImportJSON()
        {
            using (StreamReader r = new StreamReader($"Assets/Excursions/{Содержание}", Encoding.UTF8))
            {
                string json = r.ReadToEnd();
                List<List<Dictionary<string, string>>> input = System.Text.Json.JsonSerializer.Deserialize<List<List<Dictionary<string, string>>>>(json);
                lastRoomIndex = input.Count - 1;
                lastPartIndex = input[lastRoomIndex].Count - 1;
                content = input;
            }
        }
    }
}
