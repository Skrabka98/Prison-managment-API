﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PrisonBack.Domain.Models;
using PrisonBack.Domain.Repositories;
using PrisonBack.Persistence.Context;
using PrisonBack.Resources.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PrisonBack.Persistence.Repositories
{
    public class PrisonerRepository : BaseRepository, IPrisonerRepository
    {
        public PrisonerRepository(AppDbContext context) : base(context)
        {

        }
        public async Task<IEnumerable<Prisoner>> AllPrisoner(string userName)
        {
            var prison = _context.UserPermissions.FirstOrDefault(x => x.UserName == userName);

            return await _context.Prisoners.Where(x => x.Cell.IdPrison == prison.IdPrison).Include(x => x.Punishments).ToListAsync();


        }
        public async Task<IEnumerable<UserPermission>> Prison(string userName)
        {
            return await _context.UserPermissions.Where(x => x.UserName == userName).ToListAsync();

        }

        public void CreatePrisoner(Prisoner prisoner)
        {
            _context.Prisoners.Add(prisoner);
        }

        public void DeletePrisoner(Prisoner prisoner)
        {
            _context.Prisoners.Remove(prisoner);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public Prisoner SelectedPrisoner(int id)
        {
            return _context.Prisoners.FirstOrDefault(x => x.Id == id);

        }

        public void UpdatePrisoner(Prisoner prisoner)
        {
        }
        public int PrisonID(string userName)
        {
            var prison = _context.UserPermissions.FirstOrDefault(x => x.UserName == userName);
            return prison.IdPrison;
        }
    }
}
