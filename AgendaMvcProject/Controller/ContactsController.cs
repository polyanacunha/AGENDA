using Application.DTOs;
using Application.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AgendaMvcProject.Controller;

[Route("api/[controller]")]
[ApiController]
// [Authorize]
public class ContactsController : ControllerBase
{
    private readonly IContactService _contactService;
    public ContactsController(IContactService contactService)
    {
        _contactService = contactService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Contact>>> Get()
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
    public async Task<ActionResult<Contact>> Get(int id)
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
    public async Task<ActionResult<Contact>> Delete(int id)
    {
        var contact = await _contactService.GetById(id);
        if (contact == null)
        {
            return NotFound("Contact not found");
        }

        await _contactService.Remove(id);

        return Ok(contact);

    }
}
