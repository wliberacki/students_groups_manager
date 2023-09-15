using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysZarzGr
{
    public class NrAlbumuComparator: IComparer<Student>
    {
        public int Compare(Student a, Student b)
        {
            return string.Compare(a.NumerAlbumu, b.NumerAlbumu);
        }
    }
}
