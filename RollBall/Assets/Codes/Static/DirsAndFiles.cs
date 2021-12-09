using System.IO;
using UnityEngine;

namespace Kravchuk
{
    /// <summary>
    /// Contain path to folders and files
    /// </summary>
    public static class DirsAndFiles
    {
        public static string SaveDir = Path.Combine(Application.dataPath, "Save");
        public static string SaveFileNameXML = "data.xml";
    }
}
