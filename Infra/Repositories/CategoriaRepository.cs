using System;
using LojaApi.Entities;
using LojaApi.Infra.Repositories.Interfaces;

namespace LojaApi.Repositories;

public class CategoriaRepository :ICategoriaRepository
{
    private readonly List<Categoria> _categorias = new List<Categoria>
    {
        new Categoria { Id = 1, Descricao = "Informatica", Ativo = true},
        new Categoria { Id = 2, Descricao = "Brinquedos", Ativo = true},
        new Categoria { Id = 3, Descricao = "Decoração", Ativo = true},
    };

    private int _nextId = 4;

    public List<Categoria> ObterTodos() => _categorias;

    public Categoria? ObterPorId(int id) => _categorias.FirstOrDefault(c => c.Id == id);

    public Categoria Adicionar(Categoria novaCategoria)
    {
        novaCategoria.Id = _nextId++;
        _categorias.Add(novaCategoria);
        return novaCategoria;
    }

    public Categoria? Atualizar(int id, Categoria categoriaAtualizada)
    {
        var categoriaExistente = ObterPorId(id);
        if (categoriaExistente == null) return null;

        categoriaExistente.Descricao = categoriaAtualizada.Descricao;
        categoriaExistente.Ativo = categoriaAtualizada.Ativo;
        return categoriaExistente;
    }

    public bool Remover(int id)
    {
        var categoriaParaDeletar = ObterPorId(id);
        if (categoriaParaDeletar == null) return false;

        _categorias.Remove(categoriaParaDeletar);
        return true;
    }
}
