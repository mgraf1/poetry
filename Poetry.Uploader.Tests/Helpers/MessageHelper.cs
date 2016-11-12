using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoetryTests.Helpers
{
    public class MessageHelper
    {
        private bool _messageReceived;
        public void TestMessageReceived<T>()
        {
            _messageReceived = false;
            Messenger.Default.Register<T>(this,
                msg =>
                {
                    if (msg != null)
                    {
                        _messageReceived = true;
                    }
                    Messenger.Default.Unregister<T>(this);
                });
        }

        public bool WasMessageReceived()
        {
            return _messageReceived;
        }
    }
}
