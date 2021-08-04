﻿using HotelListing.IRepository;
using HotelListing.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelListing.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _context;

        public UnitOfWork(DatabaseContext context)
        {
            _context = context;
        }

        private IGenericRepository<Country> _countries;

        private IGenericRepository<Hotel> _hotels;

        public IGenericRepository<Country> Countries => _countries ??= new GenericRepository<Country>(_context);
        public IGenericRepository<Hotel> Hotels=>  _hotels ??= new GenericRepository<Hotel>(_context);

       

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }



        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
