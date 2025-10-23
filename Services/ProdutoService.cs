using System;
using AutoMapper;
using LojaApi.Entities;
using LojaApi.Infra.Repositories.Interfaces;
using LojaApi.Services.Interfaces;
using LojaApi.Infra.DTOs;

namespace LojaApi.Services {
    public class ProdutoService : IProdutoService
    {
        private readonly IMapper _mapper;
        private readonly IProdutoRepository _produtoRepository;
        private readonly ICategoriaRepository _categoriaRepository;
        public ProdutoService(
        IProdutoRepository produtoRepository,
        ICategoriaRepository categoriaRepository,
        IMapper mapper)
        {
            _produtoRepository = produtoRepository;
            _categoriaRepository = categoriaRepository;
            _mapper = mapper;
        }

        public List<ProdutoResumoDto> ObterTodos()
        {
            var produtos = _produtoRepository.ObterTodos().Where(p => p.Estoque > 0).ToList();
            return _mapper.Map<List<ProdutoResumoDto>>(produtos);
        }

        public Produto? ObterPorId(int id)
        {
            return _produtoRepository.ObterPorId(id);
        }

        public Produto Adicionar(Produto novoProduto)
        {
            // Validação de Negócio: Regras que precisam de acesso a dados. 
            var categoria = _categoriaRepository.ObterPorId(novoProduto.CategoriaId);
            if (categoria == null)
            {
                // Em um projeto real, lançaríamos uma exceção customizada que vamos ver mais à frente no curso. 
                // Por simplicidade, podemos retornar null ou uma mensagem. 
                throw new Exception("A categoria informada não existe.");
            }

            if (categoria.Descricao.Equals("Eletrônicos", StringComparison.OrdinalIgnoreCase) && novoProduto.Valor < 50.00m)
            {
                throw new Exception("Produtos da categoria 'Eletrônicos' devem custar no mínimo R$ 50,00.");
            }

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
    }
}


