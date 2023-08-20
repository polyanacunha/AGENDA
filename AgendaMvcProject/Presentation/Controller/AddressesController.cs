using AgendaMvcProject.Application.DTOs;
using AgendaMvcProject.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AgendaMvcProject.Data.Presentation.Controller;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class AddressesController : ControllerBase
{
    private readonly IAddressService _addressService;
    public AddressesController(IAddressService addressesService)
    {
        _addressService = addressesService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AddressDTO>>> Get()
    {
        var addresses = await _addressService.GetAddresses();
        if (addresses == null)
        {
            return NotFound("Addresses not found");
        }
        return Ok(addresses);
    }

    /// <summary>
    /// Localiza um contato específico pelo Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>

    [HttpGet("{id:int}", Name = "GetAddres")]
    public async Task<ActionResult<ContactDTO>> Get(int id)
    {
        var address = await _addressService.GetById(id);
        if (address == null)
        {
            return NotFound("Address not found");
        }
        return Ok(address);
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] AddressDTO addressDto)
    {
        if (addressDto == null)
            return BadRequest("Invalid Address");

        await _addressService.Add(addressDto);

        return new CreatedAtRouteResult("GetContact", new { id = addressDto.Id },
            addressDto);
    }

    [HttpPut]
    public async Task<ActionResult> Put(int id, [FromBody] AddressDTO addressDto)
    {
        if (id != addressDto.Id)
            return BadRequest();

        if (addressDto == null)
            return BadRequest();

        await _addressService.Update(addressDto);

        return Ok(addressDto);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<AddressDTO>> Delete(int id)
    {
        var address = await _addressService.GetById(id);
        if (address == null)
        {
            return NotFound("Adress not found");
        }

        await _addressService.Remove(id);

        return Ok(address);

    }
}