using DAW.Repositories;
using DAW.Models.DTOs;
using DAW.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ComponenteController : ControllerBase
    {
        private readonly IRepositoryWrapper _repository;
        public ComponenteController(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Authorize(Roles = "Admin, User")]
        public async Task<IActionResult> GetAllComponente()
        {
            var componente = await _repository.Componente.GetAllComponente();

            var ComponentaToReturn = new List<ComponenteDTO>();

            foreach (var componenta in componente)
            {
                ComponentaToReturn.Add(new ComponenteDTO(componenta));
            }

            return Ok(ComponentaToReturn);
        }

        [HttpGet("nume")]
        [Authorize(Roles = "Admin, User")]
        public async Task<IActionResult> GetComponenteByName(string nume)
        {
            var componente = await _repository.Componente.GetComponenteByName(nume);

            var ComponenteToReturn = new List<ComponenteDTO>();

            foreach (var componenta in componente)
            {
                ComponenteToReturn.Add(new ComponenteDTO(componenta));
            }

            return Ok(ComponenteToReturn);
        }

        [HttpGet("pret:int")]
        [Authorize(Roles = "Admin, User")]
        public async Task<IActionResult> GetComponenteByPrice(int pret)
        {
            var componente = await _repository.Componente.GetComponenteByPrice(pret);

            var ComponenteToReturn = new List<ComponenteDTO>();

            foreach (var componenta in componente)
            {
                ComponenteToReturn.Add(new ComponenteDTO(componenta));
            }

            return Ok(ComponenteToReturn);
        }

        [HttpGet("detalii")]
        [Authorize(Roles = "Admin, User")]
        public async Task<IActionResult> GetComponenteByDetalii(string detalii)
        {
            var componente = await _repository.Componente.GetComponenteByDetalii(detalii);

            var ComponenteToReturn = new List<ComponenteDTO>();

            foreach (var componenta in componente)
            {
                ComponenteToReturn.Add(new ComponenteDTO(componenta));
            }

            return Ok(ComponenteToReturn);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateConfiguratie(ComponenteCreateDTO dto)
        {
            Componente newComponente = new Componente();

            newComponente.Nume = dto.Nume;
            newComponente.Pret = dto.Pret;
            newComponente.Detalii = dto.Detalii;


            _repository.Componente.Create(newComponente);

            await _repository.SaveAsync();

            return Ok(new ComponenteDTO(newComponente));
        }

        [HttpPut("{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateComponente(int id, ComponenteUpdateDTO dto)
        {

            Componente updateComponente = await _repository.Componente.GetByIdAsync(id);

            if (!updateComponente.Nume.ToUpper().Equals(dto.Nume.ToUpper()))
                updateComponente.Nume = dto.Nume;

            if (!updateComponente.Pret.Equals(dto.Pret))
                updateComponente.Pret = dto.Pret;

            if (!updateComponente.Detalii.ToUpper().Equals(dto.Detalii.ToUpper()))
                updateComponente.Detalii = dto.Detalii;

            _repository.Componente.Update(updateComponente);

            await _repository.SaveAsync();

            return Ok(new ComponenteDTO(updateComponente));
        }

        [HttpPut("update_componente_user/{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ComponenteUpdateUser(int id, ComponenteUpdateUserDTO dto)
        {
            Componente componenta = new Componente();

            componenta = await _repository.Componente.GetByIdAsync(id);

            if (dto.UserID != -1)
                componenta.UserId = dto.UserID;
            else
                componenta.UserId = 0;


            _repository.Componente.Update(componenta);


            await _repository.SaveAsync();


            return Ok(new ComponenteDTO(componenta));
        }

        [HttpDelete("{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteComponenta(int id)
        {
            Componente deleteComponente = await _repository.Componente.GetByIdAsync(id);

            _repository.Componente.Delete(deleteComponente);

            await _repository.SaveAsync();

            return Ok(new ComponenteDTO(deleteComponente));
        }
    }
}
