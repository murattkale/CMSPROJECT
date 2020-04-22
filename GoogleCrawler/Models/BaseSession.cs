
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class BaseSession : IBaseSessionMongo
{
    public BaseSession()
    {

    }
    public BaseModelMongo _BaseModel
    {
        get
        {
            return SessionRequest._User;

        }
        set
        {
            this._BaseModel = value;
        }
    }


}
