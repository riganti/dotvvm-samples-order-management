using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotVVM.Framework.Controls;
using DotVVM.Framework.ViewModel;
using OrderManagementApp.DTO;
using OrderManagementApp.Services;

namespace OrderManagementApp.ViewModels
{
	public class DefaultViewModel : SiteViewModel
	{
	    private readonly OrderService orderService;

	    public DefaultViewModel(OrderService orderService)
	    {
	        this.orderService = orderService;
	    }


        public GridViewDataSet<OrderListDTO> Orders { get; set; } = new GridViewDataSet<OrderListDTO>()
            {
	            PagingOptions =
	            {
	                PageSize = 20
	            },
	            SortingOptions =
	            {
	                SortExpression = "CreatedDate",
	                SortDescending = true
	            }
            };



	    public override Task PreRender()
	    {
IQueryable<OrderListDTO> orderListDtos = orderService.GetOrdersQuery();
this.Orders.LoadFromQueryable(orderListDtos);

	        return base.PreRender();
	    }
	}
}

