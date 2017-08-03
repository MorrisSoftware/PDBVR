using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDBVR
{
    class System : IEnumerable<Chain>
    {
        private string PDBID;
        private List<Chain> chains = new List<Chain>();

        public System(string pdbid)
        {
            this.PDBID = pdbid;
        }

        public void AddChain(Chain chain)
        {
            this.chains.Add(chain);
        }

        public Chain GetChain(int chainID)
        {
            return this.chains[chainID];
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        public IEnumerator<Chain> GetEnumerator()
        {
            return chains.GetEnumerator();
        }


    }
}
