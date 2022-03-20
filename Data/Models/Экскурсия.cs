using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Json.Net;
namespace KKKKPPP.Data.Models
{
    public class Экскурсия
    {
        [Key]
        public int id { get; set; }
        public string Тип { get; set; }
        public string Название { get; set; }
        public string Содержание { get; set; }
        [NotMapped]
        public List<Dictionary<string, object>> content { get; set; }
        [NotMapped]
        public string intro { get; set; }
        [NotMapped]
        public string epilogue { get; set; }
        public void ImportJSON()
        {
            using (StreamReader r = new StreamReader($"Assets/Excursions/{Содержание}", Encoding.UTF8))
            {
                string json = r.ReadToEnd();
                Dictionary<string, System.Text.Json.JsonElement> input = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, System.Text.Json.JsonElement>>(json);
                intro = input["Intro"].ToString();
                epilogue = input["Epilogue"].ToString();
                List<Dictionary<string, object>> mainI = new List<Dictionary<string, object>>();
                foreach (var x in input["Main"].EnumerateArray())
                {
                    Dictionary<string, object> b = new Dictionary<string, object>();
                    b.Add("Room", x.GetProperty("Room").ToString());
                    List<Dictionary<string, string>> d = new List<Dictionary<string, string>>();
                    foreach (var y in x.GetProperty("textList").EnumerateArray().ToList())
                    {
                        Dictionary<string, string> c = new Dictionary<string, string>();
                        c.Add("text", y.GetProperty("text").ToString());
                        c.Add("picNo", y.GetProperty("picNo").ToString());
                        d.Add(c);
                    }
                    b.Add("textList", d);
                    mainI.Add(b);
                }
                content = mainI;
            }
        }
    }
}
