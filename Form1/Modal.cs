using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Form1
{
    public class Modal
    {
        // клас який зберігає методи для обчеслення різних операцій

        public string ConvertToHrn(decimal sumUsd)
        {
            return (sumUsd * 26.3m).ToString();
        }

        public string ConvertToUsd(decimal sumUah)
        {
            return (sumUah / 26.3m).ToString("F2");
        }
    }
}