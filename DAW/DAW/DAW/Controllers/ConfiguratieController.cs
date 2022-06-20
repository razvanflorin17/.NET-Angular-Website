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

    public class ConfiguratieController : ControllerBase
    {
        private readonly IRepositoryWrapper _repository;
        public ConfiguratieController(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Authorize(Roles = "Admin, User")]
        public async Task<IActionResult> GetAllConfiguratie()
        {
            var configuratii = await _repository.Configuratie.GetAllConfiguratie();

            var ConfiguratieToReturn = new List<ConfiguratieDTO>();

            foreach (var configuratie in configuratii)
            {
                ConfiguratieToReturn.Add(new ConfiguratieDTO(configuratie));
            }

            return Ok(ConfiguratieToReturn);
        }

        [HttpGet("placa")]
        [Authorize(Roles = "Admin, User")]
        public async Task<IActionResult> GetConfiguratieByPlaca(string placa)
        {
            var configuratii = await _repository.Configuratie.GetConfiguratieByPlaca(placa);

            var ConfiguratieToReturn = new List<ConfiguratieDTO>();

            foreach (var configuratie in configuratii)
            {
                ConfiguratieToReturn.Add(new ConfiguratieDTO(configuratie));
            }

            return Ok(ConfiguratieToReturn);
        }

        [HttpGet("procesor")]
        [Authorize(Roles = "Admin, User")]
        public async Task<IActionResult> GetConfiguratieByProcesor(string procesor)
        {
            var configuratii = await _repository.Configuratie.GetConfiguratieByProcesor(procesor);

            var ConfiguratieToReturn = new List<ConfiguratieDTO>();

            foreach (var configuratie in configuratii)
            {
                ConfiguratieToReturn.Add(new ConfiguratieDTO(configuratie));
            }

            return Ok(ConfiguratieToReturn);
        }

        [HttpGet("ram:int")]
        [Authorize(Roles = "Admin, User")]
        public async Task<IActionResult> GetConfiguratieByRAM(int RAM)
        {
            var configuratii = await _repository.Configuratie.GetConfiguratieByRam(RAM);

            var ConfiguratieToReturn = new List<ConfiguratieDTO>();

            foreach (var configuratie in configuratii)
            {
                ConfiguratieToReturn.Add(new ConfiguratieDTO(configuratie));
            }

            return Ok(ConfiguratieToReturn);
        }

        [HttpGet("stocare:int")]
        [Authorize(Roles = "Admin, User")]
        public async Task<IActionResult> GetConfiguratieByStocare(int Stocare)
        {
            var configuratii = await _repository.Configuratie.GetConfiguratieByStocare(Stocare);

            var ConfiguratieToReturn = new List<ConfiguratieDTO>();

            foreach (var configuratie in configuratii)
            {
                ConfiguratieToReturn.Add(new ConfiguratieDTO(configuratie));
            }

            return Ok(ConfiguratieToReturn);
        }

        [HttpGet("id:int")]
        [Authorize(Roles = "Admin, User")]
        public async Task<IActionResult> GetPCsByConfiguratie(int id)
        {
            var configuratii = await _repository.Configuratie.GetPCsByConfiguratie(id);

            var PCsToReturn = new List<PCDTO>();

            foreach (var configuratie in configuratii)
            {
                PCsToReturn.Add(new PCDTO(configuratie));
            }

            return Ok(PCsToReturn);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateConfiguratie(ConfiguratieCreateDTO dto)
        {
            Configuratie newConfiguratie = new Configuratie();

            newConfiguratie.Placa = dto.Placa;
            newConfiguratie.Procesor = dto.Procesor;
            newConfiguratie.RAM = dto.RAM;
            newConfiguratie.Stocare = dto.Stocare;


            _repository.Configuratie.Create(newConfiguratie);

            await _repository.SaveAsync();

            return Ok(new ConfiguratieDTO(newConfiguratie));
        }

        [HttpPut("{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateConfiguratie(int id, ConfiguratieUpdateDTO dto)
        {

            Configuratie updateConfiguratie = await _repository.Configuratie.GetByIdAsync(id);

            if (!updateConfiguratie.Placa.ToUpper().Equals(dto.Placa.ToUpper()))
                updateConfiguratie.Placa = dto.Placa;

            if (!updateConfiguratie.Procesor.ToUpper().Equals(dto.Procesor.ToUpper()))
                updateConfiguratie.Procesor = dto.Procesor;

            if (!updateConfiguratie.RAM.Equals(dto.RAM))
                updateConfiguratie.RAM = dto.RAM;

            if (!updateConfiguratie.Stocare.Equals(dto.Stocare))
                updateConfiguratie.Stocare = dto.Stocare;

            _repository.Configuratie.Update(updateConfiguratie);

            await _repository.SaveAsync();

            return Ok(new ConfiguratieDTO(updateConfiguratie));
        }

        [HttpDelete("{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfiguratie(int id)
        {
            Configuratie deleteConfiguratie = await _repository.Configuratie.GetByIdAsync(id);

            _repository.Configuratie.Delete(deleteConfiguratie);

            await _repository.SaveAsync();

            return Ok(new ConfiguratieDTO(deleteConfiguratie));
        }
    }
}
