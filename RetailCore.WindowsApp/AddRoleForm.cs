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
		private readonly IUserService _userService;



		public AddRoleForm(IUnitOfWork unitOfWork, IRoleLevelService roleLevelService, IRoleService roleService, IUserService userService)
		{
			InitializeComponent();

			this._roleLevelService = roleLevelService;
			this._roleService = roleService;
			this._userService = userService;
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			var adminUser = _userService.GetAdminUser();

			var addedRole = this._roleService.AddRole(new Role
			{
				RoleId = Guid.Parse(this.tbxRoleID.Text),
				RoleName = this.textBox1.Text,
				RoleDisplayName = this.textBox2.Text,
				RoleLevelId = Guid.Parse(Convert.ToString(this.cbxRoleLevel.SelectedValue)),
				CreatedBy = adminUser.UserId,
				CreatedDate = DateTime.Now,
			});

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
			this.cbxRoleLevel.DisplayMember = "RoleLevelDisplayName";
			this.cbxRoleLevel.ValueMember = "RoleLevelId";
		}
	}
}
