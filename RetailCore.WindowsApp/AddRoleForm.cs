using RetailCore.BusinessObjects.BusinessObjects;
using RetailCore.Interfaces.DataAccess;
using RetailCore.ServiceContracts;
using RetailCore.Services;

namespace RetailCore.WindowsApp
{
    public partial class AddRoleForm : Form
    {
        private readonly IRoleLevelService _roleLevelService;
        private readonly IRoleService _roleService;
        private readonly ICurrentUserService _currentUserService;



        public AddRoleForm(IUnitOfWork unitOfWork, IRoleLevelService roleLevelService, IRoleService roleService, ICurrentUserService currentUserService)
        {
            InitializeComponent();

            this._roleLevelService = roleLevelService;
            this._roleService = roleService;
            this._currentUserService = currentUserService;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var addedRole = this._roleService.AddRole(new Role
            {
                RoleId = Guid.Parse(this.tbxRoleID.Text),
                RoleName = this.textBox1.Text,
                RoleLevelId = Guid.Parse(Convert.ToString(this.cbxRoleLevel.SelectedValue)),
                CreatedBy = _currentUserService.UserId,
                CreatedDate = DateTime.Now,
            });


            //get all checked permissions
            var checkedPermissions = checkedListBoxPermission.CheckedItems.Cast<Permission>().ToList();
            _roleService.AssignPermissionsToRole(addedRole.RoleId, checkedPermissions);

            if (addedRole.RoleId != default(Guid))
            {
                MessageBox.Show("Role Added Successfully", "Administrator", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            this.Close();
        }

        private void AddRoleForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void AddRoleForm_Load(object sender, EventArgs e)
        {
            this.tbxRoleID.Text = Guid.NewGuid().ToString();
            this.textBox1.Text = string.Empty;
            this.textBox2.Text = string.Empty;
            this.cbxRoleLevel.DataSource = this._roleLevelService.GetRoleLevels();
            this.cbxRoleLevel.DisplayMember = "RoleLevelName";
            this.cbxRoleLevel.ValueMember = "RoleLevelId";
        }

        private void cbxRoleLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedRoleLevelId = ((RoleLevel)cbxRoleLevel.SelectedItem).RoleLevelId;
            checkedListBoxPermission.DataSource = this._roleLevelService.GetRoleLevelPermissions(selectedRoleLevelId);
            checkedListBoxPermission.DisplayMember = "PermissionDisplayName";
            checkedListBoxPermission.ValueMember = "PermissionId";

            for (int i = 0; i < checkedListBoxPermission.Items.Count; i++)
            {
                checkedListBoxPermission.SetItemChecked(i, true);
            }
        }
    }
}
