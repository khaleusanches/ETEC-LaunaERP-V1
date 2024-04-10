using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoReigns
{
    internal class Regions
    {
        int magia;
        int conflitos;
        int alimentos;
        int riquezas;
        Random r = new Random();
        public Regions(int magia, int conflitos, int alimentos, int riquezas)
        {
            this.magia = magia;
            this.conflitos = conflitos;
            this.alimentos = alimentos;
            this.riquezas = riquezas;
        }
        public void Mago()
        {
            int random = r.Next(0, 20);
            if (random == 0)
            {

            }
            else if (random < ((magia/10)*20)) { 
                
            }
            else if (random < ((conflitos/10)*20))
            {

            }
            else if (random < ((alimentos/10)*20)) {

            }


        }
    }
}
