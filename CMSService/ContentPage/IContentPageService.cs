﻿using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;

using Entity;
using System;



public interface IContentPageService : IGenericRepo<ContentPage>
{
    RModel<ContentPage> InsertOrUpdate(ContentPage model);

}

