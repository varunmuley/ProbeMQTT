using System;
using System.Collections.Generic;
using System.Text;

namespace ProbeMQTT.Interfaces
{
    public interface IToastHelper
    {
        void LongAlert(string message);
        void ShortAlert(string message);
    }
}
