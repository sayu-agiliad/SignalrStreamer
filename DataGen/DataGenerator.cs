using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LiveStreamer.DataGen
{
    public class DataGenerator
    {
        private AutoResetEvent _autoResetEvent;
        private Timer _timer;
        private Action _action;

        public DataGenerator(Action action)
        {
            this._action = action;
            _autoResetEvent = new AutoResetEvent(false);
            _timer = new Timer(Execute, _autoResetEvent, 1000, 1000);

        }

        private void Execute(object state)
        {
            this._action();
        }
    }
}
