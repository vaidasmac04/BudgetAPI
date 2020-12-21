﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BudgetAPI.Data;
using BudgetProject.Models;

namespace BudgetAPI.Controllers
{
    [Route("api/ClientOutcome")]
    [ApiController]
    public class ClientOutcomeController : ControllerBase
    {
        private readonly BudgetContext _context;

        public ClientOutcomeController(BudgetContext context)
        {
            _context = context;
        }

        [HttpGet("{clientId}")]
        public async Task<ActionResult<IEnumerable<Outcome>>> GetOutcomes(int clientId)
        {
            var outcomes = await _context.Outcome.Where(o => o.ClientId == clientId).ToListAsync();

            if (outcomes == null)
            {
                return NotFound();
            }

            return outcomes;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutOutcome(int id, Outcome outcome)
        {
            if (id != outcome.Id)
            {
                return BadRequest();
            }

            _context.Entry(outcome).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OutcomeExists(id))
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

        [HttpPost]
        public async Task<ActionResult<Outcome>> PostOutcome(Outcome outcome)
        {
            _context.Outcome.Add(outcome);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOutcome", new { id = outcome.Id }, outcome);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Outcome>> DeleteOutcome(int id)
        {
            var outcome = await _context.Outcome.FindAsync(id);
            if (outcome == null)
            {
                return NotFound();
            }

            _context.Outcome.Remove(outcome);
            await _context.SaveChangesAsync();

            return outcome;
        }

        private bool OutcomeExists(int id)
        {
            return _context.Outcome.Any(e => e.Id == id);
        }
    }
}