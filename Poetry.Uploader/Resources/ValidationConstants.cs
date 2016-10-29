using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poetry.Uploader.Resources
{
    public static class ValidationConstants
    {
        public static string MainViewModel_GramSize_Err
        {
            get { return "Gram Size must be greater than 0."; }
        }

        public static string CreatePoetViewModel_DuplicatePoetErr
        {
            get { return "Poet already exists."; }
        }

        public static string CreatePoetViewModel_FailedLoad
        {
            get { return "Poets failed to load"; }
        }

        public static string CreatePoetViewModel_FailedAddPoet
        {
            get { return "Unable to add poet."; }
        }
    }
}
