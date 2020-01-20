using System;
using System.Collections.Generic;

namespace Lab.Models
{
    public partial class Звонки
    {
        public short Id { get; set; }
        public DateTime Дата { get; set; }
        public short Длительность { get; set; }
        public long Инн { get; set; }
        public string Город { get; set; }
        public string ВремяСуток { get; set; }

        public virtual ЮридЛица ИннNavigation { get; set; }
        public virtual Расценки Расценки { get; set; }
    }
}
