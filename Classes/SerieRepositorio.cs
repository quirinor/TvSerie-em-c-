
using System;
using System.Collections.Generic;
using tvseries.Interfaces;

namespace tvseries
{
    public class SerieRepositorio : Irepositorio<Series>
    {
        private List<Series> ListaSeries = new List<Series>();
        public void Atualiza(int id, Series entidade)
        {
            ListaSeries[id]=entidade;
        }

        public void Exclui(int id)
        {
            ListaSeries[id].excluir();
        }

        public void Insere(Series entidade)
        {
            ListaSeries.Add(entidade);
        }

        public List<Series> Lista()
        {
            return ListaSeries;
        }

        public int ProximoId()
        {
            return ListaSeries.Count;
        }

        public Series RetornaPorId(int id)
        {
            return ListaSeries[id];
        }
    }
}