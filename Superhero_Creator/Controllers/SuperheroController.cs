﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Superhero_Creator.Data;
using Superhero_Creator.Models;

namespace Superhero_Creator.Controllers
{
    public class SuperheroController : Controller
    {
        public ApplicationDbContext context;

        public SuperheroController(ApplicationDbContext db)
        {
            context = db;
        }
        // GET: SuperheroController
       
        public ActionResult Index()
        {
            List<Superhero> collection = context.Superheroes.ToList();
            return View(collection);
        }

        // GET: SuperheroController/Details/5
        public ActionResult Details(int id)
        {
            var superhero = context.Superheroes.Where(hero => hero.Id == id).SingleOrDefault();
            return View(superhero);
        }

        // GET: SuperheroController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SuperheroController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Superhero superhero)
        {
            try
            {
                context.Add(superhero);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(superhero);
            }
        }

        // GET: SuperheroController/Edit/5
        public ActionResult Edit(int id)
        {
            var superhero = context.Superheroes.Where(hero => hero.Id == id).SingleOrDefault();
            return View(superhero);
        }

        // POST: SuperheroController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Superhero hero)
        {
            try
            {
                context.Update(hero);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Index");
            }
        }

        // GET: SuperheroController/Delete/5
        public ActionResult Delete(int id)
        {
            var superhero = context.Superheroes.Where(hero => hero.Id == id).SingleOrDefault();
            return View(superhero);
        }

        // POST: SuperheroController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Superhero hero)
        {
            try
            {
                context.Remove(hero);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Index");
            }
        }
    }
}
