using NUnit.Framework;
using System.Collections.Generic;
using Wirtualnik.Data.Models;

namespace Wirtualnik.ArithmeticExpressionParser.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Product prod = new Product
            {
                Category = new Category
                {
                    Name = "cpu",
                }
            };
            Cart cart = new Cart
            {
                Products = new List<Product>
                {
                    prod,
                    new Product
                    {
                        Category = new Category
                        {
                            Name = "ram",
                        }
                    }
                }
            };

            var valueMember = new ValueMember("{ Products.where( [ { Category.Name } = { \"cpu\" } ] ).first }".Replace(" ", ""), cart);
            var res = valueMember.Evaluate();

            Assert.AreEqual(prod, res);
        }

        [Test]
        public void Test2()
        {
            Product prod = new Product
            {
                Category = new Category
                {
                    Name = "cpu",
                }
            };
            Cart cart = new Cart
            {
                Products = new List<Product>
                {
                    prod,
                    new Product
                    {
                        Category = new Category
                        {
                            Name = "ram",
                        }
                    }
                }
            };

            var valueMember = new ValueMember("{ Products.count }".Replace(" ", ""), cart);
            var res = valueMember.Evaluate();

            Assert.AreEqual(2, res);
        }

        [Test]
        public void Test3()
        {
            Product prod = new Product
            {
                Category = new Category
                {
                    Name = "m2",
                },
                ProductProperties = new List<ProductProperty>
                {
                    new ProductProperty
                    {
                        CategoryProperty = new CategoryProperty
                        {
                            Name = "interface"
                        },
                        Value = "sata"
                    }
                }
            };

            Product prod2 = new Product
            {
                Category = new Category
                {
                    Name = "m2",
                },
                ProductProperties = new List<ProductProperty>
                {
                    new ProductProperty
                    {
                        CategoryProperty = new CategoryProperty
                        {
                            Name = "interface"
                        },
                        Value = "sata"
                    }
                }
            };

            Cart cart = new Cart
            {
                Products = new List<Product>
                {
                    new Product
                    {
                        Category = new Category
                        {
                            Name = "cpu",
                        }
                    },
                    new Product
                    {
                        Category = new Category
                        {
                            Name = "ram",
                        }
                    },
                    prod,
                    prod2
                }
            };

            var valueMember =
                new ValueMember(
                    "{ Products.where( [ { Category.Name } = { \"m2\" } ] ).where( [ { ProductProperties.where( [ { CategoryProperty.Name } = { \"interface\" } ] ).first.Value } = { \"sata\" } ] ).count }".Replace(" ", ""),
                    cart);
            var res = valueMember.Evaluate();

            Assert.AreEqual(2, res);
        }

        [Test]
        public void Test4()
        {
            Product cpu = new Product
            {
                Category = new Category
                {
                    Name = "cpu",
                },
                ProductProperties = new List<ProductProperty>
                {
                    new ProductProperty
                    {
                        CategoryProperty = new CategoryProperty
                        {
                            Name = "socket"
                        },
                        Value = "AM4"
                    }
                }
            };

            Product motherboard = new Product
            {
                Category = new Category
                {
                    Name = "motherboard",
                },
                ProductProperties = new List<ProductProperty>
                {
                    new ProductProperty
                    {
                        CategoryProperty = new CategoryProperty
                        {
                            Name = "socket"
                        },
                        Value = "AM4"
                    }
                }
            };


            Cart cart = new Cart
            {
                Products = new List<Product>
                {
                    cpu,
                    motherboard
                }
            };

            var valueMember = new Expression("[ { Products.where( [ { Category.Name } = { \"cpu\" } ] ).first.ProductProperties.where( [ { CategoryProperty.Name } = { \" socket \" } ] ).first.Value } = { Products.where( [ { Category.Name } = { \"motherboard\" } ] ).first.ProductProperties.where( [ { CategoryProperty.Name } = { \" socket \" } ] ).first.Value }]".Replace(" ", ""), cart);
            var res = valueMember.Evaluate();

            Assert.AreEqual(true, res);
        }
    }
}
