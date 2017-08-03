using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace PDBVR
{
    class FileReader
    {
        private List<string> all_lines = new List<string>();
        public FileReader()
        {
            OpenFile();
        }

        private void OpenFile()
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.InitialDirectory = "C:\\Users\\gavin\\Downloads";
            ofd.Filter = "pdb files (*.pdb)|*.pdb";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                StreamReader pdb_file = new StreamReader(ofd.OpenFile());
                string line = "";
                if (pdb_file != null)
                {
                    while ((line = pdb_file.ReadLine()) != null)
                    {
                        this.all_lines.Add(line);
                    }
                }
            }
            System system = new System(ofd.FileName);

            CatalogeManager cat = new CatalogeManager(system);
            var watch = Stopwatch.StartNew();
            cat.ExtractAtomLines(all_lines);
            watch.Stop();
            Console.WriteLine(watch.Elapsed);
            Console.ReadLine();
        }
    }
}
