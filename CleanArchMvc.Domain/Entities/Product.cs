using CleanArchMvc.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Entities
{
    public class Product : Entity
    {
        public string Name { get; private set; }

        public string Description { get; private set; }

        public decimal Price { get; private set; }

        public int Stock { get; private set; }

        public string Image { get; private set; }

        #region nav props

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        #endregion

        public Product(string name, string description, decimal price, int stock, string image)
        {
            ValidateDomain(name, description, price, stock, image);

            SetDomain(name, description, price, stock, image);
        }

        public Product(int id, string name, string description, decimal price, int stock, string image)
        {
            ValidateDomain(name, description, price, stock, image, id);

            SetDomain(name, description, price, stock, image);
            Id = id;
        }

        private void ValidateDomain(string name, string description, decimal price, int stock, string image, int id = 0)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                "Invalid Name. Name is required");

            DomainExceptionValidation.When(name.Length < 3,
                "Invalid Name, too short, minimum 3 characters");

            DomainExceptionValidation.When(string.IsNullOrEmpty(description),
                "Invalid Description. Description is required");

            DomainExceptionValidation.When(description.Length < 5,
                "Invalid Description, too short, minimum 5 characters");

            DomainExceptionValidation.When(stock < 0,
                "Invalid Stock value");

            DomainExceptionValidation.When(image?.Length > 250,
                "Invalid Image name, too long, maximum 250 characters");

            DomainExceptionValidation.When(id < 0,
                "Invalid Id value");
        }

        private void SetDomain(string name, string description, decimal price, int stock, string image)
        {
            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            Image = image;
        }

        public void Update(string name, string description, decimal price, int stock, string image, int categoryId)
        {
            SetDomain(name, description, price, stock, image);
            CategoryId = categoryId;
        }
    }
}
