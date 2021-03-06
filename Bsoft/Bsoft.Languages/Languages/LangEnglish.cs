using System;

namespace Bsoft.Languages
{
    public class LangEnglish : LangInterface
    {
        #region LangInterface Members

        public string ok
        {
            get { return "ok"; }
        }

        #endregion LangInterface Members

        #region LangInterface Members

        public string close
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        #endregion LangInterface Members

        #region LangInterface Members

        public string ShouldNotBeEmpty
        {
            get { return "{0} field can't be left blank."; }
        }

        public string CorrectNumber
        {
            get { return "Enter a valid number in {0}."; }
        }

        public string CorrectDate
        {
            get { return "Enter a valid Date in {0}."; }
        }

        public string DoYouWantToLogOff
        {
            get { return "Do you want to log off ."; }
        }

        public string DoYouWantToSave
        {
            get { return "Do you want to Save Data"; }
        }

        public string DoYouWantToUpdate
        {
            get { return "Do you want to update Data"; }
        }

        public string DoYouWantToDelete
        {
            get { return "Do you want to Delete Data?"; }
        }

        public string DoYouWantToAddMoreRecords
        {
            get { return "Do you want to add more records ?"; }
        }

        public string NewAdd { get { return "New"; } }

        public string Edit { get { return "Edit"; } }

        public string Delete { get { return "Delete"; } }

        public string Save { get { return "Save"; } }

        public string Search { get { return "Search"; } }

        public string ExporttoExcel { get { return "Export"; } }

        public string ExporttoExcelSuccessFull { get { return "Data is Exported to Excel Successfully "; } }

        public string Ok { get { return "Ok"; } }

        public string Yes { get { return "Yes"; } }

        public string No { get { return "No"; } }

        public string Close { get { return "Close"; } }

        public string Cancel { get { return "Cancel"; } }

        public string CancelGoBack { get { return "Cancel"; } }

        public string Date { get { return "Date"; } }

        public string AttentionPlease { get { return "Attention Please"; } }

        public string DoYouWantToClose { get { return "Do you want to close ?"; } }

        public string LogOff { get { return "LogOff"; } }

        public string Login { get { return "Log in"; } }

        public string OrganizationDetails { get { return "Organization Details"; } }

        public string changePassword { get { return "Change Password"; } }

        public string UserName { get { return "User"; } }

        public string UserId { get { return "User Name"; } }

        public string OldPassWord { get { return "Old Password"; } }

        public string PassWord { get { return "Password"; } }

        public string Active { get { return "Active"; } }

        public string LastLoginDate { get { return "Last Log in Date"; } }

        public string LastLogoffDate { get { return "Last Log off Date "; } }

        public string UserRoles { get { return "User Rights and Roles "; } }

        public string FiscalYear { get { return "Fiscal Year"; } }

        public string Restore { get { return "Restore"; } }

        public string Backup { get { return "Backup"; } }

        public string MasterEntry { get { return "MasterEntry"; } }

        public string Report { get { return "Report"; } }

        public string Management { get { return "Management"; } }

        public string System { get { return "System"; } }

        public string Remarks { get { return "Remarks"; } }

        public string District { get { return "District"; } }

        public string Zone { get { return "Zone"; } }

        public string LocalBody { get { return "Local Body"; } }

        public string Address { get { return "Address"; } }

        public string Phone { get { return "Phone"; } }

        public string Fax { get { return "Fax"; } }

        public string Email { get { return "Email"; } }

        public string WebSite { get { return "URL"; } }

        public string Register { get { return "Register"; } }

        public string OrganizationName { get { return "Organization Name"; } }

        public string Start { get { return "Start"; } }

        public string End { get { return "End"; } }

        public string Clear { get { return "Clear"; } }

        public string InvalidUserName { get { return "Invalid UserName"; } }

        public string InvalidPassword { get { return "Invalid Password"; } }

        public string PasswordCannotbeEmpty { get { return "Password Cannot be Empty"; } }

        public string UserNameCannotbeEmpty { get { return "User Name Cannot be Empty"; } }

        public string Name { get { return "Name"; } }

        public string Details
        {
            get { return "Details"; }
        }

        #endregion LangInterface Members
    }
}