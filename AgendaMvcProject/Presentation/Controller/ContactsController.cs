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
    public async Task<ActionResult> Post([FromBody] Contact contact)
    {
        if (contact == null)
            return BadRequest("Invalid Data");

        await _contactService.Add(contact);

        return new CreatedAtRouteResult("GetContact", new { id = contact.Id },
            contact);
    }

    [HttpPut]
    public async Task<ActionResult> Put(int id, [FromBody] Contact contact)
    {
        if (id != contact.Id)
            return BadRequest();

        if (contact == null)
            return BadRequest();

        await _contactService.Update(contact);

        return Ok(contact);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<Contact>> Delete(int id)
    {
        var contact = await _contactService.GetById(id);
        if (contact == null)
        {
            return NotFound("Contact not found");
        }

        await _contactService.Delete(id);

        return Ok(contact);

    }
}
