using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Safirex.CachingObjects
{
    public interface IGlobalCachingProvider
    {
        void AddItem(string key, object value);

        object GetItem(string key);
    }
}