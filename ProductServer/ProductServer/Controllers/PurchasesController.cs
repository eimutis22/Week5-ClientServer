using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProductServer.Controllers
{
    [Authorize(Roles = "PurchasesManager")]
    public class PurchasesController : ApiController
    {
    }
}
