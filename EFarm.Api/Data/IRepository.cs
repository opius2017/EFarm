﻿using EFarm.Api.Model;

namespace EFarm.Api.Data;

public interface IRepository<T> where T : BaseEntity
{
	IEnumerable<T> GetAll();
	T Get(long id);
	void Insert(T entity);
	void Update(T entity);
	void Delete(T entity);

}