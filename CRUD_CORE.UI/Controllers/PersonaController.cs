﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CRUD_CORE.UI.Models.Context;
using CRUD_CORE.UI.Models.Modelos;

namespace CRUD_CORE.UI.Controllers
{
    public class PersonaController : Controller
    {
        private readonly Context _context;

        public PersonaController(Context context)
        {
            _context = context;
        }

        // GET: Persona
        public async Task<IActionResult> Index()
        {
            return View(await _context.Personas.ToListAsync());
        }

        // GET: Persona/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var persona = await _context.Personas
                .FirstOrDefaultAsync(m => m.IdPersona == id);
            if (persona == null)
            {
                return NotFound();
            }

            return View(persona);
        }

        // GET: Persona/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Persona/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPersona,Nombre,Cedula,FechaNacimiento")] Persona persona)
        {
            if (ModelState.IsValid)
            {
                _context.Add(persona);
                _context.Entry(persona).State = EntityState.Added;
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

                

            }
            return View(persona);
        }

        // GET: Persona/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var persona = await _context.Personas.FindAsync(id);
            if (persona == null)
            {
                return NotFound();
            }
            return View(persona);
        }

        // POST: Persona/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPersona,Nombre,Cedula,FechaNacimiento")] Persona persona)
        {
            if (id != persona.IdPersona)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(persona);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonaExists(persona.IdPersona))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(persona);
        }

        // GET: Persona/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
                var persona = await _context.Personas.FindAsync(id);
                _context.Personas.Remove(persona);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));

            
        }


        private bool PersonaExists(int id)
        {
            return _context.Personas.Any(e => e.IdPersona == id);
        }
    }
}
