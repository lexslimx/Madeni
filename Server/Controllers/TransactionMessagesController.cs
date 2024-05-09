using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Madeni.Server.Data;
using Madeni.Server.Models;

namespace Madeni.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionMessagesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TransactionMessagesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/TransactionMessages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TransactionMessage>>> GetTransactionMessages()
        {
            return await _context.TransactionMessages.ToListAsync();
        }

        // GET: api/TransactionMessages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TransactionMessage>> GetTransactionMessage(int id)
        {
            var transactionMessage = await _context.TransactionMessages.FindAsync(id);

            if (transactionMessage == null)
            {
                return NotFound();
            }

            return transactionMessage;
        }

        // PUT: api/TransactionMessages/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTransactionMessage(int id, TransactionMessage transactionMessage)
        {
            if (id != transactionMessage.TransactionMessageId)
            {
                return BadRequest();
            }

            _context.Entry(transactionMessage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransactionMessageExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TransactionMessages
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TransactionMessage>> PostTransactionMessage(TransactionMessage transactionMessage)
        {
            var message = new TransactionMessage
            {
                Text = transactionMessage.Text,
                DateReceived = transactionMessage.DateReceived,
            };
            _context.TransactionMessages.Add(message);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTransactionMessage", new { id = transactionMessage.TransactionMessageId }, transactionMessage);
        }

        // DELETE: api/TransactionMessages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransactionMessage(int id)
        {
            var transactionMessage = await _context.TransactionMessages.FindAsync(id);
            if (transactionMessage == null)
            {
                return NotFound();
            }

            _context.TransactionMessages.Remove(transactionMessage);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TransactionMessageExists(int id)
        {
            return _context.TransactionMessages.Any(e => e.TransactionMessageId == id);
        }
    }
}
