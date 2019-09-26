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


using Autodesk.AutoCAD.Windows;
using Autodesk.AutoCAD.Geometry;

namespace AutoCAD_SelectByLayer

{
    public class AutoCAD_PluginCollection
    {

        [CommandMethod("SelectByLayer", CommandFlags.UsePickSet)] //AutoCAD plugin command
        public void SelectByLayer()
        {
            var layerSelectDialog = new LayerSelect();

            layerSelectDialog.Show();

        }


        [CommandMethod("ImportFormQGIS")] //AutoCAD plugin command
        public void ImportFormQGIS()
        {
            Document doc = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument;
            Database db = doc.Database;
            Editor ed = doc.Editor;

            Autodesk.AutoCAD.Windows.OpenFileDialog ofd = new Autodesk.AutoCAD.Windows.OpenFileDialog(
                "Select DXF file exported from QGIS - v0.1 - Frans Nygaard 2019",
                null,
                "dxf",
                "Select DXF",
                Autodesk.AutoCAD.Windows.OpenFileDialog.OpenFileDialogFlags.DoNotTransferRemoteFiles
                );

            System.Windows.Forms.DialogResult dr = ofd.ShowDialog();

            ed.WriteMessage(ofd.Filename);

            Database sourceDb = new Database(false, true);
            Transaction trSource = sourceDb.TransactionManager.StartTransaction(); //Start a transaction with the source's database
            DocumentLock docLock = doc.LockDocument();
            using (trSource)
            using (docLock)
            {
                sourceDb.DxfIn(ofd.Filename, ofd.Filename + ".log");

                // MOVE ALL FILES TO LAYER NAMED AFTER DXF FILENAME


                ed.WriteMessage(ofd.Filename);
                trSource.Commit();
            }


            Transaction trDb = db.TransactionManager.StartTransaction(); //Start a transaction with the document's database
            Matrix3d transform = Matrix3d.Scaling(1000, Point3d.Origin);
            using (trDb)
            {
                db.Insert(transform, sourceDb, false);
                trDb.Commit();
            }
        }

    }
}

