using System;
using System.Collections.Generic;
using System.Text;

namespace App1.DependencyServices
{
    public interface ICookieManagerService
    {
        string GetCookies(string url);
    }
}
