using DesafioMeta.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioMeta.Repository.Contracts
{
    public interface IContatoRepository : IDisposable
    {
        void Create(Contato contato);
        void Delete(Contato contato);
        void Update(Contato contato);
        
        Contato GetById(int idContato);
        List<Contato> SelectAll();
    }
}
