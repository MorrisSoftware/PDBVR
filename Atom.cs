using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDBVR
{
    class Atom
    {
        public string atom_type { get; set; }
        public float x_coord { get; set; }
        public float y_coord { get; set; }
        public float z_coord { get; set; }

        public Atom(string atomtype, float xcoord, float ycoord, float zcoord)
        {
            this.atom_type = atomtype;
            this.x_coord = xcoord;
            this.y_coord = ycoord;
            this.z_coord = zcoord;
        }
    }
}
