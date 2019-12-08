using System;
using System.Collections.Generic;
using System.Text;
using Training10.Interfaces;

namespace Training10.Services
{
    public class CounterService
    {
        protected internal ICounter Counter { get; }
        public CounterService(ICounter counter)
        {
            Counter = counter;
        }
    }
}
