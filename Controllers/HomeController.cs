using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
    private readonly ProductRepository _productRepository;

    public HomeController(ProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public IActionResult Index()
    {
        var products = _productRepository.GetAll();
        return View(products);
    }

    [HttpGet]
    public IActionResult AddProduct()
    {
        return View();
    }

    [HttpPost]
    public IActionResult AddProduct(Product product)
    {
        _productRepository.Add(product);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult EditProduct(int id)
    {
        var product = _productRepository.GetById(id);

        if (product == null)
        {
            return NotFound();
        }

        return View(product);
    }

    [HttpPost]
    public IActionResult EditProduct(Product product)
    {
        _productRepository.Update(product);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        var product = _productRepository.GetById(id);

        if (product == null)
        {
            return NotFound();
        }

        return View(product);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        _productRepository.Delete(id);
        return RedirectToAction("Index");
    }
}
