using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDBVR
{
    class Chain : IEnumerable<Residue>
    {
        public string chainID { get; set; }
        public List<Residue> residues = new List<Residue>();

        public Chain(string chainid)
        {
            this.chainID = chainid;
        }

        public void AddRes(Residue res)
        {
            this.residues.Add(res);
        }

        public void RemoveRes(Residue res)
        {

        }

        public Residue GetRes(int index)
        {
            return residues[index];
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        public IEnumerator<Residue> GetEnumerator()
        {
            return residues.GetEnumerator();
        }
    }
}
