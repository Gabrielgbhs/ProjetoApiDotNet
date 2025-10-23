using System;
using LojaApi.Entities;
using LojaApi.Infra.Repositories.Interfaces;

namespace LojaApi.Repositories;

public class ProdutoRepository : IProdutoRepository
{
    private readonly List<Produto> _produtos = new List<Produto>
    {
        new Produto{ Id=1, Nome= "Teclado", Valor= 200.0m, Descricao= "Teclado Mecanico", Estoque= 20, Ativo = true },
        new Produto{ Id=2, Nome= "Processador", Valor= 300.0m, Descricao= "Processador Amd Ryzen5500u", Estoque= 5, Ativo = true  },
        new Produto{ Id=3, Nome= "Mémoria ram", Valor= 100.0m, Descricao= "Mémoria ram de 8gb", Estoque= 4, Ativo = true  },
        new Produto{ Id=4, Nome= "Mouse pad", Valor= 30.0m, Descricao= "Mouse pad 30x30cm", Estoque= 40, Ativo = true  }

    };

    private int _nextId = 5;

    public List<Produto> ObterTodos() => _produtos;
    public Produto? ObterPorId(int id) => _produtos.FirstOrDefault(p => p.Id == id);
    public Produto Adicionar(Produto novoProduto) {
        novoProduto.Id = _nextId++;
        _produtos.Add(novoProduto);
        return novoProduto;
    }
    public Produto? Atualizar(int id, Produto produtoAtualizado) {
        var produtoExistente = ObterPorId(id);
        if (produtoExistente == null)
        {
            return null;
        }

        produtoExistente.Nome = produtoAtualizado.Nome;
        produtoExistente.Descricao = produtoAtualizado.Descricao;
        produtoExistente.Valor = produtoAtualizado.Valor;
        produtoExistente.Estoque = produtoAtualizado.Estoque;
        produtoExistente.Ativo = produtoAtualizado.Ativo;
        return produtoExistente;
    }

    public bool Remover(int id) {
        var produtoParaDeletar = ObterPorId(id);
        if (produtoParaDeletar == null)
        {
            return false;
        }

        _produtos.Remove(produtoParaDeletar);
        return true;
    }
}
