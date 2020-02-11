using Friuts;
using System.Windows.Forms;

namespace Bsoft.AppCom
{
    public class ComboLoaders
    {
        public static void LoadDrCr(ComboBox cbo, bool forSearch, bool allowEdit)
        {
            cbo.Items.Clear();
            //set the combobox default properties
            if (allowEdit)
                cbo.DropDownStyle = ComboBoxStyle.DropDown;
            else
                cbo.DropDownStyle = ComboBoxStyle.DropDownList;

            cbo.AutoCompleteSource = AutoCompleteSource.ListItems;
            cbo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

            //add the items into the comboboxes
            if (forSearch)
                cbo.Items.Add(new ComboItem("-999999", "Any", ColumnTypes.String));
            int i = 1;
            cbo.Items.Add(new ComboItem("Dr", "Dr", ColumnTypes.String));
            i++;
            cbo.Items.Add(new ComboItem("Cr", "Cr", ColumnTypes.String));

            if (forSearch)
                cbo.SelectedIndex = 0;
        }

        public static void LoadSex(ComboBox cbo, bool forSearch)
        {
            LoadSex(cbo, forSearch, false);
        }

        public static void LoadSex(ComboBox cbo, bool forSearch, bool allowEdit)
        {
            cbo.Items.Clear();
            //set the combobox default properties
            if (allowEdit)
                cbo.DropDownStyle = ComboBoxStyle.DropDown;
            else
                cbo.DropDownStyle = ComboBoxStyle.DropDownList;

            cbo.AutoCompleteSource = AutoCompleteSource.ListItems;
            cbo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

            //add the items into the comboboxes
            if (forSearch)
                cbo.Items.Add(new ComboItem("-999999", "Any Sex", ColumnTypes.String));
            int i = 1;
            cbo.Items.Add(new ComboItem(i.ToString(), "Male", ColumnTypes.Number));
            i++;
            cbo.Items.Add(new ComboItem(i.ToString(), "Female", ColumnTypes.Number));

            if (forSearch)
                cbo.SelectedIndex = 0;
        }

        /// <summary>
        /// Loads the possible ward nos in the combo box.
        /// </summary>
        /// <param name="cbo">the comboBox in which the ward no has to be loaded.</param>
        public static void LoadWardNo(ComboBox cbo, bool forSearch)
        {
            LoadWardNo(cbo, forSearch, false);
        }

        public static int MaxWardNo = 17;

        /// <summary>
        /// Loads the possible ward nos in the combo box.
        /// </summary>
        /// <param name="cbo">the comboBox in which the ward no has to be loaded.</param>
        public static void LoadWardNo(ComboBox cbo, bool forSearch, bool allowEdit)
        {
            cbo.Items.Clear();
            //set the combobox default properties
            if (allowEdit)
                cbo.DropDownStyle = ComboBoxStyle.DropDown;
            else
                cbo.DropDownStyle = ComboBoxStyle.DropDownList;

            cbo.AutoCompleteSource = AutoCompleteSource.ListItems;
            cbo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

            //add the items into the comboboxes
            if (forSearch)
                cbo.Items.Add(new ComboItem("-999999", "Any Wada No", ColumnTypes.String));
            int i;
            for (i = 1; i <= MaxWardNo; i++)
            {
                cbo.Items.Add(new ComboItem(i.ToString(), i.ToString(), ColumnTypes.Number));
            }
            if (forSearch)
                cbo.SelectedIndex = 0;
        }
    }
}