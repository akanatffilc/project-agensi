using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Agensi.Web.Core.Context
{
    public partial class AgensiHttpContextWrapper : HttpContextWrapper
    {
        private const string ContextKey = "AgensiHttpContext";
        private readonly HttpContext _context;

        private AgensiHttpContextWrapper(HttpContext context)
            : base(context)
        {
            _context = context;
        }

        public static AgensiHttpContextWrapper Current
        {
            get
            {
                var current = HttpContext.Current;
                if (current == null)
                    return null;

                var instance = current.Items[ContextKey] as AgensiHttpContextWrapper;
                if (instance != null)
                    return instance;

                var newInstance = new AgensiHttpContextWrapper(current);
                current.Items[ContextKey] = newInstance;
                return newInstance;
            }
        }
    }
}