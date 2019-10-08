using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CV.Core
{
    public class SystemSetting
    {

        public SystemSetting()
        {
            var parentFolderPath = Directory.GetParent(Directory.GetCurrentDirectory()).FullName;

            ResourceFolderPath = Path.Combine(parentFolderPath, "UploadFile");

            ResourceFolderEndpoint = "/UploadFile";
        }

        public static SystemSetting Current { set; get; }

        public string ResourceFolderEndpoint { set; get; }

        public string ResourceFolderPath { get; set; }
    }
}
