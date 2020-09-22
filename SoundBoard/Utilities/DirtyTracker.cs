using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoundBoard.Utilities
{
    public class DirtyTracker
    {
        private DataGridView audioHotkeysDataGrid, ctrlHotkeysDataGrid, fadingValuesDataGrid;
        private string[] audioHotkeysDataGridCleanValues, ctrlHotkeysDataGridCleanValues, fadingValuesDataGridCleanValues;
        private Dictionary<DataGridView, string[]> gridsAndValuesToCompare;

        public DirtyTracker(DataGridView audioHotkeysDataGrid, DataGridView ctrlHotkeysDataGrid, DataGridView fadingValuesDataGrid)
        {
            int i;
            audioHotkeysDataGridCleanValues = new string[audioHotkeysDataGrid.Rows.Count];
            for (i = 0; i < audioHotkeysDataGrid.Rows.Count; ++i)
            {
                audioHotkeysDataGridCleanValues[i] = getStringValueOfDataGridRow(audioHotkeysDataGrid.Rows[i]);
            }
            ctrlHotkeysDataGridCleanValues = new string[ctrlHotkeysDataGrid.Rows.Count];
            for (i = 0; i < ctrlHotkeysDataGrid.Rows.Count; ++i)
            {
                ctrlHotkeysDataGridCleanValues[i] = getStringValueOfDataGridRow(ctrlHotkeysDataGrid.Rows[i]);
            }
            fadingValuesDataGridCleanValues = new string[fadingValuesDataGrid.Rows.Count];
            for (i = 0; i < fadingValuesDataGrid.Rows.Count; ++i)
            {
                fadingValuesDataGridCleanValues[i] = getStringValueOfDataGridRow(fadingValuesDataGrid.Rows[i]);
            }
            this.audioHotkeysDataGrid = audioHotkeysDataGrid;
            this.ctrlHotkeysDataGrid = ctrlHotkeysDataGrid;
            this.fadingValuesDataGrid = fadingValuesDataGrid;
            gridsAndValuesToCompare = new Dictionary<DataGridView, string[]>()
            {
                {audioHotkeysDataGrid,  audioHotkeysDataGridCleanValues},
                {ctrlHotkeysDataGrid,  ctrlHotkeysDataGridCleanValues},
                {fadingValuesDataGrid,  fadingValuesDataGridCleanValues}
            };
        }

        private string getStringValueOfDataGridRow(DataGridViewRow row)
        {
            string rowValue = "";
            int i;
            for (i = 0; i < row.Cells.Count; ++i)
            {
                rowValue += row.Cells[i].Value?.ToString();
            }
            return rowValue;
        }

        public bool isFormDirty()
        {
            bool dirty = false;
            int i = 0;
            
            if (audioHotkeysDataGrid.Rows.Count != audioHotkeysDataGridCleanValues.Length || ctrlHotkeysDataGrid.Rows.Count != ctrlHotkeysDataGridCleanValues.Length || fadingValuesDataGrid.Rows.Count != fadingValuesDataGridCleanValues.Length)
            {
                dirty = true;
            }
            else
            {
                string[] dataGridCurrentValues;
                foreach (DataGridView dataGrid in gridsAndValuesToCompare.Keys)
                {
                    dataGridCurrentValues = new string[dataGrid.Rows.Count];
                    for (i = 0; i < dataGrid.Rows.Count; ++i)
                    {
                        dataGridCurrentValues[i] = getStringValueOfDataGridRow(dataGrid.Rows[i]);
                    }
                    if (!new HashSet<string>(dataGridCurrentValues).SetEquals(gridsAndValuesToCompare[dataGrid]))
                    {
                        dirty = true;
                        break;
                    }
                }
            }

            return dirty;
        }
    }
}
