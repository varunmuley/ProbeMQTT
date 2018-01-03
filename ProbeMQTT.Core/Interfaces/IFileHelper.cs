using System;
using System.Collections.Generic;
using System.Text;

namespace ProbeMQTT.Interfaces
{
    public interface IFileHelper 
    {
        string GetLocalFilePath(string filename);
    }
}
