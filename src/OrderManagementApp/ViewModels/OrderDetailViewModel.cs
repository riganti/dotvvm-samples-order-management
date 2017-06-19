using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotVVM.Framework.ViewModel;
using OrderManagementApp.Model;
using OrderManagementApp.Services;

namespace OrderManagementApp.ViewModels
{
	public class OrderDetailViewModel : SiteViewModel
	{
	    private readonly OrderService orderService;
	    private readonly ProductService productService;

	    public OrderDetailViewModel(OrderService orderService, ProductService productService)
	    {
	        this.orderService = orderService;
	        this.productService = productService;
	    }


	    public int EditedOrderId => Convert.ToInt32(Context.Parameters["id"]);

	    public OrderDetailDTO EditedOrder { get; set; }

        [Bind(Direction.ServerToClientFirstRequest)]
	    public List<ProductListDTO> Products => productService.GetProducts();


	    public override Task PreRender()
	    {
	        if (!Context.IsPostBack)
	        {
	            EditedOrder = orderService.GetOrderDetail(EditedOrderId);
	        }

	        return base.PreRender();
	    }


	    public void AddOrderItem()
	    {
	        EditedOrder.OrderItems.Add(new OrderItemDetailDTO()
	        {
	            Quantity = 1,
                ProductId = Products.First().Id
	        });
            orderService.RecalculateOrderTotalPrice(EditedOrder);
	        RecalculatePrice();
	    }

        public void RemoveOrderItem(OrderItemDetailDTO item)
        {
	        EditedOrder.OrderItems.Remove(item);
	        RecalculatePrice();
        }

	    public void RecalculatePrice()
	    {
	        orderService.RecalculateOrderTotalPrice(EditedOrder);
        }


        public void SaveChanges()
	    {
	        orderService.SaveOrderDetail(EditedOrder);
            Context.RedirectToRoute("Default");
	    }
	}
}

