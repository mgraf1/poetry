using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poetry.Uploader.Services.Messages
{
    public class OpenFileResultMessage : MessageBase
    {
        public bool Result { get; set; }
        public string FilePath { get; set; }

        public OpenFileResultMessage(bool? result, string filePath)
        {
            if (result.HasValue && result.Value)
            {
                FilePath = filePath;
                Result = true;
            }
            else
            {
                Result = false;
            }
        }
    }
}
