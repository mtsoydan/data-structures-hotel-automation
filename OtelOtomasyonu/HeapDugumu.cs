using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtelOtomasyonu
{
   public class HeapDugumu
    {
        public PersonelBilgi otel { get; set; }
        public HeapDugumu(PersonelBilgi o)
        {
            this.otel = o;
        }
    }
}
