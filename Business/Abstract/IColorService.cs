using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IColorService
    {
        void Add(Color color);
        void Delete(Color color);
        List<Color> GetAll();
        void Update(Color color);
        Color GetColorById(int colorId);
        
    }
}
