using RetailCore.BusinessObjects.BusinessObjects;
using RetailCore.Interfaces.DataAccess;
using RetailCore.ServiceContracts;

namespace RetailCore.WindowsApp
{
	public partial class AddRoleLevelForm : Form
	{
		private readonly IRoleLevelService _roleLevelService;
		private readonly IUserService _userService;

		public AddRoleLevelForm(IUnitOfWork unitOfWork, IRoleLevelService roleLevelService, IUserService userService)
		{
			InitializeComponent();

			this._roleLevelService = roleLevelService;
			this._userService = userService;
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			var adminUser = _userService.GetAdminUser();

			var addedRoleLevel = this._roleLevelService.AddRoleLevel(new RoleLevel
			{
				RoleLevelId = Guid.Parse(this.tbxRoleLevelID.Text),
				RoleLevelName = this.textBoxRoleLevelName.Text,
				RoleLevelDisplayName = this.tbxRoleLevelDName.Text,
				CreatedBy = adminUser.UserId,
				CreatedOn = DateTime.Now,
			});

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
		}
	}
}
