using MStarSupplyLog.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MStarSupplyLog.Domain.Entities
{
    public class TipoMercadoria : Entity
    {
        public string Nome { get; private set; }
        public ICollection<Mercadoria> Mercadorias { get; set; }

        public TipoMercadoria(string nome) 
        {
            ValidateDomain(nome);
        }

        public void Update(string nome)
        {
            ValidateDomain(nome);
        }

        private void ValidateDomain(string nome) 
        {
            DomainExceptionValidadion.When(string.IsNullOrEmpty(nome),
                "O Campo nome é obrigatório");

            DomainExceptionValidadion.When(nome.Length < 4,
                "O Campo nome deve conter no minimo 4 caracteres.");

            Nome = nome;
        }
    }
}
