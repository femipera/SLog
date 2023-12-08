using FluentAssertions;
using MStarSupplyLog.Domain.Entities;

namespace MStarSupplyLog.Domain.Tests
{
    public class MercadoriaUnitTest
    {
        [Fact]
        public void CreateMercadoria_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Mercadoria("Nome da mercadoria", 1, "Descrição da mercadoria" );
            action.Should()
                .NotThrow<MStarSupplyLog.Domain.Validation.DomainExceptionValidadion>();

        }

        [Fact]
        public void CreateMercadoria_ShortValueName_DomainExceptionShortName()
        {
            Action action = () => new Mercadoria("Nom", 1, "Descrição da mercadoria");
            action.Should()
                .Throw<MStarSupplyLog.Domain.Validation.DomainExceptionValidadion>()
                .WithMessage("O Campo nome deve conter no minimo 4 caracteres.");

        }

        [Fact]
        public void CreateMercadoria_EmptyValueName_DomainExceptionEmptyName()
        {
            Action action = () => new Mercadoria("", 1, "Descrição da mercadoria");
            action.Should()
                .Throw<MStarSupplyLog.Domain.Validation.DomainExceptionValidadion>()
                .WithMessage("O Campo nome é obrigatório");

        }

        [Fact]
        public void CreateMercadoria_NullValueName_DomainExceptionNullName()
        {
            Action action = () => new Mercadoria(null, 1, "Descrição da mercadoria");
            action.Should()
                .Throw<MStarSupplyLog.Domain.Validation.DomainExceptionValidadion>()
                .WithMessage("O Campo nome é obrigatório");

        }
        public void CreateMercadoria_ShortValueDescricao_DomainExceptionShortDescricao()
        {
            Action action = () => new Mercadoria("Nome da mercadoria", 1, "Descr");
            action.Should()
                .Throw<MStarSupplyLog.Domain.Validation.DomainExceptionValidadion>()
                .WithMessage("O Campo descrição deve conter no minimo 6 caracteres.");

        }

        [Fact]
        public void CreateMercadoria_EmptyValueDescricao_DomainExceptionEmptyDescricao()
        {
            Action action = () => new Mercadoria("Nome da mercadoria", 1, "");
            action.Should()
                .Throw<MStarSupplyLog.Domain.Validation.DomainExceptionValidadion>()
                .WithMessage("O Campo descrição é obrigatório");

        }

        [Fact]
        public void CreateMercadoria_NullValueDescricao_DomainExceptionNullDescricao()
        {
            Action action = () => new Mercadoria("Nome da mercadoria", 1, null);
            action.Should()
                .Throw<MStarSupplyLog.Domain.Validation.DomainExceptionValidadion>()
                .WithMessage("O Campo descrição é obrigatório");

        }

        [Theory]
        [InlineData(-2)]
        public void CreateMercadoria_InvalidValueNumeroRegistro_DomainExceptionNegativeNumeroRegistro(int value)
        {
            Action action = () => new Mercadoria("Nome da mercadoria", value, "Descrição da mercadoria");
            action.Should()
                .Throw<MStarSupplyLog.Domain.Validation.DomainExceptionValidadion>()
                .WithMessage("Valor inválido para Número do Registro.");

        }

    }
}
