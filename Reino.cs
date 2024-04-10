using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoReigns
{
    internal class Reino
    {
        string nome_reino;
        int region_id;
        string nome_personagem;


        int level;  //in 1
        int poulacao;  // in random 10-30
        int total_soldados;  // in 1/10 populacao
        int alimentos;      

        int slot1;
        int slot2;
        int slot3;

        StreamReader leitor = new StreamReader("Region.txt");
        Regions region;
        public void lendo()
        {
            string linha = leitor.ReadLine();
            switch (linha)
            {
                case "0":
                    region = new Regions(8, 8, 6, 6);
                    break;
                case "1":
                    region = new Regions(3, 4, 2, 7);
                    break;
                case "2":
                    region = new Regions(4, 4, 4, 4);
                    break;
                case "3":
                    region = new Regions(6, 4, 7, 2);
                    break;
            }

        }

    }
}
