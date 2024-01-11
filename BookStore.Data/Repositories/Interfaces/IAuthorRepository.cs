﻿using BookStore.Data.Entities;
using BookStore.Data.Repositories.Interfaces.Base;

namespace BookStore.Data.Repositories.Interfaces;

public interface IAuthorRepository : IGenericRepository<Author,int>
{
    
}