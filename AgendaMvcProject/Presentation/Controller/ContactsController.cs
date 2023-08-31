using AgendaMvcProject.Application.DTOs;
using AgendaMvcProject.Application.Interfaces;
using AgendaMvcProject.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AgendaMvcProject.Data.Presentation.Controller;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class ContactsController : ControllerBase
{
    private readonly IContactService _contactService;
    public ContactsController(IContactService contactService)
    {
        _contactService = contactService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ContactDTO>>> Get()
    {
        var contacts = await _contactService.GetContacts();
        if (contacts == null)
        {
            return NotFound("Contacts not found");
        }
        return Ok(contacts);
    }

    /// <summary>
    /// Localiza um contato específico pelo Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>

    [HttpGet("{id:int}", Name = "GetContact")]
    public async Task<ActionResult<ContactDTO>> Get(int id)
    {
        var contact = await _contactService.GetById(id);
        if (contact == null)
        {
            return NotFound("Contact not found");
        }
        return Ok(contact);
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] ContactDTO contactDto)
    {
        if (contactDto == null)
            return BadRequest("Invalid Data");

        await _contactService.Add(contactDto);

        return new CreatedAtRouteResult("GetContact", new { id = contactDto.Id },
            contactDto);
    }

    [HttpPut]
    public async Task<ActionResult> Put(int id, [FromBody] ContactDTO contactDto)
    {
        if (id != contactDto.Id)
            return BadRequest();

        if (contactDto == null)
            return BadRequest();

        await _contactService.Update(contactDto);

        return Ok(contactDto);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<ContactDTO>> Delete(int id)
    {
        var category = await _contactService.GetById(id);
        if (category == null)
        {
            return NotFound("Contact not found");
        }

        await _contactService.Delete(id);

        return Ok(contact);

    }
}
