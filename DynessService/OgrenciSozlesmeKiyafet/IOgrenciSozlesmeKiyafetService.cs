using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;

using Entity;
using System;


public interface IOgrenciSozlesmeKiyafetService : IGenericRepo<OgrenciSozlesmeKiyafet>
{
    RModel<OgrenciSozlesmeKiyafet> InsertOrUpdate(OgrenciSozlesmeKiyafet model);

}

