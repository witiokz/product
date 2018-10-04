using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Web.API;

namespace Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly Client productApiClient;
        private const string BaseUrl = "http://localhost:44958/";


        public ProductController()
        {
            productApiClient = new Client(BaseUrl);
        }

        // GET: Product
        public async Task<IActionResult> Index()
        {
            return View(await productApiClient.ApiProductGetAsync());
        }

        // GET: Product/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await productApiClient.ApiProductByIdGetAsync(id.Value);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Product/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Code,Name,Photo,Price,LastUpdated")] ProductDto product)
        {
            if (ModelState.IsValid)
            {
                await productApiClient.ApiProductPostAsync(product);
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Product/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productDto = await productApiClient.ApiProductByIdGetAsync(id.Value);

            if (productDto == null)
            {
                return NotFound();
            }
            return View(productDto);
        }

        // POST: Product/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("Id,Code,Name,Photo,Price,LastUpdated")] ProductDto product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await productApiClient.ApiProductByIdPutAsync(id.Value, product);

                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Product/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productDto = await productApiClient.ApiProductByIdGetAsync(id.Value);

            if (productDto == null)
            {
                return NotFound();
            }

            return View(productDto);
        }

        // POST: ProductDtoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            await productApiClient.ApiProductByIdDeleteAsync(id.Value);

            return RedirectToAction(nameof(Index));
        }
    }
}
