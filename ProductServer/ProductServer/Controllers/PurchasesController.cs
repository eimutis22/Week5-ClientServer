using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProductServer.Controllers
{
    [Authorize(Roles = "PurchasesManager")]
    [RoutePrefix("api/Purchases")]
    public class PurchasesController : ApiController
    {
    }
}
