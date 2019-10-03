using CV.Utils.Utils.Check;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CV.Utils.Utils.Data
{
    public class DirectoryHelper
    {
        public static void CreateIfNotExist(params string[] paths)
        {
            foreach (var path in paths)
            {
                CheckHelper.CheckNullOrWhiteSpace(path, nameof(paths));

                var fullPath = PathHelper.GetFullPath(path);

                if (!Directory.Exists(fullPath))
                {
                    Directory.CreateDirectory(fullPath);
                }
            }
        }
    }
}
