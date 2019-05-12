using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtelOtomasyonu
{
   public class HeapDugumu
    {
        public OtelBilgi otel { get; set; }
        public HeapDugumu(OtelBilgi o)
        {
            this.otel = o;
        }
    }
}
