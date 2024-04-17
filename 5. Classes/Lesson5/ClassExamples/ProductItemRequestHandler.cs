namespace ClassExamples
{
    /* Классы не обязаны отражать сущности реального мира. Они могут играть роль общих и частных абстракций -
    "evaluator", "service", "parser", "helper", "set", "adapter", "handler" и мн. др. Главное правило при проектировании классов -
    придерживаться SOLID-принципов и применять паттерны проектирования там, где это уместно.
    */
    internal class ProductItemRequestHandler
    {
        private readonly ProductService _productService;

        public ProductItemRequestHandler(ProductService productService)
        {
            _productService = productService;
        }

        public CreateProductItemResponse CreateProduct(CreateProductItemRequest request)
        {
            var product = _productService.Create(request.Name, request.Description);
            return new CreateProductItemResponse { ProductItem = product };
        }
    }

    internal class ProductService
    {
        public ProductItem Create(string name, string? description)
        {
            return new ProductItem(name, description);
        }
    }

    internal class CreateProductItemRequest
    {
        public required string Name { get; set; }
        public string Description { get; set; } = string.Empty;
    }

    internal class CreateProductItemResponse
    {
        public ProductItem? ProductItem { get; init; }
    }
}
