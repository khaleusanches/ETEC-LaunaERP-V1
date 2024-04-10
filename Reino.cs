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
        int populacao;  // in random 10-30
        int total_soldados;  // in 1/10 populacao
        int alimentos;      

        int slot1;
        int slot2;
        int slot3;

        StreamReader leitor;
        StreamWriter salvar;
        Random r = new Random();
        Regions region;
        
        public void criarReino(string nome_reino, int region_id, string nome_personagem)
        {
            this.nome_reino = nome_reino;
            this.region_id = region_id;
            this.nome_personagem = nome_personagem;
            this.level = 1;
            this.populacao = r.Next(10, 30);
            this.total_soldados = populacao/10;
            this.alimentos = 100;
            this.slot1 = 0;
            this.slot2 = 0;
            this.slot3 = 0;
        }
        public void Carregando() //Carregar informações do save no objeto
        {
            leitor = new StreamReader("Region.txt");
            Dictionary<string, string> linhas = new Dictionary<string, string>();
            for (int i = 0; i < 10; i++)
            {
                linhas.Add(leitor.ReadLine(), leitor.ReadLine());
            }
            leitor.Close();
            this.nome_reino = linhas["Nome:"];
            this.region_id = int.Parse(linhas["Region:"]);
            this.nome_personagem = linhas["NomePersonagem:"];
            this.level = int.Parse(linhas["Level:"]);
            this.populacao = int.Parse(linhas["População:"]);
            this.total_soldados = int.Parse(linhas["Soldados:"]);
            this.alimentos = int.Parse(linhas["Alimentos:"]);
            this.slot1 = int.Parse(linhas["Slot 1:"]);
            this.slot2 = int.Parse(linhas["Slot 2:"]);
            this.slot3 = int.Parse(linhas["Slot 3:"]);
        }
        public void Salvando() //Salvar informações do objeto no save
        {
            salvar = new StreamWriter("Region.txt");
            salvar.WriteLine("Nome:");
            salvar.WriteLine(this.nome_reino);

            salvar.WriteLine("Region:");
            salvar.WriteLine(this.region_id);

            salvar.WriteLine("NomePersonagem:");
            salvar.WriteLine(this.nome_personagem);

            salvar.WriteLine("Level:");
            salvar.WriteLine(this.level);

            salvar.WriteLine("População:");
            salvar.WriteLine(this.populacao);

            salvar.WriteLine("Soldados:");
            salvar.WriteLine(this.total_soldados);

            salvar.WriteLine("Alimentos:");
            salvar.WriteLine(this.alimentos);

            salvar.WriteLine("Slot 1:");
            salvar.WriteLine(this.slot1);

            salvar.WriteLine("Slot 2:");
            salvar.WriteLine(this.slot2);

            salvar.WriteLine("Slot 3:");
            salvar.WriteLine(this.slot3);
            salvar.Close();
        }
        public void Recarregar()
        {
            Salvando();
            Carregando();
        }
        public void CriandoRegion()
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
