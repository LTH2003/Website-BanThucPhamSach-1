using Website_Ban_Thuc_Pham.Models;
using Microsoft.AspNetCore.Mvc;

namespace Website_Ban_Thuc_Pham.Components
{
	[ViewComponent(Name = "MenuView")]
	public class MenuViewComponent : ViewComponent
	{
		private Bantraicayraucu1Context _context;

		public MenuViewComponent(Bantraicayraucu1Context context)
		{
			_context = context;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var listofMenu = (from m in _context.Menus
							  where (m.IsActive == true) && (m.Position == 1)
							  select m).ToList();
			return await Task.FromResult((IViewComponentResult)View("Default", listofMenu));

		}
	}
}
