using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Friuts;
using Bsoft.Common.Language;
using Bsoft.Common;
namespace UEMS
{
    [System.ComponentModel.DesignerCategory("form")]
    public partial class MainFromtemp : Friuts.EntryFormBase
    {
         

      

      


        private void mnuCourseDesign_Click(object sender, EventArgs e)
        {
          
        }

        private void examDesignToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        UEMS.Master_Lst frmSex;
        private void mnuAanotanodjno_Click(object sender, EventArgs e)
        {
            getForm(ref frmSex);
            frmSex.TableName = "Master_Gender";
            frmSex.Show();
            frmSex.Activate();
        }

        //Keep in main form

        UEMS.Master_Lst frmObjective;
        private void mnuObjective_Click(object sender, EventArgs e)
        {
            getForm(ref frmObjective);
            frmObjective.TableName = "Objective";
            frmObjective.Show();
            frmObjective.Activate();
        }


        UEMS.Master_Lst frmDocument;
        private void mnuDocument_Click(object sender, EventArgs e)
        {
            getForm(ref frmDocument);
            frmDocument.TableName = "Document";
            frmDocument.Show();
            frmDocument.Activate();
        }


        UEMS.Master_Lst frmAffiliationOrganization;
        private void mnuAffiliationOrganization_Click(object sender, EventArgs e)
        {
            getForm(ref frmAffiliationOrganization);
            frmAffiliationOrganization.TableName = "AffiliationOrganization";
            frmAffiliationOrganization.Show();
            frmAffiliationOrganization.Activate();
        }


        UEMS.Master_Lst frmSubjectiveWrk;
        private void mnuSubjectiveWrk_Click(object sender, EventArgs e)
        {
            getForm(ref frmSubjectiveWrk);
            frmSubjectiveWrk.TableName = "SubjectiveWrk";
            frmSubjectiveWrk.Show();
            frmSubjectiveWrk.Activate();
        }


        UEMS.Master_Lst frmTargetAudience;
        private void mnuTargetAudience_Click(object sender, EventArgs e)
        {
            getForm(ref frmTargetAudience);
            frmTargetAudience.TableName = "TargetAudience";
            frmTargetAudience.Show();
            frmTargetAudience.Activate();
        }


        UEMS.Master_Lst frmMajorTaskAchieved;
        private void mnuMajorTaskAchieved_Click(object sender, EventArgs e)
        {
            getForm(ref frmMajorTaskAchieved);
            frmMajorTaskAchieved.TableName = "MajorTaskAchieved";
            frmMajorTaskAchieved.Show();
            frmMajorTaskAchieved.Activate();
        }


        UEMS.Master_Lst frmMaster_Specialization;
        private void mnuMaster_Specialization_Click(object sender, EventArgs e)
        {
            getForm(ref frmMaster_Specialization);
            frmMaster_Specialization.TableName = "Master_Specialization";
            frmMaster_Specialization.Show();
            frmMaster_Specialization.Activate();
        }


        UEMS.Master_Lst frmMaster_Position;
        private void mnuMaster_Position_Click(object sender, EventArgs e)
        {
            getForm(ref frmMaster_Position);
            frmMaster_Position.TableName = "Master_Position";
            frmMaster_Position.Show();
            frmMaster_Position.Activate();
        }


        UEMS.Master_Lst frmMaster_Sex;
        private void mnuMaster_Sex_Click(object sender, EventArgs e)
        {
            getForm(ref frmMaster_Sex);
            frmMaster_Sex.TableName = "Master_Sex";
            frmMaster_Sex.Show();
            frmMaster_Sex.Activate();
        }


        UEMS.Master_Lst frmMaster_Education;
        private void mnuMaster_Education_Click(object sender, EventArgs e)
        {
            getForm(ref frmMaster_Education);
            frmMaster_Education.TableName = "Master_Education";
            frmMaster_Education.Show();
            frmMaster_Education.Activate();
        }


        UEMS.Master_Lst frmMaster_MaritalStatus;
        private void mnuMaster_MaritalStatus_Click(object sender, EventArgs e)
        {
            getForm(ref frmMaster_MaritalStatus);
            frmMaster_MaritalStatus.TableName = "Master_MaritalStatus";
            frmMaster_MaritalStatus.Show();
            frmMaster_MaritalStatus.Activate();
        }


        UEMS.Master_Lst frmMaster_Ethnicity;
        private void mnuMaster_Ethnicity_Click(object sender, EventArgs e)
        {
            getForm(ref frmMaster_Ethnicity);
            frmMaster_Ethnicity.TableName = "Master_Ethnicity";
            frmMaster_Ethnicity.Show();
            frmMaster_Ethnicity.Activate();
        }


        UEMS.Master_Lst frmMaster_Profession;
        private void mnuMaster_Profession_Click(object sender, EventArgs e)
        {
            getForm(ref frmMaster_Profession);
            frmMaster_Profession.TableName = "Master_Profession";
            frmMaster_Profession.Show();
            frmMaster_Profession.Activate();
        }


        UEMS.Master_Lst frmPerson_Role;
        private void mnuPerson_Role_Click(object sender, EventArgs e)
        {
            getForm(ref frmPerson_Role);
            frmPerson_Role.TableName = "Person_Role";
            frmPerson_Role.Show();
            frmPerson_Role.Activate();
        }

        UEMS.HelpingOrganization_Lst  frmHelpingOrg;
        private void mnuHelpingOrg_Click(object sender, EventArgs e)
        {
            getForm(ref frmHelpingOrg);
  
            frmHelpingOrg.Show();
            frmHelpingOrg.Activate();
        }
        UEMS.FinancialSource_Lst  frmFinancialSource;
        private void mnuFinancialSource_Click(object sender, EventArgs e)
        {
            getForm(ref frmFinancialSource);
     
            frmFinancialSource.Show();
            frmFinancialSource.Activate();
        }
        UEMS.NGO_Lst  frmNgo;
        private void दरतToolStripMenuItem_Click(object sender, EventArgs e)
        {
            getForm(ref frmNgo);
            frmNgo.Show();
            frmNgo.Activate();
        }
        UEMS.Address_Lst  frmAddress;
        private void addressToolStripMenuItem_Click(object sender, EventArgs e)
        {
            getForm(ref frmAddress);
            frmAddress.Show();
            frmAddress.Activate();
        }

        UEMS.IndividualPerson_Lst frmPerson;
        private void personToolStripMenuItem_Click(object sender, EventArgs e)
        {
            getForm(ref frmPerson);
            frmPerson.Show();
            frmPerson.Activate();
        }


        


       
    }
}
