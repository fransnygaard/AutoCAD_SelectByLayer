using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoCAD_SelectByLayer

{
    public class Class1
    {

        [CommandMethod("SelectByLayer")] //AutoCAD plugin command
        public void SelectByLayer()
        {
            var layerSelectDialog = new LayerSelect();

            layerSelectDialog.Show();

        }


    }
}
