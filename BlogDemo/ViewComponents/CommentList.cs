using BlogDemo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BlogDemo.ViewComponents
{
	public class CommentList: ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			var commentvalues = new List<UserComment>
			{
				new UserComment
				{
					ID = 1,
					UserName = "Özgür"
				},
				new UserComment
				{
					ID=2,
					UserName = "Çağatay"
				},
				new UserComment
				{
					ID=3,
					UserName = "Ahmet"
				}
			};
			return View(commentvalues);
		}

	}
}
