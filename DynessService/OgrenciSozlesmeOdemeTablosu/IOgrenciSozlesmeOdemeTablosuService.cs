using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using GenericRepository;
using Entity;
using System;


public interface IOgrenciSozlesmeOdemeTablosuService : IGenericRepo<OgrenciSozlesmeOdemeTablosu>
{
    RModel<OgrenciSozlesmeOdemeTablosu> InsertOrUpdate(OgrenciSozlesmeOdemeTablosu model);

}

