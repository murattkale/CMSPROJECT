using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using GenericRepository;
using Entity;
using System;


public interface IOgrenciSozlesmeYayinService : IGenericRepo<OgrenciSozlesmeYayin>
{
    RModel<OgrenciSozlesmeYayin> InsertOrUpdate(OgrenciSozlesmeYayin model);

}

