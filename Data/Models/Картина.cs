using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace KKKKPPP.Data.Models
{
    public class Картина
    {
        [Key]
        public int Инвентарный_номер { get; set; }
        public string Название { get; set; }
        public DateTime ДатаПриема { get; set; }
        public DateTime ДатаОкончания { get; set; }
        public string ЦельПередачи { get; set; }
        public float Ширина { get; set; }
        public float Высота { get; set; }
        public int Техника { get; set; }
        public int Состояние { get; set; }
        public int Статус { get; set; }
        public int Автор { get; set; }
        public int СтранаСоздания { get; set; }
        public int Жанр { get; set; }
        public int Стиль { get; set; }
        public int ГодСоздания { get; set; }
        //public Техника Техника { get; set; }
        //public Состояние_картины Состояние { get; set; }
        //public Статус_картины Статус { get; set; }
        //public Автор Автор { get; set; }
        //public Страна СтранаСоздания { get; set; }
        //public Жанр Жанр { get; set; }
        //public Стиль Стиль { get; set; }
        public override bool Equals(object obj)
        {
            Картина a= obj as Картина;
            if(this.Автор==a.Автор&&  this.Высота == a.Высота && this.ГодСоздания == a.ГодСоздания && this.ДатаОкончания == a.ДатаОкончания
                && this.ДатаПриема == a.ДатаПриема && this.Жанр == a.Жанр && this.Инвентарный_номер == a.Инвентарный_номер &&
                this.Название == a.Название && this.Состояние == a.Состояние && this.Статус == a.Статус && this.Стиль == a.Стиль && 
                this.СтранаСоздания == a.СтранаСоздания && this.Техника == a.Техника && this.ЦельПередачи == a.ЦельПередачи &&
                this.Ширина == a.Ширина)
            {
                return true;
            }
            return false;
        }
    }
}
