using RetailCore.BusinessObjects.BusinessObjects;
using RetailCore.Interfaces.DataAccess;
using RetailCore.ServiceContracts;

namespace RetailCore.WindowsApp
{
    public partial class AddRoleLevelForm : Form
    {
        private readonly IRoleLevelService _roleLevelService;
        private readonly ICurrentUserService _userService;
        private readonly IPermissionTypeService _permissionTypeService;

        private BusinessObjects.BusinessObjects.RoleLevel existingRoleLevel = null;


        public AddRoleLevelForm(IUnitOfWork unitOfWork, IRoleLevelService roleLevelService, ICurrentUserService userService, IPermissionTypeService permissionTypeService)
        {
            InitializeComponent();

            this._roleLevelService = roleLevelService;
            this._userService = userService;
            this._permissionTypeService = permissionTypeService;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            BusinessObjects.BusinessObjects.RoleLevel addedRoleLevel = null;

            if (existingRoleLevel == null)
            {
                addedRoleLevel = this._roleLevelService.AddRoleLevel(new RoleLevel
                {
                    RoleLevelId = Guid.Parse(this.tbxRoleLevelID.Text),
                    RoleLevelName = this.textBoxRoleLevelName.Text,
                    RoleLevelDisplayName = this.tbxRoleLevelDName.Text,
                    RoleLevel1 = int.Parse(textBoxRoleLevel.Text),
                    CreatedBy = _userService.UserId,
                    CreatedDate = DateTime.Now,
                });

                this._roleLevelService.AddRoleLevelPermissionTypes(addedRoleLevel.RoleLevelId, checkedListBoxPermissionTypes.CheckedItems.Cast<PermissionType>().ToList());
            }
            else
            {
                addedRoleLevel = this._roleLevelService.UpdateRoleLevel(new RoleLevel
                {
                    RoleLevelId = existingRoleLevel.RoleLevelId,
                    RoleLevelName = this.textBoxRoleLevelName.Text,
                    RoleLevelDisplayName = this.tbxRoleLevelDName.Text,
                    RoleLevel1 = int.Parse(textBoxRoleLevel.Text),
                    ModifiedBy = _userService.UserId,
                    ModifiedDate = DateTime.Now,
                });

                this._roleLevelService.UpdateRoleLevelPermissionTypes(addedRoleLevel.RoleLevelId, checkedListBoxPermissionTypes.CheckedItems.Cast<PermissionType>().ToList());
            }

            if (addedRoleLevel.RoleLevelId != default(Guid))
            {
                string message = existingRoleLevel == null ? "Role Level Added Successfully" : "Role Level Updated Successfully";
                MessageBox.Show(message, "Administrator", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            this.Close();
        }

        private void AddRoleForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.existingRoleLevel = null;
        }

        private void AddRoleForm_Load(object sender, EventArgs e)
        {
            this.tbxRoleLevelID.Text = Guid.NewGuid().ToString();
            this.textBoxRoleLevelName.Text = string.Empty;
            this.tbxRoleLevelDName.Text = string.Empty;
            this.textBoxRoleLevel.Text = "1";//Default role level is User i.e., 1
            checkedListBoxPermissionTypes.DataSource = null;

            var permissionTypes = this._permissionTypeService.GetPermissionTypes();

            checkedListBoxPermissionTypes.DataSource = permissionTypes;
            checkedListBoxPermissionTypes.DisplayMember = "TypeName";
            checkedListBoxPermissionTypes.ValueMember = "PermissionTypeId";

            //Set UI for existing role level if available
            if (existingRoleLevel != null)
            {
                this.tbxRoleLevelID.Text = existingRoleLevel.RoleLevelId.ToString();
                this.textBoxRoleLevelName.Text = existingRoleLevel.RoleLevelName;
                this.tbxRoleLevelDName.Text = existingRoleLevel.RoleLevelDisplayName;
                this.textBoxRoleLevel.Text = existingRoleLevel.RoleLevel1.ToString();
                // Check the permission types that are already assigned to the role level
                var assignedPermissionTypes = _roleLevelService.GetRoleLevelPermissionTypes(existingRoleLevel.RoleLevelId);
                foreach (var permissionType in assignedPermissionTypes)
                {
                    var index = checkedListBoxPermissionTypes.FindString(permissionType.TypeName);
                    if (index >= 0)
                    {
                        checkedListBoxPermissionTypes.SetItemChecked(index, true);
                    }
                }
                // Set the button text to "Update" for existing role level
                this.btnSave.Text = "Update";
            }
            else
            {
                this.btnSave.Text = "Save";
            }
        }

        internal void SetUIForExistingRoleLevel(RoleLevel currentRow)
        {
            existingRoleLevel = currentRow;
        }

        private void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            // Check or uncheck all items in the checked list box based on the checkbox state
            if (checkedListBoxPermissionTypes.Items.Count > 0)
            {
                for (int i = 0; i < checkedListBoxPermissionTypes.Items.Count; i++)
                {
                    checkedListBoxPermissionTypes.SetItemChecked(i, chkSelectAll.Checked);
                }
            }
        }
    }
}
