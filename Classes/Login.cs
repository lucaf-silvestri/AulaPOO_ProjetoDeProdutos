using System;
using System.Collections.Generic;
using Projeto_Produtos.Interfaces;

namespace Projeto_Produtos.Classes
{
    public class Login : ILogin
    {
        public bool logado;
        public Login()
        {
            int userId = 1;
            int marcaId = 1;
            int produtoId = 1;
            int i = 0;

            Marca m = new Marca();
            Produto p = new Produto();

            Console.WriteLine("\n Para entrar no nosso sistema primeiro se cadastre.");

            Usuario u = new Usuario(userId);

            Console.WriteLine(u.Cadastrar(u));

            while (logado == false)
            {
                Console.WriteLine(Logar(u));
            }

            do
            {
                Console.WriteLine($@"
O que você deseja fazer?

1 - Cadastrar marca
2 - Listar marcas
3 - Deletar marca
4 - Cadastrar produtos
5 - Listar produtos
6 - Deletar produtos
7 - Sair");
            

                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        Marca marca = new Marca(marcaId);

                        Console.WriteLine(m.Cadastrar(marca));
                        i++;
                        marcaId++;
                        break;

                    case "2":
                        m.Listar();
                        break;

                    case "3":
                        Console.WriteLine("Qual marca você deseja deletar?");
                        string marcaDelete = Console.ReadLine();
                        List<Marca> procurarMarcas = m.ListarExistentes();

                        Marca encontrada = procurarMarcas.Find(item => item.nomeMarca == marcaDelete);

                        Console.WriteLine(m.Deletar(encontrada));
                        break;

                    case "4":
                        Produto produto = new Produto(produtoId, u, m.ListarExistentes());

                        if (p.Cadastrar(produto, m.ListarExistentes(), produtoId) == "\n Produto Cadastrado!") 
                        {
                            Console.WriteLine("Produto cadastrado com sucesso!");
                            produtoId++;
                        }
                        break;

                    case "5":
                        p.Listar();
                        break;

                    case "6":
                        Console.WriteLine("Qual produto você deseja deletar?");
                        string produtoDelete = Console.ReadLine();
                        List<Produto> procurarProdutos = p.ListarExistentes();

                        Produto encontrado = procurarProdutos.Find(item => item.nomeProduto == produtoDelete);

                        Console.WriteLine(p.Deletar(encontrado));
                        break;

                    case "7":
                        Console.Write(Deslogar(u));
                        break;

                    default:
                        Console.WriteLine("Digite uma opção válida!");
                        break;
                }
            } while (logado == true);




        }
        public string Deslogar(Usuario user)
        {
            logado = false;
            return "Deslogando do sistema!";
        }

        public string Logar(Usuario user)
        {
            Console.WriteLine("\n Digite seu nome:");
            string nomeLogin = Console.ReadLine();
            Console.WriteLine("Digite sua senha:");
            string senhaLogin = Console.ReadLine();
            if (user.nomeUser == nomeLogin && user.senha == senhaLogin)
            {
                logado = true;
                return "Logado!";
            }
            else
            {
                logado = false;
                return "Voce digitou seu nome de usuário ou senha incorretamente! Tente novamente:";
            }
        }
    }
}