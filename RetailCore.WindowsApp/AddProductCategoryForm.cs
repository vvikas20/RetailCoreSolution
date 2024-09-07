using RetailCore.BusinessObjects.BusinessObjects;
using RetailCore.Interfaces.DataAccess;
using RetailCore.ServiceContracts;
using RetailCore.Services;

namespace RetailCore.WindowsApp
{
    public partial class AddProductCategoryForm : Form
    {
        private readonly IRoleService _roleService;
        private readonly IProductCategoryService _productCategoryService;
        private readonly ICurrentUserService _currentUserService;


        public AddProductCategoryForm(IUnitOfWork unitOfWork, IRoleService roleService, IProductCategoryService productCategoryService, ICurrentUserService currentUserService)
        {
            InitializeComponent();

            this._roleService = roleService;
            this._productCategoryService = productCategoryService;
            this._currentUserService = currentUserService;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var addedProductCategory = new ProductCategory
            {
                ProductCategoryId = Guid.NewGuid(),
                CategoryName = this.textBoxCategoryName.Text,
                IsDeleted = false,
                CreatedBy = this._currentUserService.UserId,
                CreatedDate = DateTime.Now
            };

            this._productCategoryService.AddProductCategory(addedProductCategory);

            if (addedProductCategory.ProductCategoryId != default(Guid))
            {
                MessageBox.Show("Product Category Added Successfully", "Administrator", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            this.Close();
        }

        private void AddRoleForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void AddProductCategoryForm_Load(object sender, EventArgs e)
        {
            this.tbxRoleID.Text = Guid.NewGuid().ToString();
            this.textBoxCategoryName.Text = string.Empty;
            this.textBoxCategoryDisplay.Text = string.Empty;
        }
    }
}
