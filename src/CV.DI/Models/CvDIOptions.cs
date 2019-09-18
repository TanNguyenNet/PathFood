using Microsoft.Extensions.PlatformAbstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace CV.DI.Models
{
    public class CvDIOptions
    {
        public List<string> ListAssemblyFolderPath { get; set; } = new List<string> { PlatformServices.Default.Application.ApplicationBasePath };

        /// <summary>
        ///     List assembly name to scan, default is application name. 
        /// </summary>
        /// <remarks>Default is root assembly name, e.g: Elect.DI.dll => Scan Elect.dll and Elect.*.dll </remarks>
        public List<string> ListAssemblyName { get; set; } = new List<string> { PlatformServices.Default.Application.ApplicationName };
    }
}
