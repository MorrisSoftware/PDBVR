using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDBVR
{
    class StructureBuilder
    {

        public StructureBuilder()
        {

        }

        public void BuildStruct(System pdbstructure)
        {
            foreach (Chain chain in pdbstructure)
            {
                Console.WriteLine(chain.chainID);
                foreach (Residue residue in chain)
                {
                    Console.WriteLine("\t" + residue._resname);
                    foreach (Atom atom in residue)
                    {
                        Console.WriteLine("\t\t" + atom.atom_type);
                    }
                }
            }

        }
    }
}
