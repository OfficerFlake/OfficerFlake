using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Com.OfficerFlake.Libraries.Color;
using Com.OfficerFlake.Libraries.Interfaces;
using Com.OfficerFlake.Libraries.Logger;

namespace Com.OfficerFlake.Libraries
{
	public static class MasterObjectFactory
	{
		private class _MasterObjectFactory : IObjectFactory
		{
			public object Create(Type _interfaceType)
			{
				Type test = typeof(I24BitColor);

				if (_interfaceType == typeof(IRichTextElement))
				{
					Debug.AddSummaryMessage("Got Rich Text Message!");
					return new RichText.RichTextString.MessageElement("ThisWorks", SimpleColors.White, true, false, false, false, false);
				}
				return null;
			}
		}

		public static void LinkMasterFactory()
		{
			ObjectFactory.LinkSlaveFactory(new _MasterObjectFactory());
		}
	}
}