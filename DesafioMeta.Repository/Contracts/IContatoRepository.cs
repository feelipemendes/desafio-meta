using DesafioMeta.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioMeta.Repository.Contracts
{
    public interface IContatoRepository : IDisposable
    {
        void Create(Contato contato);
        void Delete(int idContato);
        void Update(Contato contato);
        
        Contato GetById(int Id);
        List<Contato> SelectBy(int size, int page);
    }
}
