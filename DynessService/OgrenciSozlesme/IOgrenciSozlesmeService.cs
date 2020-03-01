using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using GenericRepository;
using Entity;
using System;


public interface IOgrenciSozlesmeService : IGenericRepo<OgrenciSozlesme>
{
    RModel<OgrenciSozlesme> InsertOrUpdate(OgrenciSozlesme model);

}

