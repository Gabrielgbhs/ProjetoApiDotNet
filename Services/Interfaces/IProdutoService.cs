using System;
using LojaApi.Entities;

namespace LojaApi.Services.Interfaces;

public interface IProdutoService
{
    List<Produto> ObterTodos();
    Produto? ObterPorId(int id);
    Produto Adicionar(Produto novoProduto);
    Produto? Atualizar(int id, Produto ProdutoAtualizado);
    bool Remover(int id);
}
/*
public List<Produto> ObterTodos()
    {
        return _produtoRepository.ObterTodos().Where(p => p.Ativo).ToList();
    }

    public Produto? ObterPorId(int id)
    {
        return _produtoRepository.ObterPorId(id);
    }

    public Produto Adicionar(Produto novoProduto)
    {
        novoProduto.Nome = novoProduto.Nome.ToUpper();
        novoProduto.Descricao = novoProduto.Descricao.ToUpper();
        return _produtoRepository.Adicionar(novoProduto);
    }

    public Produto? Atualizar(int id, Produto produtoAtualizado)
    {
        if (id != produtoAtualizado.Id)
        {
            return null;
        }
        return _produtoRepository.Atualizar(id, produtoAtualizado);
    }

    public bool Remover(int id)
    {
        var produto = _produtoRepository.ObterPorId(id);
        if (produto != null)
        {
            produto.Ativo = false;
            return _produtoRepository.Atualizar(id, produto) != null;
        }
        return false;
    }
*/