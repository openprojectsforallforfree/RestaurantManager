using Bsoft.AppCom;
using Bsoft.Data;
using Bsoft.Forms;
using Friuts;
using RestoSys.MasterEntry;
using RestoSys.Tags;
using System;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace RestoSys.Inventory
{
    [System.ComponentModel.DesignerCategory("form")]
    public partial class frmDamageLossEntry : Bsoft.Design.EntryFromDesignBase
    {
        public frmDamageLossEntry()
        {
            InitializeComponent();

            TableName = "Inv_Damage_Loss_Return";
            ColumnList.AddNewEditColumn("Id", ColumnTypes.Number, txtId, true, false);
            ColumnList.AddNewEditColumn("fk_Product", ColumnTypes.Number, txtProduct, true, "Product", "");
            ColumnList.AddNewEditColumn("Quantity", ColumnTypes.Number, txtQuantity);
            ColumnList.AddNewEditColumn("Remarks", ColumnTypes.String, txtRemarks);
            //ColumnList.AddNewEditColumn("loss_code",ColumnTypes.String , txtloss_code );
            ColumnList.AddNewEditColumn("UserId", ColumnTypes.Number, GlobalValues.LoginUserIDPk);
            ColumnList.AddNewEditColumn("entrydate", ColumnTypes.String, DateTime.Now.ToString("yyyyMMdd"));
            this.AcceptButton = btnOk;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

       
      
        //private int getComboID()
        //{
        //    string id;
        //    ComboItem ci=         (ComboItem)cboProduct.SelectedItem;
        //    id=  ci.Key.ToString ();
        //    return Convert.ToInt16(id);
        //}
        private void UpdatequantityTOStore(string id, double damageqty, double quantity)
        {
            double quantityinstore = quantity - damageqty;

            double totaldamagequantity;

            totaldamagequantity = Convert.ToDouble(clsDataAccess . getDamagequantity(id));
           clsDataAccess. UpdateProduct(id, quantityinstore);

            totaldamagequantity += damageqty;

           clsDataAccess. UpdateDamaged(id, totaldamagequantity);
        }

    
     

        private void groupBox1_Enter(object sender, EventArgs e)
        {
        }

        private void clearValuesinLabel()
        {
            lblListPrice.Text = "";

            lblName.Text = lblfk_Group.Text = lblfk_Company.Text = "";

            lblsizeunit.Text = lblweightunit.Text = lblcolour.Text = lblweight.Text = "";

            lblsize.Text = lblentrydate.Text = "";
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (txtGroup_Code.Focused)
            {
                clearValuesinLabel();
                string[] a;
                a = txtGroup_Code.Text.Split('.');
                if (a.Length != 2)
                {
                    MessageBox.Show("Please give code in format : Group Code.Item Code eg 25.201");
                    return;
                }
                string product;
                product = dal.GetProductIdFromCode(a[0], a[1]);
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
                return;
            }
            string id;
            double damageqty, quantity;
            id = txtProduct.Text;
            quantity =clsDataAccess . getquantity(id.ToString());
            damageqty = Convert.ToDouble(txtQuantity.Text);
            if (damageqty > quantity)
            {
                MessageBoxMy.Show("There are only " + quantity.ToString() + " in store . Damage cannot be more than that quantity.", MessageBoxButtons.OK);
                return;
            }
            if (Save())
            {
                UpdatequantityTOStore(id, damageqty, quantity);
            }
        }

        private void frmDamageLossEntry_Load(object sender, EventArgs e)
        {
            this.FirstControl = txtProduct;
            //ComboBoxDataLoader loader = new ComboBoxDataLoader();

            //loader.ComboLoadinfoItems.Add("ID", "code", "Master_Product", cboProduct , true);
            ////  loader.ComboLoadinfoItems.Add("ID", "id", "Inv_Purchase", cboPurchage, true);
            //loader.LoadDataInComboBoxes();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            RestoSys.MasterEntry.frmProductList frm = new RestoSys.MasterEntry.frmProductList();
            frm.FormType = FormTypes.SelectionForm;
            frm.toolStrip1.Enabled = false;
            frm.valueSelected += new ListingFormBase.ValueSelected(frm_valueSelected);
            frm.ShowDialog(this);
        }

        private void frm_valueSelected(object sender, string SelectedPrimaryKey)
        {
            //DataGridViewRow row = (DataGridViewRow)frm.SelectedValue;
            string KEY = SelectedPrimaryKey;// row.Cells["colid"].Value.ToString();
            //SelectComboValue(cboProduct, KEY);
            txtProduct.Text = KEY;
            if (KEY != "")
            {
                txtGroup_Code.Text = ProductIsSelected(KEY);
            }
        }

        private void displayvaluesinLabel(DataTable productddt)
        {
            //  if (product == null | product .Tables .Count ==0| product .Tables [0].Rows .Count ==0 )
            if (productddt.Rows.Count > 0)
            {
                //    lblListPrice.Text = productddt.Rows[0]["listprice"].ToString();

                lblName.Text = productddt.Rows[0]["Name"].ToString();

                lblfk_Group.Text = productddt.Rows[0]["fk_Group"].ToString();

                lblfk_Company.Text = productddt.Rows[0]["fk_Company"].ToString();

                lblsizeunit.Text =staticClasses. GetUnit(productddt.Rows[0]["fk_sizeunit"].ToString());

                lblweightunit.Text = staticClasses.GetUnit(productddt.Rows[0]["fk_weightunit"].ToString());

                lblcolour.Text = productddt.Rows[0]["colour"].ToString();

                lblweight.Text = productddt.Rows[0]["weight"].ToString();

                lblsize.Text = productddt.Rows[0]["size"].ToString();

                //   lblquantityinStore.Text = productddt.Rows[0]["quantity_instore"].ToString();

                lblentrydate.Text = productddt.Rows[0]["entrydate"].ToString();

                lblMeasureUnit.Text = staticClasses.GetUnit(productddt.Rows[0]["fk_MeasureUnit"].ToString());
            }
        }

        private string ProductIsSelected(string prodid)
        {//Retruns Group.code
            DataTable dt = new DataTable();
            string GroupId, groupCode, mycode, itemCode;

            GroupId = clsDataAccess.GetGroupId(prodid);

            DataSet product =clsDataAccess . isProductExist(prodid);
            displayvaluesinLabel(product.Tables[0]);

            groupCode = clsDataAccess.GetGroupCode(GroupId);

            itemCode = clsDataAccess.GetCode(prodid);
            mycode = groupCode + "." + itemCode;
            return mycode;
        }

      

      
    }
}