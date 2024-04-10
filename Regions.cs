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

        public void evento()
        {
            for(int i = 0; i < magia; i++)
            {
                
            }
        }
    }
}
