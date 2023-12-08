using MStarSupplyLog.Domain.Validation;

namespace MStarSupplyLog.Domain.Entities
{
    public class Fabricante : Entity
    {
        public string Nome { get; private set; }
        public ICollection<Mercadoria> Mercadorias { get; set; }

        public Fabricante(string nome)
        {
            ValidateDomain(nome);
        }

        public void Update(string nome)
        {
            ValidateDomain(nome);
        }
        private void ValidateDomain(string nome)
        {
            DomainExceptionValidadion.When(string.IsNullOrEmpty(nome), "O Campo nome é obrigatório");

            DomainExceptionValidadion.When(nome.Length < 2,"O Campo nome deve conter no minimo 2 caracteres.");

            Nome = nome;
        }
    }
}
