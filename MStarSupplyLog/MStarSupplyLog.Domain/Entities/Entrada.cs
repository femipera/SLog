using MStarSupplyLog.Domain.Validation;

namespace MStarSupplyLog.Domain.Entities
{
    public class Entrada : Movimentacao
    {
        public Entrada(int quantidade, DateTime dataHora, string local)
        {
            ValidateDomain(quantidade, dataHora, local);
        }

        public void Update(int quantidade, DateTime dataHora, string local, int mercadoriaId)
        {
            ValidateDomain(quantidade, dataHora, local);
            MercadoriaId = mercadoriaId;
        }

        private void ValidateDomain(int quantidade, DateTime dataHora, string local)
        {
            DomainExceptionValidadion.When(quantidade < 0, "Valor inválido para a Quantidade.");

            DomainExceptionValidadion.When(string.IsNullOrEmpty(local), "O campo Local é obrigatório.");

            DomainExceptionValidadion.When(local.Length < 3, "O campo Local deve conter no minimo 3 caracteres.");

            Quantidade = quantidade;
            DataHora = dataHora;
            Local = local;
        }
    }
}
