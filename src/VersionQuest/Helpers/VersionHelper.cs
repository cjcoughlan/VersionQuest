using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq;


namespace VersionQuest.Helpers
{
    public static class VersionHelper
    {
        public static int[] GetNumericVersionArray(string version)
        {
            var versionArray = version.Split(".");

            // Determine if version has all three segments and if not, zero fill
            for (var i = 0; i < 3; i++)
            {
                if (versionArray.ElementAtOrDefault(i) == null)
                {
                    //numOne[i] = "0";
                    versionArray = versionArray.Append("0").ToArray();
                }
            }

            var versionArrayNum = Array.ConvertAll(versionArray, int.Parse);

            return versionArrayNum;
        }

        public static int[] GetNumericSearchArray(string version)
        {
            var searchArray = version.Split(".");

            var searchArrayNum = Array.ConvertAll(searchArray, int.Parse);

            return searchArrayNum;
        }
    }
}
