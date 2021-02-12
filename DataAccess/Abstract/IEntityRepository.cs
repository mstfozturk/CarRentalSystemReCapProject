using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    //DataAccess te interface içeriği aynı olduğu için tekrarı önlemek için base interface oluşturuldu.
    public interface IEntityRepository<T> where T: class,IEntity, new() //T referans tipte newlenebilir bir entity olmalı
    {
        void Add(T entity); 
        void Delete(T entity);
        void Update(T entity);
        List<T> GetAll(Expression<Func<T,bool>> filter=null); //Filtre verilmezse hepsini getir 
        T Get(Expression<Func<T, bool>> filter ); //filtre girilmek zorunda
    }
}
