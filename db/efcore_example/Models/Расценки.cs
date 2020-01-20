using System;
using System.Collections.Generic;

namespace Lab.Models
{
    public partial class Расценки
    {
        public Расценки()
        {
            Звонки = new HashSet<Звонки>();
        }

        public string Город { get; set; }
        public string ВремяСуток { get; set; }
        public short Стоимость { get; set; }

        public virtual ICollection<Звонки> Звонки { get; set; }
    }
}
