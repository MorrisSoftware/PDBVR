using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace PDBVR
{
    class CatalogeManager
    {
        private List<string> atomcoords = new List<string>();
        public System system;
        public CatalogeManager(System system)
        {
            this.system = system;
        }

        public void ExtractAtomLines(List<string> pdb_file_data)
        {
            foreach (string line in pdb_file_data)
            {
                if (line != null)
                {
                    if (line.Substring(0, 6) == "ATOM  ")
                    {
                        this.atomcoords.Add(line);
                    }
                }
            }
            BuildCompositeObjectModel(atomcoords);
        }

        public void BuildCompositeObjectModel(List<string> atomscoords)
        {
            string chainID = atomcoords[0].Substring(21, 1);
            int resNum = int.Parse(atomcoords[0].Substring(22, 4));
            string resname = atomcoords[0].Substring(17, 3);
            //start ball rolling
            int chainindex = 0;
            int resindex = 0;
            system.AddChain(new Chain(chainID));
            system.GetChain(chainindex).AddRes(new Residue(resname, resNum));

            foreach (string line in atomcoords)
            {
                if (line.Substring(21, 1) != chainID)
                {
                    chainID = line.Substring(21, 1);

                    chainindex += 1;
                    resindex = 0;

                    resname = line.Substring(17, 3);
                    resNum = int.Parse(line.Substring(22, 4));

                    system.AddChain(new Chain(chainID));
                    system.GetChain(chainindex).AddRes(new Residue(resname, resNum));
                    system.GetChain(chainindex).GetRes(resindex).AddAtom(new Atom(line.Substring(12, 4), float.Parse(line.Substring(30, 8)), float.Parse(line.Substring(38, 8)), float.Parse(line.Substring(46, 8))));
                }
                else
                {

                    if (line.Substring(17, 3) != resname || int.Parse(line.Substring(22, 4)) != resNum)
                    {
                        resname = line.Substring(17, 3);
                        resNum = int.Parse(line.Substring(22, 4));
                        resindex += 1;
                        system.GetChain(chainindex).AddRes(new Residue(resname, resNum));
                        system.GetChain(chainindex).GetRes(resindex).AddAtom(new Atom(line.Substring(12, 4), float.Parse(line.Substring(30, 8)), float.Parse(line.Substring(38, 8)), float.Parse(line.Substring(46, 8))));
                    }
                    else
                    {
                        system.GetChain(chainindex).GetRes(resindex).AddAtom(new Atom(line.Substring(12, 4), float.Parse(line.Substring(30, 8)), float.Parse(line.Substring(38, 8)), float.Parse(line.Substring(46, 8))));
                    }

                }
            }

            StructureBuilder structbuild = new StructureBuilder();
            structbuild.BuildStruct(system);
        }
    }
}
