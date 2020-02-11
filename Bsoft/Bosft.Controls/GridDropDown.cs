using Bsoft.Common;
using Bsoft.Common.Utilities;
using System;
using System.Data;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class GridDropDown : UserControl
    {
        //Events
        public delegate void rowSelectedHandler(Object sender, int selectedIndex);

        public event rowSelectedHandler RowSelected;

        //settings
        public int DisplayColumn { get; set; }

        public int KeyColumn { get; set; }

        public int Limit { get; set; }

        public int SelectedRow { get; set; }

        public DataTable Data
        {
            get
            { return _data; }
            set
            {
                if (DesignMode || value == null)
                {
                    return;
                }

                _data = value;
                s = new DataTableSearchClass(value);
                s.Limit = Limit;
            }
        }

        private DataTable _data;
        private DataTableSearchClass s;
        private GridSizeUtility g = new GridSizeUtility();

        private bool gridSelected = false;// reqd to make grid visible during textbox leave also
        private bool selectingFromGrid = false;//to make sure text dont fire search when direcly selecting from grid

        public GridDropDown()
        {
            Limit = -1;
            DisplayColumn = 0;
            SelectedRow = -1;
            KeyColumn = 0;
            InitializeComponent();
            AutoSize = true;
        }

        private void mainTextBox_Enter(object sender, EventArgs e)
        {
            if (mainTextBox.Text.Length > 0)
            {
                grid.Visible = true;
                Height = grid.Bottom + 3;
            }
            this.BringToFront();
        }

        private void mainTextBox_Leave(object sender, EventArgs e)
        {
            if (!gridSelected)
            {
                grid.Visible = false;
                Height = mainTextBox.Bottom + 2;
            }
        }

        private void mainTextBox_TextChanged(object sender, EventArgs e)
        {
            if (mainTextBox.Text.Length > 0)
            {
                grid.Visible = true;
            }
            else
            {
                grid.Visible = false;
            }

            try
            {
                if (!selectingFromGrid)
                {
                    grid.DataSource = s.Search(mainTextBox.Text);
                    g.AdjustSize(grid);
                }
            }
            catch
            {//null returnced from search so ignore
            }
        }

        private void mainTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                gridSelected = true;
                grid.Select();
                selectingFromGrid = true;
            }
            else
            {
                selectingFromGrid = false;
                if (e.KeyCode == Keys.Enter)
                {
                    selectRow();
                    grid.Visible = false;
                }
            }
        }

        private void grid_SelectionChanged(object sender, EventArgs e)
        {
            if (selectingFromGrid)
            {
                selectRow();
            }
        }

        private void grid_DoubleClick(object sender, EventArgs e)
        {
            selectRow();
            grid.Visible = false;
        }

        private void grid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                selectRow();
                grid.Visible = false;
            }
        }

        private void selectRow()
        {
            if (grid.SelectedRows.Count > 0)
            {
                SelectedRow = GetIndex(grid.SelectedRows[0].Cells[KeyColumn].Value.ToString());
                mainTextBox.Text = grid.SelectedRows[0].Cells[DisplayColumn].Value.ToString();
                if (RowSelected != null)
                {
                    RowSelected(this, SelectedRow);
                }
            }
            else
            {
                SelectedRow = -1;
                mainTextBox.Text = string.Empty;
            }
        }

        private int GetIndex(string keyvalue)
        {
            for (int i = 0; i < _data.Rows.Count; i++)
            {
                if (_data.Rows[i][KeyColumn].ToString() == keyvalue)
                {
                    return i;
                }
            }
            return -1;
        }

        public string GetSelectedValue(string column)
        {
            try
            {
                return _data.Rows[SelectedRow][column].ToString();
            }
            catch
            {
                throw;
            }
        }
    }
}