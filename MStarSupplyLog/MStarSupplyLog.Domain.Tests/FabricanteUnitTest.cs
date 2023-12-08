using FluentAssertions;
using MStarSupplyLog.Domain.Entities;

namespace MStarSupplyLog.Domain.Tests
{
    public class FabricanteUnitTest
    {
        [Fact]
        public void CreateFabricante_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Fabricante("Nome Fabricante");
            action.Should()
                .NotThrow<MStarSupplyLog.Domain.Validation.DomainExceptionValidadion>();

        }

        [Fact]
        public void CreateFabricante_ShortValueName_DomainExceptionShortName()
        {
            Action action = () => new Fabricante("N");
            action.Should()
                .Throw<MStarSupplyLog.Domain.Validation.DomainExceptionValidadion>()
                .WithMessage("O Campo nome deve conter no minimo 2 caracteres.");

        }

        [Fact]
        public void CreateFabricante_EmptyValueName_DomainExceptionEmptyName()
        {
            Action action = () => new Fabricante("");
            action.Should()
                .Throw<MStarSupplyLog.Domain.Validation.DomainExceptionValidadion>()
                .WithMessage("O Campo nome é obrigatório");

        }

        [Fact]
        public void CreateFabricante_NullValueName_DomainExceptionNullName()
        {
            Action action = () => new Fabricante(null);
            action.Should()
                .Throw<MStarSupplyLog.Domain.Validation.DomainExceptionValidadion>()
                .WithMessage("O Campo nome é obrigatório");

        }
    }
}