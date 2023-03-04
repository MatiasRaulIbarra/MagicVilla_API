﻿using MagicVilla_API.Datos;
using MagicVilla_API.Modelos;
using MagicVilla_API.Modelos.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace MagicVilla_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VillaController : ControllerBase
    {

        [HttpGet]
        public IEnumerable<VillaDto> GetVillas()
        {
            return VillaStore.villaList;
        }

        [HttpGet("id:int")]
        public  ActionResult< VillaDto> GetVilla(int id)
        {

            if (id == 0)
            {
                return BadRequest();
            }
            var villa= VillaStore.villaList.FirstOrDefault(v => v.Id == id);

            if (villa == null)
            {
                return NotFound();
            }
            return Ok(villa);
        }
    }
}
