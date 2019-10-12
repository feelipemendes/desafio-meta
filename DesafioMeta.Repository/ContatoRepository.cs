using System.Collections.Generic;
using DesafioMeta.Entities;
using DesafioMeta.Repository.Contracts;
using Dapper;
using System.Data.SqlClient;
using System.Linq;
using System;


namespace DesafioMeta.Repository
{
    public class ContatoRepository : IContatoRepository
    {
        //atributo
        private readonly string connectionString;

        //construtor para injeção de dependência
        public ContatoRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        #region Metodos
        public void Create(Contato contato)
        {
            var query = "INSERT INTO CONTATO (NOME, CANAL, VALOR, OBS) " +
                        "VALUES (@Nome, @Canal, @Valor, @Obs)";

            using (var conn = new SqlConnection(connectionString))
            {
                conn.Execute(query, contato);
            }
        }

        public void Delete(Contato contato)
        {
            var query = "DELETE FROM CONTATO " +
                "WHERE ID = @Id";

            using (var conn = new SqlConnection(connectionString))
            {
                conn.Execute(query, contato);
            }
        }

        public void Update(Contato contato)
        {
            var query = "UPDATE CONTATO SET NOME = @Nome, CANAL = @Canal, VALOR = @Valor, OBS = @Obs " +
                "WHERE ID = @Id";

            using (var conn = new SqlConnection(connectionString))
            {
                conn.Execute(query, contato);
            }
        }

        public Contato GetById(int idContato)
        {
            var query = "SELECT * FROM CONTATO WHERE ID = @idContato";

            using (var conn = new SqlConnection(connectionString))
            {
                var teste = conn.QuerySingleOrDefault(query, new { idContato });
                return teste;
            }
        }

        public List<Contato> SelectAll()
        {
            var query = "SELECT * FROM CONTATO";

            using (var conn = new SqlConnection(connectionString))
            {
                return conn.Query<Contato>(query).ToList();
            }
        }
        #endregion
        
        public void Dispose()
        {
            //GC.SupressFinalize(this); TODO
        }
    }
}
