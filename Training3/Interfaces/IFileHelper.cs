using System;
using System.Collections.Generic;
using System.Text;

namespace Training3.Interfaces
{
    public interface IFileHelper
    {
        string GetAllFilesByDirectory(string directory);
        string SearchFileByPartialName(string partialName, string directory);
    }
}
