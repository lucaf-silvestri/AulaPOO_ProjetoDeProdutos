using System;
using System.Collections.Generic;
using Projeto_Produtos.Interfaces;

namespace Projeto_Produtos.Classes
{
    public class Produto : IProduto
    {
        public int codigo { get; set; }
        public string nomeProduto { get; set; }
        public float preco { get; set; }
        public Marca marca { get; set; }
        public Usuario cadastradoPor { get; set; }
        public DateTime DataCadastro { get; set; }
        List<Produto> ListarProdutos = new List<Produto>();

        public Produto() { }
        public Produto(int codigoId, Usuario user, List<Marca> ListarMarcas)
        {
            codigo = codigoId;
            Console.WriteLine("Digite o nome do produto:");
            nomeProduto = Console.ReadLine();
            Console.WriteLine("\nDigite o preço do produto: R$");
            preco = float.Parse(Console.ReadLine());
            DataCadastro = DateTime.Now;

            cadastradoPor = user;
            Console.WriteLine("Digite o nome da marca:");
            string VMarca = Console.ReadLine();
            marca = ListarMarcas.Find(x => x.nomeMarca == VMarca);
        }


        public string Cadastrar(Produto produtoCadastrar, List<Marca> ListarMarcas, int produtoid)
        {
            if (ListarMarcas.Count > 0 && produtoCadastrar.marca != null)
            {
                ListarProdutos.Add(produtoCadastrar);
                return "\n Produto Cadastrado!";
            }
            else if (ListarMarcas.Count <= 0)
            {
                return "Não é possível cadastrar um produto quando não há marcas cadastradas!";
            }
            else
            {
                return "";
            }

        }

        public string Deletar(Produto produtoCadastrar)
        {
            ListarProdutos.Remove(produtoCadastrar);
            return "\n Produto deletado!";
        }

        public void Listar()
        {
            if (ListarProdutos.Count <= 0)
            {
                Console.WriteLine("A lista está vazia! Ou você não cadastrou nenhuma marca!");

            }
            else
            {
                Console.WriteLine("\n Produtos cadastrados:");
                foreach (Produto item in ListarProdutos)
                {
                    Console.WriteLine($@"
===================================
Nome do produto: {item.nomeProduto}
Preço: {item.preco:C2}
Código: {item.codigo}
Data de cadastro: {item.DataCadastro}
Marca: {item.marca.nomeMarca}
Cadastrado por: {item.cadastradoPor.nomeUser}
===================================
");}
            }
        }
        public List<Produto> ListarExistentes()
        {
            return ListarProdutos;
        }
    }
}