using CreditCardTransaction.Domain;
using CreditCardTransaction.Domain.Specification;
using CreditCardTransaction.Repository;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace CreditCardTransaction.Test
{
    public class ProdutoSpecificationTests
    {
        private IRepository<Produto> _produtoRepository;

        [SetUp]
        public void Setup()
        {
            _produtoRepository = new StaticListRepository<Produto>();
        }

        [Test]
        public void TestarAdicionarVariosEObterTodos()
        {
            _produtoRepository.ExcluirTudo();

            var produtos = new List<Produto> {
                new Produto
                {
                    Id = Guid.NewGuid(),
                    Nome = "Produto Teste 1",
                    Valor = 50
                },
                new Produto
                {
                    Id = Guid.NewGuid(),
                    Nome = "Produto Teste 2",
                    Valor = 50
                },
                new Produto
                {
                    Id = Guid.NewGuid(),
                    Nome = "Produto Teste 3",
                    Valor = 50
                },
            };

            _produtoRepository.AdicionarVarios(produtos);
            var produtosObtidos = _produtoRepository.ObterTodos();
            
            Assert.AreEqual(produtos.Count, produtosObtidos.Count);
        }

        [Test]
        public void TestarObterProdutoPorNome()
        {
            _produtoRepository.ExcluirTudo();

            var produto = new Produto
            {
                Id = Guid.NewGuid(),
                Nome = "Produto Teste",
                Valor = 50
            };

            _produtoRepository.Adicionar(produto);
            var produtoObtido = _produtoRepository.ObterUmPorCriterio(ProdutoSpecification.ObterPorNome(produto.Nome));

            Assert.AreEqual(produto.Id, produtoObtido.Id);
        }

        [Test]
        public void TestarObterProdutoPorValorMaximo()
        {
            _produtoRepository.ExcluirTudo();

            var produto = new Produto
            {
                Id = Guid.NewGuid(),
                Nome = "Produto Teste",
                Valor = 50
            };

            _produtoRepository.Adicionar(produto);
            var produtoObtido1 = _produtoRepository.ObterUmPorCriterio(ProdutoSpecification.ObterPorValorMaximo(produto.Valor - 1));
            var produtoObtido2 = _produtoRepository.ObterUmPorCriterio(ProdutoSpecification.ObterPorValorMaximo(produto.Valor));
            var produtoObtido3 = _produtoRepository.ObterUmPorCriterio(ProdutoSpecification.ObterPorValorMaximo(produto.Valor + 1));

            Assert.IsNull(produtoObtido1);
            Assert.AreEqual(produto.Id, produtoObtido2.Id);
            Assert.AreEqual(produto.Id, produtoObtido3.Id);
        }

        [Test]
        public void TestarObterProdutoPorValorMinimo()
        {
            _produtoRepository.ExcluirTudo();

            var produto = new Produto
            {
                Id = Guid.NewGuid(),
                Nome = "Produto Teste",
                Valor = 50
            };

            _produtoRepository.Adicionar(produto);
            var produtoObtido1 = _produtoRepository.ObterUmPorCriterio(ProdutoSpecification.ObterPorValorMinimo(produto.Valor - 1));
            var produtoObtido2 = _produtoRepository.ObterUmPorCriterio(ProdutoSpecification.ObterPorValorMinimo(produto.Valor));
            var produtoObtido3 = _produtoRepository.ObterUmPorCriterio(ProdutoSpecification.ObterPorValorMinimo(produto.Valor + 1));

            Assert.AreEqual(produto.Id, produtoObtido1.Id);
            Assert.AreEqual(produto.Id, produtoObtido2.Id);
            Assert.IsNull(produtoObtido3);
        }
    }
}