using System;
using System.Collections.Generic;

namespace Lab.Models
{
    public partial class ЮридЛица
    {
        public ЮридЛица()
        {
            Звонки = new HashSet<Звонки>();
        }

        public string Наименование { get; set; }
        public string Город { get; set; }
        public long Инн { get; set; }
        public long БанкСчет { get; set; }
        public int ТелТочка { get; set; }

        public virtual ICollection<Звонки> Звонки { get; set; }
    }
}
