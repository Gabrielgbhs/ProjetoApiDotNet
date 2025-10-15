using System;
using LojaApi.Data;
using LojaApi.Entities;
using LojaApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LojaApi.Repositories;

public class CategoriaDbRepository : ICategoriaRepository
{
    private readonly LojaContext _context;
    public CategoriaDbRepository(LojaContext context)
    {
        _context = context;
    }
    public List<Categoria> ObterTodos()
    {
        return _context.Categorias.Include(c => c.Produtos).ToList();
    }
    public Categoria? ObterPorId(int id)
    {
        return _context.Categorias.Include(c => c.Produtos).FirstOrDefault(c => c.Id == id);
    }
    public Categoria Adicionar(Categoria novaCategoria)
    {
        // A regra de negócio da data de cadastro fica aqui, pois é uma responsabilidade de persistência.
        novaCategoria.DataCadastro = DateTime.UtcNow;
        _context.Categorias.Add(novaCategoria);
        _context.SaveChanges();
        return novaCategoria;
    }
    public Categoria? Atualizar(int id, Categoria categoriaAtualizada)
    {
        // O serviço já carregou e alterou a entidade. O repositório apenas persiste.
        _context.Categorias.Update(categoriaAtualizada);
        _context.SaveChanges();
        return categoriaAtualizada;
    }
    public bool Remover(int id)
    {
        var categoriaParaDeletar = ObterPorId(id);
        if (categoriaParaDeletar == null) return false;
        _context.Categorias.Remove(categoriaParaDeletar);
        _context.SaveChanges();
        return true;
    }
}
