using System; // sem a biblioteca system o environment esava dando erro


namespace tvseries
{
    public class Series : EntidadeBase
    {
      

        // Atributos
        private Genero Genero{get;set;}//Genero é um enum
        
        private string Titulo{get;set;}

        private string Descricao{get; set;}

        private int Ano{get; set;}

        private bool Excluido{get;set;}

        //Metodos
        public Series(int id, Genero genero,string titulo,string descricao,int ano)
        {
            this.Id=id;
            this.Genero=genero;
            this.Titulo=titulo;
            this.Descricao=descricao;
            this.Ano=ano;
            this.Excluido=false;
        }
        public override string ToString()
        {
            string retorno="";
            retorno += "Gênero: "+this.Genero + Environment.NewLine;//Environment.NewLine cria uma nova linha independente do sistema operacional, ele precisa da biblioteca system
            retorno += "Título: "+this.Titulo + Environment.NewLine;
            retorno += "Descrição: "+this.Descricao + Environment.NewLine;
            retorno += "Ano de Início: "+this.Ano + Environment.NewLine; 
            retorno += "Serie excluida"+this.Excluido;        
            
            
            return retorno;
        }
        public void excluir()
        {
            this.Excluido=true;
        }
        public string retornaTitulo()
        {
            return this.Titulo;
        }
        public int retornaId()
        {
            return this.Id;
        }
        public bool retornaExcluido()
        {
            return this.Excluido;
        }
    }
}