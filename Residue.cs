using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDBVR
{
    class Residue : IEnumerable<Atom>
    {
        public int _resnum { get; set; }
        public string _resname { get; set; }
        private Tuple<float> cm_coords;
        private List<Atom> atoms = new List<Atom>();

        public Residue(string resname, int resnum)
        {
            this._resname = resname;
            this._resnum = resnum;
        }

        public void AddAtom(Atom atom)
        {
            atoms.Add(atom);
        }

        public void RemoveAtom(int index)
        {
            atoms.Remove(atoms[index]);
        }

        private void CalcBonds()
        {
            foreach (var atom in atoms)
            {

            }
        }

        private void CalcResCM()
        {

        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        public IEnumerator<Atom> GetEnumerator()
        {
            return atoms.GetEnumerator();
        }
    }
}
