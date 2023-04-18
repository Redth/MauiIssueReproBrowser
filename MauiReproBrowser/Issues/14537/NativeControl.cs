using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiReproBrowser.Issues._14537
{
	public interface INativeControl : IView
	{
	}

	public class NativeControl : View, INativeControl
	{
	}
}
