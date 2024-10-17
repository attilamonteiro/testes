using System.Collections.Generic;
using System.Linq;
using testes.Models;

namespace testes.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly List<Produto> _produtos = new List<Produto>();

        public IEnumerable<Produto> GetAll()
        {
            return _produtos;
        }

        public Produto GetById(int id)
        {
            return _produtos.FirstOrDefault(p => p.Id == id);
        }

        public void Add(Produto produto)
        {
            produto.Id = _produtos.Count + 1; // Simplesmente gerando um Id incremental
            _produtos.Add(produto);
        }

        public void Update(Produto produto)
        {
            var existingProduto = GetById(produto.Id);
            if (existingProduto != null)
            {
                existingProduto.Nome = produto.Nome;
                existingProduto.Preco = produto.Preco;
            }
        }

        public void Delete(int id)
        {
            var produto = GetById(id);
            if (produto != null)
            {
                _produtos.Remove(produto);
            }
        }
    }
}
