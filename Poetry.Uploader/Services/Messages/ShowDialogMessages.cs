using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poetry.Uploader.Services.Messages
{
    public static class ShowDialogMessages
    {
        public class OpenFileMessage : MessageBase { }
        public class UploadPoemMessage : MessageBase { }
        public class PoetSelectionMessage : MessageBase { }
        public class CreatePoetMessage : MessageBase { }
    }
}
