using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotVVM.Framework.Controls;
using DotVVM.Framework.ViewModel;
using OrderManagementApp.Model;
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
	                PageSize = 10
	            },
	            SortingOptions =
	            {
	                SortExpression = nameof(OrderListDTO.CreatedDate),
	                SortDescending = true
	            }
            };



	    public override Task PreRender()
	    {
            if (this.Orders.IsRefreshRequired)
            {
                IQueryable<OrderListDTO> orders = orderService.GetOrdersQuery();
                this.Orders.LoadFromQueryable(orders);
            }

            return base.PreRender();
	    }
	}
}

