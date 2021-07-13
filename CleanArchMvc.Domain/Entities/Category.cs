using CleanArchMvc.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Category : Entity
    {
        public string Name { get; private set; }

        public Category(string name)
        {
            ValidateDomain(name);

            Name = name;
        }

        public Category(int id, string name)
        {
            ValidateDomain(id);
            ValidateDomain(name);

            Id = id;
            Name = name;
        }

        #region nav props

        public ICollection<Product> Products { get; set; }

        #endregion
        public void Update(string name)
        {
            ValidateDomain(name);

            Name = name;
        }

        private void ValidateDomain(int id)
        {
            DomainExceptionValidation.When(id < 0,
                "Invalid id value.");
        }

        private void ValidateDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                "Invalid name. Name is required");

            DomainExceptionValidation.When(name.Length < 3,
                "Invalid name, too short, minimum 3 characters");
        }

    }
}
