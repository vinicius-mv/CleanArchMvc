using CleanArchMvc.Domain.Entities;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CleanArchMvc.Domain.Tests
{
    public class ProducUnitTest1
    {
        [Fact]
        public void CreateProduct_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Product(1, "Product Name", "Procduct Description", 9.99m, 99, "product.img");
            action.Should().NotThrow<Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateProduct_NegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Product(-1, "Product Name", "Procduct Description", 9.99m, 99, "product.img");
            action.Should().Throw<Validation.DomainExceptionValidation>()
                    .WithMessage("Invalid Id value");
        }

        [Fact]
        public void CreateProduct_ShortNameValue_DomainExceptionShortName()
        {
            Action action = () => new Product(1, "Pr", "Procduct Description", 9.99m, 99, "product.img");
            action.Should().Throw<Validation.DomainExceptionValidation>()
                    .WithMessage("Invalid Name, too short, minimum 3 characters");
        }

        [Fact]
        public void CreateProduct_MissingNameValue_DomainExceptionRequiredName()
        {
            Action action = () => new Product(1, "", "Procduct Description", 9.99m, 99, "product.img");
            action.Should().Throw<Validation.DomainExceptionValidation>()
                    .WithMessage("Invalid Name. Name is required");
        }

        [Fact]
        public void CreateProduct_WithNullNameValue_DomainExceptionInvalidName()
        {
            Action action = () => new Product(1, null, "Procduct Description", 9.99m, 99, "product.img");
            action.Should().Throw<Validation.DomainExceptionValidation>()
                    .WithMessage("Invalid Name. Name is required");
        }

        [Fact]
        public void CreateProduct_LongImageName_DomainExceptionLongImnage()
        {
            var sb = new StringBuilder();
            for (int i = 0; i < 251; i++)
                sb = sb.Append('a');

            Action action = () => new Product(1, "Product Name", "Procduct Description", 9.99m, 99, sb.ToString());
            action.Should().Throw<Validation.DomainExceptionValidation>()
                    .WithMessage("Invalid Image name, too long, maximum 250 characters");
        }

        [Fact]
        public void CreateProduct_NullImageName_NoException()
        {
            Action action = () => new Product(1, "Product Name", "Procduct Description", 9.99m, 99, null);
            action.Should().NotThrow<Validation.DomainExceptionValidation>();
            action.Should().NotThrow<NullReferenceException>();
        }

        [Theory]
        [InlineData(-5)]
        [InlineData(-1)]
        public void CreateProduct_InvalidStock_DomainExceptionNegativeStock(int value)
        {
            Action action = () => new Product(1, "Product Name", "Procduct Description", 9.99m, -1, "product.img");
            action.Should().Throw<Validation.DomainExceptionValidation>()
                    .WithMessage("Invalid stock value");
        }
    }
}
