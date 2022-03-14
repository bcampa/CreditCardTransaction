using CreditCardTransaction.Domain;
using CreditCardTransaction.Domain.Specification;
using CreditCardTransaction.Repository;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace CreditCardTransaction.Test
{
    public class ClienteSpecificationTest
    {
        private IRepository<Cliente> _clienteRepository;

        [SetUp]
        public void Setup()
        {
            _clienteRepository = new StaticListRepository<Cliente>();
        }

        [Test]
        public void TestarObterPorIdDoCartaoDeCredito()
        {
            _clienteRepository.ExcluirTudo();

            var cliente = new Cliente
            {
                Id = Guid.NewGuid(),
                Nome = "Cliente Teste"
            };

            cliente.CartoesDeCredito = new List<CartaoDeCredito>
            {
                new CartaoDeCredito
                {
                    Id = Guid.NewGuid(),
                },
                new CartaoDeCredito
                {
                    Id = Guid.NewGuid(),
                }
            };

            _clienteRepository.Adicionar(cliente);

            Cliente clienteObtido;
            foreach (var cartao in cliente.CartoesDeCredito) {
                clienteObtido = _clienteRepository.ObterUmPorCriterio(ClienteSpecification.ObterPorIdDoCartaoDeCredito(cartao.Id));
                Assert.AreEqual(cliente.Id, clienteObtido.Id);
            }

            clienteObtido = _clienteRepository.ObterUmPorCriterio(ClienteSpecification.ObterPorIdDoCartaoDeCredito(Guid.NewGuid()));
            Assert.IsNull(clienteObtido);
        }

        [Test]
        public void TestarObterPorNome()
        {
            _clienteRepository.ExcluirTudo();

            var cliente = new Cliente
            {
                Id = Guid.NewGuid(),
                Nome = "Cliente Teste"
            };

            _clienteRepository.Adicionar(cliente);

            Cliente clienteObitdo;
            
            clienteObitdo = _clienteRepository.ObterUmPorCriterio(ClienteSpecification.ObterPorNome(cliente.Nome));
            Assert.AreEqual(cliente.Id, clienteObitdo.Id);

            clienteObitdo = _clienteRepository.ObterUmPorCriterio(ClienteSpecification.ObterPorNome(cliente.Nome.Trim(cliente.Nome[0])));
            Assert.IsNull(clienteObitdo);
        }

        [Test]
        public void TestarObterPorParteDoNome()
        {
            _clienteRepository.ExcluirTudo();

            var cliente = new Cliente
            {
                Id = Guid.NewGuid(),
                Nome = "Cliente Teste"
            };

            _clienteRepository.Adicionar(cliente);

            Cliente clienteObitdo;

            clienteObitdo = _clienteRepository.ObterUmPorCriterio(ClienteSpecification.ObterPorParteDoNome(cliente.Nome.Substring(1, cliente.Nome.Length - 1).ToLower()));
            Assert.AreEqual(cliente.Id, clienteObitdo.Id);

            clienteObitdo = _clienteRepository.ObterUmPorCriterio(ClienteSpecification.ObterPorParteDoNome("Nome não contido"));
            Assert.IsNull(clienteObitdo);
        }
    }
}
