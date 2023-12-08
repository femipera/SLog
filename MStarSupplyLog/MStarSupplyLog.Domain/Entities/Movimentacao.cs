using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MStarSupplyLog.Domain.Entities
{
    public abstract class Movimentacao : Entity
    {
        public int Quantidade { get; protected set; }
        public DateTime DataHora { get; protected set; }
        public string Local { get; protected set; }
        public int MercadoriaId { get; protected set; }
        public Mercadoria Mercadoria { get; protected set; }
    }
}
