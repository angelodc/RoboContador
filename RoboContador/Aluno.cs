using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboContador
{
    public class Aluno : Object
    {
        string nome, estado, cidade, cpf, inscricao, semestre;

        public Aluno()
        {
        }

        public Aluno(string nome, string estado, string cidade, string inscricao, string cpf, string semestre)
        {
            this.nome = nome;
            this.estado = estado;
            this.cidade = cidade;
            this.inscricao = inscricao;
            this.cpf = cpf;
            this.semestre = semestre;
        }

        public string Nome { get => nome; set => nome = value; }
        public string Estado { get => estado; set => estado = value; }
        public string Cidade { get => cidade; set => cidade = value; }
        public string Cpf { get => cpf; set => cpf = value; }
        public string Inscricao { get => inscricao; set => inscricao = value; }
        public string Semestre { get => semestre; set => semestre = value; }
    }
}
