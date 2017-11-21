using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Com.OfficerFlake.Libraries.RichText;

namespace Com.OfficerFlake.Libraries.Permissions
{
	public interface IHasPermissions
	{
		//generic plug to accept any object that has permissions.

		bool Can();
		bool Cannot();
	}
}
