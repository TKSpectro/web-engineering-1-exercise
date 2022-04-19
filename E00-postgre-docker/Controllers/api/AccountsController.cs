using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using E00_postgre_docker.Models;

namespace E00_postgre_docker.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountsController : Controller
{
    private readonly ILogger<AccountsController> _logger;
    private readonly ApiDbContext _context;

    public AccountsController(ILogger<AccountsController> logger, ApiDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Account>> Get()
    {
        return _context.Accounts.ToList();
    }

    [HttpGet("{id}")]
    public ActionResult<Account> Get(Guid id)
    {
        var account = _context.Accounts.Where(x => x.Id == id).FirstOrDefault();
        if (account == null)
        {
            return NotFound();
        }

        return account;
    }

    [HttpPost]
    public ActionResult<Account> Post(Account account)
    {
        _logger.LogInformation("Account created: {@Account}", account);
        _context.Accounts.Add(account);
        _context.SaveChanges();


        return CreatedAtAction(nameof(Get), new { id = account.Id }, account);
    }
}