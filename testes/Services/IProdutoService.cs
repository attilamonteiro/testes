using System.Collections.Generic;
using testes.Models;

namespace testes.Services
{
    public interface IProdutoService
    {
        IEnumerable<Produto> GetAll();
        Produto GetById(int id);
        void Add(Produto produto);
        void Update(Produto produto);
        void Delete(int id);
    }
}
