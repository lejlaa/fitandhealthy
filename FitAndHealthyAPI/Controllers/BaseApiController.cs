using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

/*
using FitAndHealthyAPI.Models;

namespace FitAndHealthyAPI.Controllers
{
    public class BaseApiController : ApiController
    {
        private baseInterface<T> depo;
        private ModelFactory fact;


        public BaseApiController(baseInterface<T> depo)
        {
            this.depo = depo;
        }

        protected baseInterface<T> timeDepo { get { return depo; } }

        protected ModelFactory timeFact
        {
            get
            {
                if (fact == null)

                    fact = new ModelFactory(depo.baseContext());

                return fact;
            }
        }
    }
}

*/