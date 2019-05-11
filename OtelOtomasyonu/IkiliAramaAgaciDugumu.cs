using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtelOtomasyonu
{
    public class IkiliAramaAgaciDugumu
    {
        public OtelBilgi veri;
        public IkiliAramaAgaciDugumu sol;
        public IkiliAramaAgaciDugumu sag;

        public IkiliAramaAgaciDugumu()
        {
        }

        public IkiliAramaAgaciDugumu(OtelBilgi otl)
        {
            this.veri = otl;
            sol = null;
            sag = null;
        }
    }
}
