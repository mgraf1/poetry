using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poetry.Uploader.Services.Messages
{
    public class SelectFileResultMessage : MessageBase
    {
        public bool Result { get; set; }
        public string FilePath { get; set; }

        public SelectFileResultMessage(bool? result, string filePath)
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
