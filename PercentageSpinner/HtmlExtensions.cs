using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PercentageSpinner
{
	public static class HtmlExtensions
	{
		public static IHtmlContent CirclePercentage(this IHtmlHelper htmlHelper, int percentage)
		{
			var color = GetColorGradient(percentage);

			var htmlString = $@"
	            <div class='col-12'>
	                <svg viewBox='0 0 36 36' class='circular-chart'>
						<path class='circle-bg'
							d='M18 2.0845 a 15.9155 15.9155 0 0 1 0 31.831 a 15.9155 15.9155 0 0 1 0 -31.831'
						/>
						<path class='circle'
							d='M18 2.0845 a 15.9155 15.9155 0 0 1 0 31.831 a 15.9155 15.9155 0 0 1 0 -31.831'
							stroke-dasharray='{percentage}, 100'
							style='stroke: {color};'
						/>
						<circle cx='18' cy='18' r='14' fill='white' />
						<text x='18' y='20.35' class='percentage'>{percentage}%</text>
					</svg>
				</div>
			";

			return new HtmlString(htmlString);
		}

		private static string GetColorGradient(int percentage)
		{
			int r, g, b;
			if (percentage < 50)
			{
				// Gradient from red to yellow
				r = 255;
				g = (int)(255 * (percentage / 50.0));
				b = 0;
			}
			else
			{
				// Gradient from yellow to green
				r = (int)(255 * ((100 - percentage) / 50.0));
				g = 255;
				b = 0;
			}
			return $"rgba({r},{g},{b},{0.7})"; ;
		}
	}
}
