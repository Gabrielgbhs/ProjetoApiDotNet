using System;
using LojaApi.Entities;
using LojaApi.Infra.Repositories.Interfaces;
using LojaApi.Services.Interfaces;

namespace LojaApi.Services;

public class CategoriaService : ICategoriaService
{
    private readonly ICategoriaRepository _categoriaRepository;

    public CategoriaService(ICategoriaRepository categoriaRepository)
    {
        _categoriaRepository = categoriaRepository;
    }

    public List<Categoria> ObterTodos()
    {
        // Regra: Não exibir clientes inativos.
        return _categoriaRepository.ObterTodos().Where(c => c.Ativo).ToList();
    }
    public Categoria? ObterPorId(int id)
    {
        return _categoriaRepository.ObterPorId(id);
    }

    public Categoria Adicionar(Categoria novaCategoria)
    {
        novaCategoria.Descricao = novaCategoria.Descricao.ToUpper();
        novaCategoria.Ativo = true;
        return _categoriaRepository.Adicionar(novaCategoria);
    }
    public Categoria? Atualizar(int id, Categoria categoriaAtualizada)
    {
        if (id != categoriaAtualizada.Id) return null;
        return _categoriaRepository.Atualizar(id, categoriaAtualizada);
    }

    public bool Remover(int id)
    {
        var categoria = _categoriaRepository.ObterPorId(id);
        if (categoria != null)
        {
            categoria.Ativo = false;
            return _categoriaRepository.Atualizar(id, categoria) != null;
        }
        return false;
    }
}
