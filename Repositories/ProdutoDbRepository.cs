using System;
using LojaApi.Data;
using LojaApi.Entities;
using LojaApi.Repositories.Interfaces;

namespace LojaApi.Repositories;

public class ProdutoDbRepository : IProdutoRepository
{
    private readonly LojaContext _context;
    public ProdutoDbRepository(LojaContext context)
    {
        _context = context;
    }
    public List<Produto> ObterTodos()
    {
        return _context.Produtos.ToList();
    }
    public Produto? ObterPorId(int id)
    {
        return _context.Produtos.FirstOrDefault(c => c.Id == id);
    }
    public Produto Adicionar(Produto novoProduto)
    {
        // A regra de negócio da data de cadastro fica aqui, pois é uma responsabilidade de persistência.
        novoProduto.DataCadastro = DateTime.UtcNow;
        _context.Produtos.Add(novoProduto);
        _context.SaveChanges();
        return novoProduto;
    }
    public Produto? Atualizar(int id, Produto produtoAtualizado)
    {
        // O serviço já carregou e alterou a entidade. O repositório apenas persiste.
        _context.Produtos.Update(produtoAtualizado);
        _context.SaveChanges();
        return produtoAtualizado;
    }
    public bool Remover(int id)
    {
        var produtoParaDeletar = ObterPorId(id);
        if (produtoParaDeletar == null) return false;
        _context.Produtos.Remove(produtoParaDeletar);
        _context.SaveChanges();
        return true;
    }
}
