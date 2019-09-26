using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;



namespace AutoCAD_SelectByLayer
{
    public partial class LayerSelect : Form
    {

        List<string> layersList = new List<string>();
        private List<Object> selectedObjects = new List<object>();
        public List<string> debugList = new List<string>();

        ObjectIdCollection objectsToSelect;

        //SelectionSet preSelected;

        public object OwningWindowSettings { get; private set; }

        public LayerSelect()
        {
            InitializeComponent();

            Document doc = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument;
            Database db = doc.Database;
            Editor ed = doc.Editor;


            layersList = LayersToList(db);
            layer_listBox.DataSource = layersList;


            objectsToSelect = new ObjectIdCollection();



            using (Transaction tr = db.TransactionManager.StartOpenCloseTransaction())
            {

            PromptSelectionResult acSSPrompt;
            acSSPrompt = ed.SelectImplied();
            SelectionSet acSSet;
               
            // If the prompt status is OK, objects were selected before
            // the command was started
            if (acSSPrompt.Status == PromptStatus.OK)
            {
                acSSet = acSSPrompt.Value;

                //Autodesk.AutoCAD.ApplicationServices.Application.ShowAlertDialog("Number of objects in Pickfirst selection: " +
                //                            acSSet.Count.ToString());

                foreach (ObjectId objectId in acSSet.GetObjectIds())
                {
                    objectsToSelect.Add(objectId);
                }

            }

            }

            UpdateDebugPanel();
            MakeSelection();

        }

        private void Add_button_Click(object sender, EventArgs e)
        {
            AddToSelection();
        }

        private void Remove_button_Click(object sender, EventArgs e)
        {
            RemoveFromSelection();
        }

        private void Clear_button_Click(object sender, EventArgs e)
        {
            objectsToSelect.Clear();
            UpdateDebugPanel();
            MakeSelection();
        }

        private void Close_Button_Click(object sender, EventArgs e)
        {
            this.Close();

        }
        private void Layer_listBox_DoubleClick(object sender, EventArgs e)
        {
            AddToSelection();
        }

        private void AddToSelection()
        {
            Document doc = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument;
            Editor ed = doc.Editor;
            string selectedLayer = layer_listBox.SelectedItem.ToString();
            ObjectIdCollection ents = GetEntitiesOnLayer(selectedLayer);

            int addedCounter = 0;
            foreach (ObjectId ent in ents)
            {
                if (!objectsToSelect.Contains(ent))
                {
                    objectsToSelect.Add(ent);
                    addedCounter++;
                }
            }


            ed.WriteMessage(

              "\nADD: {0} entit{1} on layer {2}",

              addedCounter,

              (ents.Count == 1 ? "y" : "ies"),

              selectedLayer

            );



            UpdateDebugPanel();
            MakeSelection();
        }


        private void RemoveFromSelection()
        {

            Document doc = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument;
            Editor ed = doc.Editor;
            string selectedLayer = layer_listBox.SelectedItem.ToString();
            ObjectIdCollection ents = GetEntitiesOnLayer(selectedLayer);

            int removedCounter = 0;
            foreach (ObjectId ent in ents)
            {
                if (objectsToSelect.Contains(ent))
                {
                    objectsToSelect.Remove(ent);
                    removedCounter++;
                }
            }

            ed.WriteMessage(

            "\nREMOVE: {0} entit{1} on layer {2}",

            removedCounter,

            (ents.Count == 1 ? "y" : "ies"),

            selectedLayer

          );



            UpdateDebugPanel();
            MakeSelection();
        }



        private void MakeSelection()
        {
            Document doc = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument;
            Editor ed = doc.Editor;


            if (objectsToSelect.Count > 0)
            {

                ObjectId[] objectIds = new ObjectId[objectsToSelect.Count];

                ed.SetImpliedSelection(objectIds);

                for (int i = 0; i < objectsToSelect.Count; i++)
                {
                    objectIds[i] = objectsToSelect[i];
                }


                ed.SetImpliedSelection(objectIds);


            }

            ed.UpdateScreen();
        }

        private void LayerSelect_Load(object sender, EventArgs e)
        {
        }




        private List<string> LayersToList(Database db)
        {

            List<string> lstlay = new List<string>();

            LayerTableRecord layer;
            using (Transaction tr = db.TransactionManager.StartOpenCloseTransaction())
            {
                LayerTable lt = tr.GetObject(db.LayerTableId, OpenMode.ForRead) as LayerTable;
                foreach (ObjectId layerId in lt)
                {
                    layer = tr.GetObject(layerId, OpenMode.ForWrite) as LayerTableRecord;
                    lstlay.Add(layer.Name);
                }

            }
            return lstlay;
        }

        private void UpdateDebugPanel()
        {
            Document doc = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument;
            Database db = doc.Database;

            debugList.Clear();

            using (Transaction tr = db.TransactionManager.StartOpenCloseTransaction())
            {
                foreach (ObjectId objectId in objectsToSelect)
                {
                    String type = tr.GetObject(objectId, OpenMode.ForRead).GetType().ToString();
                    debugList.Add(type);
                }

            }


            if (objectsToSelect.Count == 0)
            {
                nSelected.Text = "NO ITEMS SELECTED";
            }
            else
            {
                nSelected.Text = String.Format("{0} ITEMS SELECTED", objectsToSelect.Count);
            }

            listBox_debug.DataSource = null;
            listBox_debug.DataSource = debugList;
        }


        private static ObjectIdCollection GetEntitiesOnLayer(string layerName)

        {

            Document doc = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument;
            Database db = doc.Database;
            Editor ed = doc.Editor;


            // Build a filter list so that only entities

            // on the specified layer are selected


            TypedValue[] tvs = new TypedValue[1]
            {
                new TypedValue( (int)DxfCode.LayerName, layerName)
            };

            SelectionFilter sf = new SelectionFilter(tvs);

            PromptSelectionResult psr = ed.SelectAll(sf);

            if (psr.Status == PromptStatus.OK)

                return

                  new ObjectIdCollection(

                    psr.Value.GetObjectIds()

                  );

            else

                return new ObjectIdCollection();

        }

    }
}

