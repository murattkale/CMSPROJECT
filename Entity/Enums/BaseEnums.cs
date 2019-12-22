using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;


public enum RType
{
    OK = 1,
    Error = 2,
    Warning = 3
}

public enum LoginErrorType
{
    Error = -1,
    Success = 0,
    Page = 1,
    Permission = 2,
    Role = 3,
    User = 4,
}

public enum FormType
{
    [Description("Anasayfa")]
    Anasayfa = 1,
    [Description("Şube")]
    Şube = 2,
    [Description("Franch")]
    Franch = 3,
    [Description("Diğer")]
    Diger = 4,
    [Description("ilkteknem.com")]
    ilkteknem = 9,
}

public enum GelirGiderType
{
    [Description("Gelir")]
    Gelir = 1,
    [Description("Gider")]
    Gider = 2,
}




