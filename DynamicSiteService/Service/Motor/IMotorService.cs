using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;


using System;



public interface IMotorService : IGenericRepo<Motor>
{
    RModel<Motor> InsertOrUpdate(Motor Motor);

}

