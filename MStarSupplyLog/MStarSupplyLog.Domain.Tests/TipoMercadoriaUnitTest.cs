using FluentAssertions;
using MStarSupplyLog.Domain.Entities;

namespace MStarSupplyLog.Domain.Tests
{
    public class TipoMercadoriaUnitTest
    {
        [Fact]
        public void CreateTipoMercadoria_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new TipoMercadoria("Nome TipoMercadoria");
            action.Should()
                .NotThrow<MStarSupplyLog.Domain.Validation.DomainExceptionValidadion>();

        }

        [Fact]
        public void CreateTipoMercadoria_ShortValueName_DomainExceptionShortName()
        {
            Action action = () => new TipoMercadoria("Nom");
            action.Should()
                .Throw<MStarSupplyLog.Domain.Validation.DomainExceptionValidadion>()
                .WithMessage("O Campo nome deve conter no minimo 4 caracteres.");

        }

        [Fact]
        public void CreateTipoMercadoria_EmptyValueName_DomainExceptionEmptyName()
        {
            Action action = () => new TipoMercadoria("");
            action.Should()
                .Throw<MStarSupplyLog.Domain.Validation.DomainExceptionValidadion>()
                .WithMessage("O Campo nome é obrigatório");

        }

        [Fact]
        public void CreateTipoMercadoria_NullValueName_DomainExceptionNullName()
        {
            Action action = () => new TipoMercadoria(null);
            action.Should()
                .Throw<MStarSupplyLog.Domain.Validation.DomainExceptionValidadion>()
                .WithMessage("O Campo nome é obrigatório");

        }
    }
}