using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IColorService
    {
        IResult Add(Color color);
        IResult Delete(Color color);
        IDataResult<List<Color>> GetAll();
        IResult Update(Color color);
        IDataResult<Color> GetColorById(int colorId);
        
    }
}
