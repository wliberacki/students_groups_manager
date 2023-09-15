using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysZarzGr
{
    public interface IGrupa
    {   void DodajStudenta(Student student);
        void UsunStudenta(string nralbumu);
        void Sortuj();
        void SortujNrAlbumu();
    }
}
