using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DesafioMeta.Presentation.ViewModels;
using DesafioMeta.Repository.Contracts;
using AutoMapper;
using DesafioMeta.Entities;

namespace DesafioMeta.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContatoController : Controller
    {
        private readonly IContatoRepository repository;
        private readonly IMapper _mapper;

        public ContatoController(IContatoRepository repository, IMapper mapper)
        {
            this.repository = repository;
            _mapper = mapper;
        }

        // POST api/contato
        [HttpPost]
        public IActionResult Post([FromBody] ContatoCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return new BadRequestResult();//400
            }

            try
            {
                var contato = _mapper.Map<Contato>(model);
                repository.Create(contato);

                return Ok($"Contato '{model.Nome}' cadastrado com sucesso.");
            }
            catch (Exception e)
            {
                //INTERNAL SERVERR ERROR
                return StatusCode(500, e.Message);
            }
        }

        // PUT api/contato
        [HttpPut]
        public IActionResult Put([FromBody] ContatoUpdateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return new BadRequestResult();//400
            }

            try
            {
                var contato = _mapper.Map<Contato>(model);
                repository.Update(contato);

                return Ok($"Contato '{model.Nome}' atualizado com sucesso.");
            }
            catch (Exception e)
            {
                //INTERNAL SERVERR ERROR
                return StatusCode(500, e.Message);
            }
        }

        // DELETE api/contato/id
        [HttpDelete("{idContato}")]
        public IActionResult Delete(int idContato)
        {
            try
            {
                var contato = repository.SelectAll().FirstOrDefault(x => x.Id == idContato);
                repository.Delete(contato);

                return Ok($"Contato '{contato.Nome}' excluído com sucesso.");
            }
            catch (Exception e)
            {
                //INTERNAL SERVERR ERROR
                return StatusCode(500, e.Message);
            }
        }

        // GET api/contato
        [HttpGet]
        public IActionResult GetAll()
        {            
            try
            {
                var list = _mapper.Map<List<ContatoViewModel>>
                                (repository.SelectAll());
                return Ok(list);
            }
            catch (Exception e)
            {
                //INTERNAL SERVERR ERROR
                return StatusCode(500, e.Message);
            }
        }

        // GET api/contato/id
        [HttpGet("{idContato}")]
        public IActionResult GetById(int idContato)
        {
            try
            {
                
                var contato = repository.SelectAll().FirstOrDefault(x => x.Id == idContato);
                var model = _mapper.Map<ContatoViewModel>
                    (contato);
                return Ok(model);
            }
            catch (Exception e)
            {
                //INTERNAL SERVERR ERROR
                return StatusCode(500, e.Message);
            }
        }
    }
}