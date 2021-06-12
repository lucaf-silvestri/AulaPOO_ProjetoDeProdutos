using System.Collections.Generic;
using Projeto_Produtos.Interfaces;
using System;

namespace Projeto_Produtos.Classes
{
    public class Usuario : IUsuario
    {

        public int codigo { get; set; }
        public string nomeUser { get;  }
        public string email { get; set; }
        public string senha { get; set; }
        public DateTime dataCadastro { get; set; }

        List<Usuario> Listausers = new List<Usuario>();

        public Usuario(int userId)
        {
            codigo = userId; 
            Console.WriteLine("Qual o nome do usuário?");
            nomeUser = Console.ReadLine();
            Console.WriteLine("Qual o email do usuário?");
            email = Console.ReadLine();
            Console.WriteLine("Qual a senha do usuário?");
            senha = Console.ReadLine();

            dataCadastro = DateTime.Now;
            userId++;

        }
        public string Cadastrar(Usuario userCadastro)
        {
            Listausers.Add(userCadastro);
            return "Usuário cadastrado!";
        }

        public string Deletar(Usuario userDelete)
        {
            Listausers.Remove(userDelete);
            return "Usuário deletado!";
            
        }
    }
}