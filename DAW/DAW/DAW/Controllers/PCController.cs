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

    public class PCController : ControllerBase
    {
        private readonly IRepositoryWrapper _repository;
        public PCController(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Authorize(Roles = "Admin, User")]
        public async Task<IActionResult> GetAllPCs()
        {
            var pcs = await _repository.PC.GetAllPCs();

            var PCsToReturn = new List<PCDTO>();

            foreach (var pc in pcs)
            {
                PCsToReturn.Add(new PCDTO(pc));
            }

            return Ok(PCsToReturn);
        }

        [HttpGet("type")]
        [Authorize(Roles = "Admin, User")]
        public async Task<IActionResult> GetPCsByType(string type)
        {
            var pcs = await _repository.PC.GetPCsByType(type);

            var PCsToReturn = new List<PCDTO>();

            foreach (var pc in pcs)
            {
                PCsToReturn.Add(new PCDTO(pc));
            }

            return Ok(PCsToReturn);
        }

        [HttpGet("{price:int}")]
        [Authorize(Roles = "Admin, User")]
        public async Task<IActionResult> GetPCsByPrice(int price)
        {
            var pcs = await _repository.PC.GetPCsByPrice(price);

            var PCsToReturn = new List<PCDTO>();

            foreach (var pc in pcs)
            {
                PCsToReturn.Add(new PCDTO(pc));
            }

            return Ok(PCsToReturn);
        }

        [HttpGet("users")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetPCsWithUser()
        {
            var pcs = await _repository.PC.GetPCsWithUser();

            var PCsToReturn = new List<PCUserDTO>();

            foreach (var pc in pcs)
            {
                PCsToReturn.Add(new PCUserDTO(pc));
            }

            return Ok(PCsToReturn);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreatePC(PCCreateDTO dto)
        {
            PC newPC = new PC();

            newPC.Tip = dto.Tip;
            newPC.Pret = dto.Pret;

            _repository.PC.Create(newPC);

            await _repository.SaveAsync();

            return Ok(new PCDTO(newPC));
        }

        [HttpPut("{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdatePC(int id, PCUpdateDTO dto)
        {

            PC updatePC = await _repository.PC.GetByIdAsync(id);

            if (!updatePC.Tip.ToUpper().Equals(dto.Tip.ToUpper()))
                updatePC.Tip = dto.Tip;

            if (!updatePC.Pret.Equals(dto.Pret))
                updatePC.Pret = dto.Pret;

            if (!updatePC.Id_Client.Equals(dto.Id_Client))
                updatePC.Id_Client = dto.Id_Client;

            _repository.PC.Update(updatePC);

            await _repository.SaveAsync();

            return Ok(new PCDTO(updatePC));
        }

        [HttpPut("update_pc_user/{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> PCUpdateUser(int id, PCUpdateUserDTO dto)
        {
            PC pc = new PC();

            pc = await _repository.PC.GetByIdAsync(id);

            if (dto.Id_Client != -1)
                pc.Id_Client = dto.Id_Client;
            else
                pc.Id_Client = 0;


            _repository.PC.Update(pc);


            await _repository.SaveAsync();


            return Ok(new PCDTO(pc));
        }

        [HttpPut("cerere_pc/{id:int}")]
        [Authorize(Roles = "Admin, User")]
        public async Task<IActionResult> CererePC(int id, PCUpdateUserDTO dto)
        {
            PC pc = new PC();

            pc = await _repository.PC.GetByIdAsync(id);

            if (pc.Id_Client == 0)
                pc.Id_Client = dto.Id_Client;
            else return BadRequest("Masina deja este rezervata");

            _repository.PC.Update(pc);


            await _repository.SaveAsync();


            return Ok(new PCDTO(pc));
        }

        [HttpDelete("{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeletePC(int id)
        {
            PC deletePC = await _repository.PC.GetByIdAsync(id);

            _repository.PC.Delete(deletePC);

            await _repository.SaveAsync();

            return Ok(new PCDTO(deletePC));
        }
    }
}
