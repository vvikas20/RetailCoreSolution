using RetailCore.BusinessObjects.BusinessObjects;
using RetailCore.Interfaces.DataAccess;
using RetailCore.ServiceContracts;

namespace RetailCore.WindowsApp
{
    public partial class AddProductForm : Form
    {
        private readonly IRoleService _roleService;
        private readonly ICurrentUserService _currentUserService;
        private readonly IProductService _productService;
        private readonly IProductCategoryService _productCategoryService;

        public AddProductForm(IRoleService roleService, ICurrentUserService userService, IProductService productService, IProductCategoryService productCategoryService)
        {
            InitializeComponent();

            _roleService = roleService;
            _currentUserService = userService;
            _productService = productService;
            _productCategoryService = productCategoryService;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var product = new Product
            {
                ProductId = Guid.NewGuid(),
                ProductName = tbxProductName.Text,
                Description=textBoxDescription.Text,
                Price = Convert.ToDecimal(tbxPrice.Text),
                Stock = Convert.ToInt32(tbxStock.Text),
                CategoryId = ((ProductCategory)cbxProductCategory.SelectedItem).ProductCategoryId,
                IsDeleted = false,
                CreatedBy = _currentUserService.UserId,
                CreatedDate = DateTime.Now
            };

            _productService.AddProduct(product);

            this.Close();
        }

        private void AddRoleForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void AddProductForm_Load(object sender, EventArgs e)
        {
            this.textBoxProductId.Text = Guid.NewGuid().ToString();

            this.tbxProductName.Text = tbxPrice.Text = tbxStock.Text = string.Empty;

            this.cbxProductCategory.DataSource = this._productCategoryService.GetProductCategories();
            this.cbxProductCategory.DisplayMember = "CategoryName";
            this.cbxProductCategory.ValueMember = "ProductCategoryId";
        }
    }
}
