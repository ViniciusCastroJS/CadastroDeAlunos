
using System.Collections.Generic;

namespace Asp.net.Models
{
    public static class BaseDeDados
    {
        private static List<Aluno> alunos = new List<Aluno>();

        public static void Incluir(Aluno aluno)
        {
            alunos.Add(aluno);
        }

        public static List<Aluno> Listar()
        {
            return alunos;
        }
    }
}