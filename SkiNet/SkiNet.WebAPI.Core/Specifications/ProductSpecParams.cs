namespace SkiNet.WebAPI.Core.Specifications
{
    public class ProductSpecParams
    {
        /// <summary>
        /// The maximum page size
        /// </summary>
        private const int MaxPageSize = 50;

        /// <summary>
        /// Gets or sets the index of the page.
        /// </summary>
        /// <value>
        /// The index of the page.
        /// </value>
        public int PageIndex { get; set; } = 1;

        /// <summary>
        /// The pagesize
        /// </summary>
        private int pagesize = 6;

        /// <summary>
        /// Gets or sets the size of the page.
        /// </summary>
        /// <value>
        /// The size of the page.
        /// </value>
        public int PageSize
        {
            get => this.pagesize;
            set => this.pagesize = (value > MaxPageSize) ? MaxPageSize : value;
        }

        /// <summary>
        /// Gets or sets the brand identifier.
        /// </summary>
        /// <value>
        /// The brand identifier.
        /// </value>
        public int? BrandId { get; set; }

        /// <summary>
        /// Gets or sets the type identifier.
        /// </summary>
        /// <value>
        /// The type identifier.
        /// </value>
        public int? TypeId { get; set; }

        /// <summary>
        /// Gets or sets the sort.
        /// </summary>
        /// <value>
        /// The sort.
        /// </value>
        public string Sort { get; set; }

        private string search;

        public string Search
        {
            get => this.search;
            set => this.search = value.ToLower();
        }
    }
}
