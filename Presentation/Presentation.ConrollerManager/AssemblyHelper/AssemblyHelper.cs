
using System.Reflection;

namespace Presentation.ConrollerManager.AssemblyHelper
{
    public class AssemblyHelper
    {
        private static AssemblyHelper assemblyHelper;
        public static AssemblyHelper getAssemblyHelper
        {
            get { if (assemblyHelper == null) { assemblyHelper = new AssemblyHelper(); return assemblyHelper;}
                else return assemblyHelper;
            }
        }









    }
}
