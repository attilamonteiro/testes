using System.Collections.Generic;
using testes.Models;
using testes.Repositories;

namespace testes.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public IEnumerable<Produto> GetAll()
        {
            return _produtoRepository.GetAll();
        }

        public Produto GetById(int id)
        {
            return _produtoRepository.GetById(id);
        }

        public void Add(Produto produto)
        {
            _produtoRepository.Add(produto);
        }

        public void Update(Produto produto)
        {
            _produtoRepository.Update(produto);
        }

        public void Delete(int id)
        {
            _produtoRepository.Delete(id);
        }
    }
}
