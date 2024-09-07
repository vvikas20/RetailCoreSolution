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

        public AddRoleLevelForm(IUnitOfWork unitOfWork, IRoleLevelService roleLevelService, ICurrentUserService userService, IPermissionTypeService permissionTypeService)
		{
			InitializeComponent();

			this._roleLevelService = roleLevelService;
			this._userService = userService;
            this._permissionTypeService = permissionTypeService;
        }

		private void btnSave_Click(object sender, EventArgs e)
		{
			var addedRoleLevel = this._roleLevelService.AddRoleLevel(new RoleLevel
			{
				RoleLevelId = Guid.Parse(this.tbxRoleLevelID.Text),
				RoleLevelName = this.textBoxRoleLevelName.Text,
                RoleLevelDisplayName = this.tbxRoleLevelDName.Text,
                RoleLevel1 = int.Parse( textBoxRoleLevel.Text),
                CreatedBy = _userService.UserId,
				CreatedDate = DateTime.Now,
			});

            this._roleLevelService.AddRoleLevelPermissionTypes(addedRoleLevel.RoleLevelId, checkedListBoxPermissionTypes.CheckedItems.Cast<PermissionType>().ToList());	

            if (addedRoleLevel.RoleLevelId != default(Guid))
			{
				MessageBox.Show("Role Level Added Successfully", "Administrator", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}

			this.Close();
		}

		private void AddRoleForm_FormClosing(object sender, FormClosingEventArgs e)
		{

		}

		private void AddRoleForm_Load(object sender, EventArgs e)
		{
			this.tbxRoleLevelID.Text = Guid.NewGuid().ToString();
			this.textBoxRoleLevelName.Text = string.Empty;
			this.tbxRoleLevelDName.Text = string.Empty;

			var permissionTypes = this._permissionTypeService.GetPermissionTypes();

			checkedListBoxPermissionTypes.DataSource = permissionTypes;
            checkedListBoxPermissionTypes.DisplayMember = "TypeName";
            checkedListBoxPermissionTypes.ValueMember = "PermissionTypeId";
        }
	}
}
