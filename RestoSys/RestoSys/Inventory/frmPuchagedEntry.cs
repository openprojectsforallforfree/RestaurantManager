using Bsoft.AppCom;
using Bsoft.Common;
using Bsoft.Forms;
using Friuts;
using RestoSys.BLL;
using RestoSys.DAl;
using System;
using System.Data;
using System.Windows.Forms;

namespace RestoSys.Inventory
{
    [System.ComponentModel.DesignerCategory("form")]
    public partial class frmPuchagedEntry : Bsoft.Design.EntryFromDesignBase
    {
        public frmPuchagedEntry()
        {
            InitializeComponent();

            ComboBoxDataLoader loader = new ComboBoxDataLoader();
            loader.ComboLoadinfoItems.Add("ID", "Name", "Master_Vendor", cboVendor, true);
            loader.LoadDataInComboBoxes();
            TableName = "Inv_Purchase";
            ColumnList.AddNewEditColumn("Id", ColumnTypes.Number, txtId, true, false);
            ColumnList.AddNewEditColumn("ManufactureDate", ColumnTypes.String, dtManufacture);
            ColumnList.AddNewEditColumn("ExpiryDate", ColumnTypes.String, dtExpiry);
            ColumnList.AddNewEditColumn("fk_Product", ColumnTypes.Number, txtProduct, true, "Product", "");
            ColumnList.AddNewEditColumn("fk_Vendor", ColumnTypes.Number, cboVendor);
            ColumnList.AddNewEditColumn("Quantity", ColumnTypes.Number, txtQuantity, true, "Quantity", "");
            ColumnList.AddNewEditColumn("CostPrice", ColumnTypes.Number, txtCostPrice, true, "Cost Price", "");
            ColumnList.AddNewEditColumn("SellingPrice", ColumnTypes.Number, txtSellingPrice, true, "Selling Price", "");
            ColumnList.AddNewEditColumn("PurchageDate", ColumnTypes.String, dtPurchageDate.Value.ToString("yyyyMMdd"));

            if (FormType == FormTypes.EntryForm)
            {
                ColumnList.AddNewEditColumn("quantity_damage", ColumnTypes.Number, 0);
                ColumnList.AddNewEditColumn("quantity_sold", ColumnTypes.Number, 0);
            }
            ColumnList.Add("Remarks", ColumnTypes.String, txtRemarks);
            ColumnList.AddNewEditColumn("UserId", ColumnTypes.String, GlobalValues.LoginUserName);
            ColumnList.AddNewEditColumn("entrydate", ColumnTypes.String, DateTime.Now.ToString("yyyyMMdd"));

            this.AcceptButton = btnOk;
            this.CancelButton = btnCancel;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string product = "";
            if (txtGroup_Code.Focused)
            {
                clearValuesinLabel();
                string[] a;
                a = txtGroup_Code.Text.Split('.');
                if (a.Length != 2)
                {
                    if (StringUtilities.IsInteger(txtGroup_Code.Text.Trim()))
                    {
                        //bar code
                        product = RestoSysDAl.GetProductIdFromBarCode(txtGroup_Code.Text.Trim());
                    }
                    else
                    {
                        //Search
                        txtProduct.Text = "";
                        searhItemClick(txtGroup_Code.Text);
                        txtQuantity.Focus();
                        return;
                    }
                }
                else
                {
                    product = RestoSys.Inventory.dal.GetProductIdFromCode(a[0], a[1]);
                }
                try
                {
                    if (product == null)
                    {
                        MessageBox.Show("Product Not found Please check the code.");
                        txtProduct.Text = "";
                        return;
                    }
                    else
                    {
                        ProductIsSelected(product);
                        txtProduct.Text = product;
                    }
                }
                catch { return; }
                txtQuantity.Focus();
                return;
            }
            try
            {
                if (txtCostPrice.Text.Trim().Length < 1)
                {
                    txtCostPrice.Focus();
                    return;
                }
                if (txtSellingPrice.Text.Trim().Length < 1)
                {
                    txtSellingPrice.Focus();
                    return;
                }
                double cp = Convert.ToDouble(txtCostPrice.Text.Trim());
                double sp = Convert.ToDouble(txtSellingPrice.Text.Trim());

                if (cp > sp)
                { MessageBoxMy.Show("Cost price can not be more than selling price ", MessageBoxButtons.OK); return; }
            }
            catch
            {
                MessageBoxMy.Show("Please give proper cost and selling price.", MessageBoxButtons.OK); return;
            }
            if (Save())
            {
                RestoSys.RestoSysDAl.UpdatequantityTOStore(PurchageTable.GetLatestID().ToString(), txtProduct.Text, "", txtQuantity.Text, StockType.Purchase);
            }
            string s = UpdateSQL;
        }

        //When the search is cliked or code entered in text box
        private void searhItemClick(string searchString)
        {
            RestoSys.MasterEntry.frmProductList frm = new RestoSys.MasterEntry.frmProductList();
            frm.FormType = FormTypes.SelectionForm;
            frm.StockCode = string.Format("'{0}' , '{1}', '{2}' ", ItemType.Consumable, ItemType.Ingredient, ItemType.Retail);
            frm.Text = "Purchase : Items that can be purchased";
            frm.Text = "Select " + frm.Text;
            frm.txtName.Text = searchString;
            frm.valueSelected += new ListingFormBase.ValueSelected(frm_valueSelected);
            frm.ShowDialog(this);
        }

        private void clearValuesinLabel()
        {
            lblName.Text = lblfk_Group.Text = lblfk_Company.Text = "";
            lblsizeunit.Text = lblweightunit.Text = lblcolour.Text = lblweight.Text = "";
            lblsize.Text = lblRemarks.Text = "";
            lblMeasureUnit.Text = "";
        }

        private void displayvaluesinLabel(DataTable productddt)
        {
            if (productddt.Rows.Count > 0)
            {
                lblName.Text = productddt.Rows[0]["Name"].ToString();
                lblfk_Group.Text = dal.getGroup(productddt.Rows[0]["fk_Group"].ToString());
                lblfk_Company.Text = dal.getCompany(productddt.Rows[0]["fk_Company"].ToString());
                lblsizeunit.Text = dal.getUnit(productddt.Rows[0]["fk_sizeunit"].ToString());
                lblweightunit.Text = dal.getUnit(productddt.Rows[0]["fk_weightunit"].ToString());
                lblcolour.Text = productddt.Rows[0]["colour"].ToString();
                lblweight.Text = productddt.Rows[0]["weight"].ToString();
                lblsize.Text = productddt.Rows[0]["size"].ToString();
                lblRemarks.Text = productddt.Rows[0]["Remarks"].ToString();
                lblMeasureUnit.Text = dal.getUnit(productddt.Rows[0]["fk_MeasureUnit"].ToString());
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmPuchagedEntry_Load(object sender, EventArgs e)
        {
            this.FirstControl = txtGroup_Code;
            txtGroup_Code.Select();
            calculatorButton1.AssociatedControl = txtCostPrice;
            calculatorButton2.AssociatedControl = txtSellingPrice;
        }

        public override bool LoadData()
        {
            base.LoadData();
            txtGroup_Code.Text = ProductIsSelected(txtProduct.Text);
            //dtExpiry.Text = dtExpiry.Text;
            //dtManufacture.Text = dtManufacture.Text;
            return true;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            RestoSys.MasterEntry.frmProductList frm = new RestoSys.MasterEntry.frmProductList();
            frm.FormType = FormTypes.SelectionForm;
            frm.toolStrip1.Enabled = false;
            frm.valueSelected += new ListingFormBase.ValueSelected(frm_valueSelected);
            frm.Filter = "Filter Products";
            frm.ShowDialog(this);
            txtQuantity.Focus();
        }

        private void frm_valueSelected(object sender, string SelectedPrimaryKey)
        {
            //DataGridViewRow row = (DataGridViewRow)((ListingFormBase)sender).SelectedValue;
            // DataGridViewRow row = (DataGridViewRow)frm.SelectedValue;
            string KEY = SelectedPrimaryKey;// row.Cells["colid"].Value.ToString();
            //SelectComboValue(cboProduct, KEY);
            txtProduct.Text = KEY;
            if (KEY != "")
            {
                txtGroup_Code.Text = ProductIsSelected(KEY);
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="prodid"></param>
        /// <returns>Retruns group.code</returns>
        private string ProductIsSelected(string prodid)
        {
            DataTable product = PurchageTable.GetProduct(prodid);
            displayvaluesinLabel(product);
            return ProductDAL.GetCode(prodid);
        }

        private void lblfk_Vendor_Click(object sender, EventArgs e)
        {
            RestoSys.MasterEntry.frmProductVendorList frm = new RestoSys.MasterEntry.frmProductVendorList();
            frm.ShowDialog();
            ComboBoxDataLoader loader = new ComboBoxDataLoader();
            loader.ComboLoadinfoItems.Add("ID", "Name", "Master_Vendor", cboVendor, true);
            loader.LoadDataInComboBoxes();
        }
    }
}